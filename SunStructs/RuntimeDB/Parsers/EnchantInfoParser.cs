using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items.EnchantSystem;

namespace SunStructs.RuntimeDB.Parsers
{
    public class EnchantInfoParser
    {
        private readonly Dictionary<byte, Dictionary<byte, List<ItemEnchantInfo>>> _enchantInfos = new();

        public Dictionary<byte, Dictionary<byte, List<ItemEnchantInfo>>> ParseAllEnchantInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\Enchant.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _enchantInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 14; i < allLines.Length; i++)
            {
                var line = allLines[i];
                if (!line.StartsWith("//")) noCommentLines.Add(line);
            }

            noCommentLines.RemoveAt(0);
            return noCommentLines;
        }

        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            var enchantInfo = new ItemEnchantInfo(info);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Enchant for [{(ItemType) enchantInfo.ItemType}]");
#endif
            AddInfo(enchantInfo);
        }

        private void AddInfo(ItemEnchantInfo info)
        {
            if(!_enchantInfos.ContainsKey(info.ItemType))
                _enchantInfos.Add(info.ItemType,new Dictionary<byte, List<ItemEnchantInfo>>());
            if(!_enchantInfos[info.ItemType].ContainsKey(info.ItemLevel))
                _enchantInfos[info.ItemType].Add(info.ItemLevel,new List<ItemEnchantInfo>());
            _enchantInfos[info.ItemType][info.ItemLevel].Add(info);
        }
    }

}
