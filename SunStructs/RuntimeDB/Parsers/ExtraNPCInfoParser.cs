using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using SunStructs.ServerInfos.General.Object.Character.NPC;

namespace SunStructs.RuntimeDB.Parsers
{
    public class ExtraNPCInfoParser
    {
        private readonly Dictionary<uint, List<ExtraNPCInfo>> _extraNPCInfos = new();

        public Dictionary<uint, List<ExtraNPCInfo>> ParseAllInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\NPCExtraInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _extraNPCInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 9; i < allLines.Length; i++)
            {
                var line = allLines[i];
                if (!line.StartsWith("//")) noCommentLines.Add(line);
            }

            noCommentLines.RemoveAt(0);
            return noCommentLines;
        }
        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            if (info[0] == "") return;
            var npcInfo = new ExtraNPCInfo(info);
            if(!_extraNPCInfos.ContainsKey(npcInfo.MapCode))
                _extraNPCInfos.Add(npcInfo.MapCode,new List<ExtraNPCInfo>());
            _extraNPCInfos[npcInfo.MapCode].Add(npcInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded ExtrNPCInfo[{npcInfo.NPCCode}]");
#endif
        }
    }
}
