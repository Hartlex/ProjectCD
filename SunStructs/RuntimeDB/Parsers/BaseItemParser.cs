using CDShared.Logging;
using SunStructs.ServerInfos.General.Object.Items;

namespace SunStructs.RuntimeDB.Parsers
{
    public class BaseItemParser
    {
        private readonly Dictionary<ushort, BaseItemInfo> _itemDict = new();
        public Dictionary<ushort,BaseItemInfo> ParseAllBaseItems(string path)
        {
            LoadItems(path+"\\WeaponItemInfo.txt",8);
            LoadItems(path+"\\ArmorItemInfo.txt",8);
            LoadItems(path+"\\WasteItemInfo.txt",10);
            LoadItems(path+"\\AccessoryItemInfo.txt",9);
            LoadItems(path+"\\ChargeItemInfo.txt",10);
            return _itemDict;
        }
        private void LoadItems(string path,int startOffset)
        {
            var itemLines = File.ReadAllLines(path);
            for (var i = startOffset; i < itemLines.Length; i++)
            {
                var line = itemLines[i];
                if (line.StartsWith("//")) continue;
                var item = new BaseItemInfo(line.Split('\t'));
#if DEBUG
                Logger.Instance.LogOnLine($"Loaded Item[{item.BaseItemId}]");
#endif
                _itemDict.Add(item.BaseItemId,item);
            }
        }
    }
}
