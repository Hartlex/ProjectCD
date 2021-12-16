using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Quest;

namespace SunStructs.RuntimeDB
{
    public class RewardInfoDB : Singleton<RewardInfoDB>
    {
        private Dictionary<uint, RewardInfo> _rewardInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new RewardInfoParser();
            _rewardInfos = parser.ParseAllInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_rewardInfos.Count} Rewards loaded!\n", LogType.SUCCESS);

        }
        public RewardInfo GetRewardInfo(uint rewardCode)
        {
            try
            {
                return _rewardInfos[rewardCode];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e);
                return null;
            }
        }

        
        
    }
}
