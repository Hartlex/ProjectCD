using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SearchOption.Options;
using static SunStructs.Definitions.AbilityRangeType;


namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem
{


    internal abstract class SearchOption
    {
        internal enum Options
        {
            Option_None,
            Option_LookAround,
            Option_NpcAI,
            Option_SingleSearch,
            Option_SkillBase,
            Option_SelectBestFit,
        };
        internal enum Filter
        {
            Filter_None = 0,
            //
            Filter_SkipCantBeAttacked = 1 << 0, //
            Filter_SkipObserver = 1 << 1, //
            Filter_SkipTransparent = 1 << 2, //
            Filter_SkipDead = 1 << 4, //
            Filter_SkipTileCheck = 1 << 5, // SkillBase
            Filter_SkipRangeCheck = 1 << 7, // SkillBase
            //
            Filter_CheckNonPreemptive = 1 << 10, // NpcAI
            //
        };
        internal enum ContinueResult
        {
            Stop,
            Continue,
        };

        public Options Option;
        public ulong FilterValue;
        public IffFilter IffFilter;
        public int MaxNumberOfSelectedChars;
        public bool Valid;

        public SkillTargetType searchTargetType;
        public SunVector StartPosition;
        public SunVector ApplicationCenterPos;
        public float AttackRange;
        public float RangesOfApplication;
        public SkillAreaType FormsOfApplication;
        public Character ExceptObject;

        protected SearchOption(Options searchOption, ulong searchFilter)
        {
            Option = searchOption;
            FilterValue = searchFilter;
            MaxNumberOfSelectedChars = 0;
            Valid = false;
        }

    }

    //internal class SearchLookAround : SearchOption
    //{
    //    public SearchLookAround(SkillTargetType targetType) : base(Option_LookAround, 0)
    //    {
    //    }
    //}

    //internal class NpcAI : SearchOption
    //{
    //    public NpcAI(NPC npc)
    //    {

    //    }

    //    public ContinueResult AppendToResultIfIsSatisfiedObject(NPC actor,Character target,ulong )
    //}

}
