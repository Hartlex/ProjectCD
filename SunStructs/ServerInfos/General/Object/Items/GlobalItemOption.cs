using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using static SunStructs.Definitions.AttrType;

namespace SunStructs.ServerInfos.General.Object.Items
{
    public static class GlobalItemOption
    {
        private static readonly AttrType[] _attrTypes = new AttrType[]
        {
            ATTR_TYPE_INVALID, //[  0] ¾øÀ½ (ÃÊ±â°ª)
            ATTR_ATTACK_SPEED, //[  1] ÀüÃ¼°ø°Ý¼ÓµµÃß°¡
            ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, //[  2] ÀüÃ¼°ø°Ý¼º°øÀ²Ãß°¡À²
            ATTR_MAGICAL_FIRE_ATTACK_POWER, //[  3] [V] ¿ø¼Ò(ºÒ) °ø°Ý·Â
            ATTR_MAGICAL_WATER_ATTACK_POWER, //[  4] [V] ¿ø¼Ò(¹°) °ø°Ý·Â
            ATTR_MAGICAL_EARTH_ATTACK_POWER, //[  5] [V] ¿ø¼Ò(¹Ù¶÷) °ø°Ý·Â
            ATTR_MAGICAL_WIND_ATTACK_POWER, //[  6] [V] ¿ø¼Ò(´ëÁö) °ø°Ý·Â
            ATTR_MAGICAL_DARKNESS_ATTACK_POWER, //[  7] [V] ¿ø¼Ò(¾ÏÈæ) °ø°Ý·Â
            ATTR_DEL_PHYSICAL_TARGET_DEFENSE_RATIO, //[  8] [R] °ø°Ý´ë»ó ¹°¸® ¹æ¾î·Â °¨¼ÒÀ²
            ATTR_DEL_FIRE_TARGET_DEFENSE_RATIO, //[  9] [R] °ø°Ý´ë»ó ¿ø¼Ò(ºÒ) ¹æ¾î·Â °¨¼ÒÀ²
            ATTR_DEL_WATER_TARGET_DEFENSE_RATIO, //[ 10] [R] °ø°Ý´ë»ó ¿ø¼Ò(¹°) ¹æ¾î·Â °¨¼ÒÀ²
            ATTR_DEL_EARTH_TARGET_DEFENSE_RATIO, //[ 11] [R] °ø°Ý´ë»ó ¿ø¼Ò(¹Ù¶÷) ¹æ¾î·Â °¨¼ÒÀ²
            ATTR_DEL_WIND_TARGET_DEFENSE_RATIO, //[ 12] [R] °ø°Ý´ë»ó ¿ø¼Ò(´ëÁö) ¹æ¾î·Â °¨¼ÒÀ²
            ATTR_DEL_DARKNESS_TARGET_DEFENSE_RATIO, //[ 13] [R] °ø°Ý´ë»ó ¿ø¼Ò(¾ÏÈæ) ¹æ¾î·Â °¨¼ÒÀ²
            ATTR_MOVE_SPEED, //[ 14] ÀÌµ¿¼ÓµµÃß°¡
            ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, //[ 15] [R] °ø°Ý ¹æ¾îÀ² Ãß°¡À²
            ATTR_MAGICAL_FIRE_DEFENSE_POWER, //[ 16] EP2:unused, [V] ¸¶¹ý¼Ó¼ºÀúÇ×(ºÒ)
            ATTR_MAGICAL_WATER_DEFENSE_POWER, //[ 17] EP2:unused, [V] ¸¶¹ý¼Ó¼ºÀúÇ×(¹°)
            ATTR_MAGICAL_EARTH_DEFENSE_POWER, //[ 18] EP2:unused, [V] ¸¶¹ý¼Ó¼ºÀúÇ×(´ëÁö)
            ATTR_MAGICAL_WIND_DEFENSE_POWER, //[ 19] EP2:unused, [V] ¸¶¹ý¼Ó¼ºÀúÇ×(¹Ù¶÷)
            ATTR_MAGICAL_DARKNESS_DEFENSE_POWER, //[ 20] EP2:unused, [V] ¸¶¹ý¼Ó¼ºÀúÇ×(¾ÏÈæ)
            ATTR_OPTION_ALL_ATTACK_POWER, //[ 21] EP2:unused, ¿É¼Ç ÀüÃ¼ ¹°¸® °ø°Ý·Â, EP2: 47°ú µ¿ÀÏ
            ATTR_OPTION_ALL_DEFENSE_POWER, //[ 22] EP2:unused, ¿É¼Ç ÀüÃ¼ ¹°¸® ¹æ¾î·Â, EP2: 49¿Í µ¿ÀÏ
            ATTR_STR, //[ 23] ½ºÅÈ(Èû)
            ATTR_DEX, //[ 24] ½ºÅÈ(¹ÎÃ¸)
            ATTR_INT, //[ 25] ½ºÅÈ(Áö·Â)
            ATTR_VIT, //[ 26] ½ºÅÈ(Ã¼·Â)
            ATTR_SPR, //[ 27] ½ºÅÈ(Á¤½Å·Â)
            ATTR_MAX_HP, //[ 28] ÃÖ´ë HP
            ATTR_MAX_MP, //[ 29] ÃÖ´ë MP/SP
            ATTR_ADD_SKILL_ATTACK_POWER, //[ 30] ½ºÅ³ Ãß°¡ °ø°Ý·Â
            ATTR_ADD_SKILL_DAMAGE_RATIO, //[ 31] ½ºÅ³ µ¥¹ÌÁö Ãß°¡À²
            ATTR_INCREASE_STAT_POINT, //[ 32] ¸ðµç ½ºÅÝ
            //[2006 ¿ÀÈÄ 1:23:22
            ATTR_DECREASE_LIMIT_STAT, //[ 33] ½ºÅÝ Á¦ÇÑ ¼öÄ¡ °¨¼Ò
            ATTR_MP_SPEND_INCREASE, //[ 34] MP ¼Òºñ Áõ°¨
            ATTR_MAGICAL_ALL_ATTACK_POWER, //[ 35] ¸ðµç ¿ø¼Ò °ø°Ý·Â
            ATTR_MAGICAL_ALL_DEFENSE_POWER, //[ 36] EP1: ¸ðµç ¿ø¼Ò ¹æ¾î·Â
            //[20061206 ¿ÀÀü 10:30:01
            ATTR_ABSORB_HP, //[ 37] HP Èí¼ö
            ATTR_ABSORB_MP, //[ 38] MP/SP Èí¼ö
            ATTR_RECOVERY_HP, //[ 39] HP È¸º¹·®
            ATTR_RECOVERY_MP, //[ 40] MP È¸º¹·®
            ATTR_ADD_ALL_CRITICAL_RATIO, //[ 41] ÀüÃ¼ Å©¸®Æ¼ÄÃ È®·ü
            ATTR_CRITICAL_DAMAGE_CHANGE, //[ 42] Å©¸®Æ¼ÄÃ µ¥¹ÌÁö
            ATTR_REFLECT_DAMAGE_RATIO, //[ 43] µ¥¹ÌÁö ¹Ý»ç
            ATTR_BONUS_MONEY_RATIO, //[ 44] ÇÏÀÓ Áõ°¡
            ATTR_BONUS_EXP_RATIO, //[ 45] °æÇèÄ¡ Áõ°¡
            ATTR_AREA_ATTACK_RATIO, //[ 46] ´ÙÁß°ø°Ý È®·ü
            ATTR_OPTION_PHYSICAL_ATTACK_POWER, //[ 47] ¹°¸® °ø°Ý·Â
            ATTR_OPTION_MAGICAL_ATTACK_POWER, //[ 48] EP2:unused, ¸¶¹ý °ø°Ý·Â
            ATTR_OPTION_PHYSICAL_DEFENSE_POWER, //[ 49] ¹°¸® ¹æ¾î·Â
            ATTR_OPTION_MAGICAL_DEFENSE_POWER, //[ 50] EP2:unused, ¸¶¹ý ¹æ¾î·Â
            ATTR_DECREASE_DAMAGE, //[ 51] µ¥¹ÌÁö °¨¼Ò (Àû¿ë ½ÃÁ¡: Àû¿ëÇÒ µ¥¹ÌÁö ÀÚÃ¼¸¦ °¨¼Ò½ÃÅ²´Ù.)
            ATTR_RESURRECTION_RATIO, //[ 52] »ç¸Á½Ã ½º½º·Î ºÎÈ° ÇÒ È®·ü
            ATTR_DOUBLE_DAMAGE_RATIO, //[ 53] µ¥¹ÌÁöÀÇ µÎ¹è°¡ µÉ È®·ü
            ATTR_LUCKMON_INC_DAMAGE, //[ 54] ·°Å° ¸ó½ºÅÍ °ø°Ý½Ã Ãß°¡ µ¥¹ÌÁö
            ATTR_COPOSITE_INC_RATIO, //[ 55] Á¶ÇÕ ¼º°ø·ü Áõ°¡
            ATTR_BYPASS_DEFENCE_RATIO, //[ 56] ¹æ¾î·Â ¹«½Ã È®À²
            ATTR_INCREASE_MIN_DAMAGE, //[ 57] ÃÖ¼Ò µ¥¹ÌÁö Áõ°¡
            ATTR_INCREASE_MAX_DAMAGE, //[ 58] ÃÖ´ë µ¥¹ÌÁö Áõ°¡
            ATTR_DECREASE_ITEMDURA_RATIO, //[ 59] ¾ÆÀÌÅÛ ³»±¸·Â °¨¼Ò¹«½Ã È®À²
            ATTR_RESISTANCE_BADSTATUS_RATIO, //[ 60] ½ºÅ³ È¿°ú ¹«½ÃÈ®À²
            ATTR_INCREASE_SKILLDURATION, //[ 61] ½ºÅ³ Áö¼Ó ½Ã°£ Áõ°¡ (¹öÇÁ °è¿­)
            ATTR_DECREASE_SKILL_SKILLDURATION, //[ 62] ½ºÅ³ Áö¼Ó ½Ã°£ Áõ°¨ (µð¹öÇÁ °è¿­) < f110531.6L, changed from '°¨¼Ò'
            ATTR_OPTION_ETHER_DAMAGE_RATIO, //[ 63] ¿¡Å×¸£¿þÆù µ¥¹ÌÁö º¯È­ (EP2:reserve deletion)
            ATTR_INCREASE_RESERVE_HP, //[ 64] Àû¸³ HP Áõ°¡
            ATTR_BONUS_CASTING_TIME, //[ 65] ½ºÅ³ Ä³½ºÆÃ ½Ã°£ Áõ°¨.
            ATTR_RESIST_HOLDING, //[ 66] È¦µù ³»¼º
            ATTR_RESIST_SLEEP, //[ 67] ½½¸³ ³»¼º
            ATTR_RESIST_POISON, //[ 68] Áßµ¶ ³»¼º
            ATTR_RESIST_KNOCKBACK, //[ 69] ³Ë¹é ³»¼º
            ATTR_RESIST_DOWN, //[ 70] ´Ù¿î ³»¼º
            ATTR_RESIST_STUN, //[ 71] ½ºÅÏ ³»¼º
            ATTR_DECREASE_PVPDAMAGE, //[ 72] PVPµ¥¹ÌÁö °¨¼Ò (Àû¿ë ½ÃÁ¡:[51:µ¥¹ÌÁö°¨¼Ò] Àû¿ë½Ã PvPÇÑÁ¤ Ãß°¡ °è»ê)
            ATTR_ADD_DAMAGE, //[ 73] Ãß°¡µ¥¹ÌÁö (Àû¿ë ½ÃÁ¡: ±âº» µ¥¹ÌÁö °ø½Ä ¸¶Áö¸·)
            ATTR_AUTO_ITEM_PICK_UP, //[ 74] Item ÀÚµ¿ ÁÝ±â
            // __NA_001244_20090417_ATTACK_RESIST
            // CHANGES: f110103.4L, block contents about PvP resist attributes. ranges = [75, 92]
            ATTR_BONUS_SKILL_COOL_TIME, //[ 75] [R] ½ºÅ³ ÄðÅ¸ÀÓ Áõ°¨ (EP2)
            ATTR_OPTION_ETHER_PvE_DAMAGE_RATIO, //[ 76] ¿¡Å×¸£¿þÆù µ¥¹ÌÁö º¯È­ (PvE)
            ATTR_INCREASE_ENCHANT_RATIO, // [77] ÀÎÃ¾Æ® ¼º°ø·ü Áõ°¡
            ATTR_TYPE_INVALID, // [78]  ATTR_RESIST_NOMALATTACK_BERSERKER, //  78 ¹ö¼­Ä¿ ÀÏ¹Ý°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [79]  ATTR_RESIST_SKILLATTACK_BERSERKER, //  79 ¹ö¼­Ä¿ ½ºÅ³°ø°Ý ³»¼º.
            ATTR_TYPE_INVALID, // [80]  ATTR_RESIST_ALLATTACK_BERSERKER, //  80 ¹ö¼­Ä¿ ¸ðµç°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [81]  ATTR_RESIST_NOMALATTACK_VALKYRIE, //  81 ¹ßÅ°¸® ÀÏ¹Ý°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [82]  ATTR_RESIST_SKILLATTACK_VALKYRIE, //  82 ¹ßÅ°¸® ½ºÅ³°ø°Ý ³»¼º.
            ATTR_TYPE_INVALID, // [83]  ATTR_RESIST_ALLATTACK_VALKYRIE, //  83 ¹ßÅ°¸® ¸ðµç°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [84]  ATTR_RESIST_NOMALATTACK_DRAGON, //  84 µå·¡°ï ÀÏ¹Ý°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [85]  ATTR_RESIST_SKILLATTACK_DRAGON, //  85 µå·¡°ï ½ºÅ³°ø°Ý ³»¼º.
            ATTR_TYPE_INVALID, // [86]  ATTR_RESIST_ALLATTACK_DRAGON, //  86 µå·¡°ï ¸ðµç°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [87]  ATTR_RESIST_NOMALATTACK_ELEMENTALIST, //  87 ¿¤¸® ÀÏ¹Ý°ø°Ý ³»¼º.  
            ATTR_TYPE_INVALID, // [88]  ATTR_RESIST_SKILLATTACK_ELEMENTALIST, //  88 ¿¤¸® ½ºÅ³°ø°Ý ³»¼º.  
            ATTR_TYPE_INVALID, // [89]  ATTR_RESIST_ALLATTACK_ELEMENTALIST, //  89 ¿¤¸® ¸ðµç°ø°Ý ³»¼º.  
            ATTR_TYPE_INVALID, // [90]  ATTR_RESIST_NOMALATTACK_SHADOW, //  90 ¼âµµ¿ì ÀÏ¹Ý°ø°Ý ³»¼º.     
            ATTR_TYPE_INVALID, // [91]  ATTR_RESIST_SKILLATTACK_SHADOW, //  91 ¼âµµ¿ì ½ºÅ³°ø°Ý ³»¼º. 
            ATTR_TYPE_INVALID, // [92]  ATTR_RESIST_ALLATTACK_SHADOW, //  92 ¼âµµ¿ì ¸ðµç°ø°Ý ³»¼º. 
            // __NA_001290_20090525_SHIELD_SYSTEM
            ATTR_MAX_SD, //[ 93] ÃÖ´ë SD
            ATTR_RECOVERY_SD, //[ 94] SD È¸º¹·®
            ATTR_DEL_MAGICAL_TARGET_DEFENSE_RATIO, //[ 95] EP2:unused, °ø°Ý´ë»ó ¸¶¹ý ¹æ¾î·Â °¨¼Ò
            ATTR_ENEMY_CRITICAL_RATIO_CHANGE, //[ 96] ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ È®·ü °¨¼Ò
            ATTR_PREMIUMSERVICE_PCBANG, //[ 97] PC¹æ È¿°ú

            //_NA_006680_20130426_ITEM_OPTION_ADD_AND_MODIFY
            ATTR_ATTACK_DAMAGE_ABSORB_SD_RATIO, //[ 98] °¡ÇØ µ¥¹ÌÁö SD ÀüÈ¯·®
            ATTR_ATTACK_DAMAGE_ABSORB_HP_RATIO, //[ 99] °¡ÇØ µ¥¹ÌÁö HP ÀüÈ¯·®

            //_NA_007330_20140620_GUILD_SYSTEM_EXTENSION
            ATTR_ENEMY_CRITICAL_DAMAGE_CHANGE, //[100]ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Áõ°¨
            ATTR_CRAFT_COST_RATIO, // [101] Á¦ÀÛ ºñ¿ë Áõ°¨
            ATTR_CRAFT_PREVENT_EXTINCTION_MATERIAL_RATIO, // [102] Á¦ÀÛ ½ÇÆÐ½Ã Àç·á ¼Ò¸ê ¹æÁö
            ATTR_ENCHANT_COST_RATIO, // [103] ÀÎÃ¦Æ® ºñ¿ë Áõ°¨
            ATTR_ENCHANT_PREVENT_DESTROY_N_DOWNGRADE_ITEM_RATIO, // [104] ÀÎÃ¦Æ® ½ÇÆÐ½Ã ¾ÆÀÌÅÛ ¼Ò¸ê, ´Ù¿î ¹æÁö
            ATTR_RECOVER_POTION_COOLTIME_RATIO, // [105] È¸º¹ Æ÷¼Ç ÄðÅ¸ÀÓ °¨¼Ò
            ATTR_RECOVER_POTION_RECOVERY_RATIO, // [106] È¸º¹ Æ÷¼Ç È¸º¹·® Áõ°¡
            ATTR_QUEST_REWARD_EXP_RATIO, // [107] Äù½ºÆ® º¸»ó °æÇèÄ¡ Áõ°¡
            ATTR_MAX_DAMAGE_RATIO, // [108] ÃÖ´ë µ¥¹ÌÁö ¹ß»ýÈ®·ü Áõ°¨
            ATTR_DOMINATION_MAPOBJECT_DAMAGE_RATIO, // [109] °ø¼º ¿ÀºêÁ§Æ® µ¥¹ÌÁö Áõ°¨
            ATTR_SHOP_REPAIR_HEIM_RATIO, // [110] »óÁ¡ ¼ö¸® ÇÏÀÓ Áõ°¨
            ATTR_SHOP_BUY_HEIM_RATIO, // [111] »óÁ¡ ±¸¸Å ÇÏÀÓ Áõ°¨

            ATTR_MAX_FP, // [112] À§Ä¡ºí·¹ÀÌµå ÃÖ´ëFP
            ATTR_RECOVERY_FP, // [113] À§Ä¡ºí·¹ÀÌµå FPÈ¸º¹·® (°ø°Ý½Ã)
            ATTR_INCREASE_DAMAGE_RATIO, // [114] µ¥¹ÌÁö Áõ°¡ 
            //_NA_008124_20150313_AWAKENING_SYSTEM
            ATTR_AWAKENING_PROBABILITY, // [115] °¢¼º È®·ü Áõ°¨

            //_NA_008486_20150914_TOTAL_BALANCE
            ATTR_DEBUFF_DURATION, // [116] ÀÚ»êÀÌ¤Ñ µð¹öÇÁ±â¼ú È¿°úÁö¼Ó½Ã°£ °­È­(ms)

            //_NA_008540_20151027_ADD_ITEMOPTION_ELITE4
            ATTR_DECREASE_DAMAGE_NPC, // [117] npc°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_BERSERKER, // [118] ¹ö¼­Ä¿°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_DRAGONKNIGHT, // [119] µå·¡°ï³ªÀÌÆ®°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_VALKYRIE, // [120] ¹ßÅ°¸®°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_ELEMENTALIST, // [121] ¿¤¸®¸àÅ»¸®½ºÆ®°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_SHADOW, // [122] ¼¨µµ¿ì°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_MYSTIC, // [123] ¹Ì½ºÆ½ÀÌ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_HELLROID, // [124] Çï·ÎÀÌµå°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
            ATTR_DECREASE_DAMAGE_WITCHBLADE, // [125] À§Ä¡ºí·¹ÀÌµå°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
};

        public static AttrType GetItemAttrOption(int index)
        {
            return _attrTypes[index];
        }
    }
}
