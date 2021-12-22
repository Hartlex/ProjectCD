using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.Character.NPC;

namespace SunStructs.RuntimeDB
{
    public class ExtraNPCInfoDB : Singleton<ExtraNPCInfoDB>
    {
        private Dictionary<uint, List<ExtraNPCInfo>> _allInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new ExtraNPCInfoParser();
            _allInfos = parser.ParseAllInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_allInfos.Count} ExtraNPCInfos loaded!\n", LogType.SUCCESS);

        }

        public SunVector? GetRandomNPCPosOnMap(uint mapCode)
        {
            if(_allInfos.TryGetValue(mapCode,out var list))
            {
                if(list.Count > 0)
                    return list.FirstOrDefault()!.NPCPos;
            }

            return null;
        }
    }
}
