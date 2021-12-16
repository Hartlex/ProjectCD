using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Connection.Server
{
    public class ConnectToWorldInfo : ServerPacketInfo
    {
        public readonly string IpAddress;
        public readonly int Port;

        public ConnectToWorldInfo(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteString(IpAddress,32);
            buffer.WriteBlock(ByteUtils.ToByteArray(Port,5));
        }
    }
}
