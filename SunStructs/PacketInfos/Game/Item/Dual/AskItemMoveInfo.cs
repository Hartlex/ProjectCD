using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Item.Dual
{
    public class ItemMoveInfo : DualPacketInfo
    {
        public readonly SlotContainerIndex SlotIdFrom;
        public readonly SlotContainerIndex SlotIdTo;
        public readonly int PositionFrom;
        public readonly int PositionTo;
        public readonly int AmountToMove;

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte)SlotIdFrom);
            buffer.WriteByte((byte)SlotIdTo);
            buffer.WriteByte(PositionFrom);
            buffer.WriteByte(PositionTo);
            buffer.WriteByte(AmountToMove);
        }

        public ItemMoveInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            SlotIdFrom =(SlotContainerIndex) buffer.ReadByte();
            SlotIdTo = (SlotContainerIndex) buffer.ReadByte();
            PositionFrom = buffer.ReadByte();
            PositionTo = buffer.ReadByte();
            AmountToMove = buffer.ReadByte();
        }
    }
}
