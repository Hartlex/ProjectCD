using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.MOB;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class ReturnState : NpcState
    {
        //private bool _regenLocSelected;
        //private Monster _monster;

        //public override void SetNpc(NPC npc)
        //{
        //    if (npc is Monster monster)
        //    {
        //        _monster = monster;
        //    }
        //    base.SetNpc(npc);
        //}

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);

        //    if (Owner.ThrustMoveAndBroadCast(_monster.GetSpawnPos(), CMS_RUN))
        //    {
        //        _regenLocSelected = true;
        //    }
        //    else
        //    {
        //        _regenLocSelected = false;
        //    }

        //    _monster.GetStatusManager().AllocStatus(eCHAR_STATE_TYPE.eCHAR_STATE_ETC_RETURNING);
        //}

        //public override void OnExit()
        //{
        //    base.OnExit();

        //    _monster.GetStatusManager().Remove(eCHAR_STATE_TYPE.eCHAR_STATE_ETC_RETURNING);
        //}

        //public override void OnUpdate(long tick)
        //{
        //    if (_regenLocSelected)
        //    {
        //        if(SunVector.GetDistance(_monster.GetPos(),_monster.GetSpawnPos())<=1)
        //            _monster.ChangeState((uint) ENUM_STATE_ID.STATE_ID_IDLE);
        //    }
        //    //if (!_monster.IsMoving())
        //    //{
        //    //    if (_regenLocSelected)
        //    //    {
        //    //        _monster.ChangeState((uint) ENUM_STATE_ID.STATE_ID_IDLE);
        //    //    }
        //    //    else
        //    //    {
        //    //        DoReturn();
        //    //    }
        //    //}

            
        //}

        //private void DoReturn()
        //{   
        //}
    }
}
