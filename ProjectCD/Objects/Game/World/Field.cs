using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server.Config;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
using ProjectCD.Objects.Game.CDObject;
using ProjectCD.Objects.Game.CDObject.CDCharacter;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.MOB;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Servers.Game;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.PacketInfos.Game.Map.Server;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Map;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using SunStructs.ServerInfos.General.Object.Character.NPC;
using SunStructs.ServerInfos.General.World;
using static SunStructs.Definitions.Const;
using static SunStructs.Definitions.ItemResult;
using Timer = System.Timers.Timer;

namespace ProjectCD.Objects.Game.World
{
    internal class Field
    {
        private readonly BaseFieldInfo _baseFieldInfo;
        private readonly GameServer _server;
        private readonly Dictionary<uint, Player> _activePlayers;
        private readonly Dictionary<uint, ObjectBase> _activeObjects;
        private readonly WarPacketScheduler _warPacketScheduler;
        private readonly EffectManager _effectManager;

        public Field(BaseFieldInfo baseFieldInfo, GameServer server)
        {
            _baseFieldInfo = baseFieldInfo;
            _server = server;
            _activePlayers = new(MAX_PLAYERS_ON_MAP);
            _activeObjects = new(MAX_OBJECTS_ON_MAP);
            _warPacketScheduler = new (this);
            _effectManager = new(this);
        }

        public virtual bool EnterField(ObjectBase obj, SunVector pos, ushort angle = 0)
        {
            var pSuccess = true;
            if (obj.GetObjectType() == ObjectType.PLAYER_OBJECT)
            {
                var player = (Player) obj;
                pSuccess = _activePlayers.TryAdd(player.GetKey(), player);
#if DEBUG
                Logger.Instance.Log($"Player[{player.GetKey()}] joined Field[{_baseFieldInfo.MapCode}]");
#endif
                SendPlayerAllInfos(player);

            }

            var oSuccess = _activeObjects.TryAdd(obj.GetKey(), obj) && pSuccess;

            obj.OnEnterField(this,pos);
            return oSuccess && pSuccess;
        }
        public virtual bool LeaveField(ObjectBase obj)
        {
            if (obj.GetObjectType() == ObjectType.PLAYER_OBJECT)
            {
                var player = (Player)obj;
                _activePlayers.Remove(player.GetKey());

#if DEBUG
                Logger.Instance.Log($"Player[{player.GetKey()}] left Field[{_baseFieldInfo.MapCode}]");
                Logger.Instance.Log($"{_activePlayers.Count} Players left on Field[{_baseFieldInfo.MapCode}]");
#endif
            }
            obj.OnLeaveField();
            return _activeObjects.Remove(obj.GetKey());
        }
        public void SendToAll(Packet packet)
        {
            foreach (var activePlayer in _activePlayers.Values)
            {
                activePlayer.SendPacket(packet);
            }
        }
        public void QueueWarPacketInfo(WarPacketInfo warInfo)
        {
            _warPacketScheduler.AddInfo(warInfo);
        }
        public void DropItemFromPlayer(Player player, Item item)
        {
            var fieldItem = (FieldItem) ObjectFactory.Instance.CreateObject(ObjectType.ITEM_OBJECT)!;

            Logger.Instance.Log($"FieldItemKey[{fieldItem.GetKey()}]");
            fieldItem.SetOwner(player);
            fieldItem.SetItem(item);
            //fieldItem.SetMoney(10000);
            EnterField(fieldItem, SunVector.GetRandomPosAround(player.GetPos(), 2));
        }

