using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Skill;

namespace SunStructs.RuntimeDB
{
    public class StateInfoDB : Singleton<StateInfoDB>
    {
        private Dictionary<ushort, BaseStateInfo> _stateInfos;
        public void Init(string dataFolderPath)
        {

            var parser = new StateInfoParser();
            _stateInfos = parser.ParseInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_stateInfos.Count} StateInfos loaded!\n", LogType.SUCCESS);
        }

        public BaseStateInfo GetStateInfo(ushort id)
        {
            try
            {
                return _stateInfos[id];
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }

        }
    }
}
