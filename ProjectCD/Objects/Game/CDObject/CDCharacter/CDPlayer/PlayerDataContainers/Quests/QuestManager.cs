using CDShared.ByteLevel;
using ProjectCD.Objects.Game.Items;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.PacketInfos.Game.Quest.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Item;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Quest;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Quests
{
    public class QuestManager
    {
        private readonly List<ushort> _finishedQuestCodes;
        private readonly Dictionary<ushort, Quest> _ongoingQuests;
        private readonly List<ushort> _questMonsters= new();
        private ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.Player _owner;
        public QuestManager(byte[] questBytes, ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.Player owner)
        {
            _owner = owner;
            ByteBuffer buffer = new ByteBuffer(questBytes);
            var finishedQuestCount = buffer.ReadUInt16();
            _finishedQuestCodes = new List<ushort>(finishedQuestCount);
            for (int i = 0; i < finishedQuestCount; i++)
            {
                buffer.ReadByte();
                _finishedQuestCodes.Add(buffer.ReadUInt16());
            }

            var ongoingQuestCount = buffer.ReadByte();
            _ongoingQuests = new Dictionary<ushort, Quest>(ongoingQuestCount);
            for (int i = 0; i < ongoingQuestCount; i++)
            {
                var quest = new Quest(ref buffer);
                _ongoingQuests.Add(quest.GetQuestCode(),quest);
            }

        }
        public byte[] Serialize()
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteUInt16((ushort)_finishedQuestCodes.Count);
            foreach (var questCode in _finishedQuestCodes)
            {
                buffer.WriteByte(1);
                buffer.WriteUInt16(questCode);
            }
            buffer.WriteByte((byte)_ongoingQuests.Count);
            foreach (var ongoingQuest in _ongoingQuests.Values)
            {
                ongoingQuest.GetBytes(ref buffer);
            }

            return buffer.GetData();
        }
        public QuestListInfo GetQuestListInfo()
        {
            var finishedQuestInfos = new FinishedQuestInfo[_finishedQuestCodes.Count];

            int i;
            for (i = 0; i < _finishedQuestCodes.Count; i++)
            {
                finishedQuestInfos[i] = new FinishedQuestInfo(_finishedQuestCodes[i]);
            }

            var ongoingQuestInfos = new OngoingQuestInfo[_ongoingQuests.Count];
            i = 0;
            foreach (var ongoingQuest in _ongoingQuests.Values)
            {
                ongoingQuestInfos[i] = ongoingQuest.GetInfo();
                i++;
            }
            return new QuestListInfo(finishedQuestInfos, ongoingQuestInfos);

            //var quest = new Quest(611);
            //return new QuestListInfo(
            //    new FinishedQuestInfo[0],
            //    new OngoingQuestInfo[]
            //    {
            //        quest.GetInfo()
            //    }
            //);
        }

        public bool TryAcceptQuest(ushort questCode)
        {
            if (_finishedQuestCodes.Contains(questCode)) return false;
            if (_ongoingQuests.ContainsKey(questCode)) return false;
            var quest = new Quest(questCode);
            OnAcceptQuest(quest);
            return true;
        }

        public bool TryUpdateQuest(ushort questCode)
        {
            if (!_ongoingQuests.ContainsKey(questCode)) return false;
            //Does player meet requirements?
            return true;
        }

        public bool TryHandInQuest(ushort questCode,out HandInQuestInfo outInfo)
        {
            outInfo = null;
            if (!_ongoingQuests.ContainsKey(questCode)) return false;
            //Check Requirements
            var quest = _ongoingQuests[questCode];
            OnHandInQuest(quest, out outInfo);
            
            return true;
        }

        private void OnAcceptQuest(Quest quest)
        {
            _ongoingQuests.Add(quest.GetQuestCode(),quest);
            var monsterList = quest.GetReqMonsterCodes();
            _questMonsters.AddRange(monsterList);
            
            var itemsToAdd = quest.GetOnAcceptItems();
            if (!_owner.GetInventory().InsertItems(itemsToAdd,out var slotInfos)) return;
            var outPacket = new AckItemPickup(new (slotInfos));

            var mobToSpawn = quest.GetSpawnMobOnAccept();
            if (mobToSpawn != 0)
            {
                //_owner.CurrentMap.SpawnMobAtPlayer(_owner.GetObjectKey(),mobToSpawn);
            }

            _owner.SendPacket(outPacket);

        }
        private void OnHandInQuest(Quest quest, out HandInQuestInfo info)
        {
            var monsterList = quest.GetReqMonsterCodes();
            foreach (var monsterCode in monsterList)
            {
                _questMonsters.Remove(monsterCode);
            }

            var rewardInfo = quest.GetRewardInfo();
            info = GiveRewardToPlayer(rewardInfo);
            
            _ongoingQuests.Remove(quest.GetQuestCode());
            _finishedQuestCodes.Add(quest.GetQuestCode());
        }
        private void OnUpdateQuest(Quest quest)
        {
            var buffer = new ByteBuffer();
            quest.GetBytes(ref buffer);
            
            _owner.SendPacket(new TestPacket((byte) GamePacketType.QUEST,208,new (buffer.GetData())));

            
        }

        private HandInQuestInfo GiveRewardToPlayer(RewardInfo info)
        {
            var exp = info.GiveExp;
            var money = info.GiveHeim;
            var amount = info.SelectNum;
            var addItemInfos = info.GetItemsAndType(0);
            var items = new List<Item>();
            foreach (var addItemInfo in addItemInfos)
            {
                var itemInfo = BaseItemDB.Instance.GetBaseItemInfo((ushort)addItemInfo.Key);
                var item = new Item(itemInfo);
                if(!itemInfo.IsArmor() && !itemInfo.IsWeapon())
                    item.SetAmount((byte)addItemInfo.Value);
                //item.SetAmount(amount);
                items.Add(item);
            }

            if (!_owner.GetInventory().InsertItems(items, out var slotInfos)) return null;
            //_owner.AddExp(exp, 0, false);
            return new HandInQuestInfo(exp, _owner.IncreaseMoney(money), new InventoryAddInfo(slotInfos));

        }
        //public void UpdateQuestMonsterKills(Monster monster)
        //{
        //    if (!_questMonsters.Contains(monster.GetMonsterId())) return;
        //    foreach (var ongoingQuest in _ongoingQuests.Values)
        //    {
        //        if (!ongoingQuest.GetReqMonsterCodes().Contains(monster.GetMonsterId())) continue;
        //        ongoingQuest.UpdateMonsterKill(monster.GetMonsterId());
        //        OnUpdateQuest(ongoingQuest);
        //    }
        //}
    }
}
