using CDShared.Logging;
using SunStructs.ServerInfos.General.Quest;

namespace SunStructs.RuntimeDB.Parsers
{
    public class RewardInfoParser
    {

        private readonly Dictionary<uint, RewardInfo> _rewardInfos = new();
        
        public Dictionary<uint, RewardInfo> ParseAllInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"RewardInfoList.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _rewardInfos;
        }
        
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 8; i < allLines.Length; i++)
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
            var rewardInfo = new RewardInfo(info);
            _rewardInfos.Add(rewardInfo.RewardCode,rewardInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Reward[{rewardInfo.RewardCode}]");
#endif
        }
    }
}