        public void SpawnMonsterEx(ushort monsterKey,SunVector pos)
        {
            var monster = (Monster)ObjectFactory.Instance.CreateObject(ObjectType.MONSTER_OBJECT)!;
            if (!monster.Initialize(monsterKey, 0, 0, 0)) return;

            EnterField(monster, pos);


        }
        public ItemResult PlayerPickupItem(Player player, uint objectKey,out ItemSlotInfo[]? slotInfos,out ulong money)
        {
            slotInfos = null;
            money = 0;
            if (!_activeObjects.TryGetValue(objectKey, out var obj)) return RC_ITEM_NOTEXISTITEMATFIELD;
            if (!(obj is FieldItem fieldItem)) return RC_ITEM_NOTEXISTITEMATFIELD;
            if (SunVector.GetDistance(obj.GetPos(), player.GetPos()) > DISTANCE_SPACE_GET_ITEM) return RC_ITEM_CANT_PICKABLE_BY_LENGTH;
            if (!fieldItem.CanPick(player)) return RC_ITEM_DONOT_HAVE_OWNERSHIP;

            if (fieldItem.IsMoney())
            {
                player.IncreaseMoney(fieldItem.GetMoney());
                money = fieldItem.GetMoney();   
                LeaveField(fieldItem);
                return RC_ITEM_SUCCESS;
            }

            if (!player.GetInventory().InsertItem(fieldItem.GetItem()!,out slotInfos)) return RC_ITEM_NOSPACEININVENTORY;

            LeaveField(fieldItem);

            return RC_ITEM_SUCCESS;

        }

        public void SendPlayerAllInfos(Player player)
        {
            var itemRenderInfos = new List<ItemRenderInfo>();
            var playerRenderInfos = new List<PlayerRenderInfo>();
            var equipRenderInfos = new List<EquipRenderInfo>();

            foreach (var activeObject in _activeObjects)
            {
                switch (activeObject.Value.GetObjectType())
                {
                    case ObjectType.ITEM_OBJECT:
                        var fieldItem = (FieldItem)activeObject.Value;
                        itemRenderInfos.Add(fieldItem.GetRenderInfo());
                        continue;
                    case ObjectType.PLAYER_OBJECT:
                        if (activeObject.Value is Player playerObject)
                        {
                            if(playerObject.GetKey() == player.GetKey()) continue;
                            playerRenderInfos.Add(playerObject.GetRenderInfo());
                            equipRenderInfos.Add(playerObject.GetEquipRenderInfo());
                        }
                        continue;

                }
            }
            

            //SendAllFieldItemInfo(player,itemRenderInfos);
            //SendAllPlayerRenderInfo(player,playerRenderInfos);
            //SendAllPlayerEquipInfo(player, renderInfos);
            SendAll<ItemRenderInfo, AllFieldItemInfo, AllFieldItemInfoBrd>(player, itemRenderInfos, MAX_FIELDITEM_INFO_SIZE);
            SendAll<PlayerRenderInfo, AllPlayerRenderInfo, AllPlayerRenderInfoCmd>(player, playerRenderInfos, MAX_PLAYER_RENDER_INFO_SIZE);
            SendAll<EquipRenderInfo,AllPlayerEquipInfo,AllPlayersEquipInfoCmd>(player,equipRenderInfos, MAX_PLAYER_RENDER_INFO_SIZE);

        }

        public void Broadcast(Packet packet)
        {
            foreach (var player in _activePlayers.Values)
            {
                player.SendPacket(packet);
            }
        }

        public void Broadcast(params Packet[] packets)
        {
            foreach (var player in _activePlayers.Values)
            {
                player.SendPackets(packets);
            }
        }

        private void SendAll<TArrayType,TPacketInfoType,TPacketType>(Player player, List<TArrayType> allInfos,int MaxCount) where TPacketType : Packet where TPacketInfoType : ServerPacketInfo
        {
            int count = allInfos.Count;
            int currentIndex = 0;
            while (count > 0)
            {
                //Is allRenderInfos bigger than maxSize
                var amount = count > MaxCount ? MaxCount : count;
                count -= amount;

                var infos = new TArrayType[amount];

                allInfos.CopyTo(infos);

                //if there are still more left, delete the ones that are send this iteration
                if (count > 0)
                {
                    allInfos.RemoveRange(currentIndex, amount);
                    currentIndex += amount;
                }

                var outInfo = (TPacketInfoType) Activator.CreateInstance(typeof(TPacketInfoType), infos)!;
                var packet = (TPacketType) Activator.CreateInstance(typeof(TPacketType), outInfo)!;
                //var outInfo = new PacketInfoType(infos);
                //var packet = new AllPlayersEquipInfoCmd(outInfo);
                player.SendPacket(packet);
            }
        }

