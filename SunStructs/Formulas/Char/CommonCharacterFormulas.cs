using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;


namespace SunStructs.Formulas.Char
{
    public static class CommonCharacterFormulas
    {
        public static uint CalcHP(in CharType charType,in ushort level,in ushort vitality)
        {
            switch (charType)
            {
                case CharType.CHAR_NONE:
                    break;
                case CharType.CHAR_BERSERKER:
                    return (uint) (170 + (level-1) * 30 + (vitality -24) * 10);
                case CharType.CHAR_DRAGON:
                    return (uint)(180 + (level - 1) * 22 + (vitality - 20) * 7);
                case CharType.CHAR_SHADOW:
                    return (uint)(160 + (level - 1) * 19 + (vitality - 15) * 7);
                case CharType.CHAR_VALKYRIE:
                    return (uint)(160 + (level - 1) * 19 + (vitality - 15) * 5);
                case CharType.CHAR_ELEMENTALIST:
                    return (uint)(150 + (level - 1) * 18 + (vitality - 13) * 5);
                case CharType.CHAR_MYSTIC:
                case CharType.CHAR_HELLROID:
                case CharType.CHAR_WITCHBLADE:
                case CharType.CHAR_TYPE_MAX:
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
                case CharType.CHAR_NONE:
                    break;
                case CharType.CHAR_BERSERKER:
                    return (uint)(20 + (level - 1) * 5 + (spirit - 10) * 2);
                case CharType.CHAR_DRAGON:
                    return (uint)(25 + (level - 1) * 7 + (spirit - 12) * 4);
                case CharType.CHAR_SHADOW:
                    return (uint)(40 + (level - 1) * 8.5f + (spirit - 13) * 6);
                case CharType.CHAR_VALKYRIE:
                    return (uint)(32 + (level - 1) * 8 + (spirit - 19) * 5);
                case CharType.CHAR_ELEMENTALIST:
                    return (uint)(100 + (level - 1) * 25 + spirit  * 6);
                case CharType.CHAR_MYSTIC:
                case CharType.CHAR_HELLROID:
                case CharType.CHAR_WITCHBLADE:
                case CharType.CHAR_TYPE_MAX:
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
    }
}
