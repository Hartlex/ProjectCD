using CDShared.Logging;
using SunStructs.ServerInfos.General.Skill;

namespace SunStructs.RuntimeDB.Parsers
{
    public class BaseSkillParser
    {
        private readonly Dictionary<ushort, RootSkillInfo> _skillInfos = new();

        public Dictionary<ushort, RootSkillInfo> ParseBaseSkillInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\SkillInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _skillInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 18; i < allLines.Length; i++)
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
            var baseSkillInfo = new BaseSkillInfo(info);
            _skillInfos.Add(baseSkillInfo.SkillCode,baseSkillInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Skill[{baseSkillInfo.SkillCode}]");
#endif
        }
    }
}
