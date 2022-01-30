namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class DeadState: NpcState
    {
    //    private long _deadTick;
    //    private bool _removedProcessed;
    //    public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
    //    {
    //        base.OnEnter(param1, param2, param3);
    //        _deadTick = DateTime.Now.Ticks;
    //        _removedProcessed = false;

    //    }

    //    public override void OnUpdate(long tick)
    //    {
    //        //base.OnUpdate(tick);
    //        if (_removedProcessed) return;
            
    //        Owner.CurrentMap.HandleWaste(Owner);
    //        _removedProcessed = true;
    //    }

    //    protected override void OnMsgLeaveField(AI_MSG msg)
    //    {
    //        if (!(msg is AI_MSG_LeaveField leaveMsg)) return;
    //        Owner.RemoveEnemy(leaveMsg.ObjectKey);
    //    }

    //    public override void OnAIMsg(AI_MSG msg)
    //    {
    //        switch (msg.MsgId)
    //        {
    //            case AI_MSG_ID.AI_MSG_ID_LEAVE_FIELD:
    //                OnMsgLeaveField(msg);
    //                break;
    //        }
    //    }
    }
    
}
