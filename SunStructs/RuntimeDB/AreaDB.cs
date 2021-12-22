using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.World;

namespace SunStructs.RuntimeDB
{
    public class AreaDB : Singleton<AreaDB>
    {
        private Dictionary<uint, AreaInfo> _areaInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new AreaInfoParser();
            _areaInfos = parser.ParseAllInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_areaInfos.Count} AreaInfos loaded!\n", LogType.SUCCESS);
        }

        public bool TryGetAreaPosition(uint mapCode, string area, out SunVector vector)
        {
            vector = null;
            if (!_areaInfos.TryGetValue(mapCode, out var areaInfo)) return false;
            return areaInfo.TryGetArea(area, out vector);
        }
    }
}
