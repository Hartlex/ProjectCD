using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using SunStructs.Definitions;

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
    }
}
