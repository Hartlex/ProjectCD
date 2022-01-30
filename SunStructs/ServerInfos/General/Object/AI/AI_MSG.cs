using SunStructs.Definitions;
using static SunStructs.Definitions.AIMsgID;

namespace SunStructs.ServerInfos.General.Object.AI
{
    public class AIMsg
    {
        public readonly AIMsgID MsgId;
        public readonly long DeliveryTick;

        public AIMsg(AIMsgID id, long deliveryTick)
        {
            MsgId = id;
            DeliveryTick = deliveryTick;
        }

        public AIMsg(AIMsgID id)
        {
            MsgId = id;
            DeliveryTick = DateTime.Now.Ticks;
        }

    }

    public class AIMsgBlind : AIMsg
    {
        public readonly int BlindTime;

        public AIMsgBlind(int blindTime) : base(AI_MSG_ID_BLIND, DateTime.Now.Ticks)
        {
            BlindTime = blindTime;
        }
    }

    public class AIMsgForceAttack : AIMsg
    {
        public readonly uint TargetId;
        public AIMsgForceAttack(uint targetId, long deliveryTick) : base(AI_MSG_ID_FORCE_ATTACK, deliveryTick)
        {
            TargetId = targetId;
        }
    }
    public class AIMsgAttacked : AIMsg
    {
        public readonly uint AttackerKey;
        public readonly int Damage;

        public AIMsgAttacked(uint attackerKey,int damage) : base(AI_MSG_ID_ATTACKED)
        {
            AttackerKey = attackerKey;
            Damage = damage;
        }
    }
        public class AIMsgLeaveField : AIMsg
    {
        public readonly uint ObjectKey;

        public AIMsgLeaveField(long deliveryTick, uint objectKey) : base(AI_MSG_ID_LEAVE_FIELD, deliveryTick)
        {
            ObjectKey = objectKey;
        }
    }
    public class AIMsgHelpRequest : AIMsg
    {
        public readonly uint AttackerKey;
        public readonly uint TargetKey;
        public AIMsgHelpRequest(long deliveryTick, uint attackerKey,uint targetKey) : base(AI_MSG_ID_HELP_REQUEST, deliveryTick)
        {
            AttackerKey = attackerKey;
            TargetKey = targetKey;
        }
    }
    public class AIMsgThrust : AIMsg
    {
        public readonly bool DownAfterThrust;
        public AIMsgThrust(long deliveryTick,bool downAfterThrust): base(AI_MSG_ID_THRUST, deliveryTick)
        {
            DownAfterThrust = downAfterThrust;
        }
    }
    public class AIMsgKnockDown : AIMsg
    {
        public readonly long KnockDownTick;

        public AIMsgKnockDown(long deliveryTick, long knockDownTick) : base(AI_MSG_ID_KNOCKDOWN, deliveryTick)
        {
            KnockDownTick = knockDownTick;
        }
    }
    public class AIMsgFlying : AIMsg
    {
        public readonly long FlyingTick;

        public AIMsgFlying(long deliveryTick, long flyingTick) : base(AI_MSG_ID_FLYING, deliveryTick)
        {
            FlyingTick = flyingTick;
        }
    }
    public class AIMsgStun : AIMsg
    {
        public readonly long StunTick;

        public AIMsgStun(long deliveryTick, long stunTick) : base(AI_MSG_ID_STUN, deliveryTick)
        {
            StunTick = stunTick;
        }
    }
    public class AIMsgGroupMemberAttack : AIMsg
    {
        public readonly uint AttackerKey;
        public readonly uint TargetKey;
        public readonly uint Damage;
        public AIMsgGroupMemberAttack(long deliveryTick,uint attackerKey,uint targetKey,uint damage) : base(AI_MSG_ID_GROUP_MEMBER_ATTACKED, deliveryTick)
        {
            AttackerKey = attackerKey;
            TargetKey = targetKey;
            Damage = damage;
        }
    }
    public class AIMsgGroupCommand : AIMsg
    {
        public readonly GroupCMD Type;
        public readonly uint TargetKey;

        public AIMsgGroupCommand(long deliveryTick, GroupCMD type, uint targetKey) : base(AI_MSG_ID_GROUP_C0MMAND,
            deliveryTick)
        {
            Type = type;
            TargetKey = targetKey;
        }
    }
    public class AIMsgLetsGo : AIMsg
    {
        public readonly SunVector DestPosition;
        public readonly byte MoveState;

        public AIMsgLetsGo(long deliveryTick, SunVector destPosition, byte moveState) : base(AI_MSG_ID_LETSGO,
            deliveryTick)
        {
            DestPosition = destPosition;
            MoveState = moveState;
        }
    }
    public class AIMsgChangeState : AIMsg
    {
        public readonly byte StateID;
        public readonly byte MoveState;

        public AIMsgChangeState(long deliveryTick, byte stateID, byte moveState) : base(AI_MSG_ID_CHANGESTATE,
            deliveryTick)
        {
            StateID = stateID;
            MoveState = moveState;
        }
    }
    public class AIMsgEnemyFound : AIMsg
    {
        public readonly uint TargetObjectKey;

        public AIMsgEnemyFound(long deliveryTick, uint targetObjectKey) : base(AI_MSG_ID_ENEMY_FOUND, deliveryTick)
        {
            TargetObjectKey = targetObjectKey;
        }
    }
    public class AIMsgRunAway : AIMsg
    {
        public readonly uint TargetKey;
        public readonly int RunAwayTime;

        public AIMsgRunAway(long deliveryTick, uint targetKey, int runAwayTime) : base(AI_MSG_ID_RUNAWAY,
            deliveryTick)
        {
            TargetKey = targetKey;
            RunAwayTime = runAwayTime;
        }
    }
    public class AIMsgChaos : AIMsg
    {
        public readonly long ChaosTime;

        public AIMsgChaos(long deliveryTick, long chaosTime) : base(AI_MSG_ID_CHAOS, deliveryTick)
        {
            ChaosTime = chaosTime;
        }
    }
    public class AIMsgCommandFollow:AIMsg
    {
        public AIMsgCommandFollow(long deliveryTick) : base(AI_MSG_ID_COMMAND_FOLLOW, deliveryTick){}
    }
    public class AIMsgUseSkill : AIMsg
    {
        public readonly ushort SkillCode;
        public readonly uint TargetKey;
        public readonly SunVector TargetPos;

        public AIMsgUseSkill(long deliveryTick, ushort skillCode, uint targetKey, SunVector targetPosition) : base(
            AI_MSG_ID_USE_SKILL, deliveryTick)
        {
            SkillCode = skillCode;
            TargetKey = targetKey;
            TargetPos = targetPosition;
        }
    }


}
