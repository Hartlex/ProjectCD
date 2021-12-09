using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class AckConnectInfo : ServerPacketInfo
    {
        public readonly byte CanConnectFlag;

        public AckConnectInfo(PacketResultType result)
        {
            CanConnectFlag =(byte)(result);
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(CanConnectFlag);
        }
    }
}
