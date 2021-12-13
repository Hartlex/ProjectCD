using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Connection.Server
{
    public class AnsDuplicateNameInfo : ServerPacketInfo
    {
        public readonly CharIdCheckResult Code;

        public AnsDuplicateNameInfo(CharIdCheckResult code)
        {
            Code = code;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte)Code);
        }
    }
}
