using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Server
{
    public class AckBuyItemInfo : ServerPacketInfo
    {
        public readonly ulong Money;
        public readonly ushort Count;
        public readonly ItemSlotInfo[] SlotInfos;

        public AckBuyItemInfo(ulong money, ItemSlotInfo[] slotInfos)
        {
            Money = money;
            Count = (ushort)slotInfos.Length;
            SlotInfos = slotInfos;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt64(Money);
            buffer.WriteUInt16(Count);
            foreach (var itemSlotInfo in SlotInfos)
            {
                itemSlotInfo.GetBytes(ref buffer);
            }
        }
    }
}
