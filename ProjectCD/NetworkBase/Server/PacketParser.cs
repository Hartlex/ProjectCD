using System.Text;
using CD.Network.Server;
using CDShared.ByteLevel;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;
using SunStructs.Packets;

namespace ProjectCD.NetworkBase.Server
{
    internal class PacketParser<T> : Singleton<PacketParser<T>>
    {
        private readonly ActionBib _bib;

        protected PacketParser()
        {
            if (typeof(T) == typeof(GamePacketType)) _bib = new (ServerType.GAME);
            else if (typeof(T) == typeof(AuthPacketType)) _bib = new (ServerType.LOGIN);
            else if (typeof(T) == typeof(WorldPacketType)) _bib = new(ServerType.WORLD);
            else throw new ("Wrong ParserType!");
        }

        public void RegisterAction(byte type, byte subType, Action<ByteBuffer, Connection> action)
        {
            var success = _bib.Add(type, subType, action);
#if DEBUG
            if (success)
            {
                string id;
                T typ = (T)Enum.ToObject(typeof(T), (int)type);
                if (typeof(T) == typeof(GamePacketType))
                {
                    id = "GAME";
                }
                else if (typeof(T) == typeof(AuthPacketType))
                {
                    id = "AUTH";
                }
                else
                {
                    id = "WORLD";
                }
                //Logger.Instance.LogOnLine($"Action[{id}][{typ}][{action.Method.Name}] registered!");
            }
#endif
        }

        public void ParsePacket(ByteBuffer buffer, Connection connection)
        {
            var length = buffer.GetData().Length;
            while (length > 0)
            {

                var size = buffer.ReadInt16();
                length -= size + 2;
                var packetCategory = buffer.ReadByte();
                var subPacketType = buffer.ReadByte();
                //var packetBytes = buffer.ReadBlock(size - 2);
                if (_bib.TryFindAction(packetCategory, subPacketType, out var action))
                {
#if DEBUG
                    Logger.Instance.Log("GameServer: " + action.Method.Name);
#endif 

                    action(buffer, connection);
                }
                else
                {
                    var type = typeof(T) == typeof(GamePacketType) ? "GameServer" :
                        typeof(T) == typeof(WorldPacketType) ? "WorldServer" : "AuthServer";
                    Logger.Instance.Log($"[{type}] Unknown Packet:" + packetCategory + "|" + subPacketType);
                    var sb = new StringBuilder();
                    foreach (var b in buffer.ReadBlock(size - 2))
                    {
                        sb.Append(b + "|");
                    }
                    Logger.Instance.Log(sb.ToString());
                }
            }
        }
    }

    internal class ActionBib
    {
        private readonly Dictionary<byte, Dictionary<byte, Action<ByteBuffer, Connection>>> _actions;

        public ActionBib(ServerType serverType)
        {
            var types = (int[]) GetEnumValues(serverType);
            _actions = new(types.Length);
            foreach (var type in types)
            {
                _actions.Add((byte) type,new (255));
            }
        }

        private Array GetEnumValues(ServerType type)
        {
            switch (type)
            {
                case ServerType.LOGIN:
                    return Enum.GetValues(typeof(AuthPacketType));
                case ServerType.GAME:
                    return Enum.GetValues(typeof(GamePacketType));
                case ServerType.WORLD:
                    return Enum.GetValues(typeof(WorldPacketType));
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public bool Add(byte type, byte subType, Action<ByteBuffer, Connection> action)
        {
            return _actions[type].TryAdd(subType,action);
        }
        public bool TryFindAction(byte type, byte subType, out Action<ByteBuffer, Connection>? action)
        {
            action = null;
            return _actions.TryGetValue(type, out var subDictionary) && 
                   subDictionary.TryGetValue(subType, out action);
        }
    }
}
