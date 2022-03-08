using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.NonTargetAbilities
{
    internal class PeriodicEffectAbility : Ability
    {
        private SunVector _mainTargetPos;

        public override void InitDetailed(Character attacker, ushort skillCode, ref SkillInfo skillInfo, byte skillStatType,
            BaseAbilityInfo baseInfo)
        {
            base.InitDetailed(attacker, skillCode, ref skillInfo, skillStatType, baseInfo);

            _mainTargetPos = skillInfo.MainTargetPosition;
        }

        public override AbilityType GetAbilityType()
        {
            return AbilityType.ABILITY_TYPE_EFFECT;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            return base.Execute(target, out result);
        }

        public override bool ExecuteEffect(out SkillResultEffect? result)
        {
            result = null;
            var attacker = GetAttacker();
            if (attacker == null) return false;
            var field = attacker.GetCurrentField();
            if (field == null) return false;


            var abilityInfo = GetBaseAbilityInfo();
            var attackType = (AttackType) abilityInfo.option1;
            var radius = abilityInfo.Params[0] / 10f;
            var damage = abilityInfo.Params[1];
            var applicationTime = abilityInfo.Params[2];
            var period = abilityInfo.Params[3];

            var effect = field.GetEffectManager().AllocEffect(FieldeffectType.EFFECT_TYPE_PERIODIC_DAMAGE);
            //BaseEffect effect = null;
            if (effect == null) return false;

            effect.Init(GetSkillCode(),applicationTime,period,attacker,_mainTargetPos,radius);
            effect.SetDamage(attackType,damage);

            if(effect is PeriodicDamageEffect perEffect) perEffect.SetAbilityInfo(abilityInfo);

            effect.Start();

            var effectResult = new SkillResultEffect();
            effectResult.AbilityOrder = GetIndex();
            effectResult.Count = 1;
            effectResult.EffectInfos[0] = new EffectInfo()
            {
                Time = 0,
                Position = _mainTargetPos
            };

            result = effectResult;

            return true;
        }
    }
}
