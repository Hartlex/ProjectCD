using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable IdentifierTypo

namespace SunStructs.Definitions
{
    public enum CharCreateResult
    {
        RC_CHAR_CREATE_SUCCESS,
        RC_CHAR_CREATE_ALREADY_DOING_TRANSACTION,   //< ÀÌ¹Ì ´Ù¸¥ Æ®·£Àè¼ÇÀ» ÁøÇàÁßÀÌ´Ù.
        RC_CHAR_CREATE_INVALID_PARAM,               //< ÆÐÅ¶ÀÌ Àß¸øµÈ °ªÀÔ´Ï´Ù.
        RC_CHAR_CREATE_MINIMUM_CHARACTER,           //< ÃÖ¼Ò±ÛÀÚ¼ö Á¦ÇÑ ¿À·ù : ¿µ¹®4±ÛÀÚ, ÇÑ±Û2±ÛÀÚ ÀÌ»ó
        RC_CHAR_CREATE_DISCONNECTED_DBPROXY,        //< DBP°¡ ¿¬°áÀÌ µÇÁö ¾Ê¾Ò½À´Ï´Ù.(Àá½ÃµÚ ¼­ºñ½º ÀÌ¿ë¹Ù¶÷)
        RC_CHAR_CREATE_CANNOT_CREATE_TO_SERVICE,    //< ÇØ´Þ¿ùµåÀÇ È¥ÀâÀ¸·Î ½Å±ÔÄ³¸¯ÅÍ »ý¼ºÀÌ ºÒ°¡´ÉÇÕ´Ï´Ù.
        RC_CHAR_CREATE_EXIST_SAME_NAME,             //< µ¿ÀÏ Ä³¸¯ÅÍ ¸í Á¸ÀçÇÔ
        RC_CHAR_CREATE_SLOT_FULL,                   //< ½½·Ô Ç®
        RC_CHAR_CREATE_TRANSACTION_ERROR,           //< Æ®·£Á§¼Ç ¿À·ù(Äõ¸®¿À·ù,±âÅ¸¿À·ù)
        RC_CHAR_CREATE_QUERY_ERROR,                 //< DBÄõ¸® ½ÇÆÐ
        RC_CHAR_CREATE_DBUSER_NOT_EXIST,            //< DBProxyÀÇ DBÀ¯Àú°¡ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
        RC_CHAR_CREATE_DBCHAR_ALREADY_CREATED,      //< DBPÀÇ Ä³¸¯ÅÍ°¡ ÀÌ¹Ì ¸¸µé¾îÁ® ÀÖ´Ù.
        RC_CHAR_CREATE_CHARNAME_BAN_WORD,           //< ±ÝÁö ´Ü¾î¸¦ »ç¿ëÇÑ Ä³¸¯ÅÍ¸í 
        RC_CHAR_CREATE_CANNOT_BETAKEY,              //»ç¿ëÀÚ°¡ °¡Áø º£Å¸Å°·Î´Â ÇØ´ç Ä³¸¯ÅÍ¸¦ »ý¼ºÇÒ¼ö ¾ø½À´Ï´Ù.
    };
    public enum CharDestroyResult
    {
        RC_CHAR_DESTROY_SUCCESS,
        RC_CHAR_DESTROY_ALREADY_DOING_TRANSACTION,  //< ÀÌ¹Ì ´Ù¸¥ Æ®·£Àè¼ÇÀ» ÁøÇàÁßÀÌ´Ù.
        RC_CHAR_DESTROY_INVALID_PARAM,              //< ÆÐÅ¶ÀÌ Àß¸øµÈ °ªÀÔ´Ï´Ù.
        RC_CHAR_DESTROY_DESTROIED,                  //< ÀÌ¹Ì ÆÄ±«µÈ Ä³¸¯ÅÍ ÀÌ´Ù.
        RC_CHAR_DESTROY_INCORRECT_SSN,              //< Àß¸øµÈ ÁÖ¹Îµî·Ï¹øÈ£ÀÌ´Ù.
        RC_CHAR_DESTROY_TRANSACTION_ERROR,          //< Æ®·£Á§¼Ç ¿À·ù(Äõ¸®¿À·ù,±âÅ¸¿À·ù)
        RC_CHAR_DESTROY_DISCONNECTED_DBPROXY,       //< DBP°¡ ¿¬°áÀÌ µÇÁö ¾Ê¾Ò½À´Ï´Ù.(Àá½ÃµÚ ¼­ºñ½º ÀÌ¿ë¹Ù¶÷)
        RC_CHAR_DESTROY_GUILD_MASTER,               //< »èÁ¦ Ä³¸¯ÅÍ°¡ ±æµå ¸¶½ºÅÍÀÓ(»èÁ¦ºÒ°¡)
        RC_CHAR_DESTROY_DBUSER_ALREADY_CREATED,     //< DBPÀÇ À¯Àú°¡ ÀÌ¹Ì ¸¸µé¾îÁ® ÀÖ´Ù.
        RC_CHAR_DESTROY_QUERY_ERROR,                //< DBÄõ¸® ½ÇÆÐ
        RC_CHAR_DESTROY_DBUSER_DONOT_EXIST,         //< DBProxyÀÇ DBÀ¯Àú°¡ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
        RC_CHAR_DESTROY_DBCHAR_DONOT_EXIST,         //< »èÁ¦ÇÒ Ä³¸¯ÅÍ°¡ ¾ø´Ù.
        RC_CHAR_DESTROY_FAILED,						//< Ä³¸¯ÅÍ »èÁ¦ ½ÇÆÐ
        RC_CHAR_DESTROY_GROUP_MEMBER,               //< ±×·ì¸É¹ö°¡ Á¸ÀçÇÏ¿© ÄÉ¸¯ÅÍ »èÁ¦¿¡ ½ÇÆÐ ÇÏ¿´´Ù.//[20090811][4540]±×·ì ¸É¹ö Á¸Àç½Ã »èÁ¦ ºÒ°¡ ¸Þ¼¼Áö Ãß°¡
    };
    public enum CharIdCheckResult
    {
        RC_CHAR_IDCHECK_SUCCESS,
        RC_CHAR_IDCHECK_ALREADY_DOING_TRANSACTION,  //< ´Ù¸¥ Æ®·£Àè¼ÇÀ» ÁøÇàÁßÀÌ´Ù.
        RC_CHAR_IDCHECK_DISCONNECTED_DBPROXY,       //< DBP°¡ ¿¬°áÀÌ µÇÁö ¾Ê¾Ò´Ù.
        RC_CHAR_IDCHECK_TRANSACTION_ERROR,          //< Æ®·£Á§¼Ç ¿À·ù( Äõ¸® ¿À·ù, ±âÅ¸ ¿À·ù )
        RC_CHAR_IDCHECK_DBUSER_DONOT_EXIST,         //< DBProxyÀÇ DBÀ¯Àú°¡ Á¸ÀçÇÏÁö ¾Ê´Â´Ù.
        RC_CHAR_IDCHECK_FAILED,
    };

