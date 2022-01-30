using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class SuctionAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_HP_SUCTION:
                case CharStateType.CHAR_STATE_MP_SUCTION:
                    return true;
            }

            return false;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;

            var attacker = GetAttacker();
            var abilityStatus = attacker!.GetStatusManager().AllocAbilityStatus(attacker, this);
            if (abilityStatus is SuctionStatus suctionStatus)
            {
                suctionStatus.SetTargetObjectKey(target!.GetKey());
                result!.AbilityCode = (ushort) suctionStatus.AttrType;
                result.AbilityDuration = (uint) suctionStatus.GetApplicationTime();

                return true;
            }
            else return false;




        }
    }
}
