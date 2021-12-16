using CDShared.Logging;
using SunStructs.ServerInfos.General.Skill;

namespace SunStructs.RuntimeDB.Parsers
{
    public class StyleInfoParser
    {
        private readonly Dictionary<ushort, RootSkillInfo> _baseStyleInfos = new();
        public Dictionary<ushort, RootSkillInfo> ParseBaseStyleInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\StyleInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _baseStyleInfos;
        }
        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            var baseSkillInfo = new BaseStyleInfo(info);
            _baseStyleInfos.Add(baseSkillInfo.SkillCode,baseSkillInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Skill[{baseSkillInfo.SkillCode}]");
#endif
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 9; i < allLines.Length-1; i++)
            {
                var line = allLines[i];
                if (!line.StartsWith("//")) noCommentLines.Add(line);
            }

            noCommentLines.RemoveAt(0);
            return noCommentLines;
        }
    }

}