    public enum GuildDuty
    {
        GUILD_DUTY_NONE,
        GUILD_DUTY_MASTER,                 // ±æµå ¸¶½ºÅÍ
        GUILD_DUTY_SUBMASTER,              // ¼­ºê ¸¶½ºÅÍ
        GUILD_DUTY_STRATEGIST,             // ±º»ç[Àü·«°¡]     : ±æµå ¸®´º¾ó -> X
        GUILD_DUTY_COMMANDER,              // ±º´ÜÀå           : ±æµå ¸®´º¾ó -> X
        GUILD_DUTY_LEADER,                 // ±ÙÀ§ ´ëÀå        : ±æµå ¸®´º¾ó -> NEW
        GUILD_DUTY_CAMP_LEADER,            // ÈÆ·Ã(Ä·ÇÁ)´ëÀå   : ±æµå ¸®´º¾ó -> X
        GUILD_DUTY_REGULAR_SOLDIER,        // ´Ü¿ø(Á¤¿¹±º)     : ±æµå ¸®´º¾ó -> ÀÏ¹Ý º´»ç
        GUILD_DUTY_CAMP_SOLDIER,           // ÈÆ·Ã(Ä·ÇÁ)º´     : ±æµå ¸®´º¾ó -> X
        GUILD_DUTY_MAX,
    };
    public enum ChaosState
    {
        CHAOS_STATE_NORMAL,         // ÀÏ¹Ý
        CHAOS_STATE_PREV_CHAO,      // ÇÁ¸® Ä«¿À
        CHAOS_STATE_CHAO,           // Ä«¿À
    };
    public enum ObjectType
    {
        OBJECT_OBJECT = (1 << 1),
        CHARACTER_OBJECT = (OBJECT_OBJECT | (1 << 2)),
        NONCHARACTER_OBJECT = (OBJECT_OBJECT | (1 << 3)),
        PLAYER_OBJECT = (CHARACTER_OBJECT | (1 << 4)),
        NPC_OBJECT = (CHARACTER_OBJECT | (1 << 5)),
        MONSTER_OBJECT = (NPC_OBJECT | (1 << 6)),
        SUMMON_OBJECT = (NPC_OBJECT | (1 << 7)),
        MERCHANT_OBJECT = (NPC_OBJECT | (1 << 8)),
        MAPNPC_OBJECT = (NPC_OBJECT | (1 << 9)),
        LUCKYMON_OBJECT = (MONSTER_OBJECT | (1 << 10)),
        ITEM_OBJECT = (NONCHARACTER_OBJECT | (1 << 11)),
        MAP_OBJECT = (NONCHARACTER_OBJECT | (1 << 12)),
        MONEY_OBJECT = (ITEM_OBJECT | (1 << 13)),
        CAMERA_OBJECT = (1 << 14),
        TRANSFORM_PLAYER_OBJECT = (1 << 15),
        TOTEMNPC_OBJECT = (NPC_OBJECT | (1 << 16)),
        PET_OBJECT = (CHARACTER_OBJECT | (1 << 17)),
        SSQMONSTER_OBJECT = (MONSTER_OBJECT | (1 << 18)),
        COLLECTION_OBJECT = (NONCHARACTER_OBJECT | (1 << 19)),
        LOTTO_NPC_OBJECT = (NPC_OBJECT | (1 << 20)),
        RIDER_OBJECT = (CHARACTER_OBJECT | (1 << 21)),
        CRYSTALWARP_OBJECT = (NPC_OBJECT | (1 << 22)),
        FRIEND_MONSTER_OBJECT = (MONSTER_OBJECT | (1 << 23)),   // _NA_0_20100222_UNIT_TRIGGERS_FRIEND_MONSTER
        SYNC_MERCHANT_OBJECT = (MONSTER_OBJECT | (1 << 24)),   // _NA_0_20100222_UNIT_TRIGGERS_REGEN
        MAX_OBJECT = (1 << 31),
    };

