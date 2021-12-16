using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Server
{
    public class InventoryAddInfo : ServerPacketInfo
    {
        public readonly ushort Count;
        public readonly ItemSlotInfo[] Infos;

        public InventoryAddInfo(ItemSlotInfo[] infos)
        {
            Count =(ushort) infos.Length;
            Infos = infos;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(Count);
            foreach (var itemSlotInfo in Infos)
            {
                itemSlotInfo.GetBytes(ref buffer);
            }
        }
    }
}
