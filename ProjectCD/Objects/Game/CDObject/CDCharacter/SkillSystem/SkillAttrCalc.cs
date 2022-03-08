using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem
{
    public class SkillAttrCalc
    {
        #region Const

        private static readonly AttrType[] BASE_STATS = {AttrType.ATTR_STR, AttrType.ATTR_DEX, AttrType.ATTR_VIT, AttrType.ATTR_INT, AttrType.ATTR_SPR};

        #endregion

        protected Attributes Attr;
        public SkillAttrCalc(Attributes attributes)
        {
            Attr = attributes;
        }

        public int AddAttribute(AttrType attrType, AttrValueKind valueType, int value, bool skipUpdate=false)
        {
            var attrKind = AttrValueType.SKILL;
            var calcValue = (float) value;

            if (valueType is AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX or AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
            {
                attrKind = AttrValueType.SKILL_RATIO;
                calcValue /= 10;
            }
            else if (valueType == AttrValueKind.VALUE_TYPE_RATIO_VALUE)
                calcValue /= 10;

            if (CantChangeAttribute(attrType)) return 0;

            value = (int) calcValue;
            switch (attrType)
            {
                case AttrType.ATTR_INCREASE_STAT_POINT:
                    foreach (var type in BASE_STATS)
                    {
                        Attr[type].AddValue(value,attrKind);
                    }

                    break;
                default:
                    Attr[attrType].AddValue(value, attrKind);
                    break;
            }
            if(skipUpdate== false) Attr.UpdateEx();

            return value;
        }
        public int DeleteAttribute(AttrType attrType, AttrValueKind valueType, int value, bool skipUpdate=false)
        {
            var attrKind = AttrValueType.SKILL;
            var calcValue = (float)value;

            if (valueType is AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX or AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
            {
                attrKind = AttrValueType.SKILL_RATIO;
                calcValue /= 10;
            }
            else if (valueType == AttrValueKind.VALUE_TYPE_RATIO_VALUE)
                calcValue /= 10;

            if (CantChangeAttribute(attrType)) return 0;

            value = (int)calcValue;
            switch (attrType)
            {
                case AttrType.ATTR_INCREASE_STAT_POINT:
                    foreach (var type in BASE_STATS)
                    {
                        Attr[type].SubtractValue(value, attrKind);
                    }

                    break;
                default:
                    Attr[attrType].SubtractValue(value, attrKind);
                    break;
            }
            if (skipUpdate == false) Attr.UpdateEx();

            return value;
        }

        public bool CantChangeAttribute(AttrType type)
        {
            switch (type)
            {
                case AttrType.ATTR_BASE_MELEE_MIN_ATTACK_POWER:
                case AttrType.ATTR_BASE_RANGE_MIN_ATTACK_POWER:
                case AttrType.ATTR_BASE_MAGICAL_MIN_ATTACK_POWER:
                case AttrType.ATTR_BASE_MAGICAL_DEFENSE_POWER:
                case AttrType.ATTR_BASE_MELEE_DEFENSE_POWER:
                case AttrType.ATTR_BASE_RANGE_DEFENSE_POWER:
                    return true;
            }

            return false;
        }

        public int ApplyDragonTransformation(bool apply, ushort skillCode, int curHP)
        {
            int changeHP = 0;
            float curHPRatio = (float)curHP / Attr[AttrType.ATTR_MAX_HP].GetValue();

            var baseSkillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(skillCode);
            if (baseSkillInfo == null) return 0;

            if (apply)
            {
                if (baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_DRAGON_TRANSFORMATION1, out var abilityInfo))
                {
                    Attr[AttrType.ATTR_STR].AddValue(abilityInfo!.Params[0], AttrValueType.SKILL);
                    Attr[AttrType.ATTR_DEX].AddValue(abilityInfo!.Params[1], AttrValueType.SKILL);
                }
                if (baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_DRAGON_TRANSFORMATION2, out abilityInfo))
                {
                    Attr[AttrType.ATTR_INT].AddValue(abilityInfo!.option1, AttrValueType.SKILL);
                    Attr[AttrType.ATTR_SPR].AddValue(abilityInfo!.option2, AttrValueType.SKILL);
                    Attr[AttrType.ATTR_VIT].AddValue(abilityInfo!.Params[0], AttrValueType.SKILL);
                    Attr[AttrType.ATTR_MAX_HP].AddValue(abilityInfo!.Params[1] / 10, AttrValueType.SKILL);
                    Attr[AttrType.ATTR_ATTACK_SPEED].AddValue(abilityInfo!.Params[2] / 10, AttrValueType.SKILL);
                }
                if (baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_DRAGON_TRANSFORMATION3, out abilityInfo))
                {
                    Attr[AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER].AddValue(abilityInfo!.option1 / 10, AttrValueType.SKILL_RATIO);
                    Attr[AttrType.ATTR_MAGICAL_ALL_ATTACK_POWER].AddValue(abilityInfo!.option2 / 10, AttrValueType.SKILL_RATIO);
                    Attr[AttrType.ATTR_OPTION_PHYSICAL_DEFENSE_POWER].AddValue(abilityInfo!.Params[0] / 10, AttrValueType.SKILL_RATIO);
                    Attr[AttrType.ATTR_OPTION_MAGICAL_DEFENSE_POWER].AddValue(abilityInfo!.Params[1] / 10, AttrValueType.CALC_RATIO);
                    Attr[AttrType.ATTR_MOVE_SPEED].AddValue(abilityInfo!.Params[3] / 10, AttrValueType.SKILL);
                }
            }
            else
            {
                if (baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_DRAGON_TRANSFORMATION1, out var abilityInfo))
                {
                    Attr[AttrType.ATTR_STR].SubtractValue(abilityInfo!.Params[0], AttrValueType.SKILL);
                    Attr[AttrType.ATTR_DEX].SubtractValue(abilityInfo!.Params[1], AttrValueType.SKILL);
                }
                if (baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_DRAGON_TRANSFORMATION2, out abilityInfo))
                {
                    Attr[AttrType.ATTR_INT].SubtractValue(abilityInfo!.option1, AttrValueType.SKILL);
                    Attr[AttrType.ATTR_SPR].SubtractValue(abilityInfo!.option2, AttrValueType.SKILL);
                    Attr[AttrType.ATTR_VIT].SubtractValue(abilityInfo!.Params[0], AttrValueType.SKILL);
                    Attr[AttrType.ATTR_MAX_HP].SubtractValue(abilityInfo!.Params[1] / 10, AttrValueType.SKILL);
                    Attr[AttrType.ATTR_ATTACK_SPEED].SubtractValue(abilityInfo!.Params[2] / 10, AttrValueType.SKILL);
                }
                if (baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_DRAGON_TRANSFORMATION3, out abilityInfo))
                {
                    Attr[AttrType.ATTR_OPTION_PHYSICAL_ATTACK_POWER].SubtractValue(abilityInfo!.option1 / 10, AttrValueType.SKILL_RATIO);
                    Attr[AttrType.ATTR_MAGICAL_ALL_ATTACK_POWER].SubtractValue(abilityInfo!.option2 / 10, AttrValueType.SKILL_RATIO);
                    Attr[AttrType.ATTR_OPTION_PHYSICAL_DEFENSE_POWER].SubtractValue(abilityInfo!.Params[0] / 10, AttrValueType.SKILL_RATIO);
                    Attr[AttrType.ATTR_OPTION_MAGICAL_DEFENSE_POWER].SubtractValue(abilityInfo!.Params[1] / 10, AttrValueType.CALC_RATIO);
                    Attr[AttrType.ATTR_MOVE_SPEED].SubtractValue(abilityInfo!.Params[3] / 10, AttrValueType.SKILL);
                }
            }


            Attr.Update();

            if (curHPRatio != 0)
            {
                int tmp = (int) (Attr[AttrType.ATTR_MAX_HP].GetValue() * curHPRatio);
                changeHP = SunCalc.Min(1, tmp) - curHP;
            }
            else changeHP = 0;

            return changeHP;
        }
    }
}
