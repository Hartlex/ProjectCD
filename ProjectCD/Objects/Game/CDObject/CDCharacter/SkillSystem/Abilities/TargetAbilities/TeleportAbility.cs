using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class TeleportAbility : Ability
    {
        private bool _executablePos;

        public override void InitDetailed(Character attacker, ushort skillCode, ref SkillInfo skillInfo, byte skillStatType,
            BaseAbilityInfo baseInfo)
        {
            base.InitDetailed(attacker, skillCode, ref skillInfo, skillStatType, baseInfo);

            var skill = GetSkill();

            _executablePos = skill != null;


        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;
            if (_executablePos == false) return false;
            var field = target.GetCurrentField();
            if(field == null) return false;
            var attacker = GetAttacker();
            if(attacker== null) return false;

            var rangeType = GetBaseAbilityInfo().RangeType;
            var isPlayer = target.IsObjectType(ObjectType.PLAYER_OBJECT);
            var isEnemy = attacker.IsFriend(target) == UserRelationType.USER_RELATION_ENEMY;

            if (!ReferenceEquals(target, attacker) && isPlayer && isEnemy)
            {
                var destPos = target.GetPos();
                //Get random pos
                if (!field.TeleportObject(target, ref destPos)) return false;

                var posResult = new SkillResultPosition(result);
                posResult.CurrentPosition = attacker.GetPos();
                posResult.DestinationPosition = target.GetPos();
            }
            else if (rangeType == AbilityRangeType.SKILL_ABILITY_ME && ReferenceEquals(target, attacker))
            {
                var teleportPos = GetSkill().SkillInfo.MainTargetPosition;

                if (!field.TeleportObject(target, ref teleportPos)) return false;

                var posResult = new SkillResultPosition(result);
                posResult.CurrentPosition = attacker.GetPos();
                posResult.DestinationPosition = teleportPos;
            }

            return true;
        }
    }
}
