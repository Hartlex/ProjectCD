using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Skill;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class WindShieldStatus : AbilityStatus
    {
        private AttackType _attackType;
        private float _range;
        private int _periodicDamage;
        private int _skillRatio;

        public override void Start(){}


        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);

            var baseInfo = ability.GetBaseAbilityInfo();

            _attackType = (AttackType) baseInfo.option1;
            _range = baseInfo.Params[0] / 10f;
            _periodicDamage = baseInfo.Params[1];
            _skillRatio = baseInfo.option2;
        }

        public override void Execute()
        {
            var field = GetOwner()?.GetCurrentField();
            if (field == null) return;
            var skillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(SkillCode);
            if (skillInfo == null) return;


            var attacker = GetOwner();
            var destPos = attacker.GetPos();
            var radius = _range;
            var numberOfTargetSelect = skillInfo.MaxTargetNum;

            var targets = field.FindTargets(SkillTargetType.SKILL_TARGET_AREA, SkillAreaType.SRF_FOWARD_360, attacker,
                destPos, radius, numberOfTargetSelect);

            var resultList = new DamageInfo[targets.Length];

            for (int i = 0; i < targets.Length; i++)
            {
                var target = targets[i];
                var dmgArgs = new DamageArgs
                {
                    Damage = _periodicDamage,
                    attacker = attacker,
                    attackType = _attackType,
                    SDApply = SDApply.SD_APPLY_DO,
                    AttackResistKind = AttackResist.ATTACK_RESIST_SKILL
                };


                target.Damaged(dmgArgs);

                resultList[i] = new DamageInfo(target.GetKey(), (ushort)dmgArgs.Damage, (uint)target.GetHP());

                if (target.IsObjectType(ObjectType.NPC_OBJECT))
                {
                    AIMsgAttacked msg = new AIMsgAttacked(attacker.GetKey(), dmgArgs.Damage);
                    target.OnAiMessage(msg);
                }
            }

            var periodicDmgInfo = new PeriodicDmgInfo(attacker.GetKey(), SkillCode, resultList);

            var packet = new PeriodicDamageBRD(periodicDmgInfo);
            field.SendToAll(packet);
            base.Execute();
        }
    }
}
