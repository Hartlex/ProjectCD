using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;

namespace SunStructs.RuntimeDB.Parsers
{
    public class RankOptionParser
    {
        //private readonly RankOption[,] _rankOptions = new RankOption[(int) eRANK_OPTION_ITEM_TYPE.eRANK_OPTION_ITEM_TYPE_MAX,32];
        private readonly Dictionary<ItemType,Dictionary<byte,RankOption>> _rankOptionDictionary=new();
            public Dictionary<ItemType, Dictionary<byte, RankOption>>  ParseAllOptions(string dataFolderPath)
            {
                var lines = ReadAllLines(dataFolderPath+"\\RankOptionInfo.txt");
                foreach (var line in lines)
                {
                    ParseLine(line);
                }

                return _rankOptionDictionary;
            }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 8; i < allLines.Length; i++)
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
            var rankInfo = new RankOption(info);
            if(!_rankOptionDictionary.TryGetValue(rankInfo.Type,out var dictionary))
                _rankOptionDictionary.Add(rankInfo.Type,new Dictionary<byte, RankOption>());
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded RankOption[{rankInfo.AttrOptionIndex}]");
#endif
            dictionary?.Add(rankInfo.AttrOptionIndex,rankInfo);
        }
    }
}
