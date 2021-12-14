using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.World;

namespace SunStructs.RuntimeDB
{
    public class BaseMapDB : Singleton<BaseMapDB>
    {
        private Dictionary<uint, BaseFieldInfo> _baseMapInfos = new Dictionary<uint, BaseFieldInfo>();

        public void Init(string dataFolderPath)
        {
            var parser = new BaseMapParser();
            _baseMapInfos = parser.ParseBaseMapInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_baseMapInfos.Count} FieldInfos loaded!\n", LogType.SUCCESS);
        }

        public BaseFieldInfo GetMapInfo(uint mapId)
        {
            try
            {
                return _baseMapInfos[mapId];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }

        public Dictionary<uint, BaseFieldInfo> GetAllMaps()
        {
            return _baseMapInfos;
        }
    }
}