    public enum AttrType
    {
        ATTR_TYPE_INVALID = 0,                         // À¯È¿ÇÏÁö ¾Ê´Â ¼Ó¼º
        ATTR_STR = 1,                                  // ½ºÅÈ(Èû)
        ATTR_DEX = 2,                                  // ½ºÅÈ(¹ÎÃ¸)
        ATTR_VIT = 3,                                  // ½ºÅÈ(Ã¼·Â)
        ATTR_INT = 4,                                  // ½ºÅÈ(Áö·Â)
        ATTR_SPR = 5,                                  // ½ºÅÈ(Á¤½Å·Â)

        ATTR_EXPERTY1 = 6,                             // EP2:unused, ¼÷·Ãµµ1
        ATTR_EXPERTY2 = 7,                             // EP2:unused, ¼÷·Ãµµ2

        ATTR_CUR_HP = 8,                               // ÇöÀç HP
        ATTR_CUR_MP = 9,                               // ÇöÀç MP

        ATTR_MAX_HP = 10,                              // ÃÖ´ë HP
        ATTR_MAX_MP = 11,                              // ÃÖ´ë MP

        ATTR_RECOVERY_HP = 12,                         // HP È¸º¹·®
        ATTR_RECOVERY_MP = 13,                         // MP È¸º¹·®

        //--------------------------------------------------------------------------------------------------
        // °ø°Ý·Â °ü·Ã ÆÄ¶ó¹ÌÅÍ
        //--------------------------------------------------------------------------------------------------
        ATTR_BASE_MELEE_MIN_ATTACK_POWER,              // ±âº» ¹°¸® °ø°Ý·Â
        ATTR_BASE_MELEE_MAX_ATTACK_POWER,
        ATTR_BASE_RANGE_MIN_ATTACK_POWER,
        ATTR_BASE_RANGE_MAX_ATTACK_POWER,
        ATTR_BASE_MAGICAL_MIN_ATTACK_POWER,            // EP2:unused, ±âº» ¸¶¹ý (ÃÖ¼Ò) °ø°Ý·Â
        ATTR_BASE_MAGICAL_MAX_ATTACK_POWER,            // EP2:unused, ±âº» ¸¶¹ý (ÃÖ´ë) °ø°Ý·Â

        ATTR_OPTION_PHYSICAL_ATTACK_POWER,             // [V] ¿É¼Ç ¹°¸® °ø°Ý·Â
        ATTR_OPTION_MAGICAL_ATTACK_POWER,              // EP2:unused
        ATTR_OPTION_ALL_ATTACK_POWER,                  // EP2:unused, ¿É¼Ç ÀüÃ¼ ¹°¸® °ø°Ý·Â

        ATTR_MAGICAL_WATER_ATTACK_POWER,               // [V] ¿ø¼Ò(¹°) °ø°Ý·Â
        ATTR_MAGICAL_FIRE_ATTACK_POWER,                // [V] ¿ø¼Ò(ºÒ) °ø°Ý·Â
        ATTR_MAGICAL_WIND_ATTACK_POWER,                // [V] ¿ø¼Ò(¹Ù¶÷) °ø°Ý·Â
        ATTR_MAGICAL_EARTH_ATTACK_POWER,               // [V] ¿ø¼Ò(´ëÁö) °ø°Ý·Â
        ATTR_MAGICAL_DARKNESS_ATTACK_POWER,            // [V] ¿ø¼Ò(¾ÏÈæ) °ø°Ý·Â
        ATTR_MAGICAL_DIVINE_ATTACK_POWER,              // unused

        ATTR_MAGICAL_ALL_ATTACK_POWER,                 // [V] ¸¶¹ý¼Ó¼º ÀüÃ¼ °ø°Ý·Â, EP2={ FIRE, WATER, WIND, EARTH, DARK }

