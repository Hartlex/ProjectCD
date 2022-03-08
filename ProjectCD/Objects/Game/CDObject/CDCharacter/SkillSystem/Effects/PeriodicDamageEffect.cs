using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Addin;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects
{
    internal class PeriodicDamageEffect : BaseEffect
    {
        private AttackType _attackType;
        private int _damage;
        private BaseAbilityInfo? _abilityInfo;

        public PeriodicDamageEffect()
        {
            _attackType = AttackType.ATTACK_TYPE_INVALID;
            _damage = 0;
            _abilityInfo = null;
        }

        public override void Execute()
        {
            var skillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(SkillCode);
            int limit = Const.MAX_TARGET_COUNT;

            if(skillInfo!= null && skillInfo.MaxTargetNum!=0)
                limit = skillInfo.MaxTargetNum;

            var sdApply = SDApply.SD_APPLY_EMPTY;

            if (StateInfoDB.Instance.TryGetStateInfo(GetStateType(), out var stateInfo))
            {
                sdApply = stateInfo!.SDApply;
            }

            SkillFunctions.ApplySplashDamage(Field,GetOwner(),SkillCode,_attackType,_damage,limit,(int) SectorID,Position,Radius,sdApply);


            base.Execute();
        }

        public override void SetDamage(AttackType attackType, int damage)
        {
            _attackType = attackType;
            _damage = damage;
        }
        public void SetAbilityInfo(BaseAbilityInfo info){ _abilityInfo = info;}

        public bool UseSkill(ushort skillCode)
        {
            var baseSkillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(SkillCode);
            if (baseSkillInfo == null) return false;
            var owner = GetOwner();
            if(owner== null) return false;
            if (!owner.HasEnoughMP((int) baseSkillInfo.MPCost)) return false;

            SunVector? pos = new SunVector(0,0,0);
            if (baseSkillInfo.TargetType == SkillTargetType.SKILL_TARGET_AREA)
                pos = Position;
            else if (baseSkillInfo.TargetType == SkillTargetType.SKILL_TARGET_ME)
                pos = owner.GetPos();

            var skillInfo = new SkillInfo();
            skillInfo.Owner = owner;
            skillInfo.SkillCode = SkillCode;
            //skillInfo.ClientSerial = 0;
            skillInfo.MainTargetKey = owner.GetKey();
            skillInfo.MainTargetPosition = pos;
            skillInfo.DestinationPosition = pos;
            skillInfo.CurrentPosition = pos;

            return owner.GetActiveSkillManager().RegisterSkill(SkillType.SKILL_TYPE_ACTIVE, ref skillInfo);
        }

        public bool ExecuteAura()
        {
            var statusManager = GetOwner()?.GetStatusManager();
            if(statusManager == null) return false;

            if (!statusManager.FindStatus(_abilityInfo.CharStateType))
                return false;
            var skillCode =(ushort) _abilityInfo.option2;
            if (!UseSkill(skillCode))
            {
                statusManager.Remove(_abilityInfo.CharStateType);
                return false;
            }

            return true;
        }
    }
}
