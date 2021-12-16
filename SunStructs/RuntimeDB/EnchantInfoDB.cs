using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Object.Items.EnchantSystem;

namespace SunStructs.RuntimeDB
{
    public class EnchantInfoDB : Singleton<EnchantInfoDB>
    {
        private Dictionary<byte, Dictionary<byte, List<ItemEnchantInfo>>> _enchantInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new EnchantInfoParser();
            _enchantInfos = parser.ParseAllEnchantInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_enchantInfos[0].Count + _enchantInfos[1].Count} EnchantInfos loaded!\n", LogType.SUCCESS);
        }

        public ItemEnchantInfo GetEnchantInfo(BaseItemInfo baseInfo,EnchantGrade grade)
        {
            byte baseItemType = byte.MaxValue;
            if (baseInfo.IsArmor()) baseItemType = 1;
            if (baseInfo.IsWeapon()) baseItemType = 0;
            if (baseItemType == byte.MaxValue) return null;

            if (!_enchantInfos.TryGetValue(baseItemType, out var iLevelDict)) return null;
            if (!iLevelDict.TryGetValue((byte)baseInfo.Level, out var enchantInfos)) return null;
            return enchantInfos[(int) grade];
        }
    }
}