        public override string ToString()
        {
            return _baseFieldInfo.MapCode.ToString();

        }

        public Character? FindCharacter(uint key)
        {
            return _activeObjects.TryGetValue(key, out var value) ? (Character) value : default;
        }

        public Character[] FindTargets(SkillTargetType targetType, SkillAreaType attackRangeForm, Character owner, SunVector mainTargetPosition, float skillRange, int maxTargets, uint exceptTargetKey=0)
        {
            if (attackRangeForm == SkillAreaType.SRF_FOWARD_ONE) return Array.Empty<Character>();

            var targets = new Character[MAX_TARGET_COUNT];
            int i = 0;
            foreach (var activeObject in _activeObjects.Values)
            {
                if(!activeObject.IsObjectType(ObjectType.CHARACTER_OBJECT)) continue;
                var character = (Character) activeObject;
                if(SunVector.GetDistance(character.GetPos(),mainTargetPosition)>skillRange) continue;

                switch (targetType)
                {
                    case SkillTargetType.SKILL_TARGET_AREA:
                        if (owner.IsFriend(character) != UserRelationType.USER_RELATION_ENEMY) continue;
                        if (character.IsDead()) continue;
                        break;
                    case SkillTargetType.SKILL_TARGET_AREA_ENEMY_CORPSE:
                        if (owner.IsFriend(character) != UserRelationType.USER_RELATION_ENEMY) continue;
                        if (character.IsAlive()) continue;
                        break;
                    case SkillTargetType.SKILL_TARGET_NONE:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_ENEMY:
                        if (owner.IsFriend(character) != UserRelationType.USER_RELATION_ENEMY) continue;
                        break;
                        //Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        //return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_FRIEND:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_ME:
                        if (character.IsDead()) continue;
                        break;
                    //Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                    //return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_FRIEND_CORPSE:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_REACHABLE_ENEMY:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_REACHABLE_FRIEND:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_REACHABLE_ME:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_SUMMON:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_ENEMY_PLAYER:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_ENEMY_CORPSE:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_ENEMY_AND_ME:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    case SkillTargetType.SKILL_TARGET_MAX:
                        Logger.Instance.Log($"Find Targets should not be called on TargetType[{targetType}][{attackRangeForm}]");
                        return Array.Empty<Character>();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
                }
                if (activeObject.GetKey() == exceptTargetKey) continue;

                targets[i] = (Character) activeObject;
                i++;

                if(i== maxTargets) break;
            }

            var result = new Character[i];
            Array.Copy(targets,result,i);
            return result;
        }

        public void Update(long tick)
        {
            _effectManager.Update(tick);
            lock (_activeObjects)
            {
                foreach (var activeObject in _activeObjects.Values.ToList())
                {
                    activeObject.Update(tick);
                }
            }

        }

        public EffectManager GetEffectManager(){ return _effectManager; }
        public bool TeleportObject(Character target, ref SunVector destPos)
        {
            var info = new ObjectTeleportInfo(true, target.GetKey(), destPos);

            var packet = new ObjectTeleportCMD(info);

            SendToAll(packet);

            return true;
        }

        public bool FindPath(Character owner, ref SunVector destPos, CharStateType getStateType)
        {
            return true;
        }

        public void SendAiMessageAroundExceptMe(NPC sender, AIMsg msg)
        {
            foreach (var obj in _activeObjects.Values.ToList())
            {
                if (obj.IsObjectType(ObjectType.NPC_OBJECT) && obj is NPC npc)
                {
                    if(!ReferenceEquals(npc,sender)) 
                        npc.OnAiMessage(msg);
                }
            }

        }

        public Character? SearchTarget(Character searcher, TargetSearchType searchType, UserRelationType relationType)
        {
            var range = searcher.GetSightRange();

            foreach (var activePlayer in _activePlayers.Values.ToList())
            {
                if (SunVector.GetDistance(activePlayer.GetPos(), searcher.GetPos()) <= range) return activePlayer;
            }

            return null;
        }
    }

    internal class GameField : Field
    {
        public GameField(BaseFieldInfo baseFieldInfo, GameServer server) : base(baseFieldInfo, server)
        {
        }
    }


}
