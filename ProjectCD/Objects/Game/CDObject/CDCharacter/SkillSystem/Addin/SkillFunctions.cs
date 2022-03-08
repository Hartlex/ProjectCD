using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Skill;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Addin
{
    internal static class SkillFunctions
    {
        public static void ApplySplashDamage(Field field,Character attacker,ushort skillCode,AttackType attacktype,
            int damage,int numberOfTargetSelect,int sectorID,SunVector destPos,float radius,SDApply sdApply)
        {

            var targets = field.FindTargets(SkillTargetType.SKILL_TARGET_AREA, SkillAreaType.SRF_FOWARD_360, attacker,
                destPos, radius, numberOfTargetSelect);

            var resultList = new DamageInfo[targets.Length];

            for (int i = 0; i < targets.Length; i++)
            {
                var target = targets[i];
                var dmgArgs = new DamageArgs
                {
                    Damage = damage,
                    attacker = attacker,
                    attackType = attacktype,
                    SDApply = sdApply,
                    AttackResistKind = AttackResist.ATTACK_RESIST_SKILL
                };


                target.Damaged(dmgArgs);

                resultList[i] = new DamageInfo(target.GetKey(), (ushort) dmgArgs.Damage, (uint) target.GetHP());

                if (target.IsObjectType(ObjectType.NPC_OBJECT))
                {
                    AIMsgAttacked msg = new AIMsgAttacked(attacker.GetKey(), dmgArgs.Damage);
                    target.OnAiMessage(msg);
                }
            }

            var periodicDmgInfo = new PeriodicDmgInfo(attacker.GetKey(), skillCode, resultList);

            var packet = new PeriodicDamageBRD(periodicDmgInfo);
            field.SendToAll(packet);
        }
    }
}
