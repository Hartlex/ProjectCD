namespace SunStructs.ServerInfos.General.Skill
{
    public abstract class RootSkillInfo
    {
        public readonly	ushort SkillCode;
        public readonly ushort SkillClassCode;
        public readonly RootSkillType RootSkillType;

        public bool IsSkill()
        {
            return RootSkillType == RootSkillType.SKILL;
        }

        public bool IsStyle()
        {
            return RootSkillType == RootSkillType.STYLE;
        }

        protected RootSkillInfo(ushort skillCode, ushort skillClassCode, RootSkillType rootSkillType)
        {
            SkillCode = skillCode;
            SkillClassCode = skillClassCode;
            RootSkillType = rootSkillType;
        }

        public abstract bool IsMaxLevel();
        public abstract byte GetSkillPointCost();

    }

    public enum RootSkillType : byte
    {
        SKILL,
        STYLE
    }
}
