using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using Timer = System.Timers.Timer;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class FearStatus : AbilityStatus
    {
        private const int UPDATE_INTERVAL = 1000;

        private TimerBase _timer = new TimerBase();

        private SunVector _rotatedVector;
        private SunVector _targetPos;
        private bool _touchedSomething;

        public override void Start()
        {
            _timer.SetTimer(1);

            if (Attacker == null) return;
            var owner = GetOwner();
            if(owner== null) return;

            var runMsg = new AIMsgRunAway(DateTime.Now.Ticks, Attacker.GetKey(), GetApplicationTime(),
                (ushort) GetStateType());
            owner.OnAiMessage(runMsg);

            if (owner.IsObjectType(ObjectType.PLAYER_OBJECT))
            {
                _touchedSomething = false;
                _targetPos = Attacker.GetPos();
            }

            owner.GetStatusManager().AnimationDelayController.SetAnimationDelay(this, GetApplicationTime());
        }

        public override void Execute()
        {
        }

        public override bool Update(long tick)
        {
            if (_timer.IsExpired())
            {
                
                _timer.SetTimer(UPDATE_INTERVAL);
                var owner = GetOwner();
                if (owner!.IsObjectType(ObjectType.PLAYER_OBJECT))
                {
                    if(!owner.IsMoving())
                        RunAway();
                }
            }

            return base.Update(tick);
        }

        public override void End()
        {
            _timer.Stop();

            var owner = GetOwner();
            if (owner != null)
            {
                owner.StopMoving();
                MoveStopBrd info = new(owner.GetKey(), owner.GetPos());
                owner.GetCurrentField()?.QueueWarPacketInfo(info);
            }

            base.End();
        }

        protected void RunAway()
        {
            var owner = GetOwner();
            if (owner == null) return;

            var statusManager = owner.GetStatusManager();
            if (statusManager.AnimationDelayController.NeedSkipProcessByAnimationDelay(this))
                return;

            var commonInfo = AiParameterDb.Instance.GetAiParamInfo();
            var moveDist = GlobalRandom.Rand(commonInfo.MinMovableDistance, commonInfo.MaxMoveDistance);

            SunVector destPos, movement;

            var curPos = owner.GetPos();
            if (_touchedSomething)
            {
                _touchedSomething = false;
                movement = _rotatedVector;
            }
            else
            {
                movement = (curPos - _targetPos);
                movement.Normalize();
                movement.SetX(movement.GetX()* moveDist);
                movement.SetY(movement.GetY()* moveDist);
            }

            movement.SetZ(2);

            destPos = curPos + movement;
            
            owner.SetMoveState(CharMoveState.CMS_RUN);

            if (!owner.GetCurrentField().FindPath(owner, ref destPos, GetStateType()))
            {
                //turn around
            }

            var info = new MoveBrd(owner.GetKey(), (byte) CharMoveState.CMS_RUN, 1, curPos, destPos);

            owner.GetCurrentField().QueueWarPacketInfo(info);
        }
    }
}
