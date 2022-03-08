using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes
{
    internal class PassiveSkill : Skill
    {
        public override bool StartExecute()
        {
            if (PassiveApplied) return false;

            if (!ApplyAbility()) return false;

            PassiveApplied = true;
            return true;

        }

        public override void EndExecute()
        {
            if (!PassiveApplied) return;

            if(ReleaseAbility())
                PassiveApplied = false;

        }


        private bool ApplyAbility()
        {
            if (Owner == null) return false;
            if (!Owner.IsObjectType(ObjectType.PLAYER_OBJECT) || Owner is not Player player) return false;
            if (!player.CanApplyPassiveSkill(GetBaseSkillInfo()!)) return false;

            foreach (var ability in Abilities)
            {
                ability.Execute(Owner, out var result);
            }

            return true;

        }

        private bool ReleaseAbility()
        {
            if (Owner == null) return false;
            if (!Owner.IsObjectType(ObjectType.PLAYER_OBJECT)) return false;

            foreach (var ability in Abilities)
            {
                ability.Release();
            }

            return true;
        }


        protected override void SetExecutionInterval()
        {
            Interval = 0;
        }

        public override SkillType GetSkillType()
        {
            return SkillType.SKILL_TYPE_PASSIVE;
        }
    }
}
