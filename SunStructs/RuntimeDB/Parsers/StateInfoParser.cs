using CDShared.Logging;
using SunStructs.ServerInfos.General.Skill;

namespace SunStructs.RuntimeDB.Parsers
{
    public class StateInfoParser
    {
        private readonly Dictionary<ushort, BaseStateInfo> _infos = new();

        public Dictionary<ushort, BaseStateInfo> ParseInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\StateInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _infos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 15; i < allLines.Length; i++)
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
            var baseStateInfo = new BaseStateInfo(info);
            _infos.Add(baseStateInfo.StateID,baseStateInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Skill[{baseStateInfo.StateID}]");
#endif
        }
    }
}
