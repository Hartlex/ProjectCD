using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using static SunStructs.Definitions.CharType;


namespace SunStructs.Formulas.Char
{
    public static class CommonCharacterFormulas
    {
        public static uint CalcHP(in CharType charType,in ushort level,in ushort vitality)
        {
            switch (charType)
            {
                case CHAR_NONE:
                    break;
                case CHAR_BERSERKER:
                    return (uint) (170 + (level-1) * 30 + (vitality -24) * 10);
                case CHAR_DRAGON:
                    return (uint)(180 + (level - 1) * 22 + (vitality - 20) * 7);
                case CHAR_SHADOW:
                    return (uint)(160 + (level - 1) * 19 + (vitality - 15) * 7);
                case CHAR_VALKYRIE:
                    return (uint)(160 + (level - 1) * 19 + (vitality - 15) * 5);
                case CHAR_ELEMENTALIST:
                    return (uint)(150 + (level - 1) * 18 + (vitality - 13) * 5);
                case CHAR_MYSTIC:
                case CHAR_HELLROID:
                case CHAR_WITCHBLADE:
                case CHAR_TYPE_MAX:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(charType), charType, null);
            }

            return 0;
        }

        public static uint CalcMP(in CharType charType, in ushort level, in ushort spirit)
        {
            switch (charType)
            {
                case CHAR_NONE:
                    break;
                case CHAR_BERSERKER:
                    return (uint)(20 + (level - 1) * 5 + (spirit - 10) * 2);
                case CHAR_DRAGON:
                    return (uint)(25 + (level - 1) * 7 + (spirit - 12) * 4);
                case CHAR_SHADOW:
                    return (uint)(40 + (level - 1) * 8.5f + (spirit - 13) * 6);
                case CHAR_VALKYRIE:
                    return (uint)(32 + (level - 1) * 8 + (spirit - 19) * 5);
                case CHAR_ELEMENTALIST:
                    return (uint)(100 + (level - 1) * 25 + spirit  * 6);
                case CHAR_MYSTIC:
                case CHAR_HELLROID:
                case CHAR_WITCHBLADE:
                case CHAR_TYPE_MAX:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(charType), charType, null);
            }

