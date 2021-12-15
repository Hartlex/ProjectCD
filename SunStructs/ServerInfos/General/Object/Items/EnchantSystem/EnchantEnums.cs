using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.ServerInfos.General.Object.Items.EnchantSystem
{
    public enum EnchantGrade
    {
        //ENCHANT_ERR_LV = 0,
        ENCHANT_LV0 = 0,
        ENCHANT_LV1 = (1 << 1),
        ENCHANT_LV2 = (1 << 2),
        ENCHANT_LV3 = (1 << 3),
        ENCHANT_LV4 = (1 << 4),
        ENCHANT_LV5 = (1 << 5),
        ENCHANT_LV6 = (1 << 6),
        ENCHANT_LV7 = (1 << 7),
        ENCHANT_LV8 = (1 << 8),
        ENCHANT_LV9 = (1 << 9),
        ENCHANT_LV10 = (1 << 10),
        ENCHANT_LV11 = (1 << 11),
        ENCHANT_LV12 = (1 << 12),
        ENCHANT_LV13 = (1 << 13),
        ENCHANT_LV14 = (1 << 14),
        ENCHANT_LV15 = (1 << 15),
        ENCHANT_LOW = ENCHANT_LV0 | ENCHANT_LV1 | ENCHANT_LV2 | ENCHANT_LV3 | ENCHANT_LV4 | ENCHANT_LV5,
        ENCHANT_MIDDLE = ENCHANT_LV6 | ENCHANT_LV7 | ENCHANT_LV8 | ENCHANT_LV9,
        ENCHANT_HIGH = ENCHANT_LV10 | ENCHANT_LV11,
        ENCHANT_HIGHEST = ENCHANT_LV12 | ENCHANT_LV13 | ENCHANT_LV14,
        ENCHANT_IMPOSIBLE = ENCHANT_LV15
    }
    public enum EnchantOption
    {
        ENCHANT_NOT_OPT = 0x00,
        ENCHANT_100PER = 0x01,
        ENCHANT_75PER = 0x02,
        ENCHANT_50PER = 0x04,
        ENCHANT_25PER = 0x08,
        ENCHANT_CASH = 0x10,
    };
}