        ATTR_ADD_SKILL_ATTACK_POWER,                   // [V] ½ºÅ³ Ãß°¡ °ø°Ý·Â
        ATTR_ADD_SKILL_DAMAGE_RATIO,                   // [R] ½ºÅ³ ÆÛ¼¾Æ® Ãß°¡ µ¥¹ÌÁö

        //--------------------------------------------------------------------------------------------------
        // ¹æ¾î·Â °ü·Ã ÆÄ¶ó¹ÌÅÍ
        //--------------------------------------------------------------------------------------------------
        ATTR_BASE_MELEE_DEFENSE_POWER,                 // [V] ±âº» (±Ù°Å¸®) ¹°¸® ¹æ¾î·Â
        ATTR_BASE_RANGE_DEFENSE_POWER,                 // [V] ±âº» (¿ø°Å¸®) ¹°¸® ¹æ¾î·Â
        ATTR_BASE_MAGICAL_DEFENSE_POWER,               // EP2:unused, ±âº» ¸¶¹ý ¹æ¾î·Â
        
        ATTR_OPTION_PHYSICAL_DEFENSE_POWER,            // ¿É¼Ç ¹°¸® ¹æ¾î·Â
        ATTR_OPTION_MAGICAL_DEFENSE_POWER,             // EP2:unused
        ATTR_OPTION_ALL_DEFENSE_POWER,                 // EP2:unused, ¿É¼Ç ÀüÃ¼ ¹°¸® ¹æ¾î·Â <- ¿É¼Ç ¹°¸®+¸¶¹ý ¹æ¾î·Â

        ATTR_MAGICAL_WATER_DEFENSE_POWER,              // EP2:unused, [V] ¿ø¼Ò(¹°) ¹æ¾î·Â
        ATTR_MAGICAL_FIRE_DEFENSE_POWER,               // EP2:unused, [V] ¿ø¼Ò(ºÒ) ¹æ¾î·Â
        ATTR_MAGICAL_WIND_DEFENSE_POWER,               // EP2:unused, [V] ¿ø¼Ò(¹Ù¶÷) ¹æ¾î·Â
        ATTR_MAGICAL_EARTH_DEFENSE_POWER,              // EP2:unused, [V] ¿ø¼Ò(´ëÁö) ¹æ¾î·Â
        ATTR_MAGICAL_DARKNESS_DEFENSE_POWER,           // EP2:unused, [V] ¿ø¼Ò(¾ÏÈæ) ¹æ¾î·Â
        ATTR_MAGICAL_DIVINE_DEFENSE_POWER,             // unused

        ATTR_MAGICAL_ALL_DEFENSE_POWER,                // EP2:unused, [V] ¿ø¼Ò ÀüÃ¼ ¹æ¾î·Â EP2={ FIRE, WATER, WIND, EARTH, DARK }

        ATTR_ADD_ALL_DEFENSE_POWER,                    // EP2:unused, [V] °ø°Ý Å¸ÀÔº° Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_MELEE_DEFENSE_POWER,                  // EP2:unused, [V] °ø°Ý´ë»ó (±ÙÁ¢) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_RANGE_DEFENSE_POWER,                  // EP2:unused, [V] °ø°Ý´ë»ó (¿ø°Å¸®) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_WATER_DEFENSE_POWER,                  // EP2:unused, [V] °ø°Ý´ë»ó (¹°) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_FIRE_DEFENSE_POWER,                   // EP2:unused, [V] °ø°Ý´ë»ó (ºÒ) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_WIND_DEFENSE_POWER,                   // EP2:unused, [V] °ø°Ý´ë»ó (¹Ù¶÷) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_EARTH_DEFENSE_POWER,                  // EP2:unused, [V] °ø°Ý´ë»ó (´ëÁö) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_DARKNESS_DEFENSE_POWER,               // EP2:unused, [V] °ø°Ý´ë»ó (¾ÏÈæ) Ãß°¡ ¹æ¾î·Â
        ATTR_ADD_DIVINE_DEFENSE_POWER,                 // EP2:unused
        ATTR_ADD_PHYSICAL_DEFENSE_POWER,               // EP2:unused
        ATTR_ADD_MAGICAL_DEFENSE_POWER,                // EP2:unused
        ATTR_ADD_MAGICAL_ALL_DEFENSE_POWER,            // EP2:unused

