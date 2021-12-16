using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Quest
{
    public class RewardInfo
    {
        public uint RewardCode { get; init; }
        public ulong GiveExp { get; init; }
        public ulong GiveHeim { get; init; }
        public uint GiveCoin { get; init; }
        public uint GiveChaoTime { get; init; }
        public uint FixedItemCode { get; init; }
        public uint FixedItemType { get; init; }
        public ushort Skill { get; init; }
        public byte ReferenceType { get; init; }
        public byte SelectNum { get; init; }
        public uint[] SelectItemCode { get; init; } //4
        public uint[] SelectItemType { get; init; } //4

        public RewardInfo(string[] infos)
        {
            var sb = new StringBuffer(infos);
            sb.Skip();
            RewardCode = sb.ReadUint();
            sb.Skip(2);
            GiveExp = sb.ReadUlong();
            GiveHeim = sb.ReadUlong();
            GiveCoin = sb.ReadUint();
            GiveChaoTime = sb.ReadUint();
            FixedItemCode = sb.ReadUint();
            FixedItemType = sb.ReadUint();
            Skill = sb.ReadUshort();
            ReferenceType = sb.ReadByte();
            SelectNum = sb.ReadByte();
            SelectItemCode = new uint[4];
            SelectItemType = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                SelectItemCode[i] = sb.ReadUint();
                SelectItemType[i] = sb.ReadUint();
            }
        }

        public bool HasSelectItem()
        {
            return SelectItemCode[0] != 0;
        }

        public Dictionary<uint,uint> GetItemsAndType(int index)
        {
            var result = new Dictionary<uint, uint>();
            if (FixedItemCode != 0)
            {
                result.Add(FixedItemCode,FixedItemType);
            }
            if(HasSelectItem())
            {
                for (int i = 0; i < 4; i++)
                {
                    if(SelectItemCode[i]==0) break;
                    result.Add(SelectItemCode[i],SelectItemType[i]);
                }
            }

            return result;
        }
        
    }
}
