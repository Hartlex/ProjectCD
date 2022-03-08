using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;
using static ProjectCD.Formulas.CharacterFormulas;
using static SunStructs.Definitions.AbilityID;
using static SunStructs.Definitions.AbilityRangeType;
using static SunStructs.Definitions.CharStateType;
using static SunStructs.Definitions.Const;
using static SunStructs.Definitions.ObjectType;
using static SunStructs.Definitions.StateType;
using static SunStructs.Definitions.UserRelationType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities
{
    internal class Ability
    {
        private ushort _skillCode;
        private byte _eventCode;
        private BaseAbilityInfo _baseInfo;
        private Character? _attacker;
        private SkillBase? _skill;

        #region Getters

        public ushort GetSkillCode(){ return _skillCode; }
        public BaseAbilityInfo GetBaseAbilityInfo(){ return _baseInfo; }

        public virtual void Release()
        {

        }
        public BaseAbilityInfo MakeBaseInfoEditable()
        {
            _baseInfo = _baseInfo.EditableCopy();
            return _baseInfo;
        }
        public AbilityID GetAbilityID() { return _baseInfo.AbilityId; }
        public AttrType GetAttrType() { return _baseInfo.Attribute; }
        public CharStateType GetCharStateType() { return _baseInfo.CharStateType; }
        public byte GetIndex(){ return (byte) _baseInfo.Index; }
        public SkillBase? GetSkill(){ return _skill; }
        public byte GetEventCode() { return _eventCode; }

        public Character? GetAttacker()
        {
            return _attacker;
        }

        #endregion

        public void SetEventCode(byte code) { _eventCode = code; }

        #region Virtual

        public virtual void Init(SkillBase skill, BaseAbilityInfo baseAbilityInfo)
        {
            _skill = skill;
            var owner = _skill.Owner;
            var skillCode = _skill.GetSkillCode();
            var skillInfo = _skill.SkillInfo;
            var skillStatType = _skill.GetSkillStatType();
            InitDetailed(owner,skillCode,ref skillInfo,skillStatType,baseAbilityInfo);
        }

        public virtual void InitDetailed(Character attacker, ushort skillCode, ref SkillInfo skillInfo,
            byte skillStatType, BaseAbilityInfo baseInfo)
        {
            _skillCode = skillCode;
            _baseInfo = baseInfo;
            _attacker = attacker;
            _eventCode = 0;


        }

        public virtual bool Execute(Character? target, out SkillResultAbility? result)
        {
            result = null;
            if (GetAttacker() == null) return false;
            if (target == null) return false;

            result = new ()
            {
                AbilityOrder = GetIndex(),
                AbilityCode = 0,
                AbilityDuration = 0
            };

            return true;
        }
        public virtual bool ExecuteEffect(out SkillResultEffect? result) {
        {
            result = null;
            return false;
        }}

        public virtual bool IsValidState()
        {
            return GetCharStateType() != CHAR_STATE_INVALID;
        }
        public virtual void SetBonusEffect(BonusAbilityEffect bonusAbilityEffect) { }

        public virtual bool CanExecute(Character attacker, Character target,uint mainTargetKey, SunVector mainTargetPos)
        {
            var rangeType = (AbilityRangeType)_baseInfo.RangeType;
            var rangeBitSet = (uint) (1 << (int)rangeType);

            var attackerStatusManager = attacker.GetStatusManager();
            var attackerStatusFlags = attackerStatusManager.GetStatusFlag();

            if (!attackerStatusFlags.IsPassConstraints(attacker, _baseInfo)) return false;

            const uint applyCheckCanBeAttacked = (1 << (int) SKILL_ABILITY_ENEMY) |
                                                 (1 << (int) SKILL_ABILITY_TARGETAREA_ENEMY) |
                                                 (1 << (int) SKILL_ABILITY_MYAREA_ENEMY);

            if ((rangeBitSet & applyCheckCanBeAttacked) != 0 && !target.CanBeAttacked()) return false;

            const uint applySafetyZoneRuleField = (1 << (int)SKILL_ABILITY_ENEMY) |
                                                  (1 << (int)SKILL_ABILITY_TARGETAREA_ENEMY) |
                                                  (1 << (int)SKILL_ABILITY_MYAREA_ENEMY) |
                                                  (1 << (int)SKILL_ABILITY_PLAYER_ENEMY);

            if ((applySafetyZoneRuleField & rangeBitSet) != 0)
            {
                //TODO Zone Bit Checks
                //ushort skipCheckTitleAttrForTarget = 0;

                //if (target.IsObjectType(MAPNPC_OBJECT))
                //{
                //    skipCheckTitleAttrForTarget = PTA_NO_WALK;
                //}
            }

            var targetStatusManager = target.GetStatusManager();
            bool isRidingOrSpreading = false;
            var targetStatusFlags = targetStatusManager.GetStatusFlag();

            if (targetStatusFlags.IsRidingRider() || targetStatusFlags.IsSpreadWings())
                isRidingOrSpreading = true;

            if(_baseInfo.AbilityId is ABILITY_KNOCKBACK or ABILITY_KNOCKBACK2)
                if (isRidingOrSpreading)
                    return false;

            if(_baseInfo.AbilityId is ABILITY_PULLING)
                if (targetStatusManager.FindStatus(CHAR_STATE_PROTECTION))
                    return false;

            var stateType = GetCharStateType();
            StateInfoDB.Instance.TryGetStateInfo(stateType,out var stateInfo);

            var checkSuccess = false;
            if (stateInfo != null)
            {
                if (stateInfo.RidingApply == 0)
                    if (isRidingOrSpreading)
                        return false;
                if (stateInfo.Type is STATE_TYPE_ABNORMAL or  STATE_TYPE_WEAKENING)
                {
                    if (targetStatusManager.FindStatus(CHAR_STATE_PROTECTION) ||
                        targetStatusManager.FindStatus(CHAR_STATE_STAMP) ||
                        targetStatusManager.IsImmunityDamageState())
                    {
                        return false;
                    }

                    checkSuccess = true;
                }
                else if (stateInfo.Type == STATE_TYPE_SPECIALITY)
                {
                    if (targetStatusManager.FindStatus(CHAR_STATE_IMMUNITY_DAMAGE))
                    {
                        return false;
                    }

                    checkSuccess = true;
                }

                if (!IsStatusHit(attacker, target, _baseInfo.SuccessRate, (ushort) stateType, GetSkill())) return false;
            }

            if (checkSuccess == false)
            {
                    if (!GlobalRandom.IsSuccess(_baseInfo.SuccessRate)) return false;
            }

            return CheckAbilityRange(attacker, target, mainTargetKey, (AbilityRangeType) _baseInfo.RangeType);
        }

        public bool CheckAbilityRange(Character attacker, Character target, uint mainTargetKey,
            AbilityRangeType rangeType)
        {
            if (rangeType is SKILL_ABILITY_CORPSE_RESURRECTION
                or SKILL_ABILITY_CORPSE_FRIEND
                or SKILL_ABILITY_MYAREA_CORPSE_ENEMY
                or SKILL_ABILITY_CORPSE_ENEMY)
            {
                if (target.IsAlive()) return false;
            }
            else if (target.IsDead()) return false;

            if (rangeType == SKILL_ABILITY_FIELD) return false;

            switch (rangeType)
            {
                case SKILL_ABILITY_FRIEND:
                case SKILL_ABILITY_TARGETAREA_FRIEND:
                case SKILL_ABILITY_MYAREA_FRIEND:
                case SKILL_ABILITY_CORPSE_FRIEND:
                    if (attacker.IsFriend(target) != USER_RELATION_FRIEND) return false;
                    break;
                case SKILL_ABILITY_ENEMY:
                case SKILL_ABILITY_TARGETAREA_ENEMY:
                case SKILL_ABILITY_MYAREA_ENEMY:
                case SKILL_ABILITY_MYAREA_CORPSE_ENEMY:
                case SKILL_ABILITY_CORPSE_ENEMY:
                    if (attacker.IsFriend(target) != USER_RELATION_ENEMY) return false;
                    break;
                case SKILL_ABILITY_CORPSE_RESURRECTION:
                    if (attacker.CanResurrect(target)) return false;
                    break;
                case SKILL_ABILITY_ME:
                case SKILL_ABILITY_FIELD:
                case SKILL_ABILITY_SUMMON:
                case SKILL_ABILITY_SUMMONED_MONSTER:
                    break;
                case SKILL_ABILITY_PLAYER_ENEMY:
                    if (!target.IsObjectType(PLAYER_OBJECT)) return false;
                    break;
                default:
                    break;
            }

            switch (rangeType)
            {
                case SKILL_ABILITY_FRIEND or SKILL_ABILITY_ENEMY when mainTargetKey != target.GetKey():
                case SKILL_ABILITY_ME when attacker.GetKey() != target.GetKey():
                    return false;
                default:
                    return true;
            }
        }
        #endregion

        public virtual AbilityType GetAbilityType()
        {
            return AbilityType.ABILITY_TYPE_ACTIVE;
        }
    }
}
