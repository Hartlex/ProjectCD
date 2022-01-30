using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using static SunStructs.Definitions.SkillEnum;
using static SunStructs.Definitions.SkillType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes
{
    internal class InstantSkill : Skill
    {
        protected override void SetExecutionInterval()
        {
            Interval = 0;
            switch ((SkillEnum) GetSkillClassCode())
            {
                case SKILL_DOUBLE_ATTACK: Interval = 2000; break;
                case SKILL_ILLUSION_DANCE: Interval = 1500; break;
                case SKILL_BLOOD_RAIN: Interval = 2000; break;
                case SKILL_AIRBLOW: Interval = 4000; break;
                case SKILL_BATTLERHONE: Interval = 4000; break;

            }
        }

        public override SkillType GetSkillType()
        {
            return SKILL_TYPE_ACTIVE_INSTANT;
        }

        public override bool StartExecute()
        {
            base.InitResultMsg();

            if (!CheckMainTarget(out var result))
            {
                DecreaseHPMP();
                BroadcastInstantResult();
                return false;
            }

            DecreaseHPMP();

            ExecuteSkill();

            BroadcastInstantResult();

            return true;
        }
    }
}
