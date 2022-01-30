using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Style.Server
{
    public class ChangeStyleInfo : ServerPacketInfo
    {
        public readonly uint ObjectKey;
        public readonly ushort OldStyleCode;
        public readonly ushort NewStyleCode;

        public ChangeStyleInfo(uint objectKey, ushort oldStyleCode, ushort newStyleCode)
        {
            ObjectKey = objectKey;
            OldStyleCode = oldStyleCode;
            NewStyleCode = newStyleCode;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteUInt16(OldStyleCode);
            buffer.WriteUInt16(NewStyleCode);
        }
    }
}
