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
    public enum CharStateType
    {
        CHAR_STATE_INVALID = 0,

        //-------------------------------------------------------------------------------------------------
        // »óÅÂÀÌ»ó
        //-------------------------------------------------------------------------------------------------
        CHAR_STATE_CHAOS = 1,      // È¥µ·(¾Æ¹«³ª °ø°Ý)
        CHAR_STATE_BLIND = 2,      // ºí¶óÀÎµå(Àå´Ô)
        CHAR_STATE_DOWN = 3,       // ´Ù¿î(¸ðµç Çàµ¿ ºÒ´É)
        CHAR_STATE_DELAY = 4,      // µô·¹ÀÌ
        CHAR_STATE_SEALING = 5,        // ºÀÀÎ(¸¶¹ý½ºÅ³ ºÀÀÎ)
        CHAR_STATE_STUN = 6,       // ½ºÅÏ(¸ðµç Çàµ¿ ºÒ´É)
        CHAR_STATE_STONE = 7,      // ¼®È­(¸ðµç Çàµ¿ ºÒ´É, °ø°Ý¹ÞÁö ¾ÊÀ½)
        CHAR_STATE_SLEEP = 8,      // ½½¸³(¸ðµç Çàµ¿ ºÒ´É, °ø°ÝÀ» ¹ÞÀ¸¸é ÇØÁ¦)
        CHAR_STATE_FROZEN = 9,     // ÇÁ·ÎÁð(¸ðµç Çàµ¿ ºÒ´É)
        CHAR_STATE_SEQUELA = 10,       // ÈÄÀ¯Áõ(ºÎÈ°ÀÌÈÄ ´É·Â ÀúÇÏ)
        CHAR_STATE_UPPERDOWN = 11,       // ¾îÆÛ´Ù¿î (°øÁß¿¡ ¶ä, ¸ðµç Çàµ¿ ºÒ´É) //_NA_007617_20140916_ADD_CHARSTATE_UPPERDOWN

        //-------------------------------------------------------------------------------------------------
        // »óÅÂ¾àÈ­
        //-------------------------------------------------------------------------------------------------
        CHAR_STATE_POISON = 100,       // Áßµ¶(Áö¼ÓÀû µ¥¹ÌÁö)
        CHAR_STATE_WOUND = 101,        // »óÃ³(Áö¼ÓÀû µ¥¹ÌÁö)
        CHAR_STATE_FIRE_WOUND = 102,       // È­»ó(Áö¼ÓÀû µ¥¹ÌÁö)
        CHAR_STATE_PANIC = 103,        // °øÈ²(MP °¨¼Ò)
        CHAR_STATE_LOW_SPIRIT = 104,       // ¹«±â·Â(°ø°Ý·Â °¨¼Ò)
        CHAR_STATE_WEAKENING = 105,        // ¾àÃ¼(¹æ¾î·Â °¨¼Ò)
        CHAR_STATE_ATTACK_FAIL = 106,      // ½ÇÆÐ(°ø°Ý¼º°ø·ü ÀúÇÏ)
        CHAR_STATE_FRUSTRATION = 107,      // ÁÂÀý(ºí·Ï¼º°ø·ü ÀúÇÏ)
        CHAR_STATE_FETTER = 108,       // Á·¼â(ÀÌµ¿¼Óµµ ÀúÇÏ)
        CHAR_STATE_SLOWDOWN = 109,     // µÐÈ­(°ø°Ý¼Óµµ ÀúÇÏ)
        CHAR_STATE_HP_REDUCE = 110,        // ¿ª·ù(HP °¨¼Ò)	
        CHAR_STATE_MP_REDUCE = 111,        // °¨¼Ó(MP °¨¼Ò)
        CHAR_STATE_LOW_STRENGTH = 112,     // Ã¼·ÂÀúÇÏ(HP È¸º¹·® °¨¼Ò)
        CHAR_STATE_DICLINE = 113,      // µðÅ¬¶óÀÎ(MP È¸º¹·® °¨¼Ò)
        CHAR_STATE_MAGIC_EXPOSE = 114,     // ¸¶¹ý³ëÃâ(¸¶¹ý¹æ¾î·Â °¨¼Ò)
        CHAR_STATE_HPRATE_REDUCE = 116,        // ¾àÁ¡(HP È¸º¹·ü °¨¼Ò)
        CHAR_STATE_MPRATE_REDUCE = 117,        // Àå¾Ö(MP È¸º¹·ü °¨¼Ò)

        CHAR_STATE_MAGIC_ATTACK_DECRESE = 123,     // ¸¶¹ý°ø°Ý ÀúÇÏ
        CHAR_STATE_STAT_STR_DECRESE = 124,     // Èû °¨¼Ò
        CHAR_STATE_STAT_DEX_DECRESE = 125,     // ¹ÎÃ¸ °¨¼Ò
        CHAR_STATE_STAT_VIT_DECRESE = 126,     // Ã¼·Â °¨¼Ò
        CHAR_STATE_STAT_INT_DECRESE = 127,     // Á¤½Å·Â °¨¼Ò
        CHAR_STATE_STAT_SPI_DECRESE = 128,     // Áö·Â °¨¼Ò

        CHAR_STATE_STAT_LOWHP_ATTACK_DECREASE = 129,   // ¹°¸®°ø°Ý ÀúÇÏ
        CHAR_STATE_STAT_LOWHP_DEFENSE_DECREASE = 130,  // ¹°¸®¹æ¾î ÀúÇÏ

        CHAR_STATE_FIRE_ATTACK_DECREASE = 131,     // ºÒ¼Ó¼º °ø°Ý·Â ÀúÇÏ
        CHAR_STATE_WATER_ATTACK_DECREASE = 132,        // ¹°
        CHAR_STATE_WIND_ATTACK_DECREASE = 133,     // ¹Ù¶÷
        CHAR_STATE_EARTH_ATTACK_DECREASE = 134,        // ´ëÁö
        CHAR_STATE_DARK_ATTACK_DECREASE = 135,     // ¾ÏÈæ

        CHAR_STATE_FIRE_DEFENSE_DECREASE = 136,        // ºÒ¼Ó¼º ¹æ¾î·Â ÀúÇÏ
        CHAR_STATE_WATER_DEFENSE_DECREASE = 137,       // ¹°
        CHAR_STATE_WIND_DEFENSE_DECREASE = 138,        // ¹Ù¶÷
        CHAR_STATE_EARTH_DEFENSE_DECREASE = 139,       // ´ëÁö
        CHAR_STATE_DARK_DEFENSE_DECREASE = 140,        // ¾ÏÈæ

        CHAR_STATE_INCREASE_CASTING_TIME = 141,        // Ä³½ºÆÃ Å¸ÀÓ Áõ°¡
        CHAR_STATE_INCREASE_SKILL_COOL_TIME = 142,     // ½ºÅ³ ÄðÅ¸ÀÓ Áõ°¡
        CHAR_STATE_MP_SPEND_INCREASE = 143,        // MPÀúÁÖ(MP ¼Ò¸ð Áõ°¡)
                                                    // __NA_S00015_20080828_NEW_HOPE_SHADOW
        CHAR_STATE_PAIN = 144,     // ÆäÀÎ(°íÅë)
        CHAR_STATE_FIRE_WOUND2 = 145,      // ´ÙÅ©ÆÄÀÌ¾î(È­¿°)
        CHAR_STATE_PAIN2 = 146,        // ´ÙÅ©ÆäÀÎ(¾ÏÈæÀÇ°íÅë)
        CHAR_STATE_STUN2 = 148,        // ´ÙÅ©½ºÅÏ(ÃÖ¸é)
        CHAR_STATE_POISON2 = 149,      // Æ÷ÀÌÁð(ÀÎÃ¾Æ®Æ÷ÀÌÁð)
        CHAR_STATE_BUFF_CANCEL = 150,      // ¹öÇÁÁ¦°Å(¹öÇÁÄµ½½)
        CHAR_STATE_EXPLOSION = 151,        // ÀÚÆø(´ÙÅ©ºê·¹ÀÌÅ©)
        CHAR_STATE_DARK_SPARK = 152,       // ½ºÆÄÅ©(´ÙÅ©½ºÆÄÅ©)
        CHAR_STATE_IMPOTENT = 153,     // ÀÓÆ÷ÅÏÆ®
        CHAR_STATE_CONFUSE = 154,      // ÄÁÇ»Áî
        CHAR_STATE_CANCELATION = 155,      // Äµ½½·¹ÀÌ¼Ç
        CHAR_STATE_HP_SUCTION = 156,       // HP¸¦ Èí¼öÇÑ´Ù.( ³­ µå¶óÅ¥¶ó... )
        CHAR_STATE_MP_SUCTION = 157,       // MP¸¦ Èí¼öÇÑ´Ù.( ³­ µå¶óÅ¥¶ó... )
        CHAR_STATE_MP_FEAR2 = 158,     // ¼Ò¿ï½ºÅ©¸²( ÇÇ¾î¿Í µ¿ÀÏÇÏ³ª, ÀÌÆåÆ® È¿°ú¶§¹®¿¡ µû·Î ³Ö´Â´Ù. )
        CHAR_STATE_VITAL_SUCTION = 159,        // ½ÃÃ¼ÇÑÅ× HP¸¦ »¯¾î¿Â´Ù. 
        CHAR_STATE_RUSH = 160,     // ·¯½¬(ÀÌµ¿¼ÓµµÁõ°¡+ÀÌÆåÆ®)
        CHAR_STATE_CHANGE_ATTR = 161,      // ¼Ó¼º°ªÀ» º¯°æÇÑ´Ù. ==> ¿ä »óÅÂÀÏ ¶§´Â À¯Áö½Ã°£ÀÌ 0ÀÌ´Ù.
        CHAR_STATE_ENCHANT_POISON = 162,       // ÀÎÃ¾Æ®Æ÷ÀÌÁð»ó(µ¶À» ¹Ù¸¥ »óÅÂ)
        CHAR_STATE_DETECTING_HIDE = 163,      // Àº½ÅÃ¼°¨Áö
        CHAR_STATE_WHITE_BLIND = 164,      // È­ÀÌÆ®ºí¶óÀÎµå(¹Ì½ºÆ½ ½ºÅ³, ÇÏ¾á»ö ½Ç¸í)
        CHAR_STATE_PHOENIX_BURN = 165,      // ÇÇ´Ð½º È­»ó (¹Ì½ºÆ½ ½ºÅ³ ÇÇ´Ð½º)
        CHAR_STATE_POLYMORPH = 166,      // Æú¸®¸ðÇÁ(¹Ì½ºÆ½ ½ºÅ³, µ¿¹°º¯½Å)
        CHAR_STATE_DARK_OF_LIGHT_ZONE = 167,      // ´ÙÅ©¿Àºê¶óÀÌÆ®Á¸
        CHAR_STATE_GRAVITY_ZONE = 168,      // ±×¶óºñÆ¼Á¸
        CHAR_STATE_AWAKEN_OFFENSE = 169,      // ¾î¿þÀÌÅ« °ø°Ý·Â »ó½Â(¹Ì½ºÆ½ ½ºÅ³)
        CHAR_STATE_AWAKEN_DEFENSE = 170,      // ¾î¿þÀÌÅ« ¹æ¾î·Â »ó½Â(¹Ì½ºÆ½ ½ºÅ³)
        CHAR_STATE_SLIP = 171,      // ½½¸®ÇÁ (½ºÅ³ »ç¿ëºÒ°¡)
        CHAR_STATE_FATAL_POINT = 172,      // È¦µù (¹Ì½ºÆ½ ÆäÀÌÅ»Æ÷ÀÎÆ®)

        //!~ _NA_000000_20130812_NEW_CHARACTER_HELLROID
        CHAR_STATE_ALL_ELEMENT_ATTACK_DECREASE = 174, // ¸ðµç¿ø¼Ò°ø°Ý·Â°¨¼Ò(½½·Î¿ì¿À¶ó)
        CHAR_STATE_ALL_ELEMENT_DEFENSE_DECREASE = 175, // ¸ðµç¿ø¼ÒÀúÇ×·ü°¨¼Ò(À§Å©³Ê½º¿À¶ó)
        CHAR_STATE_CRITICAL_RATIO_DECREASE = 176, // Å©¸®Æ¼ÄÃÈ®·ü°¨¼Ò
        CHAR_STATE_CRITICAL_DAMAGE_DECREASE = 177, // Å©¸®Æ¼ÄÃµ¥¹ÌÁö°¨¼Ò
        CHAR_STATE_SKILL_DAMAGE_DECREASE = 178, // ½ºÅ³µ¥¹ÌÁö°¨¼Ò
        CHAR_STATE_SLOW_AURORA = 179, // ½½·Î¿ì¿À¶ó
        CHAR_STATE_WEAKNESS_AURORA = 180, // À§Å©³Ê½º¿À¶ó
        CHAR_STATE_MISCHANCE_AURORA = 181, // ¹Ì½ºÃ¦½º¿À¶ó
        CHAR_STATE_DECLINE_AURORA = 182, // µðÅ¬¶óÀÎ¿À¶ó
        CHAR_STATE_RECOVERY_AURORA = 183, // ¸®Ä¿¹ö¸®¿À¶ó
        CHAR_STATE_BOOST_AURORA = 184, // ºÎ½ºÆ®¿À¶ó
        CHAR_STATE_IGNORE_AURORA = 185, // ÀÌ±×³ë¾î¿À¶ó
        CHAR_STATE_CONCENTRATION_AURORA = 186, // ÄÁ¼¾Æ®·¹ÀÌ¼Ç¿À¶ó
        CHAR_STATE_IGNORE_RESERVEHP6 = 187, // HPÈ¸º¹(¸®Ä¿¹ö¸®¹«½Ã)
        CHAR_STATE_BUF_RANGE_DAMAGE2 = 188, // ·¹ÀÎÁö2(Çï·ÎÀÌµå¿ë)
        CHAR_STATE_BUF_RANGE_DAMAGE3 = 189, // ·¹ÀÎÁö3(Çï·ÎÀÌµå¿ë)
        CHAR_STATE_BUF_RANGE_DAMAGE4 = 190, // ·¹ÀÎÁö4(Çï·ÎÀÌµå¿ë)
        CHAR_STATE_DAMAGED_CRITICAL_RATIO_DECREASE = 191, // ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ È®·ü °¨¼Ò
        CHAR_STATE_DAMAGED_CRITICAL_DAMAGE_DECREASE = 192, // ³ë·ÃÇÔ(ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ µ¥¹ÌÁö °¨¼Ò)
        CHAR_STATE_DAMAGED_CRITICAL_RATIO_INCREASE = 193, // ³¯·ÆÇÔ(ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ È®·ü °¨¼Ò)
        CHAR_STATE_DAMAGED_CRITICAL_DAMAGE_INCREASE = 194, // ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Áõ°¡
        CHAR_STATE_ELECTRICSHOCK = 195, // °¨Àü
        CHAR_STATE_GUARDIANSHIELD = 196, // °¡µð¾ð½¯µå
        CHAR_STATE_PROTECTION1 = 197, // º¸È£ »óÅÂ
                                       //!~ _NA_000000_20130812_NEW_CHARACTER_HELLROID

        kCharStatePoison3 = 3001, // ¸ó½ºÅÍ ½ºÅ³ µ¶
                                  // end of shadow

        //-------------------------------------------------------------------------------------------------
        // »óÅÂ°­È­
        //-------------------------------------------------------------------------------------------------
        CHAR_STATE_ABSORB = 115,       // ÇÇ°Ý µ¥¹ÌÁö Èí¼ö(HP, MP Èí¼ö)
        CHAR_STATE_ANGER = 200,        // ºÐ³ë(°ø°Ý·Â »ó½Â)
        CHAR_STATE_DEFENSE = 201,      // ¹æ¾î(¹æ¾î·Â »ó½Â)
        CHAR_STATE_PROTECTION = 202,       // º¸È£(ÀÌ»ó»óÅÂ¿¡ °É¸®Áö ¾ÊÀ½)
        CHAR_STATE_FIGHTING = 203,     // ÅõÁö(°ø°Ý¼º°ø·ü »ó½Â)
        CHAR_STATE_BALANCE = 204,      // ±ÕÇü(ºí·Ï¼º°ø·ü »ó½Â)
        CHAR_STATE_VITAL_POWER = 205,      // È°·Â(HP È¸º¹·ü »ó½Â)
        CHAR_STATE_MEDITATION = 206,       // ¸í»ó(MP, SP È¸º¹·ü »ó½Â)
        CHAR_STATE_HIGH_SPIRIT = 207,      // ±â¼¼(°ø°Ý¼Óµµ Áõ°¡)
        CHAR_STATE_SPEEDING = 208,     // ÁúÁÖ(ÀÌµ¿¼Óµµ Áõ°¡)
        CHAR_STATE_CONCENTRATION = 209,        // ÁýÁß(Å©¸®Æ¼ÄÃÈ®·ü Áõ°¡)
        CHAR_STATE_INCREASE_SKILLRANGE = 210,      // ½Ã¾ß(½ºÅ³»ç°Å¸® Áõ°¡)
        CHAR_STATE_PRECISION = 211,        // Á¤¹Ð(Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Áõ°¡)
        CHAR_STATE_HP_INCREASE = 212,      // °Ý·Á(HP Áõ°¡)
        CHAR_STATE_MP_INCREASE = 213,      // Åº·Â(MP Áõ°¡)
        CHAR_STATE_HPRATE_INCREASE = 214,      // È°±â(HP È¸º¹·® Áõ°¡)
        CHAR_STATE_MPRATE_INCREASE = 215,      // ÀÚ±Ø(MP È¸º¹·® Áõ°¡)
        CHAR_STATE_CURE = 216,     // Ä¡·á(¸ðµç»óÅÂÀÌ»ó Ãë¼Ò)
        CHAR_STATE_MAGIC_DEFENSE = 217,        // ¸¶¹ý¹æ¾î(¸¶¹ý¹æ¾î·Â Áõ°¡)
        CHAR_STATE_MAGIC_SHIELD = 218,     // ¸¶¹ýº¸È£(¸¶¹ý½¯µå HP)
        CHAR_STATE_HOLDING = 219,      // È¦µù(ÀÌµ¿ºÒ°¡, °ø°Ý°¡´É)
        CHAR_STATE_SP_BONUS = 221,     // SP´ç Ãß°¡ °ø°Ý·Â(¹°¸®µ¥¹ÌÁö Áõ°¡)
        CHAR_STATE_BUF_RANGE_DAMAGE = 222,     // ·¹ÀÎÁö(ÁÖº¯Àûµé¿¡°Ô Áö¼ÓÀû µ¥¹ÌÁö)
        CHAR_STATE_STAT_STR = 223,     // Èû°­È­
        CHAR_STATE_STAT_DEX = 224,     // ¹ÎÃ¸°­È­
        CHAR_STATE_STAT_VIT = 225,     // Ã¼·Â°­È­
        CHAR_STATE_STAT_SPI = 226,     // Á¤½Å·Â°­È­
        CHAR_STATE_STAT_INT = 227,     // Áö·Â°­È­
        CHAR_STATE_MAGIC_ATTACK_INCREASE = 228,        // ¸¶¹ý°ø°Ý »ó½Â

        CHAR_STATE_STAT_LOWHP_ATTACK_INCREASE = 229,   // ¹°¸®°ø°Ý »ó½Â
        CHAR_STATE_STAT_LOWHP_DEFENSE_INCREASE = 230,  // ¹°¸®¹æ¾î »ó½Â

        CHAR_STATE_STAT_DAMAGE_ADD = 231,      // Ãß°¡ µ¥¹ÌÁö

        CHAR_STATE_FIRE_ATTACK_INCREASE = 232,     // ºÒ¼Ó¼º °ø°Ý·Â »ó½Â
        CHAR_STATE_WATER_ATTACK_INCREASE = 233,        // ¹°
        CHAR_STATE_WIND_ATTACK_INCREASE = 234,     // ¹Ù¶÷
        CHAR_STATE_EARTH_ATTACK_INCREASE = 235,        // ´ëÁö
        CHAR_STATE_DARK_ATTACK_INCREASE = 236,     // ¾ÏÈæ

        CHAR_STATE_FIRE_DEFENSE_INCREASE = 237,        // ºÒ¼Ó¼º ¹æ¾î·Â »ó½Â
        CHAR_STATE_WATER_DEFENSE_INCREASE = 238,       // ¹°
        CHAR_STATE_WIND_DEFENSE_INCREASE = 239,        // ¹Ù¶÷
        CHAR_STATE_EARTH_DEFENSE_INCREASE = 240,       // ´ëÁö
        CHAR_STATE_DARK_DEFENSE_INCREASE = 241,        // ¾ÏÈæ

        CHAR_STATE_DECREASE_CASTING_TIME = 242,        // Ä³½ºÆÃ Å¸ÀÓ °¨¼Ò
        CHAR_STATE_DECREASE_SKILL_COOL_TIME = 243,     // ½ºÅ³ ÄðÅ¸ÀÓ °¨¼Ò
        CHAR_STATE_MP_SPEND_DECREASE = 244,        // MPÈ°·Â(MP ¼Ò¸ð °¨¼Ò)

        CHAR_STATE_REFLECT_DAMAGE = 220,       // ÇÇ°Ýµ¥¹ÌÁö¹Ý»ç(µ¥¹ÌÁö ¹Ý»ç)
        CHAR_STATE_REFLECT_SLOW = 118,     // ÇÇ°ÝÁ·¼â(µ¥¹ÌÁö + ÀÌ¼ÓÀúÇÏ)
        CHAR_STATE_REFLECT_FROZEN = 119,       // ÇÇ°ÝÇÁ·ÎÁð(µ¥¹ÌÁö + ¸ðµçÇàµ¿ºÒ´É)
        CHAR_STATE_REFLECT_SLOWDOWN = 120,     // ÇÇ°ÝµÐÈ­(µ¥¹ÌÁö + °ø¼ÓÀúÇÏ)
        CHAR_STATE_REFLECT_STUN = 121,     // ÇÇ°Ý½ºÅÏ(µ¥¹ÌÁö + ¸ðµçÇàµ¿ºÒ´É)
        CHAR_STATE_REFLECT_FEAR = 122,     // ÇÇ°ÝÇÇ¾î(µ¥¹ÌÁö + µµ¸Á)
        CHAR_STATE_IGNORE_RESERVEHP = 245,     // È°·Â(HPÀû¸³¹«½Ã)
        CHAR_STATE_ANGER8 = 246,
        CHAR_STATE_MAGIC_ATTACK_INCREASE8 = 247,
        CHAR_STATE_DEFENSE8 = 248,
        CHAR_STATE_MAGIC_DEFENSE7 = 249,
        CHAR_STATE_PRECISION7 = 250,
        //{_NA_001231_20081216_ADD_OPTION_KIND
        CHAR_STATE_RESIST_HOLDING = 251,       //È¦µù ³»¼º.
        CHAR_STATE_RESIST_SLEEP = 252,     //½½¸³ ³»¼º.
        CHAR_STATE_RESIST_POISON = 253,        //Áßµ¶ ³»¼º.
        CHAR_STATE_RESIST_KNOCKBACK = 254,     //³Ë¹é ³»¼º.
        CHAR_STATE_RESIST_DOWN = 255,      //´Ù¿î ³»¼º.
        CHAR_STATE_RESIST_STUN = 256,      //½ºÅÏ ³»¼º.
        CHAR_STATE_DECREASE_PVPDAMAGE = 257,       //PVPµ¥¹ÌÁö °¨¼Ò.
                                                    //}
                                                    //#ifdef __NA_001244_20090417_ATTACK_RESIST
                                                    //	CHAR_STATE_RESIST_NOMALATTACK_ALLCHAR	= 258,		//	¸ðµçÄÉ¸¯ ÀÏ¹Ý°ø°Ý ³»¼º.
                                                    //	CHAR_STATE_RESIST_SKILLATTACK_ALLCHAR	= 259,		//	¸ðµçÄÉ¸¯ ½ºÅ³°ø°Ý ³»¼º.
                                                    //	CHAR_STATE_RESIST_ALLATTACK_ALLCHAR	= 260,		//	¸ðµçÄÉ¸¯ ¸ðµç°ø°Ý ³»¼º.
                                                    //	CHAR_STATE_RESIST_NOMALATTACK_BERSERKER = 261,		//	¹ö¼­Ä¿ ÀÏ¹Ý°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_SKILLATTACK_BERSERKER = 262,		//	¹ö¼­Ä¿ ½ºÅ³°ø°Ý ³»¼º.
                                                    //	CHAR_STATE_RESIST_ALLATTACK_BERSERKER	= 263,		//	¹ö¼­Ä¿ ¸ðµç°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_NOMALATTACK_VALKYRIE = 264,  	//	¹ßÅ°¸® ÀÏ¹Ý°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_SKILLATTACK_VALKYRIE = 265,  	//	¹ßÅ°¸® ½ºÅ³°ø°Ý ³»¼º.
                                                    //	CHAR_STATE_RESIST_ALLATTACK_VALKYRIE	= 266,		//	¹ßÅ°¸® ¸ðµç°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_NOMALATTACK_DRAGON	= 267,		//	µå·¡°ï ÀÏ¹Ý°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_SKILLATTACK_DRAGON	= 268,		//	µå·¡°ï ½ºÅ³°ø°Ý ³»¼º.
                                                    //	CHAR_STATE_RESIST_ALLATTACK_DRAGON		= 269,		//	µå·¡°ï ¸ðµç°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_NOMALATTACK_ELEMENTALIST	= 270,	//	¿¤¸® ÀÏ¹Ý°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_SKILLATTACK_ELEMENTALIST	= 271,	//	¿¤¸® ½ºÅ³°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_ALLATTACK_ELEMENTALIST	= 272,	//	¿¤¸® ¸ðµç°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_NOMALATTACK_SHADOW	= 273,		//	¼âµµ¿ì ÀÏ¹Ý°ø°Ý ³»¼º.		
                                                    //	CHAR_STATE_RESIST_SKILLATTACK_SHADOW	= 274,		//	¼âµµ¿ì ½ºÅ³°ø°Ý ³»¼º.	
                                                    //	CHAR_STATE_RESIST_ALLATTACK_SHADOW		= 275,		//	¼âµµ¿ì ¸ðµç°ø°Ý ³»¼º.		
                                                    //#endif
                                                    //__NA_001290_20090525_SHIELD_SYSTEM
        CHAR_STATE_ENCOURAGEMENT = 276,        // Max sd Áõ°¡
        CHAR_STATE_PROMOTION = 277,        // sd È¸º¹·® Áõ°¡
                                            //-------------------------------------------------------------------------------------------------
                                            // Æ¯¼ö
                                            //-------------------------------------------------------------------------------------------------
        CHAR_STATE_TRANSFORMATION = 300,       // º¯½Å
        CHAR_STATE_STEEL = 301,        // °­Ã¶(ÀÌµ¿ ¿Ü Çàµ¿ ºÒ´É, ÀÌµ¿¼Óµµ °¨¼Ò)
        CHAR_STATE_TRANSPARENT = 302,      // Åõ¸í(ÀÌµ¿ ¿ÜÀÇ Çàµ¿½Ã ÇØÁ¦)
        CHAR_STATE_FEAR = 303,     // ÇÇ¾î(´ë»óÀ» µµ¸Á°¡°Ô ÇÑ´Ù.)
        CHAR_STATE_BLUR = 304,     // °ø°ÝºÒ´É(´ë»óÀº °ø°ÝÀ» ¸øÇÑ´Ù.)
        CHAR_STATE_THRUST = 305,       // ¹Ð¸®±â(¹Ð¸®°í ÀÖ´Â »óÅÂ)
        CHAR_STATE_SUMMON = 306,       // ¼ÒÈ¯
        CHAR_STATE_SPCHARGE = 307,     // °Ë±âÃæÀü
        CHAR_STATE_CURSE_INCREASE = 308,       // ÀúÁÖ°­È­(Ä¿½ºÀÎÅ©¸®Áî)
                                                //_NA001385_20090924_DOMINATION_ETC
        CHAR_STATE_STAMP = 309,        // °¢ÀÎ »óÅÂ(ÀÌ»ó»óÅÂ¿¡ °É¸®Áö ¾ÊÀ½)
        kCharStateIncreseHeal = 310, // Ä¡À¯·® Áõ°¡ »óÅÂ
        kCharStateActiveComboSkill = 311, // ¿¬°è ½ºÅ³ È°¼ºÈ­
        kCharStateIncreseSkillDamage = 312, // ½ºÅ³ µ¥¹ÌÁö Áõ°¡ »óÅÂ
                                            // _NA_005026_20120527_CHAOS_ZONE_BATTLE_GROUND
        CHAR_STATE_FUGITIVE = 313, // ÀüÀå µµ¸ÁÀÚ
        CHAR_STATE_TRANSFORMATION6 = 315,      // ºùÀÇ
        //_NA_007667_20141001_WITCHBLADE_SKILL
        CHAR_STATE_VICE_SWORD = 400,      // ¹ÙÀÌ½º¼Òµå
        CHAR_STATE_CHARMED = 401,      // ¸ÅÈ¤(½ÃÀüÀÚ¸¦ µû¶ó¿À°Ô ÇÑ´Ù.)
        CHAR_STATE_ALL_ELEMENTS_INCREASE = 402,      // ¸ðµç ¼Ó¼º °ø°Ý·Â Áõ°¡
        CHAR_STATE_REFLECT_LINK_SKILL = 403,      // ÇÇ°Ý½Ã ½ºÅ³»ç¿ë(µ¥¹ÌÁö + ½ºÅ³)
        CHAR_STATE_EVADE = 404,      // ÀÌº£ÀÌµå
        CHAR_STATE_FURYFORMATION = 405,      // Ç»¸®Æ÷¸ÞÀÌ¼Ç
        CHAR_STATE_RISING_FORCE = 406,      // ¶óÀÌÂ¡Æ÷½º
        CHAR_STATE_FP_POWER_INCREASE = 407,     // FP¿¡ ÀÇÇÑ µ¥¹ÌÁöÁõ°¡È¿°ú¸¦ Áõ°¡½ÃÅ²´Ù
        CHAR_STATE_WIT_VITAL_POWER = 408,      // À§Ä¡ºí·¹ÀÌµå È°·Â
        CHAR_STATE_WIT_CONCENTRATION = 409,      // À§Ä¡ºí·¹ÀÌµå ÁýÁß
        CHAR_STATE_INCREASE_DAMAGE = 410,      // µ¥¹ÌÁö Áõ°¡
        CHAR_STATE_AUTOCAST_BLEEDING_ATTACK = 411,      // ÃâÇ÷°ø°Ý ¹öÇÁ
        CHAR_STATE_RISING_FORCE_IMMUNITY_DAMAMGE = 412, // ¶óÀÌÂ¡Æ÷½º¿ë ¹«Àû //_NA_007514_20140828_NEW_CHARACTER_WITCHBLADE

        //-------------------------------------------------------------------------------------------------
        // »óÅÂ°­È­_¹°¾à
        //-------------------------------------------------------------------------------------------------
        CHAR_STATE_ANGER3 = 500,       // ºÐ³ë3
        CHAR_STATE_DEFENSE3 = 501,     // ¹æ¾î3
        CHAR_STATE_FIGHTING3 = 502,        // ÅõÁö3
        CHAR_STATE_BALANCE3 = 503,     // ±ÕÇü3
        CHAR_STATE_VITAL_POWER3 = 504,     // È°·Â3
        CHAR_STATE_MEDITATION3 = 505,      // ¸í»ó3
        CHAR_STATE_HIGH_SPIRIT3 = 506,     // ±â¼¼3
        CHAR_STATE_SPEEDING3 = 507,        // ÁúÁÖ3
        CHAR_STATE_CONCENTRATION3 = 508,       // ÁýÁß3
        CHAR_STATE_INCREASE_SKILLRANGE3 = 509,     // ½Ã¾ß3
        CHAR_STATE_PRECISION3 = 510,       // Á¤¹Ð3
        CHAR_STATE_HP_INCREASE3 = 511,     // °Ý·Á3
        CHAR_STATE_MP_INCREASE3 = 512,     // Åº·Â3
        CHAR_STATE_HPRATE_INCREASE3 = 513,     // È°±â3
        CHAR_STATE_MPRATE_INCREASE3 = 514,     // ÀÚ±Ø3
        CHAR_STATE_MAGICDEFENSE3 = 515,        // ¸¶¹ý¹æ¾î3
        CHAR_STATE_STAT_STR3 = 516,        // Èû°­È­3
        CHAR_STATE_STAT_DEX3 = 517,        // ¹ÎÃ¸°­È­3
        CHAR_STATE_STAT_VIT3 = 518,        // Ã¼·Â°­È­3
        CHAR_STATE_STAT_INT3 = 519,        // Á¤½Å·Â°­È­3
        CHAR_STATE_STAT_SPI3 = 520,        // Áö·Â°­È­3
        CHAR_STATE_MAGIC_ATTACK_INCREASE3 = 521,       // ¸¶¹ý°ø°Ý»ó½Â3
        CHAR_STATE_STAT_DAMAGE_ADD3 = 522,     // Ãß°¡µ¥¹ÌÁö3
        CHAR_STATE_FIRE_ATTACK_INCREASE3 = 523,        // ºÒ¼Ó¼º°ø°Ý·ÂÁõ°¡3
        CHAR_STATE_WATER_ATTACK_INCREASE3 = 524,       // ¹°¼Ó¼º°ø°Ý·ÂÁõ°¡3
        CHAR_STATE_WIND_ATTACK_INCREASE3 = 525,        // ¹Ù¶÷¼Ó¼º°ø°Ý·ÂÁõ°¡3
        CHAR_STATE_EARTH_ATTACK_INCREASE3 = 526,       // ´ëÁö¼Ó¼º°ø°Ý·ÂÁõ°¡3
        CHAR_STATE_DARK_ATTACK_INCREASE3 = 527,        // ¾ÏÈæ¼Ó¼º°ø°Ý·ÂÁõ°¡3
        CHAR_STATE_FIRE_DEFENSE_INCREASE3 = 528,       // ºÒ¼Ó¼º¹æ¾î·ÂÁõ°¡3
        CHAR_STATE_WATER_DEFENSE_INCREASE3 = 529,      // ¹°¼Ó¼º¹æ¾î·ÂÁõ°¡3
        CHAR_STATE_WIND_DEFENSE_INCREASE3 = 530,       // ¹Ù¶÷¼Ó¼º¹æ¾î·ÂÁõ°¡3
        CHAR_STATE_EARTH_DEFENSE_INCREASE3 = 531,      // ´ëÁö¼Ó¼º¹æ¾î·ÂÁõ°¡3
        CHAR_STATE_DARK_DEFENSE_INCREASE3 = 532,       // ¾ÏÈæ¼Ó¼º¹æ¾î·ÂÁõ°¡3
        CHAR_STATE_MP_SPEND_INCREASE3 = 533,       // MPÀúÁÖ3(MP ¼Ò¸ð Áõ°¡)
        CHAR_STATE_MP_SPEND_DECREASE3 = 534,       // MPÈ°·Â3(MP ¼Ò¸ð °¨¼Ò)	
        CHAR_STATE_DECREASE_CASTING_TIME3 = 535,       //Ä³½ºÆÃ Å¸ÀÓ °¨¼Ò3
        CHAR_STATE_DECREASE_SKILL_COOL_TIME3 = 536,        //½ºÅ³ ÄðÅ¸ÀÓ °¨¼Ò3	
        CHAR_STATE_TRANSFORMATION3 = 537,      // º¯½Å3
                                                //CHAR_STATE_STEEL3						= 538,		// °­Ã¶3(ÀÌµ¿ ¿Ü Çàµ¿ ºÒ´É, ÀÌµ¿¼Óµµ °¨¼Ò)
        CHAR_STATE_TRANSPARENT3 = 539,     // Åõ¸í3(ÀÌµ¿ ¿ÜÀÇ Çàµ¿½Ã ÇØÁ¦)
        CHAR_STATE_FEAR3 = 540,        // ÇÇ¾î3(´ë»óÀ» µµ¸Á°¡°Ô ÇÑ´Ù.)
        CHAR_STATE_BLUR3 = 541,        // °ø°ÝºÒ´É3(´ë»óÀº °ø°ÝÀ» ¸øÇÑ´Ù.)
        CHAR_STATE_THRUST3 = 542,      // ¹Ð¸®±â3(¹Ð¸®°í ÀÖ´Â »óÅÂ)
        CHAR_STATE_SUMMON3 = 543,      // ¼ÒÈ¯3
        CHAR_STATE_SPCHARGE3 = 544,        // °Ë±âÃæÀü3
        CHAR_STATE_IGNORE_RESERVEHP3 = 545,        // È°·Â(HPÀû¸³¹«½Ã3)
        CHAR_STATE_ANGER9 = 546,
        CHAR_STATE_MAGIC_ATTACK_INCREASE9 = 547,
        CHAR_STATE_DEFENSE9 = 548,
        CHAR_STATE_MAGIC_DEFENSE8 = 549,
        CHAR_STATE_PRECISION8 = 550,

        //__NA_001290_20090525_SHIELD_SYSTEM
        CHAR_STATE_ENCOURAGEMENT3 = 576,       // Max sd Áõ°¡
        CHAR_STATE_PROMOTION3 = 577,       // sd È¸º¹·® Áõ°¡

        //-------------------------------------------------------------------------------------------------
        // »óÅÂ°­È­_ÀÌº¥Æ®
        //-------------------------------------------------------------------------------------------------
        CHAR_STATE_ANGER4 = 700,       // ºÐ³ë4
        CHAR_STATE_DEFENSE4 = 701,     // ¹æ¾î4
        CHAR_STATE_FIGHTING4 = 702,        // ÅõÁö4
        CHAR_STATE_BALANCE4 = 703,     // ±ÕÇü4
        CHAR_STATE_VITAL_POWER4 = 704,     // È°·Â4
        CHAR_STATE_MEDITATION4 = 705,      // ¸í»ó4
        CHAR_STATE_HIGH_SPIRIT4 = 706,     // ±â¼¼4
        CHAR_STATE_SPEEDING4 = 707,        // ÁúÁÖ4
        CHAR_STATE_CONCENTRATION4 = 708,       // ÁýÁß4
        CHAR_STATE_INCREASE_SKILLRANGE4 = 709,     // ½Ã¾ß4
        CHAR_STATE_PRECISION4 = 710,       // Á¤¹Ð4
        CHAR_STATE_HP_INCREASE4 = 711,     // °Ý·Á4
        CHAR_STATE_MP_INCREASE4 = 712,     // Åº·Â4
        CHAR_STATE_HPRATE_INCREASE4 = 713,     // È°±â4
        CHAR_STATE_MPRATE_INCREASE4 = 714,     // ÀÚ±Ø4
        CHAR_STATE_MAGICDEFENSE4 = 715,        // ¸¶¹ý¹æ¾î4
        CHAR_STATE_STAT_STR4 = 716,        // Èû°­È­4
        CHAR_STATE_STAT_DEX4 = 717,        // ¹ÎÃ¸°­È­4
        CHAR_STATE_STAT_VIT4 = 718,        // Ã¼·Â°­È­4
        CHAR_STATE_STAT_INT4 = 719,        // Á¤½Å·Â°­È­4
        CHAR_STATE_STAT_SPI4 = 720,        // Áö·Â°­È­4
        CHAR_STATE_MAGIC_ATTACK_INCREASE4 = 721,       // ¸¶¹ý°ø°Ý»ó½Â4
        CHAR_STATE_STAT_DAMAGE_ADD4 = 722,     // Ãß°¡µ¥¹ÌÁö4
        CHAR_STATE_FIRE_ATTACK_INCREASE4 = 723,        // ºÒ¼Ó¼º°ø°Ý·ÂÁõ°¡4
        CHAR_STATE_WATER_ATTACK_INCREASE4 = 724,       // ¹°¼Ó¼º°ø°Ý·ÂÁõ°¡4
        CHAR_STATE_WIND_ATTACK_INCREASE4 = 725,        // ¹Ù¶÷¼Ó¼º°ø°Ý·ÂÁõ°¡4
        CHAR_STATE_EARTH_ATTACK_INCREASE4 = 726,       // ´ëÁö¼Ó¼º°ø°Ý·ÂÁõ°¡4
        CHAR_STATE_DARK_ATTACK_INCREASE4 = 727,        // ¾ÏÈæ¼Ó¼º°ø°Ý·ÂÁõ°¡4
        CHAR_STATE_FIRE_DEFENSE_INCREASE4 = 728,       // ºÒ¼Ó¼º¹æ¾î·ÂÁõ°¡4
        CHAR_STATE_WATER_DEFENSE_INCREASE4 = 729,      // ¹°¼Ó¼º¹æ¾î·ÂÁõ°¡4
        CHAR_STATE_WIND_DEFENSE_INCREASE4 = 730,       // ¹Ù¶÷¼Ó¼º¹æ¾î·ÂÁõ°¡4
        CHAR_STATE_EARTH_DEFENSE_INCREASE4 = 731,      // ´ëÁö¼Ó¼º¹æ¾î·ÂÁõ°¡4
        CHAR_STATE_DARK_DEFENSE_INCREASE4 = 732,       // ¾ÏÈæ¼Ó¼º¹æ¾î·ÂÁõ°¡4
        CHAR_STATE_MP_SPEND_INCREASE4 = 733,       // MPÀúÁÖ4(MP ¼Ò¸ð Áõ°¡)
        CHAR_STATE_SPCHARGE4 = 744,        // °Ë±âÃæÀü4
        CHAR_STATE_MP_SPEND_DECREASE4 = 734,       // MPÈ°·Â4(MP ¼Ò¸ð °¨¼Ò)	
        CHAR_STATE_DECREASE_CASTING_TIME4 = 735,       //Ä³½ºÆÃ Å¸ÀÓ °¨¼Ò4
        CHAR_STATE_DECREASE_SKILL_COOL_TIME4 = 736,        //½ºÅ³ ÄðÅ¸ÀÓ °¨¼Ò4	
        CHAR_STATE_TRANSFORMATION4 = 737,      // º¯½Å4
                                                //CHAR_STATE_STEEL4						= 738,		// °­Ã¶4(ÀÌµ¿ ¿Ü Çàµ¿ ºÒ´É, ÀÌµ¿¼Óµµ °¨¼Ò)
        CHAR_STATE_TRANSPARENT4 = 739,     // Åõ¸í4(ÀÌµ¿ ¿ÜÀÇ Çàµ¿½Ã ÇØÁ¦)
        CHAR_STATE_FEAR4 = 740,        // ÇÇ¾î4(´ë»óÀ» µµ¸Á°¡°Ô ÇÑ´Ù.)
        CHAR_STATE_BLUR4 = 741,        // °ø°ÝºÒ´É4(´ë»óÀº °ø°ÝÀ» ¸øÇÑ´Ù.)
        CHAR_STATE_THRUST4 = 742,      // ¹Ð¸®±â4(¹Ð¸®°í ÀÖ´Â »óÅÂ)
        CHAR_STATE_SUMMON4 = 743,      // ¼ÒÈ¯4
        CHAR_STATE_IGNORE_RESERVEHP4 = 745,        // È°·Â(HPÀû¸³¹«½Ã4)
        CHAR_STATE_ANGER10 = 746,
        CHAR_STATE_MAGIC_ATTACK_INCREASE10 = 747,
        CHAR_STATE_DEFENSE10 = 748,
        CHAR_STATE_MAGIC_DEFENSE9 = 749,
        CHAR_STATE_PRECISION9 = 750,
        //__NA_001290_20090525_SHIELD_SYSTEM
        CHAR_STATE_ENCOURAGEMENT4 = 776,       // Max sd Áõ°¡
        CHAR_STATE_PROMOTION4 = 777,       // sd È¸º¹·® Áõ°¡

        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ½ºÅ³ ¹öÇÁ »óÅÂ Ãß°¡ 951 ~ 998
        ////////////////////////////////////////////////////////////////////////////////////////////////

        kCharStateHardStance = 951, // ÇÏµå ½ºÅÄ½º (Áö¼Ó Ã¼·Â)
        kCharStateIronStance = 952, // ¾ÆÀÌ¾ð ½ºÅÄ½º (¼ø°£ Ã¼·Â)
        kCharStateBloodHaze = 953, // ºí·¯µå ÇìÀÌÁî (Áö¼Ó HP)
        kCharStateMotalBlood = 954, // ¸ðÅ» ºí·¯µå (¼ø°£ HP)
        kCharStateCourageOfKnights = 955, // Ä¿¸®Áö ¿Àºê ³ªÀÌÃ÷ (Áö¼Ó ¹ÎÃ¸)
        kCharStateFeverOfKnights = 956, // ÇÇ¹ö ¿Àºê ³ªÀÌÃ÷ (¼ø°£ ¹ÎÃ¸)
        kCharStateDragonicForce = 957, // µå·¡°í´Ð Æ÷½º (Áö¼Ó °ø°Ý·Â)
        kCharStateDragonicBless = 958, // µå·¡°í´Ð ºí·¹½º (¼ø°£ °ø°Ý·Â)
        kCharStateHelronsSoul = 959, // Çï·ÐÁî ¼Ò¿ï (Áö¼Ó Á¤½Å·Â)
        kCharStateDemonsSoul = 960, // µ¥¸óÁî ¼Ò¿ï (¼ø°£ Á¤½Å·Â)
        kCharStateDarkTrace = 961, // ´ÙÅ© Æ®·¹ÀÌ½º (Áö¼Ó °ø°Ý¼Óµµ)
        kCharStateDarkRage = 962, // ´ÙÅ© ·¹ÀÌÁö (¼ø°£ °ø°Ý¼Óµµ)
        kCharStateIncreaseMind = 963, // ÀÎÅ©¸®½º ¸¶ÀÎµå (Áö¼Ó Áö·Â)
        kCharStateMindSpark = 964, // ¸¶ÀÎµå ½ºÆÄÅ© (¼ø°£ Áö·Â)
        kCharStateSummonicShield = 965, // ¼­¸Ó´Ð ½Çµå (Áö¼Ó ¹æ¾î·Â)
        kCharStateSummonicBarrier = 966, // ¼­¸Ó´Ð º£¸®¾î (¼ø°£ ¹æ¾î·Â)
        kCharStateEnchantPower = 967, // ÀÎÃ¦Æ® ÆÄ¿ö (Áö¼Ó Èû)
        kCharStateCatalystPower = 968, // Ä«Å»¸®½ºÆ® ÆÄ¿ö (¼ø°£ Èû)
        kCharStateWhisperOfWind = 969, // À§½ºÆÛ ¿Àºê À©µå (Áö¼Ó ÀÌµ¿¼Óµµ)
        kCharStateWhisperOfSylph = 970, // À§½ºÆÛ ¿Àºê ½ÇÇÁ (¼ø°£ ÀÌµ¿¼Óµµ)
        CHAR_STATE_FIRE_ATTACK_INCREASE6 = 971,  // ºÒ ¼Ó¼º°ø·Â Áõ°¡ (¹Ì½ºÆ½)
        CHAR_STATE_WATER_ATTACK_INCREASE6 = 972,  // ¹° ¼Ó¼º°ø·Â Áõ°¡ (¹Ì½ºÆ½)
        CHAR_STATE_WIND_ATTACK_INCREASE6 = 973,  // ¹Ù¶÷ ¼Ó¼º°ø·Â Áõ°¡ (¹Ì½ºÆ½)
        CHAR_STATE_EARTH_ATTACK_INCREASE6 = 974,  // ´ëÁö ¼Ó¼º°ø·Â Áõ°¡ (¹Ì½ºÆ½)

        kCharStateIncreaseAggroPoint = 999, // ¾î±×·Î Æ÷ÀÎÆ® Áõ°¡ »óÅÂ

        //-------------------------------------------------------------------------------------------------
        // »óÅÂ°­È­_±âÅ¸
        //-------------------------------------------------------------------------------------------------
        CHAR_STATE_ANGER5 = 1500,      // ºÐ³ë5
        CHAR_STATE_DEFENSE5 = 1501,        // ¹æ¾î5
        CHAR_STATE_FIGHTING5 = 1502,       // ÅõÁö5
        CHAR_STATE_BALANCE5 = 1503,        // ±ÕÇü5
        CHAR_STATE_VITAL_POWER5 = 1504,        // È°·Â5
        CHAR_STATE_MEDITATION5 = 1505,     // ¸í»ó5
        CHAR_STATE_HIGH_SPIRIT5 = 1506,        // ±â¼¼5
        CHAR_STATE_SPEEDING5 = 1507,       // ÁúÁÖ5
        CHAR_STATE_CONCENTRATION5 = 1508,      // ÁýÁß5
        CHAR_STATE_INCREASE_SKILLRANGE5 = 1509,        // ½Ã¾ß5
        CHAR_STATE_PRECISION5 = 1510,      // Á¤¹Ð5
        CHAR_STATE_HP_INCREASE5 = 1511,        // °Ý·Á5
        CHAR_STATE_MP_INCREASE5 = 1512,        // Åº·Â5
        CHAR_STATE_HPRATE_INCREASE5 = 1513,        // È°±â5
        CHAR_STATE_MPRATE_INCREASE5 = 1514,        // ÀÚ±Ø5
        CHAR_STATE_MAGICDEFENSE5 = 1515,       // ¸¶¹ý¹æ¾î5
        CHAR_STATE_STAT_STR5 = 1516,       // Èû°­È­5
        CHAR_STATE_STAT_DEX5 = 1517,       // ¹ÎÃ¸°­È­5
        CHAR_STATE_STAT_VIT5 = 1518,       // Ã¼·Â°­È­5
        CHAR_STATE_STAT_INT5 = 1519,       // Á¤½Å·Â°­È­5
        CHAR_STATE_STAT_SPI5 = 1520,       // Áö·Â°­È­5
        CHAR_STATE_MAGIC_ATTACK_INCREASE5 = 1521,      // ¸¶¹ý°ø°Ý»ó½Â5
        CHAR_STATE_STAT_DAMAGE_ADD5 = 1522,        // Ãß°¡µ¥¹ÌÁö5
        CHAR_STATE_FIRE_ATTACK_INCREASE5 = 1523,       // ºÒ¼Ó¼º°ø°Ý·ÂÁõ°¡5
        CHAR_STATE_WATER_ATTACK_INCREASE5 = 1524,      // ¹°¼Ó¼º°ø°Ý·ÂÁõ°¡5
        CHAR_STATE_WIND_ATTACK_INCREASE5 = 1525,       // ¹Ù¶÷¼Ó¼º°ø°Ý·ÂÁõ°¡5
        CHAR_STATE_EARTH_ATTACK_INCREASE5 = 1526,      // ´ëÁö¼Ó¼º°ø°Ý·ÂÁõ°¡5
        CHAR_STATE_DARK_ATTACK_INCREASE5 = 1527,       // ¾ÏÈæ¼Ó¼º°ø°Ý·ÂÁõ°¡5
        CHAR_STATE_FIRE_DEFENSE_INCREASE5 = 1528,      // ºÒ¼Ó¼º¹æ¾î·ÂÁõ°¡5
        CHAR_STATE_WATER_DEFENSE_INCREASE5 = 1529,     // ¹°¼Ó¼º¹æ¾î·ÂÁõ°¡5
        CHAR_STATE_WIND_DEFENSE_INCREASE5 = 1530,      // ¹Ù¶÷¼Ó¼º¹æ¾î·ÂÁõ°¡5
        CHAR_STATE_EARTH_DEFENSE_INCREASE5 = 1531,     // ´ëÁö¼Ó¼º¹æ¾î·ÂÁõ°¡5
        CHAR_STATE_DARK_DEFENSE_INCREASE5 = 1532,      // ¾ÏÈæ¼Ó¼º¹æ¾î·ÂÁõ°¡5
        CHAR_STATE_MP_SPEND_INCREASE5 = 1533,      // MPÀúÁÖ5(MP ¼Ò¸ð Áõ°¡)
        CHAR_STATE_MP_SPEND_DECREASE5 = 1534,      // MPÈ°·Â5(MP ¼Ò¸ð °¨¼Ò)	
        CHAR_STATE_DECREASE_CASTING_TIME5 = 1535,      //Ä³½ºÆÃ Å¸ÀÓ °¨¼Ò5
        CHAR_STATE_DECREASE_SKILL_COOL_TIME5 = 1536,       //½ºÅ³ ÄðÅ¸ÀÓ °¨¼Ò5	
        CHAR_STATE_TRANSFORMATION5 = 1537,     // º¯½Å5
                                                //CHAR_STATE_STEEL5						= 1538,		// °­Ã¶5(ÀÌµ¿ ¿Ü Çàµ¿ ºÒ´É, ÀÌµ¿¼Óµµ °¨¼Ò)
        CHAR_STATE_TRANSPARENT5 = 1539,        // Åõ¸í5(ÀÌµ¿ ¿ÜÀÇ Çàµ¿½Ã ÇØÁ¦)
        CHAR_STATE_FEAR5 = 1540,       // ÇÇ¾î5(´ë»óÀ» µµ¸Á°¡°Ô ÇÑ´Ù.)
        CHAR_STATE_BLUR5 = 1541,       // °ø°ÝºÒ´É5(´ë»óÀº °ø°ÝÀ» ¸øÇÑ´Ù.)
        CHAR_STATE_THRUST5 = 1542,     // ¹Ð¸®±â5(¹Ð¸®°í ÀÖ´Â »óÅÂ)
        CHAR_STATE_SUMMON5 = 1543,     // ¼ÒÈ¯5
        CHAR_STATE_SPCHARGE5 = 1544,       // °Ë±âÃæÀü5
        CHAR_STATE_IGNORE_RESERVEHP5 = 1545,       // È°·Â(HPÀû¸³¹«½Ã5)
        CHAR_STATE_ANGER12 = 1546,
        CHAR_STATE_MAGIC_ATTACK_INCREASE12 = 1547,
        CHAR_STATE_DEFENSE12 = 1548,
        CHAR_STATE_MAGIC_DEFENSE11 = 1549,
        CHAR_STATE_PRECISION11 = 1550,
        //__NA_001290_20090525_SHIELD_SYSTEM
        CHAR_STATE_ENCOURAGEMENT5 = 1576,      // Max sd Áõ°¡
        CHAR_STATE_PROMOTION5 = 1577,      // sd È¸º¹·® Áõ°¡

        CHAR_STATE_PERIODIC_DAMAGE = 5000,     // ÁÖ±â µ¥¹ÌÁö

        //-------------------------------------------------------------------------------------------------
        // ±æµå ½Ã¼³ ¾×Æ¼ºê »óÅÂµé
        // ±æµå ½Ã¼³ ¾×Æ¼ºê »óÅÂ´Â »ç¿ëµÇ´Â ¾îºô¸®Æ¼°¡ °¡Áö´Â »óÅÂ¿Í µû·Î °ü¸®µÇ¾î¾ß ÇÏ¹Ç·Î Àü¿ë »óÅÂ »ý¼º
        //------------------------------------------------------------------------------------------------- 
        //Ã¹¹øÂ° ¾îºô¸®Æ¼ »óÅÂµé
        CHAR_STATE_MERCENARIES_ACTIVE = 4001, // ±æµå ½Ã¼³ ¿ëº´ Á¶ÇÕ ¾×Æ¼ºê »óÅÂ
        CHAR_STATE_ELDER_ACTIVE = 4002, // ±æµå ½Ã¼³ ¿ø·ÎÈ¸ ¾×Æ¼ºê »óÅÂ
        CHAR_STATE_ECLIPSE_ACTIVE = 4003, // ±æµå ½Ã¼³ ÀÌÅ¬¸³½º ¾×Æ¼ºê »óÅÂ
        CHAR_STATE_CLAN_ACTIVE = 4004, // ±æµå ½Ã¼³ Å¬·£ ¾×Æ¼ºê »óÅÂ
        CHAR_STATE_MAGIC_ACTIVE = 4005, // ±æµå ½Ã¼³ ¸¶¹ý¿¬±¸¼Ò ¾×Æ¼ºê »óÅÂ
        CHAR_STATE_PELES_ACTIVE = 4006, // ±æµå ½Ã¼³ ÆÓ·¹½º ¾×Æ¼ºê »óÅÂ
        CHAR_STATE_HER_ACTIVE = 4007, // ±æµå ½Ã¼³ Çï·ÎÀÌµå ¾×Æ¼ºê »óÅÂ
                                       //µÎ¹øÂ° ¾îºô¸®Æ¼ »óÅÂµé
        CHAR_STATE_ELDER_ACTIVE2 = 4008, // ±æµå ½Ã¼³ ¿ø·ÎÈ¸ ¾×Æ¼ºê »óÅÂ2

        //-------------------------------------------------------------------------------------------------
        // ¾îºô¸®Æ¼ ¿ÜÀÇ »óÅÂµé
        //------------------------------------------------------------------------------------------------- 
        CHAR_STATE_STYLE_THRUST = 5001,        // ½ºÅ¸ÀÏ °ø°Ý¿¡¼­ »ç¿ëÇÏ´Â ¹Ð¸®±â
        CHAR_STATE_STYLE_STUN = 5002,
        CHAR_STATE_STYLE_DOWN = 5003,

        CHAR_STATE_ETC_FLYING = 5004,      // °øÁß¿¡ ¶° ÀÖ´Â »óÅÂ
        CHAR_STATE_ETC_DISABLE_VISION = 5005,      // ½Ã¾ß°¡ ²¨Á® ÀÖÀ¸¸é ¸ó½ºÅÍµéÀÌ Ã£Áöµµ ¸øÇÏ°í °ø°Ýµµ ¸øÇÑ´Ù. 
        CHAR_STATE_ETC_RETURNING = 5006,       // ºÎÈ°À§Ä¡·Î µ¹¾Æ°¡´Â »óÅÂ
        CHAR_STATE_ETC_HELP = 5007,        // µµ¿ÍÁÖ·¯ °¡´Â »óÅÂ

        CHAR_STATE_ETC_AUTO_RECOVER_HP = 5008,     // ÀÚµ¿ HP, MP È¸º¹
        CHAR_STATE_ETC_AUTO_RECOVER_MP = 5009,
        CHAR_STATE_ETC_AUTO_RECOVER_HPMP = 5010,
        CHAR_STATE_ETC_ITEM_RECOVER_HP = 5011,     // ¾ÆÀÌÅÛ¿¡ ÀÇÇÑ HP, MP È¸º¹
        CHAR_STATE_ETC_ITEM_RECOVER_MP = 5012,

        CHAR_STATE_ETC_FORCED_WARP = 5013,     // ¼­¹ö¿¡ÀÇÇÑ °­Á¦¿öÇÁ »óÅÂ(ÀÌµ¿µ¿±â¸¦ ¸ÂÃß±â À§ÇØ¼­ Àá½Ã ÀÌµ¿À» ¸øÇÑ´Ù.)
        CHAR_STATE_ETC_DISABLE_VISION_TRIGGER = 5014,      // ½Ã¾ß°¡ ²¨Á® ÀÖÀ¸¸é ¸ó½ºÅÍµéÀÌ Ã£Áöµµ ¸øÇÏ°í °ø°Ýµµ ¸øÇÑ´Ù. (Æ®¸®°Å¿¡¼­ »ç¿ë)
        CHAR_STATE_BLUR_TRIGGER = 5015,        // °ø°ÝºÒ´É(´ë»óÀº °ø°ÝÀ» ¸øÇÑ´Ù. Æ®¸®°Å¿ë)

        //__NA_001290_20090525_SHIELD_SYSTEM
        CHAR_STATE_ETC_EXIST_SHELD_POINT = 5016,     //SD »óÅÂ (0ÀÌ»ó Á¸ÀçÇÏ´Â »óÅÂ) 
        CHAR_STATE_ETC_AUTO_RECOVER_SD = 5017,     //SD È¸º¹ »óÅÂ 
        CHAR_STATE_ETC_FIGHTING = 5018,     //SD ÀüÅõ »óÅÂ

        //_NA_0_20100222_UNIT_TRIGGERS_FRIEND_MONSTER
        CHAR_STATE_ETC_SKIP_UPDATE_TARGET_LIST = 5019,     // Å¸°Ù ¸®½ºÆ® °»½Å ÇÏÁö ¾Ê´Â »óÅÂ.
                                                            // _NA_0_20100817_HELLON_LAST_TRIGGER
        CHAR_STATE_ETC_TRIGGER_HOLDING = 5020,     // Æ®¸®°Å¸¦ ÅëÇÑ ¿¬ÃâÀ» À§ÇÏ¿© ÀÌµ¿ÀÌ ±ÝÁöµÈ »óÅÂ 

        // WOPS:6554
        CHAR_STATE_ETC_ITEM_RECOVER_HP_INSTANTLY = 5021,   // Áï½Ã È¸º¹Çü ¾ÆÀÌÅÛ¿¡ ÀÇÇÑ HP È¸º¹
                                                            //_NA_007514_20140828_NEW_CHARACTER_WITCHBLADE
        CHAR_STATE_ETC_AUTO_RECOVER_FP = 5022,     // ÀÚµ¿ FPÈ¸º¹( - )
                                                    //-------------------------------------------------------------------------------------------------
                                                    // »óÅÂ°­È­_Ä³½¬
                                                    //------------------------------------------------------------------------------------------------- 
        CHAR_STATE_ANGER2 = 1000,      // ºÐ³ë2
        CHAR_STATE_DEFENSE2 = 1001,        // ¹æ¾î2
        CHAR_STATE_FIGHTING2 = 1002,       // ÅõÁö2
        CHAR_STATE_BALANCE2 = 1003,        // ±ÕÇü2
        CHAR_STATE_VITAL_POWER2 = 1004,        // È°·Â2
        CHAR_STATE_MEDITATION2 = 1005,     // ¸í»ó2
        CHAR_STATE_HIGH_SPIRIT2 = 1006,        // ±â¼¼2
        CHAR_STATE_SPEEDING2 = 1007,       // ÁúÁÖ2
        CHAR_STATE_CONCENTRATION2 = 1008,      // ÁýÁß2
        CHAR_STATE_INCREASE_SKILLRANGE2 = 1009,        // ½Ã¾ß2
        CHAR_STATE_PRECISION2 = 1010,      // Á¤¹Ð2
        CHAR_STATE_HP_INCREASE2 = 1011,        // °Ý·Á2
        CHAR_STATE_MP_INCREASE2 = 1012,        // Åº·Â2
        CHAR_STATE_HPRATE_INCREASE2 = 1013,        // È°±â2
        CHAR_STATE_MPRATE_INCREASE2 = 1014,        // ÀÚ±Ø2
        CHAR_STATE_MAGIC_DEFENSE2 = 1015,      // ¸¶¹ý¹æ¾î2
        CHAR_STATE_STAT_STR2 = 1016,       // Èû°­È­2
        CHAR_STATE_STAT_DEX2 = 1017,       // ¹ÎÃ¸°­È­2
        CHAR_STATE_STAT_VIT2 = 1018,       // Ã¼·Â°­È­2
        CHAR_STATE_STAT_INT2 = 1019,       // Á¤½Å·Â°­È­2
        CHAR_STATE_STAT_SPI2 = 1020,       // Áö·Â°­È­2
        CHAR_STATE_MAGIC_ATTACK_INCREASE2 = 1021,      // ¸¶¹ý°ø°Ý»ó½Â2
        CHAR_STATE_STAT_DAMAGE_ADD2 = 1022,        // Ãß°¡µ¥¹ÌÁö2
        CHAR_STATE_FIRE_ATTACK_INCREASE2 = 1023,       // ºÒ¼Ó¼º°ø°Ý·ÂÁõ°¡2
        CHAR_STATE_WATER_ATTACK_INCREASE2 = 1024,      // ¹°¼Ó¼º°ø°Ý·ÂÁõ°¡2
        CHAR_STATE_WIND_ATTACK_INCREASE2 = 1025,       // ¹Ù¶÷¼Ó¼º°ø°Ý·ÂÁõ°¡2
        CHAR_STATE_EARTH_ATTACK_INCREASE2 = 1026,      // ´ëÁö¼Ó¼º°ø°Ý·ÂÁõ°¡2
        CHAR_STATE_DARK_ATTACK_INCREASE2 = 1027,       // ¾ÏÈæ¼Ó¼º°ø°Ý·ÂÁõ°¡2
        CHAR_STATE_FIRE_DEFENSE_INCREASE2 = 1028,      // ºÒ¼Ó¼º¹æ¾î·ÂÁõ°¡2
        CHAR_STATE_WATER_DEFENSE_INCREASE2 = 1029,     // ¹°¼Ó¼º¹æ¾î·ÂÁõ°¡2
        CHAR_STATE_WIND_DEFENSE_INCREASE2 = 1030,      // ¹Ù¶÷¼Ó¼º¹æ¾î·ÂÁõ°¡2
        CHAR_STATE_EARTH_DEFENSE_INCREASE2 = 1031,     // ´ëÁö¼Ó¼º¹æ¾î·ÂÁõ°¡2
        CHAR_STATE_DARK_DEFENSE_INCREASE2 = 1032,      // ¾ÏÈæ¼Ó¼º¹æ¾î·ÂÁõ°¡2
        CHAR_STATE_MP_SPEND_INCREASE2 = 1033,      // MPÀúÁÖ2(MP ¼Ò¸ð Áõ°¡)
        CHAR_STATE_MP_SPEND_DECREASE2 = 1034,      // MPÈ°·Â2(MP ¼Ò¸ð °¨¼Ò)	
        CHAR_STATE_DECREASE_CASTING_TIME2 = 1035,  //Ä³½ºÆÃ Å¸ÀÓ °¨¼Ò2
        CHAR_STATE_DECREASE_SKILL_COOL_TIME2 = 1036,   //½ºÅ³ ÄðÅ¸ÀÓ °¨¼Ò2	
        CHAR_STATE_TRANSFORMATION2 = 1037, // º¯½Å2
                                            //CHAR_STATE_STEEL2						= 1038, // °­Ã¶2(ÀÌµ¿ ¿Ü Çàµ¿ ºÒ´É, ÀÌµ¿¼Óµµ °¨¼Ò)
        CHAR_STATE_TRANSPARENT2 = 1039,    // Åõ¸í2(ÀÌµ¿ ¿ÜÀÇ Çàµ¿½Ã ÇØÁ¦)
        CHAR_STATE_FEAR2 = 1040, // ÇÇ¾î2(´ë»óÀ» µµ¸Á°¡°Ô ÇÑ´Ù.)
        CHAR_STATE_BLUR2 = 1041, // °ø°ÝºÒ´É2(´ë»óÀº °ø°ÝÀ» ¸øÇÑ´Ù.)
        CHAR_STATE_THRUST2 = 1042, // ¹Ð¸®±â2(¹Ð¸®°í ÀÖ´Â »óÅÂ)
        CHAR_STATE_SUMMON2 = 1043, // ¼ÒÈ¯2
        CHAR_STATE_SPCHARGE2 = 1044, // °Ë±âÃæÀü2
        CHAR_STATE_IGNORE_RESERVEHP2 = 1045,   // È°·Â(HPÀû¸³¹«½Ã2)
        CHAR_STATE_ANGER11 = 1046,
        CHAR_STATE_MAGIC_ATTACK_INCREASE11 = 1047,
        CHAR_STATE_DEFENSE11 = 1048,
        CHAR_STATE_MAGIC_DEFENSE10 = 1049,
        CHAR_STATE_PRECISION10 = 1050,
        //
        CHAR_STATE_PERK_SWITCHABLE_STATE = 1051, // ÆÜ ±³Ã¼ °¡´É, _NA001956_110210_PERK_SWITCHABLE_REGION
                                                  //__NA_001290_20090525_SHIELD_SYSTEM
        CHAR_STATE_ENCOURAGEMENT2 = 1076,      // Max sd Áõ°¡
        CHAR_STATE_PROMOTION2 = 1077,      // sd È¸º¹·® Áõ°¡
        CHAR_STATE_PLENTY = 1078,    // Ç³¿ä, ÇÏÀÓ È¹µæ·® Áõ°¡
        CHAR_STATE_SMART = 1079,    // ÃÑ¸í, ¸ó½ºÅÍ °æÇèÄ¡ È¹µæ·® Áõ°¡

        CHAR_STATE_SPEEDING6 = 1200,       // ÁúÁÖ3(ÀÌ¼Ó)
        CHAR_STATE_HIGH_SPIRIT6 = 1201,        // ±â¼¼3(°ø¼Ó)
        CHAR_STATE_HP_INCREASE6 = 1202,        // °Ý·Á(HPÁõ°¨)
        CHAR_STATE_TRANSPARENT6 = 1203,        // Åõ¸í6(ÀÌµ¿ ¿ÜÀÇ Çàµ¿½Ã ÇØÁ¦)
        CHAR_STATE_PRECISION6 = 1204,      // Á¤¹Ð3(Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Áõ°¡)
        CHAR_STATE_CONCENTRATION6 = 1205,      // ÁýÁß3(Å©¸®Æ¼ÄÃ È®·ü Áõ°¡)
        CHAR_STATE_ANGER6 = 1206,      // ºÐ³ë3(Ãß°¡ °ø°Ý·Â Áõ°¡)
        CHAR_STATE_MAGIC_ATTACK_INCREASE6 = 1207,      // ¸¶¹ý°ø°Ý»ó½Â3
        CHAR_STATE_DEFENSE6 = 1208,        // ¹°¸®¹æ¾î3
        CHAR_STATE_MAGIC_DEFENSE6 = 1209,      // ¸¶¹ý¹æ¾î3

        //__NA_000994_CHANGUP_NEW_SKILL
        CHAR_STATE_IMMUNITY_DAMAGE = 1301,     // ¹«Àû»óÅÂ( ¹°¸® & ¸¶¹ý µ¥¹ÌÁö ¾øÀ½, °ø°Ý°¡´É )
        CHAR_STATE_INTENSIFY_SKILL = 1302,     // ½ºÅ³µ¥¹ÌÁö°¡ Áõ°¡ÇÑ´Ù.( ½ºÅ³µ¥¹ÌÁö 300% )
        CHAR_STATE_INTENSIFY_SUMMON = 1303,        // ÆøÁÖ( ¼ÒÈ¯¼öÀÇ °ø°Ý·ÂÀÌ ´ëÆø Áõ°¡ )
        CHAR_STATE_ATTACK_IMPOSSIBLE = 1304,       // °ø°ÝºÒ°¡( °ø°ÝÀÌ ºÒ°¡´É ÇÏ´Ù )
        CHAR_STATE_HP_INCREASE7 = 1305,        // °Ý·Á( ÃÖ´ë HPÁõ°¡ )
        CHAR_STATE_BATTLE = 2001,      // ÀüÅõ»óÅÂ. 
        CHAR_STATE_DECREASE_SKILL_COOL_TIME6 = 7001,   // ½ºÅ³ ÄðÅ¸ÀÓ °¨¼Ò3
        CHAR_STATE_HP_INCREASE8 = 7002,    // °Ý·Á
        CHAR_STATE_ANGER7 = 7003,  // ºÐ³ë
        CHAR_STATE_HPRATE_INCREASE6 = 7004,    // È°±â
        CHAR_STATE_DECREASE_CASTING_TIME6 = 7005,  // Á¤½ÅÈ°·Â
        CHAR_STATE_MAGIC_ATTACK_INCREASE7 = 7006,  // ¸¶¹ý°ø°Ý»ó½Â
        CHAR_STATE_MPRATE_INCREASE6 = 7007,    // ÀÚ±Ø
        CHAR_STATE_CONCENTRATION7 = 7008,  // ÁýÁß
        CHAR_STATE_DEFENSE7 = 7009,    // ¹æ¾î	
                                        //CHAR_STATE_IGNORE_RESERVEHP6			= 7010,	// È°·Â(HPÀû¸³¹«½Ã6)

        //!_NA_000587_20100928_DOMINATION_BUFF_ITEM
        CHAR_STATE_HPRATE_INCREASE13 = 7101,   // È°±â_¼ºº®	        
        CHAR_STATE_DEFENSE13 = 7102,   // 	¹°¸®¹æ¾î_¼ºº®	    
        CHAR_STATE_MAGICDEFENSE13 = 7103,  // 	¸¶¹ý¹æ¾î_¼ºº®	    
        CHAR_STATE_HPRATE_INCREASE14 = 7104,   // 	È°±â_ÇÇÀÇ°í¸®	    
        CHAR_STATE_DEFENSE14 = 7105,   // 	¹°¸®¹æ¾î_ÇÇÀÇ°í¸®	    
        CHAR_STATE_MAGICDEFENSE14 = 7106,  // 	¸¶¹ý¹æ¾î_ÇÇÀÇ°í¸®	    
        CHAR_STATE_HPRATE_INCREASE15 = 7107,   // 	È°±â_ÇÇÀÇ°áÁ¤Ã¼	    
        CHAR_STATE_DEFENSE15 = 7108,   // 	¹°¸®¹æ¾î_ÇÇÀÇ°áÁ¤Ã¼	
        CHAR_STATE_MAGICDEFENSE15 = 7109,  // 	¸¶¹ý¹æ¾î_ÇÇÀÇ°áÁ¤Ã¼	

        //----------------------------------------------------------------------------------------------
        //  (WARNING) ¾Æ·¡ »óÅÂ ÀÌÈÄ¿¡ »óÅÂ Ãß°¡ÇØ¼± ¾ÈµÊ! »óÅÂ¸¦ ÀÌ¿ëÇÑ Á¦¾î ¸ñÀûÀ¸·Î »ç¿ëÇÏ°í ÀÖÀ½.
        //__NA000896_080215_TASK_SURVIVAL_SOLOING_QUEST_CSCOMMON__
        CHAR_STATE_SSQ_CTRL_BLOCK_ATTACK, // No real state|for control|SSQ »óÅÂÁ¦¾î (°ø°Ý/ÇÇ°Ý) ºÒ°¡´É »óÅÂ ¼³Á¤
        CHAR_STATE_WAR_CTRL_OBSERVER_MODE, // No real state|for control|°üÀü ¸¸À» À§ÇÑ »óÅÂ ¼³Á¤
                                            //__NA001390_090915_RIDING_SYSTEM__
        CHAR_STATE_RIDING_RIDER, // No real state|for control|Riding Status|
        CHAR_STATE_NPC_NON_PREEMPTIVE_ATTACK, // ºñ¼±°ø »óÅÂ (Á¡·ÉÁö¿ª ±æµå¿ø)   //_NA001385_20090924_DOMINATION_ETC
                                               // (CHANGES) (f100514.3L) add the flag to prevent ANY actions that
                                               // a player do a delayed spiking whether the player request a LEAVE.
        CHAR_STATE_ZONE_TRANSACTION,
        // CHANGES: f110315.2L, declared by _NA001955_110210_WING_COSTUME
        CHAR_STATE_SPREAD_WINGS, // whether a player spread winds
        CHAR_STATE_SPEED_HACK_PREVENTION, //_NA000000_SPEED_HACK_PREVENTION_SUPPORT
    };

    public enum CharCondition
    {
        CHAR_CONDITION_STANDUP,    // ¼­±â
        CHAR_CONDITION_SITDOWN,    // ¾É±â

        CHAR_CONDITION_MAX,
    };

    public enum AttackSequence
    {
        ATTACK_SEQUENCE_FIRST,
        ATTACK_SEQUENCE_SECOND,
        ATTACK_SEQUENCE_THIRD,
        ATTACK_SEQUENCE_NONE,

        ATTACK_SEQUENCE_MAX

    };
}
