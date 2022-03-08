using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Formulas;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Skill;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class WoundStatus : AbilityStatus
    {
        private AttackType _attackType;
        private int _damage;

        public override void Start() { }

        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);
            Logger.Instance.Log("WoundStatus initialized!");
            var baseAbilityInfo = ability.GetBaseAbilityInfo();
            _attackType = (AttackType) baseAbilityInfo.option1;
            _damage = baseAbilityInfo.Params[1];

            int skillAttackPower;

            var skillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(SkillCode);
            if (skillInfo == null) return;
            byte effect = 0;
            int calcDmg = CharacterFormulas.CalcSkillDamage(
                attacker,
                owner,
                _attackType,
                0, 0, 0,
                ref effect,
                skillInfo.SkillStatType,
                false
            );

            int addDmg = CalcAddDamage(ability, attacker);

            _damage = calcDmg + addDmg;
        }

        public override void Execute()
        {
            if (Attacker == null) return;
            var owner = GetOwner();
            if (owner == null) return;

            StateInfoDB.Instance.TryGetStateInfo(GetStateType(), out var stateInfo);

            var dmgArgs = new DamageArgs
            {
                attacker = Attacker,
                attackType = _attackType,
                AttackResistKind = AttackResist.ATTACK_RESIST_SKILL,
                SDApply = stateInfo?.SDApply ?? SDApply.SD_APPLY_NOT,
                Damage = _damage
            };

            owner.Damaged(dmgArgs);

            var dmgInfo = new DamageInfo(owner.GetKey(), (ushort) dmgArgs.Damage, (uint) owner.GetHP());
            var periodicDmgInfo = new PeriodicDmgInfo(Attacker.GetKey(), SkillCode, new[] {dmgInfo});
            var packet = new PeriodicDamageBRD(periodicDmgInfo);
            owner.SendPacketAround(packet);

            base.Execute();
        }

        private int CalcAddDamage(Ability ability, Character attacker)
        {
            int addDmg = 0;
            int skillDmg = BaseAbilityInfo.Params[1];
            var skill = ability.GetSkill();

            if (skill != null)
            {
                int increaseSkillDmg = CharacterFormulas.CalcIncreaseSkillDamage(attacker, skill, skillDmg);

                addDmg += increaseSkillDmg;
            }

            SkillEnum attackSkillClass = SkillEnum.SKILL_INVALID;

            switch (GetStateType())
            {
                case CharStateType.CHAR_STATE_PAIN:
                    attackSkillClass = SkillEnum.SKILL_PAIN;
                    break;
                case CharStateType.CHAR_STATE_FIRE_WOUND2:
                    attackSkillClass = SkillEnum.SKILL_DARK_FIRE;
                    break;
                case CharStateType.CHAR_STATE_POISON2:
                    attackSkillClass = SkillEnum.SKILL_ENCHANT_POISON;
                    break;
            }

            if (attackSkillClass != SkillEnum.SKILL_INVALID)
            {
                int curseDmg = CharacterFormulas.CalcIncreaseCurse(attackSkillClass, skillDmg, attacker);
                addDmg += curseDmg;
            }

            return addDmg;

        }
    }
}
