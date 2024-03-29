﻿using CDShared.Parsing;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Character.NPC
{
    public class BaseNPCInfo
    {
        public readonly ushort MonsterId;
        public readonly string Name;
        public readonly ushort Level;
        public readonly ushort DisplayLevel;
        public readonly byte ChangeTargetRatio;
        public readonly int MaxHP;
        public readonly int MaxMP;
        public readonly int MaxSD;
        public readonly int HP;
        public readonly int MP;
        public readonly int SD;
        public readonly uint NameCode;
        public readonly uint ICode;
        public readonly NPCGrade Grade;
        public readonly float GradeExpRatio;
        public readonly ushort Size;
        public readonly byte AIType;
        public readonly byte FindNPC;
        public readonly ushort AttProperty;
        public readonly byte CriticalRatio;
        public readonly uint MinAttackPower;
        public readonly uint MaxAttackPower;
        public readonly uint PhysicalDef;
        public readonly uint MagicalDef;
        public readonly ushort Attitude;
        public readonly NPCMoveAttitude MoveAttitude;
        public readonly string MoveAreaID;
        public readonly ushort Class;

        public readonly ushort WaterResist;
        public readonly ushort FireResist;
        public readonly ushort WindResist;
        public readonly ushort EarthResist;
        public readonly ushort PhysicalAttRate;
        public readonly float PhysicalAvoidRate;
        public readonly AttackType AttType;
        public readonly MeleeType MeleeType;
        public readonly ArmorType ArmorType;
        public readonly float AttRange;
        public readonly float ViewRange;
        public readonly float MoveRange;
        public readonly float WalkSpeed;
        public readonly float RunSpeed;
        public readonly ushort AttackSpeed;
        public readonly ushort AttackSpeed2;
        public readonly ushort ProjectileCode;
        public readonly ushort ProjectileCode2;
        public readonly ushort JumpRatio;
        public readonly uint SpawnAniTime;
        public readonly ulong DeadWaitingTime;
        public readonly SpecialCondition[] SpecialConditions;
        public readonly ResistanceCondition[] ResistanceConditions;

        public readonly int SkillUpdateTime;

        public readonly byte ReviveCondition;
        public readonly ushort ReviveConditionParam;
        public readonly byte ReviveRate;
        public readonly ushort ReviveCode;
        public readonly ushort ReviveDelay;

        public readonly byte HealCondition;
        public readonly ushort HealConditionParam;
        public readonly byte HealRate;
        public readonly ushort HealCode;
        public readonly ushort HealDelay;

        public readonly byte SummonCondition;
        public readonly ushort SummonConditionParam;
        public readonly byte SummonRate;
        public readonly ushort SummonCode;
        public readonly ushort SummonDelay;

        public readonly byte SkillUsePossible;
        public readonly NPCSkillInfo[] SkillInfos;

        public readonly ushort HateSkill;
        public readonly ushort RevengeSkill;
        public readonly byte RevengeRate;

        public readonly byte Region;
        public readonly byte DropOwnerShip;
        
        public readonly uint[] DropIndex;
        public readonly uint[] FieldDropIndex;
        public readonly uint[] BattleDropIndex;
        public readonly uint[] QuestCode;
        public readonly uint[] QuestDropIndex;
        public readonly ushort ACCode;
        public readonly ushort ACReferenceId;
        public readonly NPCOption[] NPCOptions;
        
        public readonly ushort Dest;
        public readonly Act_P[] ActPs;
        
        public readonly string SpawnAniCode;
        
        public uint SpawnTime;
        public BaseNPCInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            MonsterId = sb.ReadUshort();
            Name = sb.ReadString();
            Level = sb.ReadUshort();
            DisplayLevel = sb.ReadUshort();
            MaxHP = sb.ReadInt();
            MaxMP= sb.ReadInt();
            MaxSD= sb.ReadInt();
            NameCode = sb.ReadUint();
            ICode = sb.ReadUint();
            sb.Skip();
            Grade = (NPCGrade) sb.ReadByte();
            GradeExpRatio = sb.ReadFloat();
            Size = sb.ReadUshort();
            AIType = sb.ReadByte();
            FindNPC = sb.ReadByte();
            AttType = (AttackType) sb.ReadInt();;
            CriticalRatio = sb.ReadByte();
            MinAttackPower= sb.ReadUint();
            MaxAttackPower= sb.ReadUint();
            PhysicalDef = sb.ReadUint();
            MagicalDef= sb.ReadUint();
            Class= sb.ReadUshort();
            WaterResist= sb.ReadUshort();
            FireResist= sb.ReadUshort();
            WindResist= sb.ReadUshort();
            EarthResist = sb.ReadUshort();
            PhysicalAttRate= sb.ReadUshort();
            PhysicalAvoidRate= sb.ReadFloat();
            MeleeType= (MeleeType)sb.ReadInt();
            ArmorType= (ArmorType)sb.ReadInt();
            sb.Skip();
            AttRange = sb.ReadFloat();
            ViewRange = sb.ReadFloat();
            MoveRange = sb.ReadFloat();
            WalkSpeed = sb.ReadFloat();
            RunSpeed = sb.ReadFloat();
            AttackSpeed= sb.ReadUshort();
            AttackSpeed2= sb.ReadUshort();
            ProjectileCode= sb.ReadUshort();
            ProjectileCode2 = sb.ReadUshort();
            JumpRatio = sb.ReadUshort();
            sb.Skip(3);
            SpawnAniCode= sb.ReadString();
            SpawnAniTime = sb.ReadUint();
            DeadWaitingTime = sb.ReadUlong();
            Attitude= sb.ReadUshort();
            MoveAttitude= (NPCMoveAttitude)sb.ReadInt();
            MoveAreaID = sb.ReadString();
            SpecialConditions = new[]
            {
                new SpecialCondition(ref sb),
                new SpecialCondition(ref sb)
            };
            ResistanceConditions = new[]
            {
                new ResistanceCondition(ref sb),
                new ResistanceCondition(ref sb)
            };
            ChangeTargetRatio = sb.ReadByte();
            SkillUpdateTime = sb.ReadInt();
            ReviveCondition = sb.ReadByte();
            ReviveConditionParam = sb.ReadUshort();
            ReviveRate = sb.ReadByte();
            ReviveCode = sb.ReadUshort();
            ReviveDelay = sb.ReadUshort();
            HealCondition = sb.ReadByte();
            HealConditionParam = sb.ReadUshort();
            HealRate = sb.ReadByte();
            HealCode = sb.ReadUshort();
            HealDelay = sb.ReadUshort();
            SummonCondition = sb.ReadByte();
            SummonConditionParam = sb.ReadUshort();
            SummonRate = sb.ReadByte();
            SummonCode = sb.ReadUshort();
            SummonDelay = sb.ReadUshort();
            SkillUsePossible = sb.ReadByte();
            SkillInfos = new[]
            {
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
                new NPCSkillInfo(ref sb),
            };
            HateSkill = sb.ReadUshort();
            RevengeSkill = sb.ReadUshort();
            RevengeRate = sb.ReadByte();
            DropOwnerShip = sb.ReadByte();
            Region = sb.ReadByte();
            DropIndex = new uint[10];
            for (int i = 0; i < 10; i++)
            {
                DropIndex[i] = sb.ReadUint();
            }
            FieldDropIndex = new uint[10];
            for (int i = 0; i < 10; i++)
            {
                FieldDropIndex[i] = sb.ReadUint();
            }
            BattleDropIndex = new uint[10];
            for (int i = 0; i < 10; i++)
            {
                BattleDropIndex[i] = sb.ReadUint();
            }
            QuestCode= new uint[5];
            for (int i = 0; i < 5; i++)
            {
                QuestCode[i] = sb.ReadUint();
            }
            QuestDropIndex= new uint[5];
            for (int i = 0; i < 5; i++)
            {
                QuestDropIndex[i] = sb.ReadUint();
            }

            ACCode = sb.ReadUshort();
            ACReferenceId = sb.ReadUshort();
            NPCOptions = new[]
            {
                new NPCOption(ref sb),
                new NPCOption(ref sb)
            };
            Dest = sb.ReadUshort();
            ActPs = new[]
            {
                new Act_P(ref sb),
                new Act_P(ref sb),
                new Act_P(ref sb),
                new Act_P(ref sb),
                new Act_P(ref sb)
            };
        }

    }

    public class SpecialCondition
    {
        public int Condition;
        public int ConditionParam;
        public NPCSpecialActionType ActionType;
        public int ActionParam;
        public int ActionRate;

        public SpecialCondition(ref StringBuffer sb)
        {
            Condition = sb.ReadInt();
            ConditionParam = sb.ReadInt();
            ActionType = (NPCSpecialActionType) sb.ReadInt();
            ActionParam = sb.ReadInt();
            ActionRate = sb.ReadInt();

        }
    }

    public class ResistanceCondition
    {
        public ushort StateCode;
        public byte Ratio;
        public string EffectCode;

        public ResistanceCondition(ref StringBuffer sb)
        {
            StateCode = sb.ReadUshort();
            Ratio = sb.ReadByte();
            EffectCode = sb.ReadString();
        }
    }

    public enum NPCType
    {
        NONE,
        STORE,
        BANK,
        MAKE_ZONE,
        ITEM_MIX,
        GUARD,
        VILLAGE_PORTAL,
        GUILD
    }

    public class NPCSkillInfo
    {
        public ushort SkillCode;
        public byte SkillRate;
        public ushort SkillDelay;

        public NPCSkillInfo(ref StringBuffer sb)
        {
            SkillCode = sb.ReadUshort();
            SkillRate = sb.ReadByte();
            SkillDelay = sb.ReadUshort();
        }
    }

    public class NPCOption
    {
        public ushort Id;
        public ushort Param;
        public NPCOption(ref StringBuffer sb)
        {
            Id = sb.ReadUshort();
            Param = sb.ReadUshort();
        }
    }

    public class Act_P
    {
        public string ACT;
        public string P;
        public Act_P(ref StringBuffer sb)
        {
            ACT = sb.ReadString();
            P = sb.ReadString();
        }
    }
}
