using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using SunStructs.ServerInfos.General.Object.Character.NPC;
using static CDShared.Generics.SunCalc;
using static SunStructs.Definitions.AIStateID;
using static SunStructs.Definitions.NPCGrade;
using static SunStructs.Definitions.NPCMoveAttitude;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC
{
    internal class NPC : Character
    {
        #region Protected

        protected BaseNPCInfo Info;
        protected NPCAttr Attrs;
        protected TargetManager TargetManager;
        protected NpcStateManager NPCStateManager;

        #endregion

        #region Private

        private ushort _selectedSkillCode;
        private int _selectedSkillDelay;
        private SunVector _spawnPosition;

        #endregion

        
        public BaseNPCInfo GetBaseInfo(){ return Info;}

        public NPC(uint key) : base(key)
        {
            SetObjectType(ObjectType.NPC_OBJECT);
            NPCStateManager = new NpcStateManager(this);
            TargetManager = new TargetManager(this);
   
        }

        public override bool Update(long currentTick)
        {
            NPCStateManager.Update(currentTick);
            return base.Update(currentTick);
        }

        public bool Initialize(ushort npcCode, NPCMoveAttitude moveType, uint moveAreaID, AIStateID stateID, int param1 = 0)
        {
            if (!BaseNpcDB.Instance.TryGetBaseInfo(npcCode, out Info!))
            {
                Logger.Instance.Log($"Tried to initialize unknown monster[{npcCode}]");
                return false;
            }
             
            base.Initialize();

            int recoverHP = 0;
            int recoverMP = 0;
            int recoverSD = 0;

            if (IsHPMPRegenNPC())
            {
                recoverHP = NPCFormulas.CalcNpcHPRecovery(Info.MaxHP);
                recoverMP = NPCFormulas.CalcNpcHPRecovery(Info.MaxMP);
            }

            if (IsSDRegenNPC())
            {
                recoverSD = NPCFormulas.CalcNpcSDRecovery(Info.MaxSD);
            }

            Attrs = new NPCAttr(this, recoverHP, recoverMP, recoverSD);
            Attrs.Update();
            SetBaseAttributes(Attrs);

            SetInitialState(stateID,moveType,moveAreaID,param1);

            SetHP(Info.MaxHP);
            SetMP(Info.MaxMP);
            SetSD(Info.MaxSD);

            //TargetManager = new TargetManager(this);
            //NPCStateManager = new NpcStateManager(this);

            return true;
        }

        public SunVector GetSpawnPos(){return _spawnPosition;}
        public void SetSpawnPos(SunVector pos){_spawnPosition = pos;}

        public MonsterRenderInfo GetRenderInfo()
        {
            return new MonsterRenderInfo(
                GetKey(),
                Info.MonsterId,
                GetPos(),
                (uint) GetHP(),
                (uint) GetMaxHP(),
                (ushort) GetMoveSpeedRatio(),
                (ushort) GetAttSpeedRatio(),
                0
            );
        }
        
        public bool IsHPMPRegenNPC()
        {
            switch (Info.Grade)
            {
                case NPC_BOSS: 
                case NPC_ELITE: 
                case NPC_LEADER: 
                case NPC_MIDDLEBOSS:
                case NPC_SUMMON_NPC:
                    return true;
                default:
                    return false;
            }
        }

        public bool IsSDRegenNPC()
        {
            return IsObjectType(ObjectType.SSQMONSTER_OBJECT);
        }
        public override void OnEnterField(Field field, SunVector pos, ushort angle = 0)
        {
            base.OnEnterField(field, pos, angle);
            var packet = new BrdMonsterEnter(new MonsterRenderInfos(GetRenderInfo()));
            GetCurrentField()?.SendToAll(packet);

        }

        public NPCGrade GetGrade()
        {
            return  Info.Grade;
        }

        public override AttackType GetWeaponBaseAttackType() { return Info.AttType; }
        public override AttackType GetWeaponMagicAttackType() { return Info.AttType; }
        public override ushort GetDisplayLevel()
        {
            return Info.DisplayLevel;
        }
        public override ushort GetLevel()
        {
            return Info.Level;
        }

        public override int GetPhysicalAvoidValue()
        {
            return (int) (GetLevel() / 2.5f + Attrs[AttrType.ATTR_PHYSICAL_ATTACK_BLOCK_RATIO].GetValue());
        }

        #region Attributes
        
        public override NPCAttr GetAttributes()
        {
            return Attrs;
        }

        public override MeleeType GetMeleeType()
        {
            return Info.MeleeType;
        }

        public override ArmorType GetArmorType()
        {
            return Info.ArmorType;
        }

        public float GetAttackRange()
        {
            return Info.AttRange;
        }

        public float GetSightRange()
        {
            return Attrs[AttrType.ATTR_SIGHT_RANGE].GetValue() / 10f;
        }

        #endregion

        #region Movement



        public override bool ExecuteThrust(bool forced, SunVector destPos, ref SunVector posAfterThrust, float moveDistance,
            bool downAfterThrust)
        {
            if (GetCurrentField() == null) return false;
            
            if (Info.MoveAttitude is MOVE_ATTITUDE_ETERNAL_STOP_NO_ATTACK or MOVE_ATTITUDE_ETERNAL_STOP) return false;

            if (destPos.GetX() == 0 && destPos.GetY() == 0)
            {
                destPos.SetX(1);

            }

            destPos.SetZ(0);
            posAfterThrust += destPos;
            SetPos(posAfterThrust);
            Logger.Instance.Log($"Pos after Thrust ={posAfterThrust} DiffVector ={destPos} [{destPos.GetLength()}]");
            return true;

            //TODO AI MESSAGE
        }

        public bool ThrustMoveAndBroadcast(SunVector destPos, byte moveState)
        {
            var currentPos = GetPos();
            //SetPos(destPos);
            destPos.ToTwoDim();
            MoveStateControl.SetMoveState((CharMoveState) moveState);
            MoveStateControl.SetNewDestinationPos(destPos);

            var warPacketInfo = new MoveThrustBrdInfo(GetKey(), moveState, currentPos, destPos);
            GetCurrentField()?.QueueWarPacketInfo(warPacketInfo);
            return true;
        }

        public bool IsOutOfRegenLocationLimit(SunVector targetPos)
        {
            var dist = AiParameterDb.Instance.GetAiTypeInfo(Info.AIType).RegenLocationLimit;
            return SunVector.GetDistance(GetSpawnPos(), targetPos) > dist;
        }

        #endregion




        public override UserRelationType IsFriend(Character target)
        {
            if (ReferenceEquals(this, target)) return UserRelationType.USER_RELATION_FRIEND;
            if (target.IsObjectType(ObjectType.PLAYER_OBJECT)) return UserRelationType.USER_RELATION_ENEMY;
            return UserRelationType.USER_RELATION_NEUTRALIST;
        }

        #region StateManager
        
        public void SetInitialState(AIStateID stateID,NPCMoveAttitude moveType,uint moveAreaID,int param1)
        {
            //if(moveType!=0)
            //    if (moveAreaID == 0)
            //        moveAreaID = Info.MoveAreaID;
            NPCStateManager.ResetStates();

            switch (moveType)
            {
                case MOVE_ATTITUDE_ETERNAL_STOP:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE,STATE_ID_IDLE);
                    NPCStateManager.AddStateObject(STATE_ID_WANDER, STATE_ID_IDLE);
                    NPCStateManager.AddStateObject(STATE_ID_TRACK,STATE_ID_IDLE);
                    NPCStateManager.AddStateObject(STATE_ID_HELP, STATE_ID_IDLE);
                    NPCStateManager.AddStateObject(STATE_ID_ATTACK, STATE_ID_ATTACK);
                    NPCStateManager.AddStateObject(STATE_ID_DEAD, STATE_ID_DEAD);
                    NPCStateManager.AddStateObject(STATE_ID_KNOCKDOWN, STATE_ID_KNOCKDOWN);
                    NPCStateManager.AddStateObject(STATE_ID_CHAOS, STATE_ID_CHAOS);
                    NPCStateManager.AddStateObject(STATE_ID_BLIND, STATE_ID_BLIND);
                    NPCStateManager.AddStateObject(STATE_ID_DESTROY_OBJECT, STATE_ID_DESTROY_OBJECT);
                    NPCStateManager.AddStateObject(STATE_ID_SPECIAL_DEAD_ACTION, STATE_ID_SPECIAL_DEAD_ACTION);
                    break;
                case MOVE_ATTITUDE_ETERNAL_STOP_NO_ATTACK:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE,STATE_ID_NO_TRANS);
                    break;
                case MOVE_ATTITUDE_SPAWN_STOP:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE, STATE_ID_SPAWN_IDLE);
                    NPCStateManager.AddStateObject(STATE_ID_WANDER, STATE_ID_RETURN);
                    NPCStateManager.AddStateObject(STATE_ID_TRACK, STATE_ID_TRACK);
                    NPCStateManager.AddStateObject(STATE_ID_HELP, STATE_ID_HELP);
                    NPCStateManager.AddStateObject(STATE_ID_ATTACK, STATE_ID_ATTACK);
                    NPCStateManager.AddStateObject(STATE_ID_THRUST, STATE_ID_THRUST);
                    NPCStateManager.AddStateObject(STATE_ID_FLYING, STATE_ID_FLYING);
                    NPCStateManager.AddStateObject(STATE_ID_DEAD, STATE_ID_DEAD);
                    NPCStateManager.AddStateObject(STATE_ID_KNOCKDOWN, STATE_ID_KNOCKDOWN);
                    NPCStateManager.AddStateObject(STATE_ID_JUMP, STATE_ID_JUMP);
                    NPCStateManager.AddStateObject(STATE_ID_FALL_APART, STATE_ID_FALL_APART);
                    NPCStateManager.AddStateObject(STATE_ID_RETURN, STATE_ID_RETURN);
                    NPCStateManager.AddStateObject(STATE_ID_RETREAT, STATE_ID_RETREAT);
                    NPCStateManager.AddStateObject(STATE_ID_RUNAWAY, STATE_ID_RUNAWAY);
                    NPCStateManager.AddStateObject(STATE_ID_CHAOS, STATE_ID_CHAOS);
                    NPCStateManager.AddStateObject(STATE_ID_BLIND, STATE_ID_BLIND);
                    NPCStateManager.AddStateObject(STATE_ID_DESTROY_OBJECT, STATE_ID_DESTROY_OBJECT);
                    NPCStateManager.AddStateObject(STATE_ID_SPECIAL_DEAD_ACTION, STATE_ID_SPECIAL_DEAD_ACTION);
                    break;
                case MOVE_ATTITUDE_PATROL:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE, STATE_ID_PATROL);
                    NPCStateManager.AddStateObject(STATE_ID_WANDER, STATE_ID_PATROL);
                    NPCStateManager.AddStateObject(STATE_ID_TRACK, STATE_ID_TRACK);
                    NPCStateManager.AddStateObject(STATE_ID_HELP, STATE_ID_HELP);
                    NPCStateManager.AddStateObject(STATE_ID_ATTACK, STATE_ID_ATTACK);
                    NPCStateManager.AddStateObject(STATE_ID_THRUST, STATE_ID_THRUST);
                    NPCStateManager.AddStateObject(STATE_ID_FLYING, STATE_ID_FLYING);
                    NPCStateManager.AddStateObject(STATE_ID_DEAD, STATE_ID_DEAD);
                    NPCStateManager.AddStateObject(STATE_ID_KNOCKDOWN, STATE_ID_KNOCKDOWN);
                    NPCStateManager.AddStateObject(STATE_ID_JUMP, STATE_ID_JUMP);
                    NPCStateManager.AddStateObject(STATE_ID_FALL_APART, STATE_ID_FALL_APART);
                    NPCStateManager.AddStateObject(STATE_ID_RETURN, STATE_ID_RETURN);
                    NPCStateManager.AddStateObject(STATE_ID_RETREAT, STATE_ID_RETREAT);
                    NPCStateManager.AddStateObject(STATE_ID_RUNAWAY, STATE_ID_RUNAWAY);
                    NPCStateManager.AddStateObject(STATE_ID_CHAOS, STATE_ID_CHAOS);
                    NPCStateManager.AddStateObject(STATE_ID_BLIND, STATE_ID_BLIND);
                    NPCStateManager.AddStateObject(STATE_ID_DESTROY_OBJECT, STATE_ID_DESTROY_OBJECT);
                    NPCStateManager.AddStateObject(STATE_ID_SPECIAL_DEAD_ACTION, STATE_ID_SPECIAL_DEAD_ACTION);
                    break;
                case MOVE_ATTITUDE_PATHLIST:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE, STATE_ID_PATHLIST);
                    NPCStateManager.AddStateObject(STATE_ID_WANDER, STATE_ID_PATHLIST);
                    NPCStateManager.AddStateObject(STATE_ID_TRACK, STATE_ID_TRACK);
                    NPCStateManager.AddStateObject(STATE_ID_HELP, STATE_ID_HELP);
                    NPCStateManager.AddStateObject(STATE_ID_ATTACK, STATE_ID_ATTACK);
                    NPCStateManager.AddStateObject(STATE_ID_THRUST, STATE_ID_THRUST);
                    NPCStateManager.AddStateObject(STATE_ID_FLYING, STATE_ID_FLYING);
                    NPCStateManager.AddStateObject(STATE_ID_DEAD, STATE_ID_DEAD);
                    NPCStateManager.AddStateObject(STATE_ID_KNOCKDOWN, STATE_ID_KNOCKDOWN);
                    NPCStateManager.AddStateObject(STATE_ID_JUMP, STATE_ID_JUMP);
                    NPCStateManager.AddStateObject(STATE_ID_FALL_APART, STATE_ID_FALL_APART);
                    NPCStateManager.AddStateObject(STATE_ID_RETURN, STATE_ID_RETURN);
                    NPCStateManager.AddStateObject(STATE_ID_RETREAT, STATE_ID_RETREAT);
                    NPCStateManager.AddStateObject(STATE_ID_RUNAWAY, STATE_ID_RUNAWAY);
                    NPCStateManager.AddStateObject(STATE_ID_CHAOS, STATE_ID_CHAOS);
                    NPCStateManager.AddStateObject(STATE_ID_BLIND, STATE_ID_BLIND);
                    NPCStateManager.AddStateObject(STATE_ID_DESTROY_OBJECT, STATE_ID_DESTROY_OBJECT);
                    NPCStateManager.AddStateObject(STATE_ID_SPECIAL_DEAD_ACTION, STATE_ID_SPECIAL_DEAD_ACTION);
                    break;
                case MOVE_ATTITUDE_FOLLOW:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE, STATE_ID_FOLLOW);
                    NPCStateManager.AddStateObject(STATE_ID_WANDER, STATE_ID_FOLLOW);
                    NPCStateManager.AddStateObject(STATE_ID_TRACK, STATE_ID_TRACK);
                    NPCStateManager.AddStateObject(STATE_ID_HELP, STATE_ID_HELP);
                    NPCStateManager.AddStateObject(STATE_ID_ATTACK, STATE_ID_ATTACK);
                    NPCStateManager.AddStateObject(STATE_ID_THRUST, STATE_ID_THRUST);
                    NPCStateManager.AddStateObject(STATE_ID_FLYING, STATE_ID_FLYING);
                    NPCStateManager.AddStateObject(STATE_ID_DEAD, STATE_ID_DEAD);
                    NPCStateManager.AddStateObject(STATE_ID_KNOCKDOWN, STATE_ID_KNOCKDOWN);
                    NPCStateManager.AddStateObject(STATE_ID_JUMP, STATE_ID_JUMP);
                    NPCStateManager.AddStateObject(STATE_ID_FALL_APART, STATE_ID_FALL_APART);
                    NPCStateManager.AddStateObject(STATE_ID_RETURN, STATE_ID_FOLLOW);
                    NPCStateManager.AddStateObject(STATE_ID_RETREAT, STATE_ID_RETREAT);
                    NPCStateManager.AddStateObject(STATE_ID_RUNAWAY, STATE_ID_RUNAWAY);
                    NPCStateManager.AddStateObject(STATE_ID_CHAOS, STATE_ID_CHAOS);
                    NPCStateManager.AddStateObject(STATE_ID_BLIND, STATE_ID_BLIND);
                    NPCStateManager.AddStateObject(STATE_ID_DESTROY_OBJECT, STATE_ID_DESTROY_OBJECT);
                    NPCStateManager.AddStateObject(STATE_ID_SPECIAL_DEAD_ACTION, STATE_ID_SPECIAL_DEAD_ACTION);
                    NPCStateManager.AddStateObject(STATE_ID_STOP_IDLE, STATE_ID_STOP_IDLE);
                    break;
                default:
                    NPCStateManager.AddStateObject(STATE_ID_IDLE, STATE_ID_IDLE);
                    NPCStateManager.AddStateObject(STATE_ID_WANDER, STATE_ID_WANDER);
                    NPCStateManager.AddStateObject(STATE_ID_TRACK, STATE_ID_TRACK);
                    NPCStateManager.AddStateObject(STATE_ID_HELP, STATE_ID_HELP);
                    NPCStateManager.AddStateObject(STATE_ID_ATTACK, STATE_ID_ATTACK);
                    NPCStateManager.AddStateObject(STATE_ID_THRUST, STATE_ID_THRUST);
                    NPCStateManager.AddStateObject(STATE_ID_FLYING, STATE_ID_FLYING);
                    NPCStateManager.AddStateObject(STATE_ID_DEAD, STATE_ID_DEAD);
                    NPCStateManager.AddStateObject(STATE_ID_KNOCKDOWN, STATE_ID_KNOCKDOWN);
                    NPCStateManager.AddStateObject(STATE_ID_JUMP, STATE_ID_JUMP);
                    NPCStateManager.AddStateObject(STATE_ID_FALL_APART, STATE_ID_FALL_APART);
                    NPCStateManager.AddStateObject(STATE_ID_RETURN, STATE_ID_RETURN);
                    NPCStateManager.AddStateObject(STATE_ID_RETREAT, STATE_ID_RETREAT);
                    NPCStateManager.AddStateObject(STATE_ID_RUNAWAY, STATE_ID_RUNAWAY);
                    NPCStateManager.AddStateObject(STATE_ID_CHAOS, STATE_ID_CHAOS);
                    NPCStateManager.AddStateObject(STATE_ID_BLIND, STATE_ID_BLIND);
                    NPCStateManager.AddStateObject(STATE_ID_DESTROY_OBJECT, STATE_ID_DESTROY_OBJECT);
                    NPCStateManager.AddStateObject(STATE_ID_SPECIAL_DEAD_ACTION, STATE_ID_SPECIAL_DEAD_ACTION);
                    NPCStateManager.AddStateObject(STATE_ID_STOP_IDLE, STATE_ID_STOP_IDLE);
                    if (moveType == MOVE_ATTITUDE_SEARCH_AREA)
                    {
                        NPCStateManager.AddStateObject(STATE_ID_TRACK_AREA,STATE_ID_TRACK_AREA);
                        stateID = STATE_ID_TRACK_AREA;
                    }

                    break;


            }

            if (stateID == 0) stateID = STATE_ID_IDLE;
            NPCStateManager.Init(stateID,moveType,moveAreaID,param1);
        }

        public override void ChangeState(AIStateID stateID, int param1 = 0, int param2 = 0, int param3 = 0)
        {
            
            NPCStateManager.ChangeState(stateID, param1, param2, param3);
        }

        public override void OnAiMessage(AIMsg msg)
        {
            NPCStateManager.OnAiMsg(msg);
        }

        public SpecialCondition? GetNextSpecialCondition()
        {
            foreach (var condition in Info.SpecialConditions)
            {
                if(CheckCondition(condition.Condition,condition.ConditionParam))
                    if (GlobalRandom.IsSuccess(condition.ActionRate * 100))
                        return condition;
            }

            return null;
        }

        public void SpecialAction(SpecialCondition condition)
        {
            switch (condition.ActionType)
            {
                case NPCSpecialActionType.NPC_SPECIAL_ACTION_HELPREQUEST:
                    if (TargetManager.GetCurrentTarget() == null) return;
                    if (NPCStateManager.IsRequestHelp) return;

                    var msg = new AIMsgHelpRequest(TargetManager.GetCurrentTarget()!.GetKey(), GetKey());
                    SendAIMsgAroundExceptMe(msg);

                    NPCStateManager.IsRequestHelp = true;
                    break;
                case NPCSpecialActionType.NPC_SPECIAL_ACTION_TRANSFORMATION:
                case NPCSpecialActionType.NPC_SPECIAL_ACTION_SELP_DESTRUCTION:
                    UseSkill((ushort) condition.ActionParam);
                    break;
                case NPCSpecialActionType.NPC_SPECIAL_ACTION_SKILL:
                    if (TargetManager.GetCurrentTarget()==null) return;
                    SelectSkill(TargetManager.GetCurrentTarget()!, (ushort) condition.ActionParam);
                    ChangeState(STATE_ID_TRACK);
                    break;
            }
        }

        public void SendAIMsgAroundExceptMe(AIMsg msg)
        {
            var field = GetCurrentField();
            if (field == null) return;
            field.SendAiMessageAroundExceptMe(this, msg);

        }

        public bool UseSkill(ushort skillCode)
        {
            var baseInfo = BaseSkillDB.Instance.GetBaseSkillInfo(skillCode);
            if(baseInfo == null) return false;

            var skillInfo = new SkillInfo()
            {
                CurrentPosition = GetPos(),
                DestinationPosition = GetPos(),
                MainTargetKey = 0,
                MainTargetPosition = GetPos(),
                Owner = this,
                SkillCode = skillCode
            };
            var target = TargetManager.GetCurrentTarget();
            if (target != null)
            {
                skillInfo.MainTargetKey = target.GetKey();
                skillInfo.MainTargetPosition = target.GetPos();

                if (baseInfo.TargetType == SkillTargetType.SKILL_TARGET_REACHABLE_ENEMY)
                {
                    var dif = skillInfo.MainTargetPosition - GetPos();
                    ExecuteThrust(false, dif, ref skillInfo.DestinationPosition, 0, false);

                }
            }

            return GetActiveSkillManager().RegisterSkill(SkillType.SKILL_TYPE_ACTIVE, ref skillInfo);
        }

        public void SelectSkill(Character target, ushort skillCode)
        {
            TargetManager.SetCurrentTarget(target);
            _selectedSkillCode = skillCode;
            _selectedSkillDelay = 0;

        }
        #endregion

        #region Targets

        public override void SetTargetChar(Character? attacker)
        {
            TargetManager.SetCurrentTarget(attacker);
        }
        public Character? GetCurrentTarget()
        {
            return TargetManager.GetCurrentTarget();
        }

        public float GetDistToNewTarget(Character attacker)
        {
            return SunVector.GetDistance(GetPos(), attacker.GetPos());
        }
        public float GetDistToTarget()
        {
            var target = TargetManager.GetCurrentTarget();
            if (target == null) return 0;
            return SunVector.GetDistance(GetPos(), target.GetPos());
        }
        public void RemoveTarget(uint objectKey)
        {
            TargetManager.RemoveTarget(objectKey);
        }
        public Character? SearchTarget()
        {
            if (GetCurrentField() == null) return null;

            return GetCurrentField()!.SearchTarget(this, TargetSearchType.RARGET_SEARCH_NEAREST, UserRelationType.USER_RELATION_ENEMY);


        }

        #endregion

        public void StatusResist()
        {

        }


        #region Group

        public bool IsGroupMember()
        {
            return false;
        }

        public bool IsFollowerOfGroup()
        {
            return false;
        }

        public bool IsLeaderAlive()
        {
            return false;
        }
        public bool IsLeaderOfGroup()
        {
            return false;
        }
        public void SendAiMsgToGroupExceptMe(AIMsg msg)
        {

        }

        #endregion



    }
}
