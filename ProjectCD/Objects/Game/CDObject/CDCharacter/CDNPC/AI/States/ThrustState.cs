using CDShared.Generics;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class ThrustState : NpcState
    {
    //    private SunTimer _thrustTimer;
    //    private bool _downAfterThrust;
    //    private uint _downTimeAfterThrust;

    //    public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
    //    {
    //        base.OnEnter(param1, param2, param3);

    //        _downAfterThrust = param1 != 0;
    //        if (_downAfterThrust)
    //        {
    //            Owner.SetMoveState(eCHAR_MOVE_STATE.CMS_KNOCKBACK_DOWN);
    //        }
    //        else
    //        {
    //            Owner.SetMoveState(eCHAR_MOVE_STATE.CMS_KNOCKBACK);
    //        }

    //        _thrustTimer = new SunTimer(1000);
    //    }

    //    public override void OnExit()
    //    {
    //        base.OnExit();
    //        Owner.StopMoving();
    //    }

    //    public override void OnUpdate(long tick)
    //    {
    //        //base.OnUpdate(tick);

    //        if (_thrustTimer.IsElapsed())
    //        {
    //            if (_downAfterThrust)
    //            {
    //                Owner.ChangeState((uint) STATE_ID_KNOCKDOWN,_downTimeAfterThrust);
    //            }
    //            else
    //            {
    //                if (Owner.GetMainTarget()!=null)
    //                {
    //                    Owner.ChangeState((uint) STATE_ID_TRACK);
    //                }
    //                else
    //                {
    //                    Owner.ChangeState((uint) STATE_ID_IDLE);
    //                }
    //            }
    //        }
    //    }

    //    protected override void OnMsgFlying(AI_MSG msg)
    //    {
    //    }

    //    protected override void OnMsgKnockDown(AI_MSG msg)
    //    {
    //        if (!(msg is AI_MSG_KnockDown knockDownMsg)) return;
    //        _downAfterThrust = true;
    //        _downTimeAfterThrust = knockDownMsg.KnockDownTick;
            
    //    }

    //    protected override void OnMsgStun(AI_MSG msg)
    //    {
    //        _downAfterThrust = true;
    //    }
    //    protected override void OnMsgLetsGo(AI_MSG msg) { }
    //    protected override void OnMsgEnemyFound(AI_MSG msg) { }
    }
}
