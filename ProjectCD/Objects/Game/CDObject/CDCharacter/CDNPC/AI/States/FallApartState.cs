namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class FallApartState : NpcState
    {
        //private bool _findDestPos;

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    _findDestPos = false;
        //    base.OnEnter(param1, param2, param3);
        //}

        //public override void OnUpdate(long tick)
        //{
        //    //base.OnUpdate(tick);

        //    if (_findDestPos)
        //    {
        //        if (!Owner.IsMoving())
        //        {
        //            if (Owner.GetMainTarget() != null)
        //                Owner.ChangeState((uint) STATE_ID_ATTACK);
        //            else
        //                Owner.ChangeState((uint) STATE_ID_IDLE);
        //        }
        //    }
        //    FallApart();
        //}

        //private void FallApart()
        //{
        //    var target = Owner.GetMainTarget();
        //    if (target == null)
        //    {
        //        Logger.Instance.Log("[FallApart] m_pTargetChar is NULL!");
        //        Owner.ChangeState((uint) STATE_ID_IDLE);
        //        return;
        //    }

        //    var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);

        //    var targetPos = target.GetPos();
        //    var destPos = SunVector.GetRandomPosAround(targetPos, Owner.GetAttackRange());

        //    if (Owner.MoveAndBroadcast(destPos, eCHAR_MOVE_STATE.CMS_RUN))
        //        _findDestPos = true;
        //}

        //protected override void OnMsgLetsGo(AI_MSG msg)
        //{
        //}

        //protected override void OnMsgEnemyFound(AI_MSG msg)
        //{
        //}
    }
}
