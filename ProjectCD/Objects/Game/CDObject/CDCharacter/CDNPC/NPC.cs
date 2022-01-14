﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.Character.NPC;
using static CDShared.Generics.SunCalc;
using static SunStructs.Definitions.NPCGrade;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC
{
    internal class NPC : Character
    {
        #region Protected

        protected BaseNPCInfo Info;
        protected NPCAttr Attrs;

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

            return true;
        }

        public MonsterRenderInfo GetRenderInfo()
        {
            return new MonsterRenderInfo(
                GetKey(),
                Info.MonsterId,
                GetPos(),
                GetHP(),
                GetMaxHP(),
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
    }
}