using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class EnchantPoisonStatus : AbilityStatus
    {
        public void ExecuteSkill(Character target)
        {
            var owner = GetOwner();
            if (owner == null) return;

            var statusManager = target.GetStatusManager();

            if (!statusManager.FindStatus(CharStateType.CHAR_STATE_POISON2)) return;

            var baseSkillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(SkillCode);
            if (baseSkillInfo == null) return;

            var effectAbilityID = BaseAbilityInfo.option1;
            if (!baseSkillInfo.TryGetAbilityInfo((AbilityID) effectAbilityID, out var effectAbilityInfo)) return;

            var ability =
                AbilityFactory.Instance.AllocAbility(effectAbilityInfo!.AbilityId, SkillType.SKILL_TYPE_ACTIVE);
            if(ability == null) return;

            var skillInfo = new SkillInfo();
            ability.InitDetailed(owner,SkillCode,ref skillInfo,0,effectAbilityInfo);

            SunVector targetPos = target.GetPos();

            if (!ability.CanExecute(owner, target, target.GetKey(), targetPos))
                return;

            AbilityStatus abilityStatus = statusManager.AllocAbilityStatus(owner, ability);
            if(abilityStatus== null) return;

            abilityStatus.SendStatusAddBRD();

            ability = null;
        }
    }
}
