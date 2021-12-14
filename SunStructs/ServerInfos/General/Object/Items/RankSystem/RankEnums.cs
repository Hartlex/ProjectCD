using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.ServerInfos.General.Object.Items.RankSystem
{
    public enum Rank
    {
        RANK_F = -1,        //< ·¹¾î ¾ÆÀÌÅÛ µî±Þ½Ã »ç¿ë
        RANK_E = 0,
        RANK_D,
        RANK_C,
        RANK_B,
        RANK_MA,
        RANK_A,
        RANK_PA,
        RANK_MS,
        RANK_S,
        RANK_PS,
        RANK_MAX,
    };
    public enum RankOptionItemType
    {
        RANK_OPTION_ITEM_WEAPON = 0,
        RANK_OPTION_ITEM_ARMOR = 1,
        RANK_OPTION_ITEM_RING = 2,
        RANK_OPTION_ITEM_NECKLACE = 3,
        RANK_OPTION_ITEM_SACCESSORY_BERSERKER = 4,
        RANK_OPTION_ITEM_SACCESSORY_DRAGON = 5,
        RANK_OPTION_ITEM_SACCESSORY_SHADOW = 6,
        RANK_OPTION_ITEM_SACCESSORY_VALKYRIE = 7,
        RANK_OPTION_ITEM_SACCESSORY_ELEMENTALIST = 8,
        RANK_OPTION_ITEM_TYPE_MAX,
    };
    public enum RankLevel
    {
        RANK_LOW = 0,   //< E ~ B
        RANK_MIDDLE = 1,    //< -A ~ +A
        RANK_HIGH = 2,  //< -S ~ +S
    };
}
