using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Character.NPC;

namespace SunStructs.RuntimeDB
{
    public class BaseNpcDB : Singleton<BaseNpcDB>
    {
        private Dictionary<ushort, BaseNPCInfo> _npcInfos;

        public void Init(string dataFolderPath)
        {

            var parser = new BaseNPCParser();
            _npcInfos = parser.ParseBaseNpcs(dataFolderPath);
            Logger.Instance.LogOnLine($"{_npcInfos.Count} NPCs loaded!\n", LogType.SUCCESS);
        }

        public BaseNPCInfo GetBaseInfo(in ushort monsterId)
        {
            try
            {
                return _npcInfos[monsterId];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }
    }
}
