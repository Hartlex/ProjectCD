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

        public BaseItemInfo GetBaseItemInfo(ushort itemId)
        {
            try
            {
                return _baseItemInfos[itemId];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }

    }
}
