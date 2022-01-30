using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using SunStructs.ServerInfos.General.Object.Character.NPC;
using static CDShared.Generics.SunCalc;
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
        


        #endregion


        public BaseNPCInfo GetBaseInfo(){ return Info;}

        public NPC(uint key) : base(key)
        {
            SetObjectType(ObjectType.NPC_OBJECT);
            
        }

        public bool Initialize(ushort npcCode, byte moveType, uint moveAreaID, uint stateID, uint param1 = 0)
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

            SetHP(Info.MaxHP);
            SetMP(Info.MaxMP);
            SetSD(Info.MaxSD);

            TargetManager = new TargetManager(this);
            NPCStateManager = new NpcStateManager(this);

            return true;
        }

        public MonsterRenderInfo GetRenderInfo()
        {
            return new MonsterRenderInfo(
                GetKey(),
                Info.MonsterId,
                GetPos(),
                (uint) GetHP(),
                (uint) GetMaxHP(),
                Attrs.GetValue16(AttrType.ATTR_MOVE_SPEED),
                Attrs.GetValue16(AttrType.ATTR_ATTACK_SPEED),
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

        public override bool ExecuteThrust(bool forced, SunVector destPos, ref SunVector posAfterThrust, float moveDistance,
            bool downAfterThrust)
        {
            if (GetCurrentField() == null) return false;
            
            if (Info.MoveAttitude is MOVE_ATTITUDE_ETERNAL_STOP_NO_ATTACK or MOVE_ATTITUDE_ETERNAL_STOP) return false;

            if (destPos.GetX() == 0 && destPos.GetY() == 0)
            {
                destPos.SetX(1);

            }

            posAfterThrust += destPos;
            SetPos(posAfterThrust);
            return true;

            //TODO AI MESSAGE
        }

        public override void SetTargetChar(Character attacker)
        {
            TargetManager.SetCurrentTarget(attacker);
        }

        public float GetDistToNewTarget(Character attacker)
        {
            return SunVector.GetDistance(GetPos(), attacker.GetPos());
        }

        public float GetSightRange()
        {
            return Attrs[AttrType.ATTR_SIGHT_RANGE].GetValue() / 10f;
        }

        public void RemoveEnemy(uint objectKey)
        {
            
        }

        public override void ChangeState(AIStateID stateID, int param1 = 0, int param2 = 0, int param3 = 0)
        {
            NPCStateManager.ChangeState(stateID,param1,param2,param3);
        }

        public override void OnAiMessage(AIMsg msg)
        {
            NPCStateManager.OnAiMsg(msg);
        }
    }
}
