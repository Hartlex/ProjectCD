using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items;

namespace SunStructs.RuntimeDB
{
    public class BaseItemDB : Singleton<BaseItemDB>
    {
        private Dictionary<ushort, BaseItemInfo> _baseItemInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new BaseItemParser();
            _baseItemInfos = parser.ParseAllBaseItems(dataFolderPath);
            Logger.Instance.LogOnLine($"{_baseItemInfos.Count} Items loaded!\n", LogType.SUCCESS);
        }

        public bool TryGetBaseItemInfo(ushort itemId,out BaseItemInfo? info)
        {
            return _baseItemInfos.TryGetValue(itemId, out info);
        }

    }
}
