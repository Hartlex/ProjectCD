using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.MOB;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using static SunStructs.Definitions.AIStateID;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States
{
    internal class WanderState: NpcState
    {
        private SunTimeout _searchTimer;
        private bool _destSelected;
        private bool _touchedSomething;
        private SunVector _rotatedVector;
        private Monster _monster;
        public override void OnEnter(int param1 = 0, int param2 = 0, int param3 = 0)
        {
            base.OnEnter(param1, param2, param3);

            _destSelected = false;
            _touchedSomething = false;
            _searchTimer = new SunTimeout(AiParameterDb.Instance.GetAiTypeInfo(Owner.GetBaseInfo().AIType).SearchPeriod);
        }

        public override void SetNpc(NPC npc)
        {
            if (npc is Monster monster)
                _monster = monster;
            base.SetNpc(npc);
        }

        public override void OnUpdate(long tick)
        {
            if (_searchTimer.IsExpired())
            {
                var target = _monster.SearchTarget();
                if (target != null)
                {
                    if (_monster.IsGroupMember())
                    {
                        AIMsgEnemyFound msg = new (target.GetKey());
                        _monster.SendAiMsgToGroupExceptMe(msg);
                    }
                }

                if (!_destSelected)
                {
                    _destSelected = _monster.IsFollowerOfGroup() && _monster.IsLeaderAlive()
                        ? DoWanderAsFollower()
                        : DoWander();
                }

                if (_destSelected && !_monster.IsMoving())
                {
                    _destSelected = false;
                    if (!_touchedSomething)
                        _monster.ChangeState(STATE_ID_IDLE);
                }
            }
        }

        private bool DoWander()
        {
            var aiParam = AiParameterDb.Instance.GetAiTypeInfo(_monster.GetBaseInfo().AIType);

            float moveDist = aiParam.WanderRadius;

            var spawnPos = _monster.GetSpawnPos();

            if (_monster.GetCurrentField() == null) return false;

            var destPos = SunVector.GetRandomPosAround(spawnPos, moveDist);

            _monster.ThrustMoveAndBroadcast(destPos, (byte) CharMoveState.CMS_WALK);

            if (_monster.IsLeaderOfGroup())
            {
                AIMsgLetsGo msg = new (DateTime.Now.Ticks, destPos, (byte)CharMoveState.CMS_WALK);
                _monster.SendAiMsgToGroupExceptMe(msg);
            }

            return true;
        }

        private bool DoWanderAsFollower()
        {
            return false;
        }

        protected override void OnMsgAttacked(AIMsg msg)
        {
            base.OnMsgAttacked(msg);

            if (!(msg is AIMsgAttacked attackedMsg)) return;

            var attacker = _monster.GetCurrentField()?.FindCharacter(attackedMsg.AttackerKey);
            if (attacker == null) return;
            if (_monster.IsFriend(attacker)!=UserRelationType.USER_RELATION_FRIEND)
            {
                _monster.SetTargetChar(attacker);
                _monster.ChangeState(STATE_ID_TRACK);
            }
        }

        protected override void OnMsgLetsGo(AIMsg msg)
        {
            base.OnMsgLetsGo(msg);
            _destSelected = true;
        }
    }
}
