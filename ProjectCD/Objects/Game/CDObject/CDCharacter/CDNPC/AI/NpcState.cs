using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using static SunStructs.Definitions.AIMsgID;
using static SunStructs.Definitions.AIStateID;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI
{
    internal class NpcState
    {
        protected NPC Owner;
        private long _prevTick;
        private AIStateID _stateId;
        protected AiTypeInfo AiTypeInfo;

        public void SetStateId(AIStateID stateID) { _stateId = stateID; }
        public AIStateID GetStateID(){return _stateId;}


        public virtual void SetNpc(NPC npc)
        {
            Owner = npc;
            AiTypeInfo = AiParameterDb.Instance.GetAiTypeInfo(npc.GetBaseInfo().AIType);
        }

        public virtual void OnEnter(int param1 = 0, int param2 = 0, int param3 = 0)
        {

        }

        public virtual void OnExit()
        {

        }
        
        public virtual void OnUpdate(long tick){}

        public virtual void OnAIMsg(AIMsg msg)
        {
            switch (msg.MsgId)
            {
                case AI_MSG_ID_FORCE_ATTACK:
                    OnMsgForceAttack( msg );
                    break;

                case AI_MSG_ID_ATTACKED:
                    OnMsgAttacked( msg );
                    break;

                case AI_MSG_ID_HELP_REQUEST:
                    OnMsgHelpRequest( msg );
                    break;

                case AI_MSG_ID_LEAVE_FIELD:
                    OnMsgLeaveField( msg );
                    break;

                case AI_MSG_ID_THRUST:
                    OnMsgThrust( msg );
                    break;

                case AI_MSG_ID_GROUP_C0MMAND:
                    OnMsgGroupCommand( msg );
                    break;
                case AI_MSG_ID_FLYING:
                    OnMsgFlying( msg );
                    break;

                case AI_MSG_ID_KNOCKDOWN:
                    OnMsgKnockDown( msg );
                    break;

                case AI_MSG_ID_STUN:
                    OnMsgStun( msg );
                    break;

                case AI_MSG_ID_LETSGO:
                    OnMsgLetsGo( msg );
                    break;

                case AI_MSG_ID_CHANGESTATE:
                    OnMsgChangeState( msg );
                    break;

                case AI_MSG_ID_ENEMY_FOUND:
                    OnMsgEnemyFound( msg );
                    break;

                case AI_MSG_ID_GROUP_MEMBER_ATTACKED:
                    OnMsgGroupAttacked( msg );
                    break;

                case AI_MSG_ID_RUNAWAY:
                    OnMsgRunAway( msg );
                    break;

                case AI_MSG_ID_CHAOS:
                    OnMsgChaos( msg );
                    break;

                case AI_MSG_ID_COMMAND_FOLLOW:
                    OnMsgCommandFollow( msg );
                    break;
                case AI_MSG_ID_USE_SKILL:
                    OnMsgUseSkill( msg );
                    break;
                default:
                    Logger.Instance.Log("Unknown AI_MSG: "+msg.MsgId);
                    break;
            }
        }


        protected virtual void OnMsgForceAttack(AIMsg msg)
        {
            //if (!(msg is AIMsgForceAttack attackMsg)) return;
            //var target = Owner.GetCurrentField()?.FindCharacter(attackMsg.TargetId);
            //if (target == null) return;
            //if (Owner.IsFriend(target)==UserRelationType.USER_RELATION_ENEMY)
            //{
            //    Owner.SetTargetChar(target);
            //    Owner.ChangeState(STATE_ID_TRACK);

                //if (Owner.IsMemberOfGroup())
                //{
                //    AIMsgEnemyFound aiMsg = new (DateTime.Now.Ticks, attackMsg.TargetId);
                //    Owner.SendAiMessageToGroupExceptMe(aiMsg);

                //}
            //}
            
        }

        protected virtual void OnMsgAttacked(AIMsg msg)
        {
            if (!(msg is AIMsgAttacked attackedMsg)) return;
            if (Owner.IsGroupMember())
            {
                AIMsgEnemyFound aiMsg = new (attackedMsg.AttackerKey);
                Owner.SendAiMsgToGroupExceptMe(aiMsg);

            }

            if (Owner.GetBaseInfo().SpecialConditions[0].ActionType == NPCSpecialActionType.NPC_SPECIAL_ACTION_HELPREQUEST)
            {
                var aiParam = AiParameterDb.Instance.GetAiTypeInfo(Owner.GetBaseInfo().AIType);
                if (Owner.GetHP() <= Owner.GetMaxHP() * aiParam.HelpRequestHPPercent)
                {
                    AIMsgHelpRequest aiHelpMsg = new(attackedMsg.AttackerKey,Owner.GetKey());
                    Owner.SendAiMessageAroundExceptMe(aiHelpMsg);
                }
            }
            var attacker = Owner.GetCurrentField()?.FindCharacter(attackedMsg.AttackerKey);
            if (attacker == null) return;

            //Owner.AddBattlePoint(attacker, 0);
        }

        protected virtual void OnMsgHelpRequest(AIMsg msg)
        {
            if (!(msg is AIMsgHelpRequest helpMsg)) return;

            if (Owner.GetBaseInfo().Grade is NPCGrade.NPC_BOSS or NPCGrade.NPC_LUCKY_MONSTER)
                return;

            var attacker = Owner.GetCurrentField()?.FindCharacter(helpMsg.AttackerKey);
            if (attacker == null) 
                return;

            if (Owner.IsFriend(attacker) != UserRelationType.USER_RELATION_ENEMY) 
                return;

            var distance = Owner.GetDistToNewTarget(attacker);
            var sightRange = Owner.GetSightRange();

            if(distance>= sightRange * AiParameterDb.Instance.GetAiParamInfo().HelpSightrangeRatio)
            {
                Owner.SetTargetChar(attacker);
                Owner.ChangeState(STATE_ID_HELP);
            }
        }

        protected virtual void OnMsgLeaveField(AIMsg msg)
        {
            if (msg is not AIMsgLeaveField leaveFieldMsg) return;

            var target = Owner.GetCurrentTarget();
            if (target != null && target.GetKey() == leaveFieldMsg.ObjectKey)
            {
                Owner.ChangeState(STATE_ID_IDLE,0,0,(int) msg.MsgId);
            }

            Owner.RemoveTarget(leaveFieldMsg.ObjectKey);

        }

        protected virtual void OnMsgThrust(AIMsg msg)
        {
            if (!(msg is AIMsgThrust thrustMsg)) return;
            if (thrustMsg.DownAfterThrust)
                Owner.ChangeState(STATE_ID_THRUST, (int) STATE_ID_KNOCKDOWN,0,(int) msg.MsgId);
            else
                Owner.ChangeState(STATE_ID_THRUST);
        }

        protected virtual void OnMsgFlying(AIMsg msg)
        {
            if (!(msg is AIMsgFlying flyMsg)) return;
            Owner.ChangeState(STATE_ID_FLYING, flyMsg.FlyingTime);
        }

        protected virtual void OnMsgKnockDown(AIMsg msg)
        {
            if (!(msg is AIMsgKnockDown knockDownMsg)) return;
            Owner.ChangeState(STATE_ID_KNOCKDOWN, knockDownMsg.KnockDownTime);
        }

        protected virtual void OnMsgStun(AIMsg msg)
        {
            if (!(msg is AIMsgStun stunMsg)) return;
            Owner.ChangeState(STATE_ID_KNOCKDOWN, stunMsg.StunTick);
        }

        protected virtual void OnMsgGroupAttacked(AIMsg msg)
        {

        }

        protected virtual void OnMsgLetsGo(AIMsg msg)
        {
            //if (!(msg is AI_MSG_LetsGo letsGoMsg)) return;

            //var curPos = Owner.GetPos();
            //var destPos = letsGoMsg.DestPosition;
            
            //var aiParam = AiParameterDb.Instance.GetAiParamInfo(Owner.GetBaseInfo().AIType);
            //var random = GlobalRand.Instance.Random(aiParam.WanderRadius * 100,
            //    aiParam.WanderRadius * 100) / 100;
            
            //destPos = SunVector.GetRandomPosAround(destPos,random);

            //if (Owner.MoveAndBroadcast(destPos, (eCHAR_MOVE_STATE) letsGoMsg.MoveState)) return;
            //Owner.MoveAndBroadcast(letsGoMsg.DestPosition, (eCHAR_MOVE_STATE) letsGoMsg.MoveState);


        }

        protected virtual void OnMsgEnemyFound(AIMsg msg)
        {
            if (!(msg is AIMsgEnemyFound enemyFoundMsg)) return;
            var target = Owner.GetCurrentField()?.FindCharacter(enemyFoundMsg.TargetObjectKey);
            if (target == null) return;

            if (Owner.IsFriend(target)==UserRelationType.USER_RELATION_ENEMY)
            {
                Owner.SetTargetChar(target);
                Owner.ChangeState(STATE_ID_TRACK,0,0,(int) msg.MsgId);
            }

        }

        protected virtual void OnMsgRunAway(AIMsg msg)
        {
            if (!(msg is AIMsgRunAway runAwayMsg)) return;
            Owner.ChangeState(STATE_ID_RUNAWAY, (int) runAwayMsg.TargetKey, runAwayMsg.RunAwayTime,runAwayMsg.StateID);
        }

        protected virtual void OnMsgChaos(AIMsg msg)
        {
            if (!(msg is AIMsgChaos chaosMsg)) return;
            Owner.ChangeState(STATE_ID_CHAOS, chaosMsg.ChaosTime,0,(int) msg.MsgId);
        }

        protected virtual void OnMsgChangeState(AIMsg msg)
        {
            //if (!(msg is AI_MSG_ChangeState changeState)) return;
            //if (changeState.StateID == (int) STATE_ID_RETURN)
            //{
            //    Owner.ChangeState(changeState.StateID);
            //    Owner.SetMainTarget(null);
            //}

        }

        protected virtual void OnMsgCommandFollow(AIMsg msg)
        {
            //Owner.SetMainTarget(null);
            //Owner.ChangeState((uint) STATE_ID_IDLE);
        }

        protected virtual void OnMsgUseSkill(AIMsg msg)
        {
            //if (!(msg is AI_MSG_UseSkill useSkillMsg)) return;
            //var target = Owner.CurrentMap?.FindCharacter(useSkillMsg.TargetKey);
            //if (target == null) return;

            //if (!Owner.IsFriend(target))
            //{
            //    Owner.SelectSkill(target, useSkillMsg.SkillCode);
            //    Owner.ChangeState((uint) STATE_ID_TRACK);
            //}
            
        }

        protected virtual void OnMsgGroupCommand(AIMsg msg)
        {
            //if (!(msg is AI_MSG_GroupCommand groupCommand)) return;
            //switch (groupCommand.Type)
            //{
            //    case Group_CMD.GROUP_CMD_TYPE_ATTACK:
            //        OnMsgGroupCommand_Attack(groupCommand.TargetKey);
            //        break;
            //    case Group_CMD.GROUP_CMD_TYPE_STOP_ATTACK:
            //        OnMsgGroupCommand_StopAttack();
            //        break;
            //}
        }

        protected virtual void OnMsgGroupCommand_Attack(uint targetKey)
        {
            //var target = Owner.CurrentMap?.FindCharacter(targetKey);
            //if (target == null) return;
            //Owner.SetMainTarget(target);
            //Owner.ChangeState((uint) STATE_ID_HELP);
        }

        protected virtual void OnMsgGroupCommand_StopAttack()
        {
            //if (Owner.GetMainTarget() != null)
            //{
            //    Owner.GetMainTarget().FreeEnemySlot(Owner.GetTrackSlot());
            //    Owner.SetTrackSlot(-1);
                
            //}
            //Owner.ChangeState((uint) STATE_ID_IDLE);
        }
        
        
    }
}
