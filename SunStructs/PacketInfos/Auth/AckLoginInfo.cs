using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AckLoginInfo :PacketInfo
    {
        public readonly byte SuccessFlag;
        public AckLoginInfo(bool success)
        {
            SuccessFlag =(success ? (byte)0 : (byte)1);
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(SuccessFlag);
            buffer.WriteBlock(new byte[73]);
        }
    }
}