            return 0;
        }

        public static uint CalcSD(in ushort level)
        {
            var l = (float) level;
            float incValue = 3; //8
            //return (uint)(50 + MathF.Pow(l, 3) / (l * 2));
            return (uint)(50 + MathF.Pow(l, 3) / incValue / l);

        }

        public static int CalcMinMeleeAttackPower(CharType type, int str, int dex)
        {
            if (str < 0) str = 0;
            if (dex < 0) dex = 0;

            switch (type)
            {
                case CHAR_DRAGON:
                    return (str / 6);
                case CHAR_BERSERKER:
                    return (str / 7);
                case CHAR_SHADOW:
                    return (str / 9 + dex / 12);
                case CHAR_VALKYRIE:
                    return (str / 10 + dex / 8);
                case CHAR_ELEMENTALIST:
                    return (str / 9);
            }

            return 1;
        }
        public static int CalcMaxMeleeAttackPower(CharType type, int str, int dex)
        {
            if (str < 0) str = 0;
            if (dex < 0) dex = 0;

            switch (type)
            {
                case CHAR_DRAGON:
                    return (str / 4);
                case CHAR_BERSERKER:
                    return (str / 2);
                case CHAR_SHADOW:
                    return (str / 6 + dex / 8);
                case CHAR_VALKYRIE:
                    return (str / 8 + dex / 5);
                case CHAR_ELEMENTALIST:
                    return (str / 4);
            }

            return 1;
        }
        public static int CalcMinRangeAttackPower(CharType type, int str, int dex)
        {
            if (dex < 0)
            {
                dex = 0;
            }

            if (str < 0)
            {
                str = 0;
            }

            switch (type)
            {
                case CHAR_DRAGON:
                case CHAR_BERSERKER:
                case CHAR_MAGICIAN:
                    return CalcMinMeleeAttackPower(type, str, dex);
                case CHAR_SHADOW:
                    return (str / 8);
                case CHAR_VALKYRIE:
                    return (str / 8 + dex / 8);
            }
            return 1;
        }
        public static int CalcMaxRangeAttackPower(CharType type, int str, int dex)
        {
            if (dex < 0)
            {
                dex = 0;
            }

            if (str < 0)
            {
                str = 0;
            }

            switch (type)
            {
                case CHAR_DRAGON:
                case CHAR_BERSERKER:
                case CHAR_MAGICIAN:
                    return CalcMaxMeleeAttackPower(type, str, dex);
                case CHAR_SHADOW:
                    return (str / 4);
                case CHAR_VALKYRIE:
                    return (str / 5 + dex / 5);
            }
            return 1;
        }
        public static int CalcMagicAttackPower(bool bMin, int intelligence)
        {
            if (intelligence < 0)
            {
                intelligence = 0;
            }

            if (bMin) return intelligence / 3;
            else return intelligence / 2;
        }
        public static int CalcPhyBaseDef(CharType type, int vit)
        {
            if (vit < 0)
            {
                vit = 0;
            }

            switch (type)
            {
                case CHAR_DRAGON:
                    return (vit / 5 + 29);
                case CHAR_BERSERKER:
                    return (vit / 5 + 29);
                case CHAR_SHADOW:
                    return (vit / 7 + 29);
                case CHAR_VALKYRIE:
                    return (vit / 6 + 29);
                case CHAR_MAGICIAN:
                    return (vit / 10 + 29);
            }
            return 1;
        }
        public static int CalcMagicBaseDef(CharType type, int spi)
        {
            if (spi < 0)
            {
                spi = 0;
            }

            switch (type)
            {
                case CHAR_DRAGON:
                    return (spi / 9);
                case CHAR_BERSERKER:
                    return (spi / 9);
                case CHAR_SHADOW:
                    return (spi / 8);
                case CHAR_VALKYRIE:
                    return (spi / 8);
                case CHAR_ELEMENTALIST:
                    return (spi / 7);
            }
            return 1;
        }
        public static int CalcPhysicalAttackRateBase(CharType eCharType, int level, int dex)
        {
            float rateValue = 0;

            if (dex < 0)
            {
                dex = 0;
            }

            switch (eCharType)
            {
                case CHAR_DRAGON: rateValue = 2.0f; break;
                case CHAR_BERSERKER: rateValue = 1.5f; break;
                case CHAR_SHADOW: rateValue = 3.0f; break;
                case CHAR_VALKYRIE: rateValue = 5f; break;
                case CHAR_ELEMENTALIST: rateValue = 1.0f; break;
                default: break;

            }

            return (int)(50 + level * 10 + dex * rateValue);
        }
        public static int CalcPhysicalAvoidRateBase(CharType eCharType, int level, int dex)
        {
            var rateValue = 1f;
            if (dex < 0) dex = 0;
            switch (eCharType)
            {
                case CHAR_DRAGON: rateValue = 3.0f; break;
                case CHAR_BERSERKER: rateValue = 3.0f; break;
                case CHAR_SHADOW: rateValue = 3.0f; break;
                case CHAR_VALKYRIE: rateValue = 1.0f; break;
                case CHAR_MAGICIAN: rateValue = 3.0f; break;
            }

            return  (int) (level + dex / rateValue);
        }
        public static int CalcMoveSpeedRatio(int dex, int itemMoveSpeed, int skillMoveSpeed)
        {
            return (100 + dex / 15 + itemMoveSpeed + skillMoveSpeed);
        }
        public static int CalcAttackSpeedRatio(CharType type, int dex, int itemAttSpeed,
            int skillAttSpeed)
        {
            if (itemAttSpeed == 0) itemAttSpeed = 150;
            if (dex < 0) dex = 0;

            float statBonus = 0;
            switch (type)
            {
                case CHAR_DRAGON:
                    statBonus = dex / 800.0f;
                    break;
                case CHAR_BERSERKER:
                    statBonus = dex / 600.0f;
                    break;
                case CHAR_SHADOW:
                    statBonus = dex / 900.0f;
                    break;
                case CHAR_VALKYRIE:
                    statBonus = dex * 0.15f;
                    break;
                case CHAR_MAGICIAN:
                    statBonus = dex / 700.0f;
                    break;
            }

            return MaxBoundCheck(300, (int)(itemAttSpeed + statBonus + skillAttSpeed));
        }
        public static int MaxBoundCheck(int maxValue, int value)
        {
            return value < maxValue ? value : maxValue;
        }
        public static int CalcPhyCriticalBaseRatio(CharType type, int dex)
        {
            uint phyValue = 0;
            if (dex < 0) dex = 0;
            switch (type)
            {
                case CHAR_DRAGON: phyValue = 3; break;
                case CHAR_BERSERKER: phyValue = 4; break;
                case CHAR_SHADOW: phyValue = 3; break;
                case CHAR_VALKYRIE: phyValue = 2; break;
                case CHAR_ELEMENTALIST: phyValue = 4; break;
                default: return 0;
            }

            return  (int) (dex / phyValue);
        }

        public static int CalcMagicCriticalBaseRatio(CharType type, int spi)
        {
            uint phyValue = 0;
            if (spi < 0) spi = 0;
            switch (type)
            {
                case CHAR_DRAGON: phyValue = 2; break;
                case CHAR_BERSERKER: phyValue = 2; break;
                case CHAR_SHADOW: phyValue = 2; break;
                case CHAR_VALKYRIE: phyValue = 2; break;
                case CHAR_ELEMENTALIST: phyValue = 2; break;
                default: return 0;
            }

            return (int) (spi / phyValue);
        }

        public static int CalcDebufDuration(int spr)
        {
            return (int) (spr * 1.2f);
        }
    }
}
