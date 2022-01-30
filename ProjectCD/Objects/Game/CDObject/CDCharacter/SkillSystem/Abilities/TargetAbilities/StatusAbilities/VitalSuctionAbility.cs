using ProjectCD.Formulas;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class VitalSuctionAbility : BaseStatusAbility
    {
        private int _suctionCount;
        private int _totalSuctionHP;
        private int _suctionHP;

        public override void Init(SkillBase skill, BaseAbilityInfo baseAbilityInfo)
        {
            base.Init(skill, baseAbilityInfo);

            _suctionCount = 0;
            _totalSuctionHP = 0;
            _suctionHP = 0;
        }

        public override bool CanExecute(Character attacker, Character target, uint mainTargetKey, SunVector mainTargetPos)
        {
            if (target.IsObjectType(ObjectType.MONSTER_OBJECT) == false) return false;
            var abilityInfo = GetBaseAbilityInfo();

            bool isSuccessRate = false;
            if (StateInfoDB.Instance.TryGetStateInfo(GetCharStateType(), out var stateInfo))
            {
                var targetStatusManager = target.GetStatusManager();
                if (stateInfo!.Type is StateType.STATE_TYPE_ABNORMAL or StateType.STATE_TYPE_WEAKENING)
                {
                    isSuccessRate = true;
                    if(CharacterFormulas.IsStatusHit(attacker,target,abilityInfo.SuccessRate,(ushort) GetCharStateType(),GetSkill())== false || 
                       targetStatusManager.FindStatus(CharStateType.CHAR_STATE_PROTECTION) || 
                       targetStatusManager.IsImmunityDamageState())
                    {
                        return false;
                    }
                }
                else if (stateInfo.Type == StateType.STATE_TYPE_SPECIALITY)
                {
                    isSuccessRate = true;
                    if (targetStatusManager.IsImmunityDamageState())
                        return false;
                }
            }

            if (isSuccessRate == false)
            {
                if (!GlobalRandom.IsSuccess(abilityInfo.SuccessRate * 10))
                    return false;
            }

            if (!CheckAbilityRange(attacker, target, mainTargetKey, abilityInfo.RangeType)) return false;
            if (_suctionCount > abilityInfo.Params[1]) return false;

            var maxSuctionHP = abilityInfo.Params[1];
            _suctionHP = (int) (target.GetMaxHP() * (abilityInfo.option2 / 1000f));

            if (_totalSuctionHP + _suctionHP > maxSuctionHP)
            {
                _suctionHP = maxSuctionHP - _totalSuctionHP;
            }
            _totalSuctionHP +=_suctionHP;
            _suctionCount++;

            return true;
        }

        public override bool IsValidState()
        {
            return GetCharStateType() == CharStateType.CHAR_STATE_VITAL_SUCTION;
        }
    }
}