        ATTR_DEL_ALL_TARGET_DEFENSE_RATIO,             // EP2:unused
        ATTR_DEL_MELEE_TARGET_DEFENSE_RATIO,           // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
        ATTR_DEL_RANGE_TARGET_DEFENSE_RATIO,           // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
        ATTR_DEL_WATER_TARGET_DEFENSE_RATIO,           // [R] °ø°Ý´ë»ó ¿ø¼Ò(¹°) ¹æ¾î·Â °¨¼ÒÀ²
        ATTR_DEL_FIRE_TARGET_DEFENSE_RATIO,            // [R] °ø°Ý´ë»ó ¿ø¼Ò(ºÒ) ¹æ¾î·Â °¨¼ÒÀ²
        ATTR_DEL_WIND_TARGET_DEFENSE_RATIO,            // [R] °ø°Ý´ë»ó ¿ø¼Ò(¹Ù¶÷) ¹æ¾î·Â °¨¼ÒÀ²
        ATTR_DEL_EARTH_TARGET_DEFENSE_RATIO,           // [R] °ø°Ý´ë»ó ¿ø¼Ò(´ëÁö) ¹æ¾î·Â °¨¼ÒÀ²
        ATTR_DEL_DARKNESS_TARGET_DEFENSE_RATIO,        // [R] °ø°Ý´ë»ó ¿ø¼Ò(¾ÏÈæ) ¹æ¾î·Â °¨¼ÒÀ²
        ATTR_DEL_DIVINE_TARGET_DEFENSE_RATIO,          // EP2:unused
        ATTR_DEL_PHYSICAL_TARGET_DEFENSE_RATIO,        // [R] °ø°Ý´ë»ó ¹°¸® ¹æ¾î·Â °¨¼ÒÀ²
        ATTR_DEL_MAGICAL_TARGET_DEFENSE_RATIO,         // EP2:unused
        ATTR_DEL_MAGICAL_ALL_TARGET_DEFENSE_RATIO,     // [R] °ø°Ý´ë»ó ÀüÃ¼ ¿ø¼Ò ¹æ¾î·Â °¨¼ÒÀ²

        //--------------------------------------------------------------------------------------------------
        // µ¥¹ÌÁö °ü·Ã ÆÄ¶ó¹ÌÅÍ
        //--------------------------------------------------------------------------------------------------
        ATTR_ADD_ARMOR_HARD_DAMAGE,                    // EP2:unused, ¾Æ¸Ó Å¸ÀÔº° Ãß°¡ µ¥¹ÌÁö
        ATTR_ADD_ARMOR_MEDIUM_DAMAGE,                  // EP2:unused
        ATTR_ADD_ARMOR_SOFT_DAMAGE,                    // EP2:unused
        ATTR_ADD_ARMOR_SIEGE_DAMAGE,                   // EP2:unused
        ATTR_ADD_ARMOR_UNARMOR_DAMAGE,                 // EP2:unused

        ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE,              // EP2:unused, ¾Æ¸Ó Å¸ÀÔº° Ãß°¡ µ¥¹ÌÁö(ÆÛ¼¾Æ®)
        ATTR_ADD_RATIO_ARMOR_MEDIUM_DAMAGE,            // EP2:unused
        ATTR_ADD_RATIO_ARMOR_SOFT_DAMAGE,              // EP2:unused
        ATTR_ADD_RATIO_ARMOR_SIEGE_DAMAGE,             // EP2:unused
        ATTR_ADD_RATIO_ARMOR_UNARMOR_DAMAGE,           // EP2:unused
                                                        // CHANGES: changes value type to ratio type since EP2
        ATTR_DEL_ALL_DAMAGE,                           // EP2:unused, °¨¼Ò µ¥¹ÌÁö
        ATTR_DEL_MELEE_DAMAGE,                         // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
        ATTR_DEL_RANGE_DAMAGE,                         // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
        ATTR_DEL_WATER_DAMAGE,                         // [R] ¿ø¼Ò(¹°)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
        ATTR_DEL_FIRE_DAMAGE,                          // [R] ¿ø¼Ò(ºÒ)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
        ATTR_DEL_WIND_DAMAGE,                          // [R] ¿ø¼Ò(¹Ù¶÷)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
        ATTR_DEL_EARTH_DAMAGE,                         // [R] ¿ø¼Ò(´ëÁö)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
        ATTR_DEL_DARKNESS_DAMAGE,                      // [R] ¿ø¼Ò(¾ÏÈæ)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
        ATTR_DEL_DIVINE_DAMAGE,                        // EP2:unused
        ATTR_DEL_PHYSICAL_DAMAGE,                      // [R] EP2: ¹°¸® °ø°Ý¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
        ATTR_DEL_MAGICAL_DAMAGE,                       // EP2:unused
        ATTR_DEL_MAGICAL_ALL_DAMAGE,                   // [R] EP2: ¿ø¼Ò(¸ðµç)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü

        //--------------------------------------------------------------------------------------------------
        // ±âÅ¸ ÆÄ¶ó¹ÌÅÍ
        //--------------------------------------------------------------------------------------------------
        ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO,            // °ø°Ý ¼º°ø·ü(¹°¸®)
        ATTR_PHYSICAL_ATTACK_BLOCK_RATIO,              // [R][ 15] °ø°Ý ¹æ¾îÀ² (¿É¼Ç) Ãß°¡À²
        ATTR_PHYSICAL_ATTACK_BLOCK_BASE_ARMOR_RATIO,   // EP2:added, °ø°Ý ¹æ¾îÀ² ¾ÆÀÌÅÛ Á¾ÇÕ (ÃÑ ÇÕ»ê / 5)

