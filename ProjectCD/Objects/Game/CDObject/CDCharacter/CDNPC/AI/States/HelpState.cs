using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class HelpState : NpcState
    {
    //    private SunTimer _helpTimer;

    //    public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
    //    {
    //        base.OnEnter(param1, param2, param3);

    //        var map = Owner.CurrentMap;
    //        if (map != null)
    //        {
    //            Logger.Instance.Log("Implement NPC Status Change!!!");
    //        }

    //        var searchPeriod = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType).SearchPeriod;

    //        _helpTimer = new SunTimer(searchPeriod);

    //        if (Owner.GetSelectedSkill() == (int) NpcSkillEnum.SKILLCODE_INVALID)
    //        {
    //            Owner.SelectSkill();
    //        }

    //        DoTrack();
    //    }

    //    public override void OnUpdate(long tick)
    //    {
    //        //base.OnUpdate(tick);
    //        if (Owner.GetMainTarget() == null) return;

    //        var dist = Owner.GetDistToTarget();
    //        var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);
    //        if (!Owner.IsMemberOfGroup() && dist > Owner.GetSightRange())
    //        {
    //            Owner.GetMainTarget().FreeEnemySlot(Owner.GetTrackSlot());
    //            Owner.SetTrackSlot(-1);
                
    //            Owner.ChangeState((uint) STATE_ID_IDLE);
    //            return;
    //        }

    //        if (dist <= Owner.GetAttackRange())
    //        {
    //            Owner.ChangeState((uint) STATE_ID_ATTACK);
    //            return;
    //        }

    //        if (Owner.IsMoving())
    //        {
    //            if(_helpTimer.IsElapsed())
    //                DoTrack();
    //        }
    //        else
    //        {
    //            DoTrack();
    //        }
    //    }
        


    //    private void DoTrack()
    //    {
    //        if (Owner.GetMainTarget() == null) return;
    //        if (Owner.CurrentMap == null) return;

    //        if (Owner.GetDistToTarget() <= Owner.GetAttackRange())
    //        {
    //            Owner.ChangeState((uint) STATE_ID_ATTACK);
    //            return;
    //        }

    //        var destPos = Owner.GetMainTarget().GetPos();

    //        if (!Owner.MoveAndBroadcast(destPos, eCHAR_MOVE_STATE.CMS_RUN))
    //        {
    //            Owner.ChangeState((uint) STATE_ID_IDLE);
    //        }

    //    }

    //    protected override void OnMsgHelpRequest(AI_MSG msg) { }
    //    protected override void OnMsgLetsGo(AI_MSG msg) { }
    //    protected override void OnMsgEnemyFound(AI_MSG msg) { }
    }
}
