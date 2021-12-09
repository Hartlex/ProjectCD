using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class ServerInfo
    {
        private readonly string _name;
        private readonly int _serverNr;

        public ServerInfo(string name, int serverNr)
        {
            this._name = name;
            this._serverNr = serverNr;
        }

        public byte[] GetBytes()
        {
            var nameBytes = ByteUtils.ToByteArray(_name, 32);
            List<byte> packet = new List<byte>();
            packet.AddRange(nameBytes);
            packet.Add(00);
            packet.Add((byte)_serverNr);
            packet.Add(00);
            packet.Add(00);
            return packet.ToArray();
        }
    }
}