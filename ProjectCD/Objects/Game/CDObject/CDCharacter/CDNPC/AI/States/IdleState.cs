using CDShared.Generics;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using static SunStructs.Definitions.AIStateID;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class IdleState : NpcState
    {
        private SunTimeout _idleTimer;
        private SunTimeout _searchTimer;

        public override void OnEnter(int param1 = 0, int param2 = 0, int param3 = 0)
        {
            base.OnEnter(param1,param2,param3);

            var delay = param1 != 0 ? param1 : GlobalRandom.Rand(AiTypeInfo.IdleMinTime, AiTypeInfo.IdleMaxTime);
            _idleTimer = new (delay);
            _searchTimer = new(0);
            Owner.SetTargetChar(null);
        }

        public override void OnUpdate(long tick)
        {
            if (_idleTimer.IsExpired())
            {
                Owner.ChangeState(STATE_ID_WANDER);
                return;
            }

            if (_searchTimer.IsExpired() && Owner.CanAttack())
            {
                var target = Owner.SearchTarget();
                if (target == null) return;

                if (Owner.IsGroupMember())
                {
                    var msg = new AIMsgEnemyFound(target.GetKey());
                    Owner.SendAiMsgToGroupExceptMe(msg);
                }

                Owner.SetTargetChar(target);
                Owner.ChangeState(STATE_ID_TRACK);
            }

        }

        //public override void OnEnter(ulong param1 = 0, ulong param2 = 0, ulong param3 = 0)
        //{
        //    base.OnEnter(param1, param2, param3);

        //    var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);
        //    if (param1 != 0)
        //        _idleTimer = new SunTimer((uint)param1);
        //    else
        //        _idleTimer = new SunTimer((uint)GlobalRand.Instance.Random(aiParam.IdleMinTime, aiParam.IdleMaxTime));


        //    _searchTimer = new SunTimer(aiParam.SearchPeriod); ;

        //    Owner.SetTargetChar(null);
        //}

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

        protected override void OnMsgAttacked(AIMsg msg)
        {
            base.OnMsgAttacked(msg);
            if (!(msg is AIMsgAttacked attackedMsg)) return;

            var attacker = Owner.GetCurrentField()?.FindCharacter(attackedMsg.AttackerKey);
            if (attacker == null) return;

            if (Owner.IsFriend(attacker)==UserRelationType.USER_RELATION_ENEMY)
            {
                Owner.SetTargetChar(attacker);
                Owner.ChangeState(STATE_ID_TRACK,0,0,(int) attackedMsg.MsgId);
            }
        }

        //    protected override void OnMsgLeaveField(AI_MSG msg)
        //    {
        //        if (!(msg is AI_MSG_LeaveField leaveFieldMsg)) return;
        //        Owner.RemoveEnemy(leaveFieldMsg.ObjectKey);

        //    }

        protected override void OnMsgLetsGo(AIMsg msg)
        {
            base.OnMsgLetsGo(msg);

            Owner.ChangeState(STATE_ID_WANDER,0,0,(int) msg.MsgId);
        }

    }
}
