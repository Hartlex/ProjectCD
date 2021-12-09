using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AckConnectInfo : PacketInfo
    {
        public readonly byte CanConnectFlag;

        public AckConnectInfo(bool canConnect)
        {
            CanConnectFlag =(byte)(canConnect ? 0 : 1);
        }

        public AckConnectInfo(ref ByteBuffer buffer)
        {
            CanConnectFlag = buffer.ReadByte();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(CanConnectFlag);
        }
    }
}
