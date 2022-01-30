using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class KnockdownState : NpcState
    {
        //private SunTimer _knockdownTimer;

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);
        //    Logger.Instance.Log("Stun Timer:" + param1);
        //    var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);
        //    _knockdownTimer = param1 != 0 ? new SunTimer((uint) param1) : new SunTimer(1000);
            
            
        //}

        //public override void OnUpdate(long tick)
        //{
        //    //base.OnUpdate(tick);

        //    if (!_knockdownTimer.IsElapsed()) return;
        //    if (Owner.GetMainTarget() != null)
        //    {
        //        Owner.ChangeState((uint) ENUM_STATE_ID.STATE_ID_TRACK);
        //    }
        //    else
        //    {
        //        Owner.ChangeState((uint) ENUM_STATE_ID.STATE_ID_WANDER);
        //    }
        //}
        //protected override void OnMsgLetsGo(AI_MSG msg) { }

        //protected override void OnMsgEnemyFound(AI_MSG msg) { }

        //protected override void OnMsgCommandFollow(AI_MSG msg) { Owner.SetMainTarget(null);
        //}
    }
}
