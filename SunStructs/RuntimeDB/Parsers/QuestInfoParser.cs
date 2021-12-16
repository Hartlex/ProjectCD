using CDShared.Logging;
using SunStructs.ServerInfos.General.Quest;

namespace SunStructs.RuntimeDB.Parsers
{
    public class QuestInfoParser
    {
        private readonly Dictionary<ushort, QuestInfo> _questInfos=new();
        
        public Dictionary<ushort,QuestInfo>  ParseAllQuests(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\QuestInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _questInfos;
        }
        
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 7; i < allLines.Length; i++)
            {
                var line = allLines[i];
                if( line.StartsWith("//")) continue;
                if (line.StartsWith("\t//")) continue;
                noCommentLines.Add(line);
                    
            }

            return noCommentLines;
        }
        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            var questInfo = new QuestInfo(info);
            _questInfos.Add(questInfo.QuestCode,questInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Quest[{questInfo.QuestCode}]");
#endif
        }
    }
}
