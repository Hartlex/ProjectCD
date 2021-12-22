using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items;

namespace SunStructs.RuntimeDB
{
    public class ItemTypeDB : Singleton<ItemTypeDB>
    {
        private Dictionary<int, ItemTypeInfo> _typeInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new ItemTypeParser();
            _typeInfos = parser.ParseAllInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_typeInfos.Count} ItemTypeInfos loaded!\n", LogType.SUCCESS);
        }

        public bool TryGetItemType(int itemType, out ItemTypeInfo? info)
        {
            return _typeInfos.TryGetValue(itemType, out info);
        }
    }
}
