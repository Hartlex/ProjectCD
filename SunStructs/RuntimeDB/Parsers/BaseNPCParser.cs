using CDShared.Logging;
using SunStructs.ServerInfos.General.Object.Character.NPC;

namespace SunStructs.RuntimeDB.Parsers
{
    public class BaseNPCParser
    {
        private readonly Dictionary<ushort, BaseNPCInfo> _npcInfos = new();

        public Dictionary<ushort, BaseNPCInfo> ParseBaseNpcs(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\NPCInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _npcInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 12; i < allLines.Length; i++)
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
            var npcInfo = new BaseNPCInfo(info);
            _npcInfos.Add(npcInfo.MonsterId,npcInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded FieldInfo[{npcInfo.MonsterId}]");
#endif
        }
    }
}
