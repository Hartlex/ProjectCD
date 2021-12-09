using CDShared.ByteLevel;
using SunStructs.Definitions;
using static SunStructs.Definitions.Const;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class AckLoginInfo :ServerPacketInfo
    {
        public readonly byte SuccessFlag;
        public readonly byte Attempts;
        public readonly string Info;
        public readonly ulong BetaKey;
        public AckLoginInfo(AuthResultType result,byte attempts,string info,ulong betaKey)
        {
            SuccessFlag =(byte) result;
            Attempts = attempts;
            Info = info;
            BetaKey =betaKey;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(SuccessFlag);
            buffer.WriteByte(Attempts);
            buffer.WriteString(Info,INFO_MAX_LENGTH);
            buffer.WriteUInt64(BetaKey);
        }
    }
}
