using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Item.Server;

namespace SunStructs.PacketInfos.Game.Quest.Server
{
    public class HandInQuestInfo : ServerPacketInfo
    {
        public readonly ulong AddExp;
        public readonly ulong Money;
        public readonly byte[] Unk;
        public readonly InventoryAddInfo ItemAddInfo;

        public HandInQuestInfo(ulong addExp, ulong money, InventoryAddInfo itemAddInfo)
        {
            AddExp = addExp;
            Money = money;
            Unk = new byte[]{0, 0, 0, 0, 0, 0, 0};
            ItemAddInfo = itemAddInfo;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt64(AddExp);
            buffer.WriteUInt64(Money);
            buffer.WriteBlock(Unk);
            ItemAddInfo.GetBytes(ref buffer);
        }
    }
}
