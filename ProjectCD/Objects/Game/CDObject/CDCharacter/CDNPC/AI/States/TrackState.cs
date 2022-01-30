using CDShared.Generics;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class TrackState : NpcState
    {
        //private SunTimer _trackTimer;
        //private SunTimer _returnCheckTimer;

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);

        //    _returnCheckTimer = new SunTimer(2000);
        //    if (Owner.GetSelectedSkill() == 0)
        //    {
        //        Owner.SelectSkill();
        //    }
        //}

        //public override void OnUpdate(long tick)
        //{
        //    var target = Owner.GetMainTarget();
        //    if (target == null) return;
        //    var targetPos = target.GetPos();
        //    var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);

        //    if (_returnCheckTimer.IsElapsed() && !Owner.IsFollowerOfGroup())
        //    {
        //        if (Owner.IsOutOfRegenLocationLimit(targetPos))
        //        {
        //            if (Owner.IsLeaderOfGroup())
        //            {
        //                AI_MSG_ChangeState msg = new AI_MSG_ChangeState(DateTime.Now.Ticks, (byte) STATE_ID_RETURN,
        //                    (byte) CMS_RUN);
        //                Owner.SendAiMessageToGroupExceptMe(msg);
        //            }
                    
        //            Owner.ChangeState((uint) STATE_ID_RETURN,(ulong) CMS_RUN);
        //            Owner.SetMainTarget(null);
        //            return;
        //        }
        //    }

        //    if (!target.CanBeAttacked())
        //    {
        //        target.FreeEnemySlot(Owner.GetTrackSlot());
        //        Owner.SetTrackSlot(-1);
        //        Owner.ChangeState((uint) STATE_ID_IDLE);
        //    }

        //    if (Owner.GetDistToTarget() <= Owner.GetAttackRange())
        //    {
        //        Owner.ChangeState((uint) STATE_ID_ATTACK);
        //        return;
        //    }

            
        //    DoTrack();
        //}

        //private void DoTrack()
        //{
        //    var target = Owner.GetMainTarget();

        //    var targetPos = target.GetPos();
        //    var curPos = target.GetPos();

        //    Owner.ThrustMoveAndBroadCast(targetPos, CMS_RUN);
        //    _trackTimer = new SunTimer(AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType).TrackPeriod);
        //}

        //protected override void OnMsgHelpRequest(AI_MSG msg)
        //{
        //}

        //protected override void OnMsgEnemyFound(AI_MSG msg)
        //{
        //}
    }
}
