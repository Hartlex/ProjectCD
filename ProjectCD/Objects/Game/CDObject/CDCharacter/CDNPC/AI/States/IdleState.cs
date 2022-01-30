using CDShared.Generics;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class IdleState : NpcState
    {
    //    private SunTimer _idleTimer;
    //    private SunTimer _searchTimer;

    //    public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
    //    {
    //        base.OnEnter(param1, param2, param3);

    //        var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);
    //        if (param1 != 0)
    //            _idleTimer = new SunTimer((uint) param1);
    //        else
    //            _idleTimer = new SunTimer((uint) GlobalRand.Instance.Random(aiParam.IdleMinTime, aiParam.IdleMaxTime));

            
    //        _searchTimer = new SunTimer(aiParam.SearchPeriod); ;
            
    //        Owner.SetMainTarget(null);
    //    }

    //    public override void OnUpdate(long tick)
    //    {
    //        if (_idleTimer.IsElapsed())
    //        {
    //            Owner.ChangeState((uint) STATE_ID_WANDER);
    //            return;
    //        }
    //        if (_searchTimer.IsElapsed())
    //        {
    //            var target = Owner.SearchTarget();
    //            if (target == null) return;

    //            if (Owner.IsMemberOfGroup())
    //            {
    //                AI_MSG_EnemyFound msg = new AI_MSG_EnemyFound(DateTime.Now.Ticks,target.GetObjectKey());
    //                Owner.SendAiMessageToGroupExceptMe(msg);
    //            }
    //            Owner.SetMainTarget(target);
    //            Owner.ChangeState((uint) STATE_ID_TRACK);
    //        }
    //    }

    //    protected override void OnMsgAttacked(AI_MSG msg)
    //    {
    //        base.OnMsgAttacked(msg);
    //        if (!(msg is AI_MSG_Attacked attackedMsg)) return;

    //        var attacker = Owner.CurrentMap?.FindCharacter(attackedMsg.AttackerKey);
    //        if (attacker == null) return;

    //        if (!Owner.IsFriend(attacker))
    //        {
    //            Owner.SetMainTarget(attacker);
    //            Owner.ChangeState((uint) STATE_ID_TRACK);
    //        }
    //    }

    //    protected override void OnMsgLeaveField(AI_MSG msg)
    //    {
    //        if (!(msg is AI_MSG_LeaveField leaveFieldMsg)) return;
    //        Owner.RemoveEnemy(leaveFieldMsg.ObjectKey);

    //    }

    //    protected override void OnMsgLetsGo(AI_MSG msg)
    //    {
    //        base.OnMsgLetsGo(msg);
            
    //        Owner.ChangeState((uint) STATE_ID_WANDER);
    //    }

    }
}
