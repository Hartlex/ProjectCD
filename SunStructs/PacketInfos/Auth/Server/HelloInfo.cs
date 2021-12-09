using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class HelloInfo : ServerPacketInfo
    {
        public readonly string ServerInfo;
        public readonly int Key;
        public HelloInfo(string serverInfo,int key)
        {
            ServerInfo = serverInfo;
            Key = key;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteString(ServerInfo,64);
            buffer.WriteInt32(Key);
        }
    }
}
