using CherryDragon.Structures.ForGame.AI;
using SunStructs.ServerInfos.General.Object.AI;

namespace SunStructs.RuntimeDB.Parsers
{
    public class AiTypeParser
    {
        private Dictionary<byte, AiTypeInfo> _infos = new Dictionary<byte, AiTypeInfo>();

        public Dictionary<byte, AiTypeInfo> ParseTypeInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\AITypeInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _infos;
        }

        public AiParamInfo ParseParamInfo(string dataFolderPath)
        {
            var lines = File.ReadAllLines(dataFolderPath + "AiParameters.txt");
            var infos = lines[3].Split('\t');
            return new AiParamInfo(infos);
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 0; i < allLines.Length; i++)
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
            var aiTypeInfo = new AiTypeInfo(info);
            _infos.Add(aiTypeInfo.Code,aiTypeInfo);
        }
    }
}
