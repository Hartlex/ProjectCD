using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Connection.Server
{
    public class NakCreateCharInfo :ServerPacketInfo
    {
        public readonly CharCreateResult Code;
        public NakCreateCharInfo(CharCreateResult code){Code =code;}
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte) Code);
        }
    }
}
