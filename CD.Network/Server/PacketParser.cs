using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.ByteLevel;
using CDShared.Generics;
using CDShared.Logging;
using NetworkCommsDotNet.Connections;
using SunStructs.Packets;

namespace CD.Network.Server
{
    public class PacketParser<T> : Singleton<PacketParser<T>>
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
                Logger.Instance.Log($"Action[{action.Method.Name}] registered!",LogType.FULL);
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
                var packetBytes = buffer.ReadBlock(size - 2);
                if (_bib.TryFindAction(packetCategory, subPacketType, out var action))
                {
                    Logger.Instance.Log("GameServer: " + action.Method.Name);
                    action(buffer, connection);
                }
                else
                {
                    Logger.Instance.Log("Unknown Game Packet:" + packetCategory + "|" + subPacketType);
                    var sb = new StringBuilder();
                    foreach (var b in packetBytes)
                    {
                        sb.Append(b + "|");
                    }
                    Logger.Instance.Log(sb.ToString());
                }
            }
        }
    }

    public class ActionBib
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
