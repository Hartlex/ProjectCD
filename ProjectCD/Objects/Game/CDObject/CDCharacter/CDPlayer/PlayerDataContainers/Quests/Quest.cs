using CDShared.ByteLevel;
using ProjectCD.Objects.Game.Items;
using SunStructs.PacketInfos.Game.Quest.Server;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Quest;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Quests
{
    public class Quest
    {
        private readonly QuestInfo _info;
        private readonly QuestProgress _progress;

        public Quest(ushort questCode)
        {
            _info = QuestInfoDB.Instance.GetQuestInfo(questCode);
            _progress = new QuestProgress();
        }
        public Quest(ref ByteBuffer buffer)
        {
            var questCode = buffer.ReadUInt16();
            _info = QuestInfoDB.Instance.GetQuestInfo(questCode);
            _progress = new QuestProgress(ref buffer);
        }

        public OngoingQuestInfo GetInfo()
        {
            return new OngoingQuestInfo(GetQuestCode(),_progress);
        }
        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(GetQuestCode());
            _progress.GetBytes(ref buffer);
        }
        
        public ushort GetQuestCode() { return _info.QuestCode; }
        public List<ushort> GetReqMonsterCodes()
        {
            var codes = _info.CompleteConditionInfo.ReqKillMonsterCode;
            var result = new List<ushort>();
            foreach (var code in codes)
            {
                if(code!=0)
                    result.Add(code);
            }

            return result;
        }
        public List<Item> GetOnAcceptItems()
        {
            var result = new List<Item>();
            for (int i = 0; i < 3; i++)
            {
                var itemCode = _info.AcquireActionInfo.GiveItemCode[i];
                if (itemCode == 0) break;
                var itemAmount = _info.AcquireActionInfo.GiveItemNum[i];
    
                BaseItemDB.Instance.TryGetBaseItemInfo(itemCode,out var itemInfo);
                var item = new Item(itemInfo);
                item.SetAmount(itemAmount);
                result.Add(item);
            }

            return result;
        }

        public RewardInfo GetRewardInfo()
        {
            var index = 0;
            return RewardInfoDB.Instance.GetRewardInfo(_info.CompleteActionInfo.RewardCode[index]);
        }
        public void UpdateMonsterKill(ushort monsterCode)
        {
            var index = GetMonsterIndex(monsterCode);
            if (index > 5) return;
            _progress.IncreaseMonsterKillNum(index);
        }

        private byte GetMonsterIndex(ushort monsterCode)
        {
            for (byte i = 0; i < 5; i++)
            {
                if (_info.CompleteConditionInfo.ReqKillMonsterCode[i] == monsterCode) return i;
            }

            return byte.MaxValue;
        }

        public ushort GetSpawnMobOnAccept()
        {
            return _info.CompleteConditionInfo.SummonMonsterCode;
        }
    }
}
