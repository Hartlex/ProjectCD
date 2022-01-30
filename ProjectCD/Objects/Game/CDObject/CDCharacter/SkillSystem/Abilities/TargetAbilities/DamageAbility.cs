using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Formulas;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General.Object.Character.Player;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class DamageAbility : Ability
    {
        private byte _skillStatType;
        private SkillInfo _skillInfo;
        public override void InitDetailed(Character attacker, ushort skillCode, ref SkillInfo skillInfo, byte skillStatType,
            BaseAbilityInfo baseInfo)
        {
            base.InitDetailed(attacker, skillCode, ref skillInfo, skillStatType, baseInfo);
            _skillStatType = skillStatType;
            _skillInfo = skillInfo;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;

            var attacker = GetAttacker();
            if (attacker == null) return false;

            var abilityInfo = GetBaseAbilityInfo();
             var attackType = (AttackType) abilityInfo.option1;

            var dmgArgs = new DamageArgs();
            dmgArgs.attacker = attacker;
            dmgArgs.attackType = attackType;

            var skillAttackPower = abilityInfo.Params[0];
            float skillAddRatio = abilityInfo.Params[1] / 1000f;

            skillAttackPower = CalcAddDamage(skillAttackPower, attacker);

            dmgArgs.Damage = CharacterFormulas.CalcSkillDamage(attacker, target, attackType, skillAttackPower,
                skillAddRatio, 0, ref _skillInfo.SkillEffect, _skillStatType, true);

            dmgArgs.IsCrit = (_skillInfo.SkillEffect & Const.SKILL_EFFECT_CRITICAL) != 0;
            dmgArgs.AttackResistKind = AttackResist.ATTACK_RESIST_SKILL;
            dmgArgs.SDApply = SDApply.SD_APPLY_DO;

            target.Damaged(dmgArgs);

            var etherInfo = GetSkill().EtherBulletInfo;
            if (etherInfo != null)
            {
                _skillInfo.SkillEffect |= etherInfo.EffectCode;
            }

            var dmgResult = new SkillResultDmg(result!)
            {
                Damage = (ushort) dmgArgs.Damage,
                TargetHp = (uint) target.GetHP()
            };
            dmgResult.Effect |= _skillInfo.SkillEffect;
            result = dmgResult;
            return true;

        }

        public int CalcAddDamage(int skillAttackPower, Character attacker)
        {
            var baseSkill = GetSkill();
            if (baseSkill != null)
            {
                return 0;
            }
            int calcPower = baseSkill!.AddedAttackPowerPerStatus;
            calcPower += skillAttackPower;

            int increaseSkillDmg = CharacterFormulas.CalcIncreaseSkillDamage(attacker, baseSkill, skillAttackPower);

            if (increaseSkillDmg != 0) calcPower += increaseSkillDmg;

            var classCode = baseSkill.GetSkillClassCode();
            int curseAddDmg = CharacterFormulas.CalcIncreaseCurse((SkillEnum) classCode, skillAttackPower, attacker);

            calcPower += curseAddDmg;

            return calcPower;
        }
    }
}
