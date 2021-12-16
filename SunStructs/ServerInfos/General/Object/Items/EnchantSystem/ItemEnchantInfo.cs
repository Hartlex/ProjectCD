using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Object.Items.EnchantSystem
{
    public class ItemEnchantInfo
    {
        public readonly byte ItemType;
        public readonly byte ItemLevel;
        public readonly byte ItemEnchant;
        public readonly List<EnchantMatInfo> EnchantMatInfos=new();
        public readonly EnchantConsumeInfo EnchantConsumeInfo;

        public ItemEnchantInfo(string[] info)
        {
            StringBuffer sb = new StringBuffer(info);
            sb.Skip(2);
            ItemType = sb.ReadByte();
            ItemLevel = sb.ReadByte();
            ItemEnchant = sb.ReadByte();
            for (int i = 0; i < 5; i++)
            {
                var mat = sb.ReadUshort();
                if (mat == 0)
                {
                    sb.Skip();
                    continue;
                }
                var count = sb.ReadByte();
                EnchantMatInfos.Add(new EnchantMatInfo(mat,count));
            }

            EnchantConsumeInfo = new EnchantConsumeInfo(ref sb);
            
        }

        public List<EnchantMatInfo> GetNeededMatInfos(EnchantOption id)
        {
            var result = new List<EnchantMatInfo>();
            float ratio = 0;
            switch (id)
            {
                case EnchantOption.ENCHANT_100PER:
                    return EnchantMatInfos;
                case EnchantOption.ENCHANT_75PER:
                    ratio = EnchantConsumeInfo.MaterialCostRatio[1];
                    break;
                case EnchantOption.ENCHANT_50PER:
                    ratio = EnchantConsumeInfo.MaterialCostRatio[2];
                    break;
                case EnchantOption.ENCHANT_25PER:
                    ratio = EnchantConsumeInfo.MaterialCostRatio[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }

            foreach (var enchantMatInfo in EnchantMatInfos)
            {
                result.Add(enchantMatInfo.CalculateByRatio(ratio));
            }

            return result;
        }

        public float GetNeededMoneyRatio(EnchantOption id)
        {
            switch (id)
            {
                case EnchantOption.ENCHANT_100PER:
                    return EnchantConsumeInfo.HeimCostRatio[0];
                case EnchantOption.ENCHANT_75PER:
                    return EnchantConsumeInfo.HeimCostRatio[1];
                case EnchantOption.ENCHANT_50PER:
                    return EnchantConsumeInfo.HeimCostRatio[2];
                case EnchantOption.ENCHANT_25PER:
                    return EnchantConsumeInfo.HeimCostRatio[3];
                default:
                    throw new ArgumentOutOfRangeException(nameof(id), id, null);
            }
            
        }
    }

    public class EnchantConsumeInfo
    {
        public readonly float[] HeimCostRatio=new float[4];
        public readonly float[] MaterialCostRatio=new float[4];

        public EnchantConsumeInfo(ref StringBuffer sb)
        {
            for (int i = 0; i < 4; i++)
            {
                HeimCostRatio[i] = sb.ReadFloat();
                MaterialCostRatio[i] = sb.ReadFloat();
            }
        }
    }

    public class EnchantMatInfo
    {
        public readonly ushort MaterialCode;
        public readonly byte MaterialAmount;

        public EnchantMatInfo(ushort materialCode, byte materialAmount)
        {
            MaterialCode = materialCode;
            MaterialAmount = materialAmount;
        }

        public EnchantMatInfo CalculateByRatio(float ratio)
        {
            return new EnchantMatInfo(MaterialCode, (byte) (MaterialAmount * ratio));
        }
    }

}
