using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Quest;

namespace SunStructs.RuntimeDB
{
    public class QuestInfoDB : Singleton<QuestInfoDB>
    {
        private Dictionary<ushort, QuestInfo> _questInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new QuestInfoParser();
            _questInfos = parser.ParseAllQuests(dataFolderPath);
            Logger.Instance.LogOnLine($"{_questInfos.Count} Quests loaded!\n", LogType.SUCCESS);
        }

        public QuestInfo GetQuestInfo(ushort questCode)
        {
            try
            {
                return _questInfos[questCode];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e);
                return null;
            }
        }
    }
}
