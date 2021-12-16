using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Server
{
    public class AckItemPickupInfo : ServerPacketInfo
    {
        public readonly ushort Count;
        public readonly ItemSlotInfo[] SlotInfos;

        public AckItemPickupInfo(ItemSlotInfo[] slotInfos)
        {
            Count = (ushort)slotInfos.Length;
            SlotInfos = slotInfos;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(Count);
            foreach (var itemSlotInfo in SlotInfos)
            {
                itemSlotInfo.GetBytes(ref buffer);
            }
        }
    }
}