        ATTR_MOVE_SPEED,                               // ÀÌµ¿ ¼Óµµ
        ATTR_ATTACK_SPEED,                             // °ø°Ý ¼Óµµ

        ATTR_ALL_ATTACK_RANGE,                         // ¸ðµç »ç°Å¸®
        ATTR_NORMAL_ATTACK_RANGE,                      // ÀÏ¹Ý »ç°Å¸®
        ATTR_SKILL_ATTACK_RANGE,                       // ½ºÅ³ »ç°Å¸®

        ATTR_SIGHT_RANGE,                              // ½Ã¾ß

        ATTR_CRITICAL_RATIO_CHANGE,                    // Å©¸®Æ¼ÄÃ È®·ü Áõ°¨
        ATTR_ADD_MAGICAL_CRITICAL_RATIO,               // EP2:unused, ¸¶¹ý Å©¸®Æ¼ÄÃ È®·ü
        ATTR_ADD_ALL_CRITICAL_RATIO,                   // EP2:unused, ÀüÃ¼ Å©¸®Æ¼ÄÃ È®·ü
        ATTR_CRITICAL_DAMAGE_CHANGE,                   // Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Ãß°¡

        ATTR_ADD_ATTACK_INC_RATIO,                     // [R] Ãß°¡ °ø°Ý »ó½ÂÀ²
        ATTR_ADD_DEFENSE_INC_RATIO,                    // [R] Ãß°¡ ¹æ¾î »ó½ÂÀ²
        
        ATTR_INCREASE_SKILL_LEVEL,                     // ½ºÅ³ ·¹º§ 1»ó½Â
        ATTR_INCREASE_STAT_POINT,                      // ½ºÅÝ Æ÷ÀÎÆ®(¸ðµÎ)1»ó½Â

        //  2006 ¿ÀÈÄ 1:23:11
        ATTR_DECREASE_LIMIT_STAT,                      // ½ºÅÝ Á¦ÇÑ ¼öÄ¡ °¨¼Ò
        ATTR_MP_SPEND_INCREASE,                        // MP ¼Òºñ °¨¼Ò

        //  »ó¿ëÈ­ ¾ÆÀÌÅÛ ¿É¼Ç Ãß°¡
        ATTR_ABSORB_HP,                                // HPÈí¼ö
        ATTR_ABSORB_MP,                                // MP,SP Èí¼ö
        ATTR_REFLECT_DAMAGE_RATIO,                     // µ¥¹ÌÁö ¹Ý»ç
        ATTR_BONUS_MONEY_RATIO,                        // ÇÏÀÓ Áõ°¡
        ATTR_BONUS_EXP_RATIO,                          // °æÇèÄ¡ Áõ°¡
        ATTR_AREA_ATTACK_RATIO,                        // ´ÙÁß°ø°Ý È®·ü
        ATTR_BONUS_CASTING_TIME,                       // 65:Ä³½ºÆÃ Å¸ÀÓ Áõ°¨
        ATTR_BONUS_SKILL_COOL_TIME,                    // 75:[R] ½ºÅ³ ÄðÅ¸ÀÓ Áõ°¨
        ATTR_DECREASE_DAMAGE,                          // µ¥¹ÌÁö °¨¼Ò
        
        ATTR_RESURRECTION_RATIO,                       // 52:»ç¸Á½Ã ½º½º·Î ºÎÈ° ÇÒ È®·ü
        ATTR_DOUBLE_DAMAGE_RATIO,                      // 53:µ¥¹ÌÁöÀÇ µÎ¹è°¡ µÉ È®·ü
        ATTR_LUCKMON_INC_DAMAGE,                       // 54:·°Å° ¸ó½ºÅÍ °ø°Ý½Ã Ãß°¡ µ¥¹ÌÁö
        ATTR_COPOSITE_INC_RATIO,                       // 55:Á¶ÇÕ ¼º°ø·ü Áõ°¡
        ATTR_BYPASS_DEFENCE_RATIO,                     // 56:¹æ¾î·Â ¹«½Ã È®À²
        ATTR_INCREASE_MIN_DAMAGE,                      // 57:ÃÖ¼Ò µ¥¹ÌÁö Áõ°¡
        ATTR_INCREASE_MAX_DAMAGE,                      // 58:ÃÖ´ë µ¥¹ÌÁö Áõ°¡
        ATTR_DECREASE_ITEMDURA_RATIO,                  // 59:¾ÆÀÌÅÛ ³»±¸·Â °¨¼Ò¹«½Ã È®À²
        ATTR_RESISTANCE_BADSTATUS_RATIO,               // 60:½ºÅ³ È¿°ú ¹«ÁöÈ®À²
        ATTR_INCREASE_SKILLDURATION,                   // 61:½ºÅ³ È¿°ú ½Ã°£ Áõ°¡ ( ¹öÇÁ °è¿­ )
        ATTR_DECREASE_SKILL_SKILLDURATION,             // 62:½ºÅ³ È¿°ú ½Ã°£ Áõ°¨ ( µð¹öÇÁ °è¿­ ) < f110531.6L, changed from '°¨¼Ò'
        ATTR_OPTION_ETHER_DAMAGE_RATIO,                // 63:¿¡Å×¸£¿þÆù µ¥¹ÌÁö º¯È­
        ATTR_OPTION_ETHER_PvE_DAMAGE_RATIO,            // 76:¿¡Å×¸£¿þÆù µ¥¹ÌÁö º¯È­ (PvE¿ë), f110601.4L

