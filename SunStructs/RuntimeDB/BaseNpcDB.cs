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

        public bool TryGetBaseInfo(ushort monsterId, out BaseNPCInfo? info)
        {
            return _npcInfos.TryGetValue(monsterId, out info);
        }
    }
}
