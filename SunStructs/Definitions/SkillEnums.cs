using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
    public enum SkillType
    {
        SKILL_TYPE_PASSIVE = 1,
        SKILL_TYPE_ACTIVE,
        SKILL_TYPE_ACTIVE_INSTANT,
        SKILL_TYPE_ACTIVE_DELAYED,
        SKILL_TYPE_STYLE,               // ÀÏ¹Ý 3Å¸ °ø°Ý
        SKILL_TYPE_NORMAL,              // ÀÏ¹Ý 1, 2Å¸ °ø°Ý
        SKILL_TYPE_NORMAL_AREA,         // ÀÏ¹Ý ¹üÀ§°ø°Ý
        //
        SKILL_TYPE_UPPERBOUND           // no count, max number of types
    };
    public enum SkillFactorType
    {
        SKILL_FACTOR_NOMAL,             // ÀÏ¹ÝÀûÀÎ Å¬¶óÀÌ¾ðÆ®ÀÇ ½ºÅ³ »ç¿ë
        SKILL_FACTOR_ITEM,              // ¾ÆÀÌÅÛÀ» ÀÌ¿ëÇÑ ½ºÅ³ »ç¿ë( ½ºÅ³ ½½·ÔÀ» °¡ÁöÁö ¾Ê´Â´Ù. ½ºÅ³ ÄðÅ¸ÀÓ¾ø´Ù -> ¾ÆÀÌÅÛ ÄðÅ¸ÀÓ)
        SKILL_FACTOR_DOMINATION,        // ±æµåÁ¡·ÉÀüÀü¿ë ½ºÅ³ (½ºÅ³ ½½·ÔÀ» °¡ÁöÁö ¾Ê´Â´Ù.  ½ºÅ³ ÄðÅ¸ÀÓ¾ø´Ù -> Á¡·ÉÀü±æµå ÄðÅ¸ÀÓ)
        SKILL_FACTOR_EFFECT,            // ÀÌÆåÆ®°¡ »ç¿ëÇÏ´Â ½ºÅ³(½ºÅ³ÄðÅ¸ÀÓ ¾øÀ½)
    };

    // °ø°ÝÆÐÅ¶ÇÊµå¿­°Å : 4ºñÆ®
    public enum AttackPropensity
    {
        ATTACK_PROPENSITY_NORMAL = 0,   //ÀÏ¹Ý °ø°Ý
        ATTACK_PROPENSITY_FORCE,            //°­Á¦ °ø°Ý
    };

    public enum UserRelationType
    {
        USER_RELATION_NEUTRALIST = 0,       //Áß¸³ : ¹öÇÁ ºÒ°¡, °ø°Ý ºÒ°¡
        USER_RELATION_FRIEND,                   //¾Æ±º : ¹öÇÁ °¡´É, °ø°Ý ºÒ°¡
        USER_RELATION_ENEMY,                    //Àû±º : ¹öÇÁ ºÒ°¡, °ø°Ý °¡´É
    };
    public enum AbilityRangeType
    {
        SKILL_ABILITY_NONE = 0,    // f110309.1L, can't select
        SKILL_ABILITY_ENEMY = 1,    // 1 : Àû ´Ü¼ö
        SKILL_ABILITY_FRIEND,                       // 2 : ¾Æ±º ´Ü¼ö
        SKILL_ABILITY_TARGETAREA_ENEMY,             // 3 : ÁöÁ¤¹üÀ§³» Àû±º
        SKILL_ABILITY_TARGETAREA_FRIEND,            // 4 : ÁöÁ¤¹üÀ§³» ¾Æ±º
        SKILL_ABILITY_MYAREA_ENEMY,                 // 5 : ÀÚ±âÁß½É³» Àû±º
        SKILL_ABILITY_MYAREA_FRIEND,                // 6 : ÀÚ±âÁß½É³» ¾Æ±º
        SKILL_ABILITY_ME,                           // 7 : ÀÚ±âÀÚ½Å
        SKILL_ABILITY_FIELD,                        // 8 : ÇÊµå ÁÂÇ¥
        SKILL_ABILITY_CORPSE_RESURRECTION,          // 9 : ºÎÈ°À» À§ÇÑ ½ÃÃ¼(ÆÄÆ¼¿ø ½ÃÃ¼)
        SKILL_ABILITY_SUMMON,                       // 10 : ¼ÒÈ¯(Æ¯Á¤ Å¸°ÙÀÌ ¾ø´Â °æ¿ì)
        SKILL_ABILITY_CORPSE_FRIEND,                // 11 : ¾Æ±º ½ÃÃ¼(ÆÄÆ¼¿øÀÌ ¾Æ´Ï¶óµµ »ó°ü¾øÀ½)
        SKILL_ABILITY_CORPSE_RESURRECTION_MYAREA,   // 12 : ½ÃÃ¼( ºÎÈ°¿ëÀÌ¸ç, ÀÚ½Å°ú ÆÄÆ¼¿ø¸¸ Àû¿ë )
        SKILL_ABILITY_SUMMONED_MONSTER,             // 13 : ¼ÒÈ¯µÈ ¸ó½ºÅÍ
        SKILL_ABILITY_PLAYER_ENEMY,                 // 14 : Àû±º ´Ü¼ö ÇÃ·¹ÀÌ¾î
        SKILL_ABILITY_MYAREA_CORPSE_ENEMY,          // 15 : ÀÚ±âÁß½É³» Àû±º ½ÃÃ¼.
        SKILL_ABILITY_CORPSE_ENEMY,                 // 16 : Àû±º ½ÃÃ¼.
        SKILL_ABILITY_MAX
    };

    public enum SkillTargetType
    {
        SKILL_TARGET_NONE = 0,
        SKILL_TARGET_ENEMY,                         // 1 : Àû
        SKILL_TARGET_FRIEND,                        // 2 : ¾Æ±º
        SKILL_TARGET_ME,                            // 3 : ÀÚ½Å
        SKILL_TARGET_AREA,                          // 4 : Áö¿ª 
        SKILL_TARGET_FRIEND_CORPSE,                 // 5 : ÆÄÆ¼¿øÀÇ ½ÃÃ¼
        SKILL_TARGET_REACHABLE_ENEMY,               // 6 : Àû(Å¸°ÙÆÃÇÏ±âÀ§ÇØ¼­ Á¢±ÙÇÊ¿ä)
        SKILL_TARGET_REACHABLE_FRIEND,              // 7 : ¾Æ±º(Å¸°ÙÆÃÇÏ±âÀ§ÇØ¼­ Á¢±ÙÇÊ¿ä)
        SKILL_TARGET_REACHABLE_ME,                  // 8 : ÀÚ½Å(Å¸°ÙÆÃÇÏ±âÀ§ÇØ¼­ Á¢±ÙÇÊ¿ä)
        SKILL_TARGET_SUMMON,                        // 9 : Å¸°Ù¾øÀ½(¼ÒÈ¯)
        SKILL_TARGET_ENEMY_PLAYER,                  // 10 : ÀûÇÃ·¹ÀÌ¾î
        SKILL_TARGET_ENEMY_CORPSE,                  // 11 : Àû ½ÃÃ¼.
        SKILL_TARGET_AREA_ENEMY_CORPSE,             // 12 : ¹üÀ§ Àû ½ÃÃ¼.
        SKILL_TARGET_ENEMY_AND_ME,                  // 13 : Àû( ½ºÅ³Àû¿ë´ë»óÀº ÀÚ±âÀÚ½Å )
        SKILL_TARGET_MAX
    };

    public enum AbilityType
    {
        ABILITY_INVALID = 0,

        //-------------------------------------------------------------------------------------------------
        // ¼öÄ¡ °ü·Ã
        //-------------------------------------------------------------------------------------------------

        ABILITY_DAMAGE = 1,    // ½ºÅ³ µ¥¹ÌÁö
        ABILITY_DAMAGE_PER_TIME = 2,   // ½Ã°£´ç µ¥¹ÌÁö
        ABILITY_MAX_HP_INCREASE = 3,   // ÃÖ´ë HP Áõ°¡
        ABILITY_CUR_HP_INCREASE = 4,   // ÇöÀç HP Áõ°¡
        ABILITY_RECOVER_HP_INCREASE = 5,   // HP È¸º¹·® Áõ°¡
        ABILITY_EXHAUST_HP = 6,    // HP ¼ÒÁø

        ABILITY_MAX_MP_INCREASE = 7,   // ÃÖ´ë MP Áõ°¡
        ABILITY_CUR_MP_INCREASE = 8,   // ÇöÀç MP Áõ°¡
        ABILITY_RECOVER_MP_INCREASE = 9,   // MP È¸º¹·® Áõ°¡
        ABILITY_EXHAUST_MP = 10,   // MP ¼ÒÁø

        ABILITY_PHYSICAL_ATTACKPOWER_INCREASE = 11,    // ¹°¸® °ø°Ý·Â Áõ°¡
        ABILITY_ATTACKPOWER_BY_ARMORTYPE = 12, // EP2:unused, Ãß°¡ °ø°Ý·Â(¾Æ¸ÓÅ¸ÀÔº°)
        ABILITY_MAGIC_ATTACKPOWER_INCREASE = 13,   // ¸¶¹ý °ø°Ý·Â Áõ°¡

        ABILITY_PHYSICAL_DEFENSE_INCREASE = 14,    // ¹°¸® ¹æ¾î·Â Áõ°¡
        ABILITY_DEFENSE_BY_ATTACKTYPE = 15,    // EP2:unused, Ãß°¡ ¹æ¾î·Â(°ø°ÝÅ¸ÀÔº°)
        ABILITY_MAGIC_DEFENSE_INCREASE = 16,   // EP2:unused, ¸¶¹ý ¹æ¾î·Â Áõ°¡

        ABILITY_STAT_INCREASE = 17,    // ½ºÅÈ Áõ°¡

        ABILITY_PHYSICAL_ATTACKRATE_INCREASE = 18, // ¹°¸® °ø°Ý ¼º°øÀ² Áõ°¡
        ABILITY_PHYSICAL_AVOIDRATE_INCREASE = 19,  // ¹°¸® °ø°Ý È¸ÇÇÀ² Áõ°¡

        ABILITY_MOVE_SPEED_INCREASE = 20,  // ÀÌµ¿ ¼Óµµ Áõ°¡
        ABILITY_PHYSICAL_SPEED_INCREASE = 21,  // ¹°¸® °ø°Ý ¼Óµµ Áõ°¡

        ABILITY_CASTING_TIME_INCREASE = 22,    // Ä³½ºÆÃ Å¸ÀÓ Áõ°¡

        ABILITY_DAMAGE_DECREASE = 23,  // µ¥¹ÌÁö °¨¼Ò

        ABILITY_SKILLRANGE_INCREASE = 24,  // ½ºÅ³ »ç°Å¸® Áõ°¡

        ABILITY_CRITICAL_RATIO_CHANGE = 25,    // (ÀÚ½Å È¤Àº ÇÇ°ÝÀÚ °ø°ÝÀÇ) Å©¸®Æ¼ÄÃ È®·ü Áõ°¨
        ABILITY_CRITICAL_DAMAGE_CHANGE = 26,   // (ÀÚ½Å È¤Àº ÇÇ°ÝÀÚ °ø°ÝÀÇ) Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Áõ°¨

        ABILITY_AGGROPOINT_INCREASE = 27,  // ¾î±×·Î Æ÷ÀÎÆ® Áõ°¡

        ABILITY_SKILLDAMAGE_INCREASE = 28, // ½ºÅ³ µ¥¹ÌÁö Áõ°¡(CHANGUP_INTENSIFY_SKILLDAMAGE_STATUS)

        //-------------------------------------------------------------------------------------------------
        // »óÅÂ °ü·Ã
        //-------------------------------------------------------------------------------------------------

        ABILITY_STUN_STATUS = 100, // Stun »óÅÂ ¹ß»ý
        ABILITY_ABNORMAL_STATUS = 101, // ÀÌ»ó »óÅÂ ¹ß»ý
        ABILITY_WIND_SHIELD = 102, // À©µå½¯µå
        ABILITY_BUFF_RANGE_DAMAGE = 103,   // ¹öÇÁ ¹üÀ§ µ¥¹ÌÁö(ÀÏÁ¤¿µ¿ª, Ä³¸¯ÅÍ ÁÖº¯ÀÇ ½Ã°£´ç µ¥¹ÌÁö)

        ABILITY_LOWHP_ATTACKPOWER_CHANGE = 104,    // EP2:unused, HP ÀúÇÏ½Ã °ø°Ý·Â Áõ°¨
        ABILITY_LOWHP_DEFENSE_CHANGE = 105,    // EP2:unused, HP ÀúÇÏ½Ã ¹æ¾î·Â Áõ°¨
        ABILITY_BONUS_DAMAGE_PER_ATTACK = 106, // °ø°Ý´ç Ãß°¡ µ¥¹ÌÁö

        ABILITY_ATTACK_DAMAGE_HP_ABSORPTION = 107, // °ø°Ý µ¥¹ÌÁö HP Èí¼ö
        ABILITY_ATTACK_DAMAGE_MP_ABSORPTION = 108, // °ø°Ý µ¥¹ÌÁö MP Èí¼ö
        ABILITY_ATTACKED_DAMAGE_HP_ABSORPTION = 109,   // ÇÇ°Ý µ¥¹ÌÁö HP Èí¼ö
        ABILITY_ATTACKED_DAMAGE_MP_ABSORPTION = 110,   // ÇÇ°Ý µ¥¹ÌÁö MP Èí¼ö

        ABILITY_MAGIC_SHIELD = 111,    // ¸¶¹ý ½¯µå

        ABILITY_FEAR = 112,    // ÇÇ¾î

        ABILITY_REFLECT_DAMAGE = 113,  // ÇÇ°Ý µ¥¹ÌÁö(µ¥¹ÌÁö ¹Ý»ç)
        ABILITY_REFLECT_STUN = 114,    // ÇÇ°Ý ½ºÅÏ(µ¥¹ÌÁö + ¸ðµçÇàµ¿ºÒ´É)
        ABILITY_REFLECT_FEAR = 115,    // ÇÇ°Ý ÇÇ¾î(µ¥¹ÌÁö + µµ¸Á)
        ABILITY_REFLECT_FROZEN = 116,  // ÇÇ°Ý ÇÁ·ÎÁð(µ¥¹ÌÁö + ¸ðµçÇàµ¿ºÒ´É)

        ABILITY_REFLECT_SLOW = 117,    // ÇÇ°Ý Á·¼â(µ¥¹ÌÁö + ÀÌ¼ÓÀúÇÏ)
        ABILITY_REFLECT_SLOWDOWN = 118,    // ÇÇ°Ý µÐÈ­(µ¥¹ÌÁö + °ø¼ÓÀúÇÏ)

        //-------------------------------------------------------------------------------------------------
        // ±æµå ½Ã¼³ ¾îºô¸®Æ¼
        //-------------------------------------------------------------------------------------------------
        ABILITY_CRAFT_COST_RATIO = 150,  // Á¦ÀÛ ºñ¿ë Áõ°¨
        ABILITY_CRAFT_PREVENT_EXTINCTION_MATERIAL_RATIO = 151,  // Á¦ÀÛ ½ÇÆÐ½Ã Àç·á ¼Ò¸ê ¹æÁö È®·ü Áõ°¨
        ABILITY_ENCHANT_COST_RATIO = 152,  // ÀÎÃ¦Æ® ºñ¿ë Áõ°¨
        ABILITY_ENCHANT_PREVENT_DESTROY_N_DOWNGRADE_ITEM_RATIO = 153,  // ÀÎÃ¦Æ® ½ÇÆÐ½Ã ¾ÆÀÌÅÛ ¼Ò¸ê, ´Ù¿î ¹æÁö È®·ü Áõ°¨
        ABILITY_RECOVER_POTION_COOLTIME_RATIO = 154,  // È¸º¹ Æ÷¼Ç ÄðÅ¸ÀÓ Áõ°¨
        ABILITY_RECOVER_POTION_RECOVERY_RATIO = 155,  // È¸º¹ Æ÷¼Ç È¸º¹·® Áõ°¨
        ABILITY_QUEST_REWARD_EXP_RATIO = 156,  // Äù½ºÆ® º¸»ó °æÇèÄ¡ Áõ°¨
        ABILITY_MAX_DAMAGE_RATIO = 157,  // ÃÖ´ë µ¥¹ÌÁö ¹ß»ý È®·ü Áõ°¨
        ABILITY_MONEY_RAIO = 158,  // ÇÏÀÓ È¹µæ·® Áõ°¨
        ABILITY_DOMINATION_MAPOBJECT_DAMAGE_RATIO = 159,  // °ø¼º ¿ÀºêÁ§Æ® µ¥¹ÌÁö Áõ°¨
        ABILITY_SHOP_REPAIR_HEIM_RATIO = 160,  // »óÁ¡ ¼ö¸® ÇÏÀÓ Áõ°¨
        ABILITY_SHOP_BUY_HEIM_RATIO = 161,  // »óÁ¡ ±¸¸Å ÇÏÀÓ Áõ°¨

        //-------------------------------------------------------------------------------------------------
        ABILITY_MONSTER_KILL_EXP_RATIO = 162,  // ¸ó½ºÅÍ Ã³Ä¡ °æÇèÄ¡ Áõ°¨
                                                //-------------------------------------------------------------------------------------------------
                                                // ±âÅ¸
                                                //-------------------------------------------------------------------------------------------------

        ABILITY_STATUS_HEAL = 203, // »óÅÂ Ä¡·á
        ABILITY_RESURRECTION = 204,    // ºÎÈ°
        ABILITY_WEAPON_MASTERY = 205,  // ¿þÇÂ ¸¶½ºÅÍ¸®
        ABILITY_KNOCKBACK = 206,   // ³ì¹é
        ABILITY_FIGHTING_ENERGY_NUM_INCREASE = 207,    // Åõ±â °³¼ö Áõ°¡
        ABILITY_BONUS_DAMAGE_PER_FIGHTING_ENERGY = 208,    // Åõ±â´ç µ¥¹ÌÁö Ãß°¡
        ABILITY_BONUS_DAMAGE_PER_SP = 209, // SP´ç Ãß°¡ °ø°Ý·Â
        ABILITY_BONUS_DAMAGE_PER_STATUS = 210, // »óÅÂº° Ãß°¡ µ¥¹ÌÁö ¹ß»ý
        ABILITY_TELEPORT = 212,    // ÅÚ·¹Æ÷Æ®

        ABILITY_DRAGON_TRANSFORMATION1 = 213,  // µå·¡°ïº¯½Å1
        ABILITY_DRAGON_TRANSFORMATION2 = 214,  // µå·¡°ïº¯½Å2(º¸³Ê½º ´É·ÂÄ¡)
        ABILITY_DRAGON_TRANSFORMATION3 = 216,  // µå·¡°ïº¯½Å3(º¸³Ê½º ´É·ÂÄ¡)

        ABILITY_TARGET_CHANGE = 215,   // ¾î±×·Î²ø±â

        ABILITY_RANDOM_AREA_ATTACK = 217,  // ·£´ýÁö¿ª°ø°Ý
        ABILITY_SUMMON_TO_DIE = 218,   // ¼ÒÈ¯ÇØ¼­ Á×ÀÌ±â

        ABILITY_MONSTER_TRANSFORMATION = 219,  // ¸ó½ºÅÍ º¯½Å

        ABILITY_SUMMON = 220,  // ¼ÒÈ¯
        ABILITY_SUMMON_CHANGE_STATUS = 221,  // ¼ÒÈ¯½Ã ¼ÒÈ¯Ã¼ÀÇ ´É·ÂÄ¡¸¦ ÇÃ·¹ÀÌ¾îÀÇ ´É·ÂÄ¡·Î º¯°æ.

        ABILITY_PIERCE_ARROW = 223,    // ÇÇ¾î½º ¾Ö·Î¿ì

        ABILITY_SKILL_COOL_TIME_INCREASE = 225,  // ½ºÅ³ ÄðÅ¸ÀÓ Áõ°¨
        ABILITY_MP_SPEND_INCREASE = 226,  // ½ºÅ³ »ç¿ë½Ã MP·® Áõ°¨

        ABILITY_KNOCKBACK2 = 227,  // KNOCKBACK 2nd - __NA001048_080514_APPEND_ABILITY_KNOCKBACK2__
        ABILITY_ADRENALINE = 228,  // ¾Æµå·¹³¯¸°
        ABILITY_SUMMONMASTERY = 229,  // ¼­¸Õ¸¶½ºÅÍ¸®
        ABILITY_SELF_DESTRUCTION = 230,    // ÀÚÆø
                                            // __NA_S00015_20080828_NEW_HOPE_SHADOW
        ABILITY_BLOCK_SKILL = 301, // ½ºÅ³À» ¸·´Ù.(ÄÁÇ»Áî)
        ABILITY_ATTR_DEFENSIVE_POWER = 302,    // EP2:¿ø¼Ò ¹æ¾îÀ² Áõ°¨ <- EP1:¼Ó¼º¹æ¾î·Â Áõ°¨
        ABILITY_INCREASE_SKILL_ABILITY = 303,  // ½ºÅ³´É·ÂÁõ°¡.( Ä¿½ºÀÎÅ©¸®Áî )
        ABILITY_SUMMON_DEAD_MONSTER = 304, // Á×Àº ¸ó½ºÅÍ¼ÒÈ¯
        ABILITY_VITAL_SUCTION = 305,   // Á¤±âÈí¼ö
        ABILITY_ENCHANT_POISON = 306,  // ÀÎÃ¾Æ®Æ÷ÀÌÁð
        ABILITY_SUCTION_HPMP = 307,    // HP, MPÈí¼ö
        ABILITY_DARK_STUN = 308,   // ´ÙÅ©½ºÅÏ
        ABILITY_HIDE = 309,    // ÇÏÀÌµå.
        ABILITY_DARK_BREAK = 310,  // ´ÙÅ©ºê·¹ÀÌÅ©.
        ABILITY_ATTR_ATTACK_POWER = 311,   // ¼Ó¼º °ø°Ý·Â Áõ°¨.
        ABILITY_CANCEL_STATUS = 312,   // »óÅÂÇØÁ¦.
        ABILITY_CHANGE_ATTR = 313, // ¼Ó¼º°ª º¯°æ.
                                    // end of shadow
        ABILITY_RECOVERY_CHANCE = 314, // Àû¸³µÈ HP ºñÀ² Áõ°¡.
                                        //{_NA_001231_20081216_ADD_OPTION_KIND
        ABILITY_RESIST_HOLDING = 315,  // È¦µù ³»¼º.
        ABILITY_RESIST_SLEEP = 316,    // ½½¸³ ³»¼º.
        ABILITY_RESIST_POISON = 317,   // Áßµ¶ ³»¼º.
        ABILITY_RESIST_KNOCKBACK = 318,    // ³Ë¹é ³»¼º.
        ABILITY_RESIST_DOWN = 319, // ´Ù¿î ³»¼º.
        ABILITY_RESIST_STUN = 320, // ½ºÅÏ ³»¼º.
        ABILITY_DECREASE_PVPDAMAGE = 321,  // PVP´ë¹ÌÁö °¨¼Ò.
                                            //}
                                            //ABILITY_RESIST_ATTACK						= 322,	// unused, °ø°Ý ³»¼º. __NA_001244_20090417_ATTACK_RESIST
                                            //__NA_001290_20090525_SHIELD_SYSTEM
        ABILITY_MAX_SD_INCREASE = 323, // ÃÖ´ë SD Áõ°¡
        ABILITY_RECOVER_SD_INCREASE = 324, // SD È¸º¹·® Áõ°¡
                                            //_NA001385_20090924_DOMINATION_SKILL
        ABILITY_SUMMON_CRYSTALWARP = 325,  // Å©¸®½ºÅ» ¿öÇÁ(±æµå¼ÒÈ¯¹°)¼ÒÈ¯
        ABILITY_SUMMON_CRYSTALWARP_DESTROY = 326,  // Å©¸®½ºÅ» ¿öÇÁ(±æµå¼ÒÈ¯¹°)¼ÒÈ¯ ÇØÁ¦
        ABILITY_TOTEM_NPC_OPTION_EMPOWERMENT = 327, // TotemNpc ¿É¼Ç ºÎ¿©

        kAbilityIncreseHeal = 328, // Ä¡À¯·® Áõ°¡
        kAbilityActiveComboSkill = 329, // ¿¬°è ½ºÅ³ È°¼ºÈ­
        kAbilityComboSkillEffectAddDamage = 330, // ¿¬°è ½ºÅ³ ¹ßµ¿ È¿°ú - µ¥¹ÌÁö Ãß°¡
        kAbilityComboSkillEffectAddBadStatus = 331, // ¿¬°è ½ºÅ³ ¹ßµ¿ È¿°ú - »óÅÂÀÌ»ó È®·ü/Áö¼Ó½Ã°£ Áõ°¡
        kAbilityActiveIncreseSkillDamage = 332, // ½ºÅ³ µ¥¹ÌÁö Áõ°¡ »óÅÂ ¹ßµ¿
        kAbilityIncreseSkillDamage = 333, // ½ºÅ³ µ¥¹ÌÁö Áõ°¡

        ABILITY_DETECTING_HIDE = 334, // Àº½ÅÃ¼ °¨Áö
        ABILITY_PULLING = 335, // ´ç±â±â(³Ë¹éÀÇ ¹Ý´ë)
                                //ABILITY_BLIND                                = 336, // ½Ç¸í»óÅÂ  => ABILITY_ABNORMAL_STATUS
                                //ABILITY_GRAVITY                              = 337, // Áß·Â Áõ°¡ => ABILITY_ABNORMAL_STATUS
                                //ABILITY_POLYMORPH                            = 338, // µ¿¹°·Î º¯Çü½ÃÅ°´Â ¸¶¹ý => ABILITY_ABNORMAL_STATUS
        ABILITY_ROLLING_BOMB = 339, // ·Ñ¸µ¹ã
        ABILITY_QUICKSTEP = 340, // ºü¸¥ ÀÌµ¿
        ABILITY_FUGITIVE = 341, // ÀüÀå µµ¸ÁÀÚ ¹öÇÁ
        ABILITY_CUR_SD_INCREASE = 343, // ÇöÀçSDÁõ°¨
        ABILITY_SKILL_STATE_IGNORE = 344, // ½ºÅ³»óÅÂ¹«½Ã
        ABILITY_VARIATION_PUREVALUE_HP = 345, // ½ºÅ³°ø°Ý·Â,¹æ¾î·Â,ÀúÇ×·Â,¸ÅÁ÷½¯µå,SDµî¿¡ ¿µÇâ¹ÞÁö¾Ê´Â Ã¼·Â Áõ°¨
        ABILITY_AURORA = 347, // ¿À·Î¶ó ½ºÅ³
        ABILITY_FP_CHANGE = 348, // FP Ãß°¡/¼Ò¸ð (1È¸¼º)
        ABILITY_FP_TOGGLE = 349, // FP Ãß°¡/¼Ò¸ð (ÁÖ±â¼º)

        ABILITY_CHARMED = 351, // ¸ÅÈ¤ (½ÃÀüÀÚ¸¦ µû¶ó¿À°Ô ÇÑ´Ù)
        ABILITY_REFLECT_LINK_SKILL = 352,  // ÇÇ°Ý½Ã ½ºÅ³»ç¿ë(µ¥¹ÌÁö + ½ºÅ³)
        ABILITY_INCREASE_DAMAGE = 353,  // µ¥¹ÌÁö Áõ°¡
        ABILITY_AUTOCAST_BYATTACK = 354,  // ÃâÇ÷°ø°Ý ¹öÇÁ
        ABILITY_SKILL_CONDITION = 355,  // ½ºÅ³ Á¶°Ç°Ë»ç¿ë ¾îºô¸®Æ¼
        ABILITY_OVERLAP_STATE = 356,  // ÁßÃ¸ ¾îºô¸®Æ¼
        ABILITY_SUMMON_IMMOVABLE = 357,  // °íÁ¤Çü ¼ÒÈ¯¼ö(À§Ä¡ºí·¹ÀÌµå)
        ABILITY_SUMMON_CHANGE_STATUS_EXTEND = 358,  // ¼ÒÈ¯ÀÚÀÇ ´É·ÂÄ¡ ÀÏºÎ, ¼ÒÈ¯¼ö°¡ ¹Þ¾Æ¿È, 221¾îºô¸®Æ¼ÀÇ È®Àå¾îºô¸®Æ¼

        ABILITY_AWAKENING_PROBABILITY = 359,  // °¢¼º È®·ü Áõ°¨
        ABILITY_MAX
    };
}
