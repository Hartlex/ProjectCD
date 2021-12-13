using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Connection.Server
{
    public class NakDeleteCharacterInfo : ServerPacketInfo
    {
        public readonly CharDestroyResult ErrorCode;

        public NakDeleteCharacterInfo(CharDestroyResult errorCode)
        {
            ErrorCode = errorCode;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte) ErrorCode);
        }
    }
}
