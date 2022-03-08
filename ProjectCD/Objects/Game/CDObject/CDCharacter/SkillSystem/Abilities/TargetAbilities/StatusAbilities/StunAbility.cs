using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class StunAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_DOWN:
                case CharStateType.CHAR_STATE_DELAY:
                case CharStateType.CHAR_STATE_HOLDING:
                case CharStateType.CHAR_STATE_STUN:
                case CharStateType.CHAR_STATE_STONE:
                case CharStateType.CHAR_STATE_FROZEN:
                case CharStateType.CHAR_STATE_SLEEP:
                case CharStateType.CHAR_STATE_STUN2:
                case CharStateType.CHAR_STATE_FATAL_POINT:
                case CharStateType.CHAR_STATE_UPPERDOWN:
                    return true;
            }

            return false;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;

            var stunResult = new SkillResultStun(result!);
            stunResult.CurrentPosition = target!.GetPos();

            target.CancelAllSkill();
            result = stunResult;
            return true;
        }
    }
}
