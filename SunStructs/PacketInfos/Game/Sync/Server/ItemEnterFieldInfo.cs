using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class ItemEnterFieldInfo : ServerPacketInfo
    {
        public readonly uint FromMonsterKey;
        public readonly ItemRenderInfo ItemRenderInfo;

        public ItemEnterFieldInfo(uint fromMonsterKey, ItemRenderInfo itemRenderInfo)
        {
            FromMonsterKey = fromMonsterKey;
            ItemRenderInfo = itemRenderInfo;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(FromMonsterKey);
            ItemRenderInfo.GetBytes(ref buffer);
        }
    }
}