        ATTR_INCREASE_RESERVE_HP,                      // 64:Àû¸³ HP Áõ°¡

        ATTR_RESIST_HOLDING,                           // 66:È¦µù ³»¼º
        ATTR_RESIST_SLEEP,                             // 67:½½¸³ ³»¼º
        ATTR_RESIST_POISON,                            // 68:Áßµ¶ ³»¼º
        ATTR_RESIST_KNOCKBACK,                         // 69:³Ë¹é ³»¼º
        ATTR_RESIST_DOWN,                              // 70:´Ù¿î ³»¼º
        ATTR_RESIST_STUN,                              // 71:½ºÅÏ ³»¼º
        ATTR_DECREASE_PVPDAMAGE,                       // 72:PVPµ¥¹ÌÁö °¨¼Ò
        ATTR_ADD_DAMAGE,                               // 73:Ãß°¡µ¥¹ÌÁö
        ATTR_AUTO_ITEM_PICK_UP,                        // 74:Item ÀÚµ¿ ÁÝ±â
                                                        // NOTE: regenerated index
        ATTR_MAX_SD,                                   // 93:ÃÖ´ë SD
        ATTR_RECOVERY_SD,                              // 94:SD È¸º¹·®
        ATTR_CUR_SD,                                   // ÇöÀç SD

        // _NA_003966_20111227_ADD_ENCHANT
        ATTR_INCREASE_ENCHANT_RATIO, // 77:ÀÎÃ¾Æ® ¼º°ø·ü Áõ°¡

        ATTR_PREMIUMSERVICE_PCBANG,                    // PC¹æ È¿°ú

        //_NA_006731_20130521_ENCHANT_ADD_OPTION
        ATTR_ENEMY_CRITICAL_RATIO_CHANGE,                  // 96:ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ È®·ü Áõ°¨

        //_NA_006680_20130426_ITEM_OPTION_ADD_AND_MODIFY
        ATTR_ATTACK_DAMAGE_ABSORB_SD_RATIO,             // 98:°¡ÇØ µ¥¹ÌÁö SD ÀüÈ¯·®
        ATTR_ATTACK_DAMAGE_ABSORB_HP_RATIO,             // 99:°¡ÇØ µ¥¹ÌÁö HP ÀüÈ¯·®

        //_NA_006937_20131030_ABILITY_AND_STATE_CHANGE_CRITICAL
        ATTR_ENEMY_CRITICAL_DAMAGE_CHANGE,           // 100:ÇÇ°Ý ½Ã »ó´ëÀÇ Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Áõ°¨

        //_NA_007330_20140620_GUILD_SYSTEM_EXTENSION
        ATTR_CRAFT_COST_RATIO,                         // 101:Á¦ÀÛ ºñ¿ë Áõ°¨
        ATTR_CRAFT_PREVENT_EXTINCTION_MATERIAL_RATIO,  // 102:Á¦ÀÛ ½ÇÆÐ½Ã Àç·á ¼Ò¸ê ¹æÁö È®·ü Áõ°¨
        ATTR_ENCHANT_COST_RATIO,                       // 103:ÀÎÃ¦Æ® ºñ¿ë Áõ°¨
        ATTR_ENCHANT_PREVENT_DESTROY_N_DOWNGRADE_ITEM_RATIO, // 104:ÀÎÃ¦Æ® ½ÇÆÐ½Ã ¾ÆÀÌÅÛ ¼Ò¸ê, ´Ù¿î ¹æÁö È®·ü Áõ°¨
        ATTR_RECOVER_POTION_COOLTIME_RATIO,            // 105:È¸º¹ Æ÷¼Ç ÄðÅ¸ÀÓ Áõ°¨
        ATTR_RECOVER_POTION_RECOVERY_RATIO,            // 106:È¸º¹ Æ÷¼Ç È¸º¹·® Áõ°¨
        ATTR_QUEST_REWARD_EXP_RATIO,                   // 107:Äù½ºÆ® º¸»ó °æÇèÄ¡ Áõ°¨
        ATTR_MAX_DAMAGE_RATIO,                         // 108:ÃÖ´ë µ¥¹ÌÁö ¹ß»ýÈ®·ü Áõ°¨
        ATTR_DOMINATION_MAPOBJECT_DAMAGE_RATIO,        // 109:°ø¼º ¿ÀºêÁ§Æ® µ¥¹ÌÁö Áõ°¨
        ATTR_SHOP_REPAIR_HEIM_RATIO,                   // 110:»óÁ¡ ¼ö¸® ÇÏÀÓ Áõ°¨
        ATTR_SHOP_BUY_HEIM_RATIO,                      // 111:»óÁ¡ ±¸¸Å ÇÏÀÓ Áõ°¨

