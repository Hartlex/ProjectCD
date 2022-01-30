using CDShared.Generics;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class FlyingState : NpcState
    {
        //private SunTimer _flyTimer;
        //private bool _knockDown;

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);

        //    _flyTimer = new SunTimer((uint) param1);
        //    Owner.GetStatusManager().AllocStatus(eCHAR_STATE_TYPE.eCHAR_STATE_ETC_FLYING);

        //    _knockDown = false;
        //}

        //public override void OnExit()
        //{
        //    base.OnExit();

        //    _knockDown = false;
        //    Owner.GetStatusManager().Remove(eCHAR_STATE_TYPE.eCHAR_STATE_ETC_FLYING);
        //}

        //public override void OnUpdate(long tick)
        //{
        //    //base.OnUpdate(tick);

        //    if (_flyTimer.IsElapsed())
        //    {
        //        if (_knockDown)
        //        {
        //            Owner.ChangeState((uint) STATE_ID_KNOCKDOWN);
        //        }
        //        else
        //        {
        //            if (Owner.GetMainTarget() != null)
        //            {
        //                Owner.ChangeState((uint) STATE_ID_TRACK);
        //            }
        //            else
        //            {
        //                Owner.ChangeState((uint) STATE_ID_IDLE);
        //            }
        //        }
        //    }
        //}

        //protected override void OnMsgThrust(AI_MSG msg) { }

        //protected override void OnMsgFlying(AI_MSG msg) { }

        //protected override void OnMsgKnockDown(AI_MSG msg) { _knockDown = true; }

        //protected override void OnMsgStun(AI_MSG msg) { _knockDown = true; }

        //protected override void OnMsgLetsGo(AI_MSG msg) { }

        //protected override void OnMsgEnemyFound(AI_MSG msg) { }

        //protected override void OnMsgCommandFollow(AI_MSG msg) { Owner.SetMainTarget(null);
        //}
    }
}
