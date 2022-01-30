using CDShared.Generics;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Skill;

namespace SunStructs.RuntimeDB
{
    public class StateInfoDB : Singleton<StateInfoDB>
    {
        private Dictionary<CharStateType, BaseStateInfo> _stateInfos;
        public void Init(string dataFolderPath)
        {

            var parser = new StateInfoParser();
            _stateInfos = parser.ParseInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_stateInfos.Count} StateInfos loaded!\n", LogType.SUCCESS);
        }

        public bool TryGetStateInfo(CharStateType type, out BaseStateInfo? info)
        {
            return _stateInfos.TryGetValue(type, out info);
        }

    }
}