        //_NA_007514_20140828_NEW_CHARACTER_WITCHBLADE
        ATTR_MAX_FP,                                   // 112: À§Ä¡ºí·¹ÀÌµå ÃÖ´ëFP
        ATTR_RECOVERY_FP,                               // 113: À§Ä¡ºí·¹ÀÌµå FPÈ¸º¹·® (°ø°Ý½Ã)
        ATTR_INCREASE_DAMAGE_RATIO,                     // 114: µ¥¹ÌÁö Áõ°¡ 

        //_NA_008124_20150313_AWAKENING_SYSTEM
        ATTR_AWAKENING_PROBABILITY,                     // 115: °¢¼º È®·ü Áõ°¨

        //_NA_008486_20150914_TOTAL_BALANCE
        ATTR_DEBUFF_DURATION,                          // 116: ÀÚ½ÅÀÇ µð¹öÇÁ±â¼ú È¿°ú Áö¼Ó½Ã°£ °­È­(¹Ð¸®¼¼ÄÁµå)

        //_NA_008540_20151027_ADD_ITEMOPTION_ELITE4
        ATTR_DECREASE_DAMAGE_NPC,                      // 117: npc°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_BERSERKER,                // 118: ¹ö¼­Ä¿°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_DRAGONKNIGHT,             // 119: µå·¡°ï³ªÀÌÆ®°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_VALKYRIE,                 // 120: ¹ßÅ°¸®°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_ELEMENTALIST,             // 121: ¿¤¸®¸àÅ»¸®½ºÆ®°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_SHADOW,                   // 122: ¼¨µµ¿ì°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_MYSTIC,                   // 123: ¹Ì½ºÆ½ÀÌ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_HELLROID,                 // 124: Çï·ÎÀÌµå°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò
        ATTR_DECREASE_DAMAGE_WITCHBLADE,               // 125: À§Ä¡ºí·¹ÀÌµå°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò

        ATTR_MAX, // character attribute fields

    }; //end of enum eATTR_TYPE

    enum AttackType
    {
        ATTACK_TYPE_ALL_OPTION = 0, // ¸ðµç ¿É¼Ç
        ATTACK_TYPE_MELEE = 1, // ¹°¸®(±Ù°Å¸®)
        ATTACK_TYPE_RANGE = 2, // ¹°¸®(¿ø°Å¸®)
        ATTACK_TYPE_WATER = 3, // ¹°
        ATTACK_TYPE_FIRE = 4, // ºÒ
        ATTACK_TYPE_WIND = 5, // ¹Ù¶÷
        ATTACK_TYPE_EARTH = 6, // ´ëÁö
        ATTACK_TYPE_DARKNESS = 7, // ¾ÏÈæ
        ATTACK_TYPE_DIVINE = 8, // EP2:unused, ½Å¼º
        ATTACK_TYPE_PHYSICAL_OPTION = 9, // ¸ðµç ¹°¸®
        ATTACK_TYPE_MAGIC_OPTION = 10, // ¸ðµç ¿ø¼Ò
        ATTACK_TYPE_ALL_MAGIC = 11, // EP2:unused, ¸ðµç ¸¶¹ý¼Ó¼º
        ATTACK_TYPE_MAGIC = 12, // EP2:unused, ¸¶¹ý
        ATTACK_TYPE_INVALID = 13, // same as eATTACK_TYPE_NONE

        ATTACK_TYPE_MAX,
    }
    public enum ItemParseType{
        WASTE=0,
        EQUIP=10,
    }

    public enum CharType
    {
        CHAR_NONE = 0,
        CHAR_BERSERKER = 1,
        CHAR_DRAGON = 2,
        CHAR_SHADOW = 3,
        CHAR_VALKYRIE = 4,
        CHAR_MAGICIAN = 5,
        CHAR_ELEMENTALIST = 5,
        CHAR_MYSTIC = 6, // _NA_004965_20120613_NEW_CHARACTER_MYSTIC
        CHAR_HELLROID = 7, // _NA_000000_20130812_NEW_CHARACTER_HELLROID
        CHAR_WITCHBLADE = 8, //_NA_007514_20140828_NEW_CHARACTER_WITCHBLADE
        CHAR_TYPE_MAX,
    };
}
