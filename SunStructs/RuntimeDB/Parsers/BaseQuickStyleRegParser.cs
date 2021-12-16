using SunStructs.ServerInfos.General.Skill.Style;

namespace SunStructs.RuntimeDB.Parsers
{
    public class BaseQuickStyleRegParser
    {
        private Dictionary<uint, BaseQuickStyleRegisterInfo> _infos = new();

        public Dictionary<uint, BaseQuickStyleRegisterInfo> ParseAllInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\StyleQuickRegistInfo.txt");
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
            var baseQuickStyleRegister = new BaseQuickStyleRegisterInfo(info);
            var key = MakeKey(baseQuickStyleRegister.ByClass, baseQuickStyleRegister.Weapon);
            _infos.Add(key,baseQuickStyleRegister);
        }

        private uint MakeKey(byte cls,byte weapon)
        {
            return ((uint) cls << 16 | weapon);
        }
    }
}
