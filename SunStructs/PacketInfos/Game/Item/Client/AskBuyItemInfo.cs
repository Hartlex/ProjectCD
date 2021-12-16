using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Client
{
    public class AskBuyItemInfo
    {
        public readonly uint ShopId; //shop iD
        public readonly uint UnkId2; //npc id same as shop id
        public readonly byte ShopPage;
        public readonly byte ItemIndex;
        public readonly byte Count;
        public AskBuyItemInfo(ref ByteBuffer buffer)
        {
            ShopId = buffer.ReadUInt32();
            UnkId2 = buffer.ReadUInt32();
            ShopPage = buffer.ReadByte();
            ItemIndex = buffer.ReadByte();
            Count = buffer.ReadByte();
        }
    }
}
