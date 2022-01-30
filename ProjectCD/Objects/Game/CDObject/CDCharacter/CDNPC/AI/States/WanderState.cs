using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.MOB;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class WanderState: NpcState
    {
        //private SunTimer _searchTimer;
        //private bool _destSelected;
        //private bool _touchedSomething;
        //private SunVector _rotatedVector;
        //private Monster _monster;
        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);

        //    _destSelected = false;
        //    _touchedSomething = false;
        //    _searchTimer = new SunTimer(AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType).SearchPeriod);
        //}

        //public override void SetNpc(NPC npc)
        //{
        //    if (npc is Monster monster)
        //        _monster = monster;
        //    base.SetNpc(npc);
        //}

        //public override void OnUpdate(long tick)
        //{
        //    if (_searchTimer.IsElapsed())
        //    {
        //        var target = _monster.SearchTarget();
        //        if (target != null)
        //        {
        //            if (_monster.IsMemberOfGroup())
        //            {
        //                AI_MSG_EnemyFound msg = new AI_MSG_EnemyFound(DateTime.Now.Ticks, target.GetObjectKey());
        //                _monster.SendAiMessageToGroupExceptMe(msg);
        //            }
        //        }

        //        if (!_destSelected)
        //        {
        //            _destSelected = _monster.IsFollowerOfGroup() && _monster.IsLeaderAlive()
        //                ? DoWanderAsFollower()
        //                : DoWander();
        //        }

        //        if (_destSelected && !_monster.IsMoving())
        //        {
        //            _destSelected = false;
        //            if(!_touchedSomething)
        //                _monster.ChangeState((uint) STATE_ID_IDLE);
        //        }
        //    }
        //}

        //private bool DoWander()
        //{
        //    var aiParam = AiParameterDb.Instance.GetAiParamInfo(_monster.GetBaseInfo().AIType);

        //    float moveDist = aiParam.WanderRadius;

        //    var spawnPos = _monster.GetSpawnPos();
            
        //    if (_monster.CurrentMap == null) return false;

        //    var destPos = SunVector.GetRandomPosAround(spawnPos, moveDist);

        //    _monster.ThrustMoveAndBroadCast(destPos, eCHAR_MOVE_STATE.CMS_WALK);

        //    if (_monster.IsLeaderOfGroup())
        //    {
        //        AI_MSG_LetsGo msg = new AI_MSG_LetsGo(DateTime.Now.Ticks, destPos, (byte) eCHAR_MOVE_STATE.CMS_WALK);
        //        _monster.SendAiMessageToGroupExceptMe(msg);
        //    }

        //    return true;
        //}

        //private bool DoWanderAsFollower()
        //{
        //    return false;
        //}

        //protected override void OnMsgAttacked(AI_MSG msg)
        //{
        //    base.OnMsgAttacked(msg);

        //    if (!(msg is AI_MSG_Attacked attackedMsg)) return;

        //    var attacker =_monster.CurrentMap?.FindCharacter(attackedMsg.AttackerKey);
        //    if (attacker == null) return;
        //    if (!_monster.IsFriend(attacker))
        //    {
        //        _monster.SetMainTarget(attacker);
        //        _monster.ChangeState((uint) STATE_ID_TRACK);
        //    }
        //}

        //protected override void OnMsgLetsGo(AI_MSG msg)
        //{
        //    base.OnMsgLetsGo(msg);
        //    _destSelected = true;
        //}
    }
}
