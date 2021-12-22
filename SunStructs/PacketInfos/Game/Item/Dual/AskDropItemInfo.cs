using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Item.Dual
{
    public class AskDropItemInfo : DualPacketInfo
    {
        public readonly SlotContainerIndex Index;
        public readonly int Pos;

        public AskDropItemInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Index = (SlotContainerIndex) buffer.ReadByte();
            Pos = buffer.ReadByte();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte) Index);
            buffer.WriteByte(Pos);
        }
    }
}
