using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class TransparentAbility: BaseStatusAbility
    {
        public override bool IsValidState()
        {
            return GetCharStateType() == CharStateType.CHAR_STATE_TRANSPARENT;
        }

        public override bool CanExecute(Character attacker, Character target, uint mainTargetKey, SunVector mainTargetPos)
        {
            if (!ReferenceEquals(attacker, target)) return false;

            if (!IsValidState()) return false;

            var statusManager = attacker.GetStatusManager();
            var statusField = statusManager.GetStatusFlag();
            BaseStatus status = null;

            if (statusField.IsPlayerTransOn())
            {
                if (statusManager.FindStatus(CharStateType.CHAR_STATE_TRANSPARENT, out status))
                {
                    status.CancelRequestStop();
                }
                else
                {
                    statusField.OnCharTransOn(false);
                }

                return false;
            }

            if (statusManager.FindStatus(CharStateType.CHAR_STATE_BATTLE, out status))
                return false;
            return true;
        }
    }
}
