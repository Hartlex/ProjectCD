using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using static SunStructs.Definitions.AttrType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles
{
    public class AttrProfile
    {
        protected AttrType[] _attrTypes;

        public IEnumerable<AttrType> GetAttrTypes()
        {
            return _attrTypes;
        }
    }

    internal class PlayerAttrProfile : AttrProfile
    {
        public PlayerAttrProfile()
        {
            _attrTypes = new[]
            {
                //BASE start
                ATTR_STR,
                ATTR_DEX,
                ATTR_VIT,
                ATTR_INT,
                ATTR_SPR,
                ATTR_EXPERTY1,
                ATTR_EXPERTY2,

                ATTR_CUR_HP,
                ATTR_CUR_MP,

                ATTR_MAX_HP,
                ATTR_MAX_MP,

                ATTR_RECOVERY_HP,
                ATTR_RECOVERY_MP,

                //BASE end

                //ATTACK start

                ATTR_BASE_MELEE_MIN_ATTACK_POWER, // ±âº» ¹°¸® °ø°Ý·Â
                ATTR_BASE_MELEE_MAX_ATTACK_POWER,
                ATTR_BASE_RANGE_MIN_ATTACK_POWER,
                ATTR_BASE_RANGE_MAX_ATTACK_POWER,
                ATTR_BASE_MAGICAL_MIN_ATTACK_POWER, // EP2:unused, ±âº» ¸¶¹ý (ÃÖ¼Ò) °ø°Ý·Â
                ATTR_BASE_MAGICAL_MAX_ATTACK_POWER, // EP2:unused, ±âº» ¸¶¹ý (ÃÖ´ë) °ø°Ý·Â

                ATTR_OPTION_PHYSICAL_ATTACK_POWER, // [V] ¿É¼Ç ¹°¸® °ø°Ý·Â
                ATTR_OPTION_MAGICAL_ATTACK_POWER, // EP2:unused
                ATTR_OPTION_ALL_ATTACK_POWER, // EP2:unused, ¿É¼Ç ÀüÃ¼ ¹°¸® °ø°Ý·Â

                ATTR_MAGICAL_WATER_ATTACK_POWER, // [V] ¿ø¼Ò(¹°) °ø°Ý·Â
                ATTR_MAGICAL_FIRE_ATTACK_POWER, // [V] ¿ø¼Ò(ºÒ) °ø°Ý·Â
                ATTR_MAGICAL_WIND_ATTACK_POWER, // [V] ¿ø¼Ò(¹Ù¶÷) °ø°Ý·Â
                ATTR_MAGICAL_EARTH_ATTACK_POWER, // [V] ¿ø¼Ò(´ëÁö) °ø°Ý·Â
                ATTR_MAGICAL_DARKNESS_ATTACK_POWER, // [V] ¿ø¼Ò(¾ÏÈæ) °ø°Ý·Â
                ATTR_MAGICAL_DIVINE_ATTACK_POWER, // unused

                ATTR_MAGICAL_ALL_ATTACK_POWER, // [V] ¸¶¹ý¼Ó¼º ÀüÃ¼ °ø°Ý·Â, EP2={ FIRE, WATER, WIND, EARTH, DARK }

                ATTR_ADD_SKILL_ATTACK_POWER, // [V] ½ºÅ³ Ãß°¡ °ø°Ý·Â
                ATTR_ADD_SKILL_DAMAGE_RATIO,

                //ATTACK end

                //DEFENSE start

                ATTR_BASE_MELEE_DEFENSE_POWER, // [V] ±âº» (±Ù°Å¸®) ¹°¸® ¹æ¾î·Â
                ATTR_BASE_RANGE_DEFENSE_POWER, // [V] ±âº» (¿ø°Å¸®) ¹°¸® ¹æ¾î·Â
                ATTR_BASE_MAGICAL_DEFENSE_POWER, // EP2:unused, ±âº» ¸¶¹ý ¹æ¾î·Â

                ATTR_OPTION_PHYSICAL_DEFENSE_POWER, // ¿É¼Ç ¹°¸® ¹æ¾î·Â
                ATTR_OPTION_MAGICAL_DEFENSE_POWER, // EP2:unused
                ATTR_OPTION_ALL_DEFENSE_POWER, // EP2:unused, ¿É¼Ç ÀüÃ¼ ¹°¸® ¹æ¾î·Â <- ¿É¼Ç ¹°¸®+¸¶¹ý ¹æ¾î·Â

                ATTR_MAGICAL_WATER_DEFENSE_POWER, // EP2:unused, [V] ¿ø¼Ò(¹°) ¹æ¾î·Â
                ATTR_MAGICAL_FIRE_DEFENSE_POWER, // EP2:unused, [V] ¿ø¼Ò(ºÒ) ¹æ¾î·Â
                ATTR_MAGICAL_WIND_DEFENSE_POWER, // EP2:unused, [V] ¿ø¼Ò(¹Ù¶÷) ¹æ¾î·Â
                ATTR_MAGICAL_EARTH_DEFENSE_POWER, // EP2:unused, [V] ¿ø¼Ò(´ëÁö) ¹æ¾î·Â
                ATTR_MAGICAL_DARKNESS_DEFENSE_POWER, // EP2:unused, [V] ¿ø¼Ò(¾ÏÈæ) ¹æ¾î·Â
                ATTR_MAGICAL_DIVINE_DEFENSE_POWER, // unused

                ATTR_MAGICAL_ALL_DEFENSE_POWER, // EP2:unused, [V] ¿ø¼Ò ÀüÃ¼ ¹æ¾î·Â EP2={ FIRE, WATER, WIND, EARTH, DARK }

                ATTR_ADD_ALL_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý Å¸ÀÔº° Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_MELEE_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (±ÙÁ¢) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_RANGE_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (¿ø°Å¸®) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_WATER_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (¹°) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_FIRE_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (ºÒ) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_WIND_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (¹Ù¶÷) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_EARTH_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (´ëÁö) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_DARKNESS_DEFENSE_POWER, // EP2:unused, [V] °ø°Ý´ë»ó (¾ÏÈæ) Ãß°¡ ¹æ¾î·Â
                ATTR_ADD_DIVINE_DEFENSE_POWER, // EP2:unused
                ATTR_ADD_PHYSICAL_DEFENSE_POWER, // EP2:unused
                ATTR_ADD_MAGICAL_DEFENSE_POWER, // EP2:unused
                ATTR_ADD_MAGICAL_ALL_DEFENSE_POWER, // EP2:unused

                ATTR_DEL_ALL_TARGET_DEFENSE_RATIO, // EP2:unused
                ATTR_DEL_MELEE_TARGET_DEFENSE_RATIO, // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
                ATTR_DEL_RANGE_TARGET_DEFENSE_RATIO, // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
                ATTR_DEL_WATER_TARGET_DEFENSE_RATIO, // [R] °ø°Ý´ë»ó ¿ø¼Ò(¹°) ¹æ¾î·Â °¨¼ÒÀ²
                ATTR_DEL_FIRE_TARGET_DEFENSE_RATIO, // [R] °ø°Ý´ë»ó ¿ø¼Ò(ºÒ) ¹æ¾î·Â °¨¼ÒÀ²
                ATTR_DEL_WIND_TARGET_DEFENSE_RATIO, // [R] °ø°Ý´ë»ó ¿ø¼Ò(¹Ù¶÷) ¹æ¾î·Â °¨¼ÒÀ²
                ATTR_DEL_EARTH_TARGET_DEFENSE_RATIO, // [R] °ø°Ý´ë»ó ¿ø¼Ò(´ëÁö) ¹æ¾î·Â °¨¼ÒÀ²
                ATTR_DEL_DARKNESS_TARGET_DEFENSE_RATIO, // [R] °ø°Ý´ë»ó ¿ø¼Ò(¾ÏÈæ) ¹æ¾î·Â °¨¼ÒÀ²
                ATTR_DEL_DIVINE_TARGET_DEFENSE_RATIO, // EP2:unused
                ATTR_DEL_PHYSICAL_TARGET_DEFENSE_RATIO, // [R] °ø°Ý´ë»ó ¹°¸® ¹æ¾î·Â °¨¼ÒÀ²
                ATTR_DEL_MAGICAL_TARGET_DEFENSE_RATIO, // EP2:unused
                ATTR_DEL_MAGICAL_ALL_TARGET_DEFENSE_RATIO,

                //DEFENSE end

                //ARMOR start

                ATTR_ADD_ARMOR_HARD_DAMAGE, // EP2:unused, ¾Æ¸Ó Å¸ÀÔº° Ãß°¡ µ¥¹ÌÁö
                ATTR_ADD_ARMOR_MEDIUM_DAMAGE, // EP2:unused
                ATTR_ADD_ARMOR_SOFT_DAMAGE, // EP2:unused
                ATTR_ADD_ARMOR_SIEGE_DAMAGE, // EP2:unused
                ATTR_ADD_ARMOR_UNARMOR_DAMAGE, // EP2:unused

                ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE, // EP2:unused, ¾Æ¸Ó Å¸ÀÔº° Ãß°¡ µ¥¹ÌÁö(ÆÛ¼¾Æ®)
                ATTR_ADD_RATIO_ARMOR_MEDIUM_DAMAGE, // EP2:unused
                ATTR_ADD_RATIO_ARMOR_SOFT_DAMAGE, // EP2:unused
                ATTR_ADD_RATIO_ARMOR_SIEGE_DAMAGE, // EP2:unused
                ATTR_ADD_RATIO_ARMOR_UNARMOR_DAMAGE, // EP2:unused
                // CHANGES: changes value type to ratio type since EP2
                ATTR_DEL_ALL_DAMAGE, // EP2:unused, °¨¼Ò µ¥¹ÌÁö
                ATTR_DEL_MELEE_DAMAGE, // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
                ATTR_DEL_RANGE_DAMAGE, // EP2:unused, (°ø°ÝÅ¸ÀÔ/¾Æ¸ÓÅ¸ÀÔ°ü·Ã)
                ATTR_DEL_WATER_DAMAGE, // [R] ¿ø¼Ò(¹°)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
                ATTR_DEL_FIRE_DAMAGE, // [R] ¿ø¼Ò(ºÒ)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
                ATTR_DEL_WIND_DAMAGE, // [R] ¿ø¼Ò(¹Ù¶÷)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
                ATTR_DEL_EARTH_DAMAGE, // [R] ¿ø¼Ò(´ëÁö)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
                ATTR_DEL_DARKNESS_DAMAGE, // [R] ¿ø¼Ò(¾ÏÈæ)¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
                ATTR_DEL_DIVINE_DAMAGE, // EP2:unused
                ATTR_DEL_PHYSICAL_DAMAGE, // [R] EP2: ¹°¸® °ø°Ý¿¡ ´ëÇÑ µ¥¹ÌÁö Â÷°¨·ü
                ATTR_DEL_MAGICAL_DAMAGE, // EP2:unused
                ATTR_DEL_MAGICAL_ALL_DAMAGE,

                //ARMOR end

                //RATIOS start

                ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, // °ø°Ý ¼º°ø·ü(¹°¸®)
                ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, // [R][ 15] °ø°Ý ¹æ¾îÀ² (¿É¼Ç) Ãß°¡À²
                ATTR_PHYSICAL_ATTACK_BLOCK_BASE_ARMOR_RATIO, // EP2:added, °ø°Ý ¹æ¾îÀ² ¾ÆÀÌÅÛ Á¾ÇÕ (ÃÑ ÇÕ»ê / 5)

                ATTR_MOVE_SPEED, // ÀÌµ¿ ¼Óµµ
                ATTR_ATTACK_SPEED, // °ø°Ý ¼Óµµ

                ATTR_ALL_ATTACK_RANGE, // ¸ðµç »ç°Å¸®
                ATTR_NORMAL_ATTACK_RANGE, // ÀÏ¹Ý »ç°Å¸®
                ATTR_SKILL_ATTACK_RANGE, // ½ºÅ³ »ç°Å¸®

                ATTR_SIGHT_RANGE, // ½Ã¾ß

                ATTR_CRITICAL_RATIO_CHANGE, // Å©¸®Æ¼ÄÃ È®·ü Áõ°¨
                ATTR_ADD_MAGICAL_CRITICAL_RATIO, // EP2:unused, ¸¶¹ý Å©¸®Æ¼ÄÃ È®·ü
                ATTR_ADD_ALL_CRITICAL_RATIO, // EP2:unused, ÀüÃ¼ Å©¸®Æ¼ÄÃ È®·ü
                ATTR_CRITICAL_DAMAGE_CHANGE, // Å©¸®Æ¼ÄÃ µ¥¹ÌÁö Ãß°¡

                ATTR_ADD_ATTACK_INC_RATIO, // [R] Ãß°¡ °ø°Ý »ó½ÂÀ²
                ATTR_ADD_DEFENSE_INC_RATIO, // [R] Ãß°¡ ¹æ¾î »ó½ÂÀ²

                ATTR_INCREASE_SKILL_LEVEL, // ½ºÅ³ ·¹º§ 1»ó½Â
                ATTR_INCREASE_STAT_POINT, // ½ºÅÝ Æ÷ÀÎÆ®(¸ðµÎ)1»ó½Â

                //  2006 ¿ÀÈÄ 1:23:11
                ATTR_DECREASE_LIMIT_STAT, // ½ºÅÝ Á¦ÇÑ ¼öÄ¡ °¨¼Ò
                ATTR_MP_SPEND_INCREASE, // MP ¼Òºñ °¨¼Ò

                //  »ó¿ëÈ­ ¾ÆÀÌÅÛ ¿É¼Ç Ãß°¡
                ATTR_ABSORB_HP, // HPÈí¼ö
                ATTR_ABSORB_MP, // MP,SP Èí¼ö
                ATTR_REFLECT_DAMAGE_RATIO, // µ¥¹ÌÁö ¹Ý»ç
                ATTR_BONUS_MONEY_RATIO, // ÇÏÀÓ Áõ°¡
                ATTR_BONUS_EXP_RATIO, // °æÇèÄ¡ Áõ°¡
                ATTR_AREA_ATTACK_RATIO, // ´ÙÁß°ø°Ý È®·ü
                ATTR_BONUS_CASTING_TIME, // 65:Ä³½ºÆÃ Å¸ÀÓ Áõ°¨
                ATTR_BONUS_SKILL_COOL_TIME, // 75:[R] ½ºÅ³ ÄðÅ¸ÀÓ Áõ°¨
                ATTR_DECREASE_DAMAGE, // µ¥¹ÌÁö °¨¼Ò

                ATTR_RESURRECTION_RATIO, // 52:»ç¸Á½Ã ½º½º·Î ºÎÈ° ÇÒ È®·ü
                ATTR_DOUBLE_DAMAGE_RATIO, // 53:µ¥¹ÌÁöÀÇ µÎ¹è°¡ µÉ È®·ü
                ATTR_LUCKMON_INC_DAMAGE, // 54:·°Å° ¸ó½ºÅÍ °ø°Ý½Ã Ãß°¡ µ¥¹ÌÁö
                ATTR_COPOSITE_INC_RATIO, // 55:Á¶ÇÕ ¼º°ø·ü Áõ°¡
                ATTR_BYPASS_DEFENCE_RATIO, // 56:¹æ¾î·Â ¹«½Ã È®À²
                ATTR_INCREASE_MIN_DAMAGE, // 57:ÃÖ¼Ò µ¥¹ÌÁö Áõ°¡
                ATTR_INCREASE_MAX_DAMAGE, // 58:ÃÖ´ë µ¥¹ÌÁö Áõ°¡
                ATTR_DECREASE_ITEMDURA_RATIO, // 59:¾ÆÀÌÅÛ ³»±¸·Â °¨¼Ò¹«½Ã È®À²
                ATTR_RESISTANCE_BADSTATUS_RATIO, // 60:½ºÅ³ È¿°ú ¹«ÁöÈ®À²
                ATTR_INCREASE_SKILLDURATION, // 61:½ºÅ³ È¿°ú ½Ã°£ Áõ°¡ ( ¹öÇÁ °è¿­ )
                ATTR_DECREASE_SKILL_SKILLDURATION, // 62:½ºÅ³ È¿°ú ½Ã°£ Áõ°¨ ( µð¹öÇÁ °è¿­ ) < f110531.6L, changed from '°¨¼Ò'
                ATTR_OPTION_ETHER_DAMAGE_RATIO, // 63:¿¡Å×¸£¿þÆù µ¥¹ÌÁö º¯È­
                ATTR_OPTION_ETHER_PvE_DAMAGE_RATIO, // 76:¿¡Å×¸£¿þÆù µ¥¹ÌÁö º¯È­ (PvE¿ë), f110601.4L

                ATTR_INCREASE_RESERVE_HP, // 64:Àû¸³ HP Áõ°¡

                ATTR_RESIST_HOLDING, // 66:È¦µù ³»¼º
                ATTR_RESIST_SLEEP, // 67:½½¸³ ³»¼º
                ATTR_RESIST_POISON, // 68:Áßµ¶ ³»¼º
                ATTR_RESIST_KNOCKBACK, // 69:³Ë¹é ³»¼º
                ATTR_RESIST_DOWN, // 70:´Ù¿î ³»¼º
                ATTR_RESIST_STUN, // 71:½ºÅÏ ³»¼º
                ATTR_DECREASE_PVPDAMAGE, // 72:PVPµ¥¹ÌÁö °¨¼Ò
                ATTR_ADD_DAMAGE, // 73:Ãß°¡µ¥¹ÌÁö
                ATTR_AUTO_ITEM_PICK_UP, // 74:Item ÀÚµ¿ ÁÝ±â
                // NOTE: regenerated index
                ATTR_MAX_SD, // 93:ÃÖ´ë SD
                ATTR_RECOVERY_SD, // 94:SD È¸º¹·®
                ATTR_CUR_SD,

                //Ratios end
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
        ATTR_DECREASE_DAMAGE_WITCHBLADE                // 125: À§Ä¡ºí·¹ÀÌµå°¡ ÁÖ´Â µ¥¹ÌÁö °¨¼Ò

      // character attribute fields

            };
        }
    } 
}
