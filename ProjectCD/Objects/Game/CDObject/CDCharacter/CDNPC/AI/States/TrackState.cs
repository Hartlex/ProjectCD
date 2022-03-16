using CDShared.Generics;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.AI;
using static SunStructs.Definitions.AIStateID;
using static SunStructs.Definitions.CharMoveState;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class TrackState : NpcState
    {
        private SunTimeout _trackTimer;
        private SunTimeout _returnCheckTimer;

        public override void OnEnter(int param1 = 0, int param2 = 0, int param3 = 0)
        {
            base.OnEnter(param1, param2, param3);

            _returnCheckTimer = new SunTimeout(2000);
            //if (Owner.GetSelectedSkill() == 0)
            //{
            //    Owner.SelectSkill();
            //}
        }

        public override void OnUpdate(long tick)
        {
            var target = Owner.GetCurrentTarget();
            if (target == null) return;
            var targetPos = target.GetPos();
            var aiParam = AiParameterDb.Instance.GetAiTypeInfo(Owner.GetBaseInfo().AIType);

            if (_returnCheckTimer.IsExpired() && !Owner.IsFollowerOfGroup())
            {
                if (Owner.IsOutOfRegenLocationLimit(targetPos))
                {
                    if (Owner.IsLeaderOfGroup())
                    {
                        AIMsgChangeState msg = new (DateTime.Now.Ticks, (byte) STATE_ID_RETURN, (byte)CMS_RUN);
                        Owner.SendAiMsgToGroupExceptMe(msg);
                    }

                    Owner.ChangeState(STATE_ID_RETURN, (int)CMS_RUN);
                    Owner.SetTargetChar(null);
                    return;
                }
            }

            if (!target.CanBeAttacked())
            {
                //target.FreeEnemySlot(Owner.GetTrackSlot());
                //Owner.SetTrackSlot(-1);
                Owner.ChangeState(STATE_ID_IDLE);
            }

            if (Owner.GetDistToTarget() <= Owner.GetAttackRange())
            {
                Owner.ChangeState(STATE_ID_ATTACK);
                return;
            }


            DoTrack();
        }

        private void DoTrack()
        {
            var target = Owner.GetCurrentTarget();
            if (target == null) return;
            var targetPos = target.GetPos();
            var curPos = target.GetPos();

            Owner.ThrustMoveAndBroadcast(targetPos, (byte) CMS_RUN);
            _trackTimer = new SunTimeout(AiParameterDb.Instance.GetAiTypeInfo(Owner.GetBaseInfo().AIType).TrackPeriod);
        }

        protected override void OnMsgHelpRequest(AIMsg msg)
        {
        }

        protected override void OnMsgEnemyFound(AIMsg msg)
        {
        }
    }
}
