using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities
{
    internal class CancelStatusAbility : Ability
    {
        public override bool IsValidState()
        {
            switch (GetCharStateType())
            {
                case CharStateType.CHAR_STATE_CANCELATION:
                case CharStateType.CHAR_STATE_BUFF_CANCEL:
                    return true;
                default:
                    return false;
            }
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            base.Execute(target, out result);

            StateType stateType;
            byte stopCount = 0;

            var baseInfo = GetBaseAbilityInfo();

            if (baseInfo.option1 == 0)
            {
                BaseStatus? status;

                if (baseInfo.option2 != 0)
                {
                    if (target!.GetStatusManager().FindStatus((CharStateType) baseInfo.option2, out status))
                    {
                        if(StateInfoDB.Instance.TryGetStateInfo(status!.GetStateType(),out var info) && info!.GKind!=2)//Cash
                            status.StopStatus();
                    }
                }

                if (baseInfo.Params[0] != 0)
                {
                    if (target!.GetStatusManager().FindStatus((CharStateType)baseInfo.Params[0], out status))
                    {
                        if (StateInfoDB.Instance.TryGetStateInfo(status!.GetStateType(), out var info) && info!.GKind != 2)//Cash
                            status.StopStatus();
                    }
                }
                if (baseInfo.Params[1] != 0)
                {
                    if (target!.GetStatusManager().FindStatus((CharStateType)baseInfo.Params[1], out status))
                    {
                        if (StateInfoDB.Instance.TryGetStateInfo(status!.GetStateType(), out var info) && info!.GKind != 2)//Cash
                            status.StopStatus();
                    }
                }

                return true;
            }
            else if (baseInfo.option1 <= 4)
            {
                stateType = (StateType) baseInfo.option1;
                stopCount = 0;
                target!.GetStatusManager().StopStatusByStateType(stateType, stopCount);
            }
            else if (baseInfo.option1 <= 8)
            {
                stateType = (StateType)baseInfo.option1-4;
                stopCount = 1;
                target!.GetStatusManager().StopStatusByStateType(stateType, stopCount);
            }
            else if (baseInfo.option1 == 9)
            {
                if (target!.GetStatusManager().StopStatusByStateType(StateType.STATE_TYPE_ABNORMAL, 1) > 0)
                    return true;
                if (target!.GetStatusManager().StopStatusByStateType(StateType.STATE_TYPE_WEAKENING, 1) > 0)
                    return true;
            }
            else if (baseInfo.option1 == 10)
            {
                target!.GetStatusManager().StopStatusByStateType(StateType.STATE_TYPE_ABNORMAL);
                target!.GetStatusManager().StopStatusByStateType(StateType.STATE_TYPE_WEAKENING);
            }
            else
            {
                Logger.Instance.Log($"[CancelStatusAbility][Execute] Invalid Option[{baseInfo.option1}]");
                return false;
            }

            return true;
        }
    }
}
