using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class AbnormalAbility : BaseStatusAbility
    {
        public override AbilityType GetAbilityType()
        {
            return GetCharStateType() == CharStateType.CHAR_STATE_POISON2 ? AbilityType.ABILITY_TYPE_MANUAL : AbilityType.ABILITY_TYPE_ACTIVE;
        }

        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_CHAOS:
                case CharStateType.CHAR_STATE_BLIND:
                case CharStateType.CHAR_STATE_SEALING:
                case CharStateType.CHAR_STATE_WEAKENING:
                case CharStateType.CHAR_STATE_FRUSTRATION:
                case CharStateType.CHAR_STATE_FETTER:
                case CharStateType.CHAR_STATE_SLOWDOWN:
                case CharStateType.CHAR_STATE_FEAR:
                case CharStateType.CHAR_STATE_SEQUELA:
                case CharStateType.CHAR_STATE_ATTACK_IMPOSSIBLE:
                case CharStateType.CHAR_STATE_PROTECTION:
                case CharStateType.CHAR_STATE_MP_FEAR2:
                case CharStateType.CHAR_STATE_POISON2:
                case CharStateType.CHAR_STATE_STAMP:
                case CharStateType.CHAR_STATE_DETECTING_HIDE:
                case CharStateType.CHAR_STATE_WHITE_BLIND:
                case CharStateType.CHAR_STATE_DARK_OF_LIGHT_ZONE:
                case CharStateType.CHAR_STATE_POLYMORPH:
                case CharStateType.CHAR_STATE_PROTECTION1:
                    return true;
            }

            return false;
        }
    }
}
