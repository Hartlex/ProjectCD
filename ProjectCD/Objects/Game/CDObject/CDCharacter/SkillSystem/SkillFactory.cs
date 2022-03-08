using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.SkillType;
using Style = ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes.Style;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem
{
    internal class SkillFactory : Singleton<SkillFactory>
    {
        public SkillBase AllocSkill(SkillType skillType, RootSkillInfo rootInfo, int delay =0)
        {
        
            if (rootInfo.IsSkill())
            {
                var info = (BaseSkillInfo)rootInfo;
                if (info.SkillType == SKILL_TYPE_PASSIVE)
                    skillType = SKILL_TYPE_PASSIVE;
                else if (info.SkillCasting != 0 || info.FlyingLifeTime != 0 ||delay!=0)
                    skillType = SKILL_TYPE_ACTIVE_DELAYED;
                else
                    skillType = SKILL_TYPE_ACTIVE_INSTANT;
            }

            switch (skillType)
            {
                case SKILL_TYPE_PASSIVE:
                    return new PassiveSkill();
                case SKILL_TYPE_ACTIVE_INSTANT:
                    return new InstantSkill();
                case SKILL_TYPE_ACTIVE_DELAYED:
                    return new DelayedSkill();
                case SKILL_TYPE_STYLE:
                    return new Style();
                case SKILL_TYPE_NORMAL:
                    return new NormalAttack();
                case SKILL_TYPE_NORMAL_AREA:
                    return new NormalAttack();
                default:
                    throw new ArgumentOutOfRangeException(nameof(skillType), skillType, null);

            }
            return null;
        }
    }
}
