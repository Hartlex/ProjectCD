using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState;
using SunStructs.Definitions;
using SunStructs.Packets.GameServerPackets.Status;
using SunStructs.RuntimeDB;
using static SunStructs.Definitions.CharCondition;
using static SunStructs.Definitions.CharStateType;
using static SunStructs.Definitions.ConditionResult;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem
{
    class StatusNode
    {
        public bool RequestRemove;
        public BaseStatus Status;
    }
    internal class StatusManager
    {
        private readonly Character _owner;
        private Dictionary<CharStateType, StatusNode> _statusMap;
        private CharCondition _charCondition;
        private readonly GeneralStatusFlag _flags;
        private readonly StatusManagerBits _bits;
        public readonly AnimationDelayController AnimationDelayController;

        private List<CharStateType> _deleteMap;
        public StatusManager(Character owner, int maxPoolSize = 20)
        {
            _owner = owner;
            _statusMap = new(maxPoolSize);
            _deleteMap = new(maxPoolSize);
            _charCondition = CHAR_CONDITION_STANDUP;
            _flags = new();
            AnimationDelayController = new();
            _bits = new();
        }

        public void Release()
        {
            //foreach (var node in _statusMap.Values)
            //{
            //    if (node.Status.CanRemove())
            //    {
            //        node.RequestRemove = true;
            //        node.Status.End();

            //    }
            //}
        }
        public void Update(long currentTick)
        {
            if (!_owner.IsAlive())
            {
                OnDead();
                Release();
                return;
            }
            //Logger.Instance.Log($"StatusCount[{_statusMap.Values.Count}]");

            foreach (var node in _statusMap.ToList())
            {
                //Logger.Instance.Log($"Status[{node.Value.Status.GetStateType()}] Time[{(node.Value.Status.GetExpireTime() - DateTime.Now.Ticks)/10000}]");
                if (node.Value.RequestRemove) continue;
                if (!node.Value.Status.Update(currentTick))
                {
                    //Logger.Instance.Log($"Removing Status [{node.Value.Status.GetStateType()}][{node.Value.Status.GetExpireTime()}][{DateTime.Now.Ticks}]");
                    node.Value.RequestRemove = true;
                    node.Value.Status.End();
                    _deleteMap.Add(node.Key);
                }
            }
            
            DeleteRemoved();
        }

        private void DeleteRemoved()
        {
            lock (_deleteMap)
            {
                foreach (var charStateType in _deleteMap)
                {
                    _REMOVESTATUS(charStateType);

                }
                _deleteMap.Clear();
            }
        }
        public void UpdateReflect(Character attacker, int damage)
        {
            lock (_statusMap)
            {
                foreach (var statusNode in _statusMap.Values)
                {
                    if (statusNode.RequestRemove) continue;

                    if (!statusNode.Status.IsAbilityStatus()) continue;
                    var abilityStatus = (AbilityStatus)statusNode.Status;
                    if (!abilityStatus.IsReflectStatus()) continue;

                    abilityStatus.DamageMirror(attacker, damage);
                }

            }
            DeleteRemoved();
        }

        private void OnDead()
        {
            lock(_statusMap)
            {
                foreach (var node in _statusMap.Values)
                {
                    if(node.RequestRemove) continue;

                    if (node.Status.IsAbilityStatus() && node.Status is AbilityStatus abilityStatus)
                    {
                        if(abilityStatus.SkillOption.HasOption(1<<5)) //continue past death
                            continue;
                    }

                    if (node.Status.CanRemove())
                    {
                        node.RequestRemove = true;
                        node.Status.End();
                        _deleteMap.Add(node.Status.GetStateType());
                    }
                }
            }
            DeleteRemoved();
        }

        #region Getter

        public CharCondition GetCondition() { return _charCondition; }
        public GeneralStatusFlag GetStatusFlag() { return _flags; }

        #endregion

        public bool FindStatus(CharStateType charState, out BaseStatus? status)
        {
            status = null;
            if (_statusMap.TryGetValue(charState, out var node))
            {
                status = node.Status;
                return true;
            }

            return false;
        }
        
        public bool FindStatus(CharStateType charState)
        {
            return _statusMap.ContainsKey(charState);
        }

        public bool FindStatus<T>(CharStateType charState,out T? status) where T:BaseStatus
        {
            status = null;
            if (!_statusMap.TryGetValue(charState, out var node)) return false;
            status = (T) node.Status;
            return true;
        }

        public void ChangeHP()
        {
            if (FindStatus(CHAR_STATE_STAT_LOWHP_ATTACK_DECREASE, out LowHPStatus? status))
                status!.UpdateLowHP();
            if (FindStatus(CHAR_STATE_STAT_LOWHP_DEFENSE_DECREASE, out status))
                status!.UpdateLowHP();
            if (FindStatus(CHAR_STATE_STAT_LOWHP_ATTACK_INCREASE, out status))
                status!.UpdateLowHP();
            if (FindStatus(CHAR_STATE_STAT_LOWHP_DEFENSE_INCREASE, out status))
                status!.UpdateLowHP();
        }

        public bool Remove(CharStateType charState)
        {
            if (!_statusMap.TryGetValue(charState, out var node)) return false;
            if (node.RequestRemove) return true;
            if (node.Status.CanRemove())
            {
                node.RequestRemove = true;
                node.Status.End();
                _deleteMap.Add(charState);
                return true;
            }

            return false;
        }

        public bool AllocStatus(CharStateType stateType, out BaseStatus? status, int expireTime=0, int period=0, int regenHP=0, int regenMP=0)
        {
            status = null;
            bool alloc=false, replace=false;
            if (!_statusMap.TryGetValue(stateType,out var existingNode)) alloc = true;
            else
            {
                if (existingNode.RequestRemove || existingNode.Status.CanRemove())
                {
                    alloc = true;
                    replace = true;
                }
            }

            if (alloc == false) return false;

            status = StatusFactory.Instance.AllocStatus(stateType, false);
            if (status == null) return false;

            ReplaceToNewStatus(replace,stateType,status,existingNode);

            status.Init(_owner,stateType,expireTime,period);
            status.SetRegenInfo(regenHP,regenMP);
            status.Start();

            return true;
        }

        public AbilityStatus? AllocAbilityStatus(Character attacker, Ability ability)
        {
            if (_owner.IsObjectType(ObjectType.TOTEMNPC_OBJECT)) return null;

            if(_owner.IsObjectType(ObjectType.MAPNPC_OBJECT) && _owner is NPC npc)
                if(npc.GetGrade() is NPCGrade.NPC_CRYSTAL_WARP or NPCGrade.NPC_DOMINATION_MAPOBJECT_NPC)
                    return null;

            var stateType = ability.GetCharStateType();
            bool alloc = false, replace = false;
            if (!_statusMap.TryGetValue(stateType, out var existingNode)) alloc = true;
            else
            {
                if (existingNode.RequestRemove || existingNode.Status.CanRemove())
                {
                    alloc = true;
                    replace = true;
                }
            }

            if (!alloc) return null;
            AbilityStatus? abilityStatus;
            if (replace)
            {
                if (!existingNode.Status.IsAbilityStatus()) return null;
                abilityStatus = (AbilityStatus) existingNode.Status;
                //if true existing status is better than new status
                if (abilityStatus.ComparePriority(ability)) return null;

            }

            abilityStatus = (AbilityStatus?) StatusFactory.Instance.AllocStatus(stateType, true);

            if (abilityStatus == null) return null;

            ReplaceToNewStatus(replace,stateType,abilityStatus,existingNode);
            abilityStatus.Init(_owner,attacker,ability);
            abilityStatus.Start();

            return abilityStatus;
        }

        private void ReplaceToNewStatus(bool replace, CharStateType type, BaseStatus newStatus, StatusNode? existingNode)
        {
            if (replace)
            {
                if(existingNode!.RequestRemove == false)
                    existingNode.Status.End();

                //_statusMap.Remove(existingNode.Status.GetStateType());
                existingNode.RequestRemove = false;
                existingNode.Status = newStatus;
            }
            else
            {
                _ADDSTATUS(newStatus);
            }
        } 

        public bool CanBeAttacked()
        {
            return true;
        }

        public bool CanAttack()
        {
            return _bits.CanAttack();
        }

        public bool IsImmunityDamageState()
        {
            return FindStatus(CHAR_STATE_IMMUNITY_DAMAGE) || FindStatus(CHAR_STATE_TRANSPARENT);
        }

        public void Attack(int damage)
        {
            AbilityStatus abilityStatus;
            if (_statusMap.TryGetValue(CHAR_STATE_ABSORB, out var node))
            {
                abilityStatus = (AbilityStatus) node.Status;
                abilityStatus.AttackAbsorb(damage);
            }

            if (_charCondition == CHAR_CONDITION_SITDOWN)
            {
                ChangeCondition(CHAR_CONDITION_STANDUP);
            }
        }

        public ConditionResult ChangeCondition(CharCondition condition)
        {
            if (!_owner.IsObjectType(ObjectType.PLAYER_OBJECT)) return RC_CONDITION_FAILED;
            var player = (Player) _owner;

            if (condition >= CHAR_CONDITION_MAX) return RC_CONDITION_INVALID_CONDITION;
            if (_charCondition == condition) return RC_CONDITION_ALREADY_SAME_CONDITION;
            if (player.IsDoingAction()) return RC_CONDITION_DOING_ACTION;
            if (player.IsMoving()) return RC_CONDITION_DOING_ACTION;
            if (_flags.IsDragonTransforming()) return RC_CONDITION_DRAGON_TRANSFORMATION_LIMIT;

            SetCondition(condition);

            var packet = new ChangConditionBRD(new((byte) condition, _owner.GetKey()));
            _owner.SendPacketAround(packet);

            return RC_CONDITION_SUCCESS;

        }

        public void SetCondition(CharCondition condition)
        {
            _charCondition = condition;
            _owner.UpdateCalcRecover(true,true,false);
        }

        public void Attacked()
        {
            if (FindStatus(CHAR_STATE_SLEEP))
                Remove(CHAR_STATE_SLEEP);
            if (FindStatus(CHAR_STATE_POLYMORPH))
                Remove(CHAR_STATE_POLYMORPH);
            if(_charCondition == CHAR_CONDITION_SITDOWN)
                SetCondition(CHAR_CONDITION_STANDUP);

            AllocFightingStatus();
        }

        public void Damaged(Character attacker, AttackType attackType, ref int dmg)
        {
            if (dmg != 0 && _owner.IsAlive())
            {
                if (FindStatus(CHAR_STATE_IMMUNITY_DAMAGE))
                    dmg = 0;
            }

            UpdateReflect(attacker,dmg);

            if (FindStatus<BonusDamageStatus>(CHAR_STATE_STAT_DAMAGE_ADD, out var bonusDmgStatus))
            {
                bonusDmgStatus!.AddDamage(attackType, ref dmg);
            }

        }

        public void DamagedAbsorb(int damage)
        {
            if (damage != 0 && _owner.IsAlive())
            {
                if (FindStatus<AbilityStatus>(CHAR_STATE_ABSORB, out var status))
                {
                    status!.AttackedAbsorb(AttackType.ATTACK_TYPE_ALL_OPTION,damage);
                }
            }
        }

        public void UpdateExpireTime(CharStateType stateType, int time)
        {
            if (FindStatus(stateType, out var status))
            {
                status!.SetExpiredTime(DateTime.Now.AddMilliseconds(time).Ticks);
            }
            else
            {
                AllocStatus(stateType, out var baseStatus, time);
            }
        }

        public bool CanEnchant()
        {
            return _charCondition != CHAR_CONDITION_SITDOWN;
        }

        public void AllocFightingStatus()
        {
            int time = 0;
            if (_owner.IsObjectType(ObjectType.PLAYER_OBJECT))
                time = Const.PLAYER_FIGHTING_TIME;
            else if (_owner.IsObjectType(ObjectType.SSQMONSTER_OBJECT))
                time = Const.NPC_FIGHTING_TIME;
            if (time != 0)
                AllocStatus(CHAR_STATE_ETC_FIGHTING, out var status, time);
        }

        public void Move()
        {
            if (_charCondition == CHAR_CONDITION_SITDOWN)
                SetCondition(CHAR_CONDITION_STANDUP);
        }

        public void CureAll(StateType stateType )
        {
            lock (_statusMap)
            {
                foreach (var node in _statusMap.Values)
                {
                    if (node.RequestRemove) continue;
                    if(!node.Status.IsAbilityStatus()) continue;
                    var abilityStatus =(AbilityStatus) node.Status;
                    var stateID = abilityStatus.GetStateType();
                    if(stateID == CHAR_STATE_CURE) continue;

                    StateInfoDB.Instance.TryGetStateInfo(stateID, out var stateInfo);
                    if (stateInfo==null) continue;

                    if (stateInfo.Type == stateType)
                    {
                        node.RequestRemove = true;
                        node.Status.End();
                        _deleteMap.Add(stateID);
                    }
                }
            }
            DeleteRemoved();
        }

        public int StopStatusByStateType(StateType stateType, byte numberOfStops=0)
        {
            int cashIconKind = 2;
            byte number = 0;
            var stateParser = StateInfoDB.Instance;

            lock (_statusMap)
            {
                foreach (var pair in _statusMap)
                {
                    var node = pair.Value;
                    var status = node.Status;
                    var stateID = pair.Key;
                    if(node.RequestRemove) continue;

                    if (!stateParser.TryGetStateInfo(stateID, out var stateInfo)) continue;

                    if (stateInfo!.Type == stateType &&  stateInfo.GKind != cashIconKind)
                    {
                        status.StopStatus();
                        number++;
                        if(numberOfStops != 0 && numberOfStops==number) break;
                    }
                }
            }
            DeleteRemoved();

            return number;
        }

        public BaseStatus? FindAuroraStatus()
        {
            foreach (var node in _statusMap.Values.ToList())
            {
                if(node.RequestRemove) continue;
                if (node.Status.IsAbilityStatus())
                {
                    if (IsAuroraStatus(node.Status.GetStateType()))
                        return node.Status;
                }
            }

            return null;
        }

        private bool IsAuroraStatus(CharStateType type)
        {
            switch (type)
            {
                case CHAR_STATE_SLOW_AURORA:
                case CHAR_STATE_WEAKNESS_AURORA:
                case CHAR_STATE_MISCHANCE_AURORA:
                case CHAR_STATE_DECLINE_AURORA:
                case CHAR_STATE_RECOVERY_AURORA:
                case CHAR_STATE_BOOST_AURORA:
                case CHAR_STATE_IGNORE_AURORA:
                case CHAR_STATE_CONCENTRATION_AURORA:
                    return true;
            }

            return false;
        }

        private void _ADDSTATUS(BaseStatus status)
        {
            _statusMap.Add(status.GetStateType(),new StatusNode(){RequestRemove = false, Status = status});
            _bits.AddRestrictStatus(status.GetStateType());
        }

        private void _REMOVESTATUS(CharStateType type)
        {
            if (_statusMap.Remove(type))
            {
                _bits.RemoveRestrictStatus(type);
            }
        }
    }
}
