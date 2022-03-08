using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
    public enum SkillEnum
    {
        SKILL_INVALID = 0,

        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ¹ö¼­Ä¿ 
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Á÷¾÷ 1
        SKILL_TAUNT = 51,
        SKILL_STUN_KICK = 52,
        SKILL_THORNS_SKIN = 53,
        SKILL_SLASH = 54,
        SKILL_GROUND_SHOCK = 55,
        SKILL_DAMAGE_RECOVERY = 56,
        SKILL_DOUBLE_SLASH = 57,
        SKILL_WEAPON_BREAK = 58,
        SKILL_SPECTUAL_GUARD = 59,
        SKILL_REVENGE = 60,
        SKILL_JUMPING_CRASH = 61,
        SKILL_VITAL_AMPLYFY = 62,
        SKILL_WILD_SPIRITS = 63,
        SKILL_TACKLE = 66,
        kSkillHardStance = 67, // ÇÏµå ½ºÅÄ½º (Áö¼Ó Ã¼·Â)
        kSkillIronStance = 68, // ¾ÆÀÌ¾ð ½ºÅÄ½º (¼ø°£ Ã¼·Â)

        // Á÷¾÷ 2
        SKILL_BASH = 101,
        kSkillSPRecovery = 102, // SP ¸®Ä¿¹ö¸®
        SKILL_BERSERK_MODE = 103,
        SKILL_MONSTER_TACKLE = 104,
        SKILL_SPIN_RUSH = 105,
        SKILL_SPIRIT_RECHARGE = 106,
        SKILL_DEADLY_STRIKE = 107,
        SKILL_SONIC_EXPLOSION = 108,
        SKILL_SPINNING_BLOW = 109,
        SKILL_SPINING_CRUSH = 110,
        SKILL_UPPER_BLOW = 111,
        SKILL_DOUBLE_ATTACK = 112,
        SKILL_FURY_STRIKE = 113,
        SKILL_WEAPON_THROWING = 114,
        SKILL_BERSERKER_FORCE = 115,
        SKILL_WARCRY = 116,
        SKILL_SHOUT = 117,
        SKILL_DASH = 118,
        kSkillSPRecharge = 119, // SP ¸®Â÷Áö
        kSkillBloodHaze = 120, // ºí·¯µå ÇìÀÌÁî (Áö¼Ó HP)
        kSkillMotalBlood = 121, // ¸ðÅ» ºí·¯µå (¼ø°£ HP)


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // µå·¡°ï ³ªÀÌÆ®
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Á÷¾÷ 1
        SKILL_TRIPLE_PIERCE = 251,
        SKILL_SWORDDANCING = 252,
        SKILL_SONICBLADE = 253,
        SKILL_ILLUSION_DANCE = 254,
        SKILL_MACHSLASH = 255,
        SKILL_DIFFUSEBLOW = 256,
        SKILL_VIPER_BLADE = 257,
        SKILL_DEVINE_FORCE = 258,
        SKILL_MARK_OF_CHANCE = 259,
        SKILL_RAPID_ATTACK = 260,
        SKILL_DEATH_DIVIDE = 261,
        SKILL_SPIRITUAL_EYE = 262,
        SKILL_ARCANE_BLADE = 263,
        SKILL_SLAUGHTER = 264,
        SKILL_BLADE_FURY = 265,
        SKILL_CHARGE_ATTACK = 266,
        SKILL_SPRIT_SLUG = 267,
        kSkillCourageOfKnights = 268, // Ä¿¸®Áö ¿Àºê ³ªÀÌÃ÷ (Áö¼Ó ¹ÎÃ¸)
        kSkillFeverOfKnights = 269, // ÇÇ¹ö ¿Àºê ³ªÀÌÃ÷ (¼ø°£ ¹ÎÃ¸)

        // Á÷¾÷ 2
        SKILL_ASSAULT = 301,
        SKILL_STUNNINGBLOW = 302,
        SKILL_FEAR = 303,
        SKILL_MARK_OF_RECOVERY = 304,
        SKILL_DRAGON_EYE = 305,
        SKILL_DRAGON_ARM_TRANSFORM = 306,
        SKILL_STORM_WAVE = 307,
        SKILL_LIGHTING_LANCE = 308,
        SKILL_DIVINE_AMBLEM = 309,
        SKILL_ARMOR_BREAK = 310,
        SKILL_DRAGON_CLER = 311,
        SKILL_MARK_OF_SPIRIT_POWER = 312,
        SKILL_EXPLOZEN_ATTACK = 313,
        SKILL_EBON_BLADE = 314,
        SKILL_FIST_OF_FIRE = 315,
        SKILL_DRAGON_RAY = 321,
        SKILL_DRAGON_GALE = 322,
        SKILL_DRAGON_BEAD = 323,
        kSkillDragonicForce = 324, // µå·¡°í´Ð Æ÷½º (Áö¼Ó °ø°Ý·Â)
        kSkillDragonicBless = 325, // µå·¡°í´Ð ºí·¹½º (¼ø°£ °ø°Ý·Â)


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ¹ßÅ°¸® 
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Á÷¾÷ 1
        SKILL_FAST_SHOT = 451,
        SKILL_SNIPING = 452,
        SKILL_MOON_ASSAULT = 453,
        SKILL_SHOCKWAVE = 454,
        SKILL_FROZEN_ARROW = 455,
        SKILL_DOUBLE_SPINKICK = 456,
        SKILL_BLOOD_RAIN = 457,
        SKILL_ETHER_BLASE = 458,
        SKILL_DEFENCE_MOTION = 459,
        //SKILL_AIR_BLOW                 = 460,
        SKILL_AIRBLOW = 460,
        SKILL_HEAVY_SHOT = 461,
        SKILL_SPINING_WAVE = 462,
        SKILL_PIERCEARROW = 463,
        SKILL_OVER_LIMIT = 464,
        SKILL_MANA_DRAIN = 467,
        SKILL_WILD_SHOT = 468,
        SKILL_CHASE_SHOT = 470,
        kSkillIncreaseMind = 471, // ÀÎÅ©¸®½º ¸¶ÀÎµå (Áö¼Ó Áö·Â)
        kSKillMindSpark = 472, // ¸¶ÀÎµå ½ºÆÄÅ© (¼ø°£ Áö·Â)

        // Á÷¾÷ 2
        SKILL_UNLIMIT_FORCE = 501,
        SKILL_MARK_OF_FACTION = 502,
        SKILL_MARK_OF_SYMPHONY = 503,
        SKILL_SOUL_OF_LIFE = 504,
        SKILL_PATIENCE = 505,
        SKILL_SOUL_HEAL = 506,
        SKILL_RESSURECTION = 507,
        SKILL_WAR_BATTLER = 508,
        SKILL_BATTLE_BARRIOR = 509,
        //SKILL_BATTLER_HORN             = 510,
        SKILL_BATTLERHONE = 510,
        SKILL_DESTROYER = 511,
        SKILL_FILL_OFF = 512,
        SKILL_SACRIFICE = 513,
        SKILL_MAGIC_WALKER = 514,
        SKILL_MAGIC_WALKER_FIRE_ARROW = 515,
        SKILL_MAGIC_WALKER_CURE = 516,
        SKILL_DOUBLE_GORE = 517,
        SKILL_DOUBLE_GORE_LIGHTING = 518,
        SKILL_DOUBLE_GORE_DEXTERITY = 519,
        SKILL_RANGE_HEAL = 520,
        SKILL_SUMMON_MASTERY = 521,
        SKILL_ADRENALINE = 522,
        kSkillSummonicShield = 523, // ¼­¸Ó´Ð ½Çµå (Áö¼Ó ¹æ¾î·Â)
        kSkillSummonicBarrier = 524, // ¼­¸Ó´Ð º£¸®¾î (¼ø°£ ¹æ¾î·Â)


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ¿¤¸®¸àÅ»¸®½ºÆ® 
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // ÆÐ½Ãºê
        SKILL_FIRE_MASTERY = 601,
        SKILL_WATER_MASTERY = 602,
        SKILL_WIND_MASTERY = 603,
        SKILL_EARTH_MASTERY = 604,
        SKILL_MANA_REGENERATION = 605,

        // Á÷¾÷ 1
        SKILL_FIRE_ARROW = 651,
        SKILL_ICE_DAGGER = 652,
        SKILL_HEALING_HAND = 653,
        SKILL_TELEPORT = 654,
        SKILL_MAGIC_SHIELD = 655,
        SKILL_REVIVAL = 656,
        SKILL_FROZON_SHIELD = 657,
        SKILL_FIRE_BALL = 658,
        SKILL_BLAZE_FORCE = 659,
        SKILL_ICE_BLAST = 660,
        SKILL_ICE_FORCE = 661,
        SKILL_ICE_BOLT = 662,
        SKILL_MANA_RECOVERY = 663,
        SKILL_FIRE_SPEAR = 664,
        SKILL_PRESSING_WALL = 665,
        SKILL_FIRE_FILA = 666,
        SKILL_REVERSE = 667,
        SKILL_ESSENSE = 668,
        SKILL_NATURAL_FORCE = 669,
        kSkillEnchantPower = 670, // ÀÎÃ¦Æ® ÆÄ¿ö (Áö¼Ó Èû)
        kSkillCatalystPower = 671, // Ä«Å»¸®½ºÆ® ÆÄ¿ö (¼ø°£ Èû)

        // Á÷¾÷ 2
        SKILL_WIND_BOLT = 701,
        SKILL_ELECTRIC_FIELD = 702,
        SKILL_POISON_THORN = 703,
        SKILL_WIND_SHIELD = 704,
        SKILL_NATURAL_ATTACK = 705,
        SKILL_LIGHTING = 706,
        SKILL_INCRESE_SPEED = 707,
        SKILL_FOCUS = 708,
        SKILL_LIGHTING_WAVE = 709,
        SKILL_SONY_VINE = 710,
        SKILL_MAGIC_FORCE = 711,
        SKILL_POISON_RAIN = 712,
        SKILL_ACCRUCY_SPIRIT = 713,
        SKILL_MIGHTY_SPIRIT = 714,
        SKILL_POWER_WAVE = 715,
        SKILL_MIGHT_POWER = 716,
        SKILL_STAR_FALL = 717,
        SKILL_EARTHQUAKE = 718,
        SKILL_BATTLE_HEAL = 719,
        SKILL_HEAL_MAGIC_ARRAY = 720,
        SKILL_GROUP_HEAL = 721,
        SKILL_MANA_REACHARGE = 722,
        SKILL_ICE_DAGGER2 = 723,
        SKILL_TELEPORT2 = 724,
        SKILL_SACRED_FIRE = 725,
        SKILL_INQUIRY = 726,
        SKILL_DEVISH_DANCE = 727,
        SKILL_CIRCLE_SPRITS = 728,
        SKILL_INABILITTY = 729,
        SKILL_SAINT_AID = 730,
        SKILL_PURGE = 731,
        kSkillWhisperOfWind = 732, // À§½ºÆÛ ¿Àºê À©µå (Áö¼Ó ÀÌµ¿¼Óµµ)
        kSkillWhisperOfSylph = 733, // À§½ºÆÛ ¿Àºê ½ÇÇÁ (¼ø°£ ÀÌµ¿¼Óµµ)


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ¼¨µµ¿ì
        ////////////////////////////////////////////////////////////////////////////////////////////////

        // Á÷¾÷ 1
        SKILL_PAIN = 800, // ÆäÀÎ (°íÅë)
        SKILL_DARK_FIRE = 801,
        SKILL_DARK_SPARK = 802,
        SKILL_ARMOR_INCREASE = 803, // ¾Æ¸ÓÀÎÅ©¸®Áî (¹°¸®/¸¶¹ý ¹æ¾î·Â Áõ°¡, ¾ÏÈæÀúÇ×·Â »ó½Â)
        SKILL_SOUL_CONTROL = 804, // ¼Ò¿ïÄÁÆ®·Ñ (¿µÈ¥Áö¹è)
        SKILL_IMPRTENT = 805, // ÀÓÆ÷ÅÏÆ® (¹«·ÂÇÔÀÇ ÀúÁÖ)
        SKILL_VITAL_SUCTION = 806, // ¹ÙÀÌÅ»¼®¼Ç (Á¤±âÈí¼ö)
        SKILL_ENCHANT_POISON = 807, // ÀÎÃ¾Æ®Æ÷ÀÎÁð (µ¶À» ¹Ù¸¥ °Ë)
        SKILL_HP_SUCTION = 808, // HP¼®¼Ç (HPÈí¼ö)
        SKILL_MP_SUCTION = 809, // MP¼®¼Ç (MPÈí¼ö)		// ¹Ì»ç¿ë
        SKILL_CURSE_INCREASE = 810, // Ä¿ÁîÀÎÅ©¸®Áî (ÀúÁÖ°­È­)
        SKILL_DARK_PAIN = 811, // ´ÙÅ©ÆäÀÎ (¾ÏÈæÀÇ°íÅë)
        SKILL_BUFF_CANCEL = 812, // ¹öÇÁÄµ½½ (°­È­¸¶¹ýÇØÁ¦)
        SKILL_CONFUSE = 813, // ÄÁÇ»Áî (È¥¶õÀÇÀúÁÖ)
        SKILL_DEMON = 814, // µ¥¸ó (¾Ç·É)
        SKILL_DARK_FORCE = 815, // ´ÙÅ©Æ÷½º (¾îµÒÀÇÈû)
        kSkillHelronsSoul = 816, // Çï·ÐÁî ¼Ò¿ï (Áö¼Ó Á¤½Å·Â)
        kSkillDemonsSoul = 817, // µ¥¸óÁî ¼Ò¿ï (¼ø°£ Á¤½Å·Â)

        // Á÷¾÷ 2
        SKILL_WHIP_ATTACK = 850, // ÈÛ¾îÅÃ (ÈÄ·ÁÄ¡±â)
        SKILL_POISON_DAGGER = 851, // Æ÷ÀÌÁð´ë°Å (µ¶ÀÌ¹¯Àº´ë°Å)
        SKILL_DOUBLE_WIDTH = 852, // ´õºíÀ§µå (µÎ¹øÈ¾À¸·Îº£±â)
        SKILL_DARK_STUN = 853, // ´ÙÅ©½ºÅÏ (ÃÖ¸é)
        SKILL_HIDE = 854, // ÇÏÀÌµå (Àº½Å)
        SKILL_DEATH_BLOW = 855, // ´Ù½ººí·Î¿ì (Ä¡¸íÅ¸)
        SKILL_SHADOW_SPEAR = 856, // ¼¨µµ¿ì½ºÇÇ¾î (Âî¸£±â)
        SKILL_CANCELLATION = 857, // Äµ½½·¹ÀÌ¼Ç (µð¹öÇÁÁ¦°Å)
        SKILL_RUSH = 858, // ·¯½¬ (Àü·ÂÁúÁÖ)
        SKILL_SUDDEN_STRIKE = 859, // ¼­µç½ºÆ®¶óÀÌÅ© (±â½À)
        SKILL_DARK_DUST = 860, // ´ÙÅ©´õ½ºÆ® (¾ÏÈæÀÇ°¡·ç, ºí¶óÀÎµå)
        SKILL_FAST_BLOW = 861, // ÆÐ½ºÆ®ºí·Î¿ì (¿Ã·ÁÄ¡±â)
        SKILL_DOWN_SLASH = 862, // ´Ù¿î½½·¡½¬ (´Ù¿î°ø°ÝÇÔ)
        SKILL_SOUL_SCREAM = 863, // ¼Ò¿ï½ºÅ©¸² (¿µÈ¥ÀÇÀý±Ô)
        SKILL_WHIRLWIND_BLOW = 864, // ÈÙÀ©µåºí·Î¿ì
        SKILL_DARK_SLASH = 865, // ¾îµÒÀÇ³­µµÁú
        SKILL_DARK_BREAK = 866, // ´ÙÅ©ºê·ÀÅ© (ÀÚÆø)
        kSkillDarkTrace = 867, // ´ÙÅ© Æ®·¹ÀÌ½º (Áö¼Ó °ø°Ý¼Óµµ)
        kSkillDarkRage = 868, // ´ÙÅ© ·¹ÀÌÁî (¼ø°£ °ø°Ý¼Óµµ)

        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ¹Ì½ºÆ½
        ////////////////////////////////////////////////////////////////////////////////////////////////

        SKILL_MYSTIC_901 = 901,
        SKILL_MYSTIC_902 = 902,
        SKILL_MYSTIC_903 = 903,
        SKILL_MYSTIC_904 = 904,
        SKILL_MYSTIC_905 = 905,
        SKILL_MYSTIC_906 = 906,
        SKILL_MYSTIC_907 = 907,
        SKILL_MYSTIC_908 = 908,
        SKILL_MYSTIC_909 = 909,
        SKILL_MYSTIC_910 = 910,
        SKILL_MYSTIC_911 = 911,
        SKILL_MYSTIC_912 = 912,
        SKILL_MYSTIC_913 = 913,
        SKILL_MYSTIC_914 = 914,
        SKILL_MYSTIC_915 = 915,
        SKILL_MYSTIC_916 = 916,
        SKILL_MYSTIC_917 = 917,
        SKILL_MYSTIC_918 = 918,

        SKILL_MYSTIC_919 = 919,
        SKILL_MYSTIC_920 = 920,
        SKILL_MYSTIC_921 = 921,
        SKILL_MYSTIC_922 = 922,
        SKILL_MYSTIC_923 = 923,
        SKILL_MYSTIC_924 = 924,
        SKILL_MYSTIC_925 = 925,
        SKILL_MYSTIC_926 = 926,
        SKILL_MYSTIC_927 = 927,
        SKILL_MYSTIC_928 = 928,
        SKILL_MYSTIC_929 = 929,
        SKILL_MYSTIC_930 = 930,
        SKILL_MYSTIC_931 = 931,
        SKILL_MYSTIC_932 = 932,
        SKILL_MYSTIC_933 = 933,
        SKILL_MYSTIC_934 = 934,
        SKILL_MYSTIC_935 = 935,
        SKILL_MYSTIC_936 = 936,

        // ¿¬°èµÈ ½ºÅ³
        SKILL_MYSTIC_DARKOFLIGHT_ZONE = 937,
        SKILL_MYSTIC_GRAVITY_ZONE = 938,


        ////////////////////////////////////////////////////////////////////////////////////////////////
        // Çï·ÎÀÌµå
        ////////////////////////////////////////////////////////////////////////////////////////////////
        SKILL_HELLROID_1000 = 1000,     // ºí·¡½ºÅÍÆÝÄ¡
        SKILL_HELLROID_1001 = 1001,     // Å©·¡½¬¾Ï
        SKILL_HELLROID_1002 = 1002,     // ¸®Æä¾î
        SKILL_HELLROID_1003 = 1003,     // µå·ÓÅ±
        SKILL_HELLROID_1004 = 1004,     // ½½·Î¿ì¿À¶ó
        SKILL_HELLROID_1005 = 1005,     // µå¸±¾îÅÃ
        SKILL_HELLROID_1006 = 1006,     // À§Å©³Ê½º¿À¶ó
        SKILL_HELLROID_1007 = 1007,     // ½ºÇÉºí·Î¿ì
        SKILL_HELLROID_1008 = 1008,     // ÇÃ¶óÀ×Â÷Â¡
                                         //SKILL_HELLROID_1009            = 1009,     // ¹Ì»ç¿ë
        SKILL_HELLROID_1010 = 1010,     // ÇÏÆ®ºê·¹ÀÌÅ©
        SKILL_HELLROID_1011 = 1011,     // ¹Ì½ºÃ¦½º¿À¶ó
        SKILL_HELLROID_1012 = 1012,     // Æ÷Áö¼ÇÃ¼ÀÎÁö
        SKILL_HELLROID_1013 = 1013,     // µðÅ¬¶óÀÎ¿À¶ó
        SKILL_HELLROID_1014 = 1014,     // ÀÎº£ÀÌ´õ¸ðµå
        SKILL_HELLROID_1015 = 1015,     // Çï·ÎÀÌµå½ºÇÉ

        SKILL_HELLROID_1016 = 1016,     // Çìµå¹þ
        SKILL_HELLROID_1017 = 1017,     // ¿¡Å×¸£Â÷Â¡
        SKILL_HELLROID_1018 = 1018,     // ·Î¿ìºí·Î¿ì
        SKILL_HELLROID_1019 = 1019,     // ½ºÆ®·¹ÀÌÆ®ÆÝÄ¡
        SKILL_HELLROID_1020 = 1020,     // ¸®Ä¿¹ö¸®¿À¶ó
        SKILL_HELLROID_1021 = 1021,     // ¸®¹ÙÀÌºê
        SKILL_HELLROID_1022 = 1022,     // ºÎ½ºÆ®¿À¶ó
        SKILL_HELLROID_1023 = 1023,     // ºí·¡½ºÅÍºÕ
        SKILL_HELLROID_1024 = 1024,     // ºí·¡½ºÅÍÆÄÀÌ¾î
        SKILL_HELLROID_1025 = 1025,     // Çï·ÎÀÌµåºö
        SKILL_HELLROID_1026 = 1026,     // ½½¶óÀÌµù¾îÅÃ
        SKILL_HELLROID_1027 = 1027,     // ÀÌ±×³ë¾î¿À¶ó
        SKILL_HELLROID_1028 = 1028,     // ¿¡Å×¸£º£¸®¾î
        SKILL_HELLROID_1029 = 1029,     // ÄÁ¼¾Æ®·¹ÀÌ¼Ç¿À¶ó
        SKILL_HELLROID_1030 = 1030,     // °¡µð¾ð½Çµå
        SKILL_HELLROID_1031 = 1031,     // ºê·¹ÀÌÅ©¾î½º

        // ¿¬°èµÈ ½ºÅ³
        SKILL_HELLROID_AURA_1032 = 1032,
        SKILL_HELLROID_AURA_1033 = 1033,
        SKILL_HELLROID_AURA_1034 = 1034,
        SKILL_HELLROID_AURA_1035 = 1035,
        SKILL_HELLROID_AURA_1036 = 1036,
        SKILL_HELLROID_AURA_1037 = 1037,
        SKILL_HELLROID_AURA_1038 = 1038,
        SKILL_HELLROID_AURA_1039 = 1039,



        ////////////////////////////////////////////////////////////////////////////////////////////////
        // À§Ä¡ºí·¹ÀÌµå
        ////////////////////////////////////////////////////////////////////////////////////////////////
        SKILL_WITCHBLADE_1100 = 1100,      // È£¶óÀÌÁðÀè
        SKILL_WITCHBLADE_1101 = 1101,      // ÅÍ´×Å±
        SKILL_WITCHBLADE_1102 = 1102,      // ÇÇµå¿Â·¹ÀÌÁö
        SKILL_WITCHBLADE_1103 = 1103,      // ½ºÇÉÅÏ¾²·¯½ºÆ®
        SKILL_WITCHBLADE_1104 = 1104,      // Æ®À§½ºÆ®ÇÃ·¦Å±
        SKILL_WITCHBLADE_1105 = 1105,      // ¹ÙÀÌ¿Ã·¿Å©·Î½º
        SKILL_WITCHBLADE_1106 = 1106,      // ³×ÀÏ½ºÅ©·¡Ä¡
        SKILL_WITCHBLADE_1107 = 1107,      // Æä¾î¸®ºí·¹½º
        SKILL_WITCHBLADE_1108 = 1108,      // µ¥µåÆú
        SKILL_WITCHBLADE_1109 = 1109,      // µå·¡°ï´í½º
        SKILL_WITCHBLADE_1110 = 1110,      // ½ºÇÇ´×ÇÏÃ÷
        SKILL_WITCHBLADE_1111 = 1111,      // ¹ÙÀÌ½º¼Òµå
        SKILL_WITCHBLADE_1112 = 1112,      // ÀÌº£ÀÌµå
        SKILL_WITCHBLADE_1113 = 1113,      // ´ÙÅ©Æú¸µ±×·¹ÀÌºê
        SKILL_WITCHBLADE_1114 = 1114,      // Ç»¸®Æ÷¸ÞÀÌ¼Ç
        SKILL_RISINGFORCE = 1115,      // ¶óÀÌÂ¡Æ÷½º
        SKILL_WITCHBLADE_1116 = 1116,      // ¿£Á©ºí·¹½º

        SKILL_WITCHBLADE_1117 = 1117,      // ¼­¸Õ_½ºÄÃÁ¦ÀÌÅ©
        SKILL_WITCHBLADE_1118 = 1118,      // Å©·Î½ºÄÞºñ³×ÀÌ¼Ç
        SKILL_WITCHBLADE_1119 = 1119,      // ´ÙÀÌºêÇïÆÎ
        SKILL_WITCHBLADE_1120 = 1120,      // ºí·¹¾îÆÎ
        SKILL_WITCHBLADE_1121 = 1121,      // ¹ìÆÄÀÌ¾î¸¯ÅÍÄ¡
        SKILL_WITCHBLADE_1122 = 1122,      // ¼­¸Ó³ÊÁî¸®Ä¿¹ö¸®
        SKILL_WITCHBLADE_1123 = 1123,      // ºí·¹ÀÌµåÄ¿Æ°
        SKILL_WITCHBLADE_1124 = 1124,      // ¼­¸Õ_Æ¼Å¸´Ï¾Æ
        SKILL_WITCHBLADE_1125 = 1125,      // ÇÁ·Î½ºÆ®ºí·¹½º
        SKILL_WITCHBLADE_1126 = 1126,      // ¸àµù¸àÅ»
        SKILL_WITCHBLADE_1127 = 1127,      // ¼­¸Õ_º¥½¬
        SKILL_WITCHBLADE_1128 = 1128,      // ÇÁ·ÎÁðÀ©µå
        SKILL_WITCHBLADE_1129 = 1129,      // µð¹ÙÀÎ¾î¼³Æ®
        SKILL_WITCHBLADE_1130 = 1130,      // ¼­¸Õ_¾¾¿¤¸®½º
        SKILL_WITCHBLADE_1131 = 1131,      // ¸àµù¸¶ÀÎµå
        SKILL_WITCHBLADE_1132 = 1132,      // ¸¶±×³×Æ½±×¶óÇÇÅä
        SKILL_WITCHBLADE_1133 = 1133,      // ·çÆ°Æ÷ÀÎÆ®

        // ÆÐ½Ãºê
        SKILL_DAGGER_MASTERY = 900,
        SKILL_WHIP_SWORD_MASTERY = 901,
        SKILL_SHADOW_FORCE = 902,
        SKILL_CURSE_TRAINING = 903,
        SKILL_DARK_TRAINING = 904,

        ////////////////////////////////////////////////////////////////////////////////////////////////
        // ÇÃ·¹ÀÌ¾î ½ºÅ³ ³¡
        ////////////////////////////////////////////////////////////////////////////////////////////////


        SKILL_CREATE_CRYSTAL_WARP = 1400,
        SKILL_DESTROY_CRYSTAL_WARP = 1401,

        // ¸ó½ºÅÍ
        SKILL_BEAST_MASTER_DEADLY_STRIKE = 1500,
        SKILL_BEAST_MASTER_NAKED_BUD = 1501,
        SKILL_BEAST_MASTER_DIRTY_SIDE = 1502,
        SKILL_BEAST_MASTER_SOUL_OF_BEAST = 1503,
        SKILL_BEAST_MASTER_BLIND_TIME = 1504,
        SKILL_BEAST_MASTER_SPIRITS_TOUCH = 1505,
        SKILL_BEAST_MASTER_SUMMON_VAIN = 1506,
        SKILL_BEAST_MASTER_REGEN_ENERMY = 1507,
        SKILL_DRAGON_ZOMBIE_UPPER_BLOW = 1508,
        SKILL_DRAGON_ZOMBIE_StUNNING_BLOW = 1509,
        SKILL_DRAGON_ZOMBIE_HOUL = 1510,
        SKILL_DRAGON_ZOMBIE_RECOVERY_HOUL = 1511,
        SKILL_DRAGON_ZOMBIE_SOUL_OF_DRAGON = 1512,
        SKILL_DRAGON_ZOMBIE_MOON_ASSERT = 1513,
        SKILL_GATESENTRY_CHIEF_GROUND_SHOCK = 1514,
        SKILL_GATESENTRY_CHIEF_TOTUR_SHOCK = 1515,
        SKILL_GATESENTRY_REGEN_ENERMY = 1516,
        SKILL_RESTRICTED_DRAGON_SONIC_EXPLORZEN = 1517,
        SKILL_RESTRICTED_DRAGON_SPINNING_BLOW = 1518,
        SKILL_RESTRICTED_DRAGON_REVERSE_SOLDIER = 1519,
        SKILL_EVIL_SORCERER_FIRE_BALL = 1520,
        SKILL_EVIL_SORCERER_PRESSING_WALL = 1521,
        SKILL_EVIL_SORCERER_ANIMATE_DEAD = 1522,
        SKILL_EVIL_SORCERER_SPIRIT_TOUCH = 1523,
        SKILL_REDAMOR_WARRIOR_SONIC_BLADE = 1524,
        SKILL_REDAMOR_WARRIOR_SPIN_CRUSH = 1525,
        SKILL_REDAMOR_WARRIOR_TOURNADO_AIDS = 1526,
        SKILL_REDAMOR_WARRIOR_REGEN_ENERMY = 1527,
        SKILL_DARK_F_INFANTRY_BASH = 1528,
        SKILL_DARK_F_OFFENSE_UP = 1529,
        SKILL_DARK_F_REVERSE_SOLDIER = 1530,
        SKILL_HEAVY_HUNTER_SNIPING = 1531,
        SKILL_HEAVY_NOIZE_SHOT = 1532,
        SKILL_HEAVY_WHISTLE_SHOT = 1533,
        SKILL_BEAST_KNIGHT_DEATH_DIVIDE = 1534,
        SKILL_BEAST_KNIGHT_CURSE_ENERMY = 1535,
        SKILL_BEAST_KNIGHT_SELF_HEAL = 1536,
        SKILL_GHOUL_STUNNING_BLOW = 1537,
        SKILL_GHOUL_GHOUL_DANCE = 1538,
        SKILL_GHOUL_ANIMATE_DEAD = 1539,
        SKILL_SKULL_INFANTRY_ASSERT = 1540,
        SKILL_SKULL_INFANTRY_CUTTER = 1541,
        SKILL_SKULL_INFANTRY_SUMMON_SOLDIER = 1542,
        SKILL_SNOW_DRAGON_ZOMBIE_UPPER_BLOW = 1543,
        SKILL_SNOW_DRAGON_ZOMBIE_STOP_ORDER = 1544,
        SKILL_SNOW_DRAGON_ZOMBIE_REVERSE_SOLDIER = 1545,
        SKILL_VOLCANO_BEAST_UPPER_BLOW = 1546,
        SKILL_VOLCANO_BEAST_STOP_ORDER = 1547,
        SKILL_VOLCANO_BEAST_SPIRIT_TOUCH = 1548,
        SKILL_BEAST_GUARD_BASH = 1549,
        SKILL_BEAST_GUARD_SLEEP_DANCE = 1550,
        SKILL_BEAST_GUARD_SELF_HEAL = 1551,
        SKILL_GATESENTRY_INFANTRY_GROUND_SHOCK = 1552,
        SKILL_GATESENTRY_INFANTRY_ARMMOR_DOWN = 1553,
        SKILL_GATESENTRY_INFANTRY_SUMMON_SOLDIER = 1554,
        SKILL_DARK_F_PATROL_WEAPON_BREAK = 1555,
        SKILL_DARK_F_PATROL_TWIN_STRECH = 1556,
        SKILL_DARK_F_PATROL_SELF_HEAL = 1557,
        SKILL_LAVA_DRAGON_SONIC_EXPLOZEN = 1558,
        SKILL_LAVA_DRAGON_SPINNING_BLOW = 1559,
        SKILL_LAVA_DRAGON_SUMMON_SOLDIER = 1560,
        SKILL_SLAVE_ARCHER_HEAVY_SHOT = 1561,
        SKILL_SLAVE_ARCHER_SOLOW_SHOT = 1562,
        SKILL_SLAVE_ARCHER_RECOVERY_SHOT = 1563,
        SKILL_ROAM_PRISONER_STURNING_BLOW = 1564,
        SKILL_ROAM_PRISONER_CHARGE_BLOW = 1565,
        SKILL_ROAM_PRISONER_SPIRITS_TOUCH = 1566,
        SKILL_DARK_KNIGHT_DARK_SHOCK = 1567,
        SKILL_DARK_KNIGHT_DARK_SWORD = 1568,
        SKILL_DARK_KNIGHT_Regen_ENERMY = 1569,
        SKILL_DARK_KNIGHT_SPRIRITS_TOUCH = 1570,
        SKILL_DARK_F_MAGICIAN_LIGHTNING = 1571,
        SKILL_DARK_F_MAGICIAN_SHADOW_ROOTS = 1572,
        SKILL_DARK_F_MAGICIAN_SUMMON_SOLIDER = 1573,
        SKILL_FIRE_DESTROYER_DOUBLE_HEAD = 1574,
        SKILL_FIRE_DESTROYER_FLAME_BREATH = 1575,
        SKILL_FIRE_DESTROYER_SELF_HEAL = 1576,
        SKILL_FIRE_DESTROYER_SUMMON_VEIN = 1577,
        SKILL_BEAST_KEEPER_DRAGON_HOUL = 1578,
        SKILL_BEAST_KEEPER_NAKED_BID = 1579,
        SKILL_BEAST_KEEPER_SUMMON_VEIN = 1580,
        SKILL_BEAST_KEEPER_SPIRITS_TOUCH = 1581,
        SKILL_CERBERUS_CUTTER = 1582,
        SKILL_CERBERUS_NOISE_HOUL = 1583,
        SKILL_CERBERUS_SUMMON_VEIN = 1584,
        SKILL_CERBERUS_REGEN_ENERMY = 1585,
        SKILL_DARKNESS_SORCERESS_DARK_FORCE = 1586,
        SKILL_DARKNESS_SORCERESS_CURSE_HEALTH = 1587,
        SKILL_DARKNESS_SORCERESS_SUMMON_SOLIDER = 1588,
        SKILL_DARKNESS_OBSERVER_HEABY_BLOW = 1589,
        SKILL_DARKNESS_OBSERVER_WHEEL_ATTACK = 1590,
        SKILL_DARKNESS_OBSERVER_REVERSE_SOLIDER = 1591,
        SKILL_DARKNESS_OBSERVER_SPRITS_TOUCH = 1592,
        SKILL_SNOWFIELD_DOOR_KEEPER_ROCK_AWAY = 1593,
        SKILL_SNOWFIELD_DOOR_KEEPER_HEAVY_BLOW = 1594,
        SKILL_SNOWFIELD_DOOR_KEEPER_SUMMMON_SOLIDER = 1595,
        SKILL_WHITE_MAGICIAN_ICE_BALL = 1596,
        SKILL_WHITE_MAGICIAN_ICE_FORM = 1597,
        SKILL_WHITE_MAGICIAN_RERVERSE_SOLIDER = 1598,
        SKILL_ICE_CASTLE_KEEPER_TACKLE = 1599,
        SKILL_ICE_CASTLE_KEEPER_ICE_THORNS = 1600,
        SKILL_ICE_CASTLE_KEEPER_SELF_HEAL = 1601,
        SKILL_CURSED_PRIEST_LIGHTING = 1602,
        SKILL_CURSED_PRIEST_ICE_SPRAY = 1603,
        SKILL_CURSED_PRIEST_SELF_HEAL = 1604,
        SKILL_CURSED_PRIEST_SPIRITS_TOUCH = 1605,
        SKILL_MASTER_OF_CASTLE_ICE_MISSILE = 1606,
        SKILL_MASTER_OF_CASTLE_ICE_CAGE = 1607,
        SKILL_MASTER_OF_CASTLE_BLIZZARD = 1608,
        SKILL_MASTER_OF_CASTLE_SUMMON_VEIN = 1609,
        SKILL_MASTER_OF_CASTLE_REGEN_ENERMY = 1610,
        SKILL_MASTER_OF_CASTLE_SPIRITS_TOUCH = 1611,
        SKILL_FIRE_CERBERUS_FIRE_BREATH = 1612,
        SKILL_FIRE_CERBERUS_GRATE_HOUL = 1613,
        SKILL_FIRE_CERBERUS_SUMMON_SOLDIER = 1614,
        //SKILL_EVIL_SORCERER_ANIMATE_DEAD           = 1615,
        //SKILL_FIRE_DRAKE_FIRE_BREATH               = 1616,
        //SKILL_FIRE_DRAKE_SUMMON_SOLDIER            = 1617,
        SKILL_FLAME_BEAST_BLOODY_BITE = 1618,
        SKILL_FLAME_BEAST_TACKLE = 1619,
        SKILL_FIRE_DRAKE_SLOWER_WING = 1620,
        SKILL_FIRE_DRAKE_FIRE_BREATH = 1621,
        SKILL_FLAME_SHAMAN_FIRE_ENERGY = 1622,
        SKILL_FLAME_SHAMAN_FIRE_WALL = 1623,
        SKILL_FLAME_WARRIOR_AXE_FLAME = 1624,
        SKILL_FLAME_WARRIOR_KNOCK_OUT = 1625,
        SKILL_FLAME_RULER_EXPLORZEN_KNOCKLE = 1626,
        SKILL_FLAME_RULER_FIRE_WALL = 1627,
        SKILL_FLAME_RULER_GIGANTIC_BOMBER = 1628,

        SKILL_CURSED_PRIEST_ICE_STORM = 1639,

        SKILL_MASTER_OF_CASTLE_FROST_RING = 1670,
        SKILL_BEAST_MASTER_FIRE_OF_DARKNESS = 1719,
        SKILL_FLAME_RULER_METEO_SHOWER = 1722,
        SKILL_MASTER_OF_CASTLE_BLIZZARD2 = 1737,

        // 07.3¿ù 15ÀÏ ¾ÆÀÌ¿ÃÆ® ¸ð½ºÅÍ ½ºÅ³Ãß°¡1 - º¸È¯
        SKILL_FELLEN_WARRIOR_DASH_ATTACK = 1784,
        SKILL_FELLEN_WARRIOR_XDANCE = 1785,
        eSkILL_CURSED_ARCHER_POISON_ARROW = 1787,

        // 07.4¿ù 5ÀÏ ¾ÆÀÌ¿ÃÆ® ¸ó½ºÅÍ ½ºÅ³ Ãß°¡2 - º¸È¯
        SKILL_CURSED_SOCERER_VAMPIRIC_KISS = 1790,
        SKILL_DARK_SWORDMAN_TRIPLE_ATTACK = 1791,
        SKILL_DARK_SWORDMAN_DEADLY_SMITE = 1792,
        SKILL_DARK_WARRIOR_BEAT = 1793,
        SKILL_DARK_WARRIOR_FATAL_BLOW = 1794,
        SKILL_ARCHBISHOP_OF_DARKNESS_FRUSTRATION_ZONE = 1795,
        SKILL_ARCHBISHOP_OF_DARKNESS_LACK = 1796,
        SKILL_ARCHBISHOP_OF_DARKNESS_DOOM = 1797,
        SKILL_ARCHBISHOP_OF_DARKNESS_SPRIT_TOUCH = 1798,
        SKILL_ARCHBISHOP_OF_DARKNESS_SUMMON_ALLY = 1799,
        SKILL_ARCHBISHOP_OF_DARKNESS_SHIELD_OF_KARMA = 1800,

        // 07.4¿ù 30ÀÏ ¼Ó¹ÚÀÇ±â»ç, ±¾ÁÖ¸®ÇÐ»ìÀÚ ½ºÅ³ Ãß°¡
        SKILL_KNIGHT_OF_SLAVERY_BINDING = 1803,

        //07.6¿ù 20ÀÏ °Å´ëÇÑ ±î¸¶±Í,¹ö·ÁÁøÀÚ ½ºÅ³ Ãß°¡
        SKILL_GIIANTIC_CROW_SCRATCH = 1833,
        SKILL_GIANNTIC_CROW_DIVE = 1834,
        SKILL_DUMPED_MAN_BLIDING = 1835,
        SKILL_DUMPED_MAN_DREIN_RANGER = 1836,

        SKILL_KNIGHT_OF_HUNGRY_SLAYER_THUNDER_CLAP = 1904,
        SKILL_BINDED_ARCHER_STUN_SHOT = 1905,

        //¸Ê»ç¹° ¿ÀºêÁ§Æ® 
        SKILL_MAP_MONSTER_1 = 3000,
        SKILL_MAP_MONSTER_2 = 3001,
        SKILL_MAP_MONSTER_3 = 3002,
        SKILL_MAP_MONSTER_4 = 3003,

        SKILL_ITEM_MINE = 5004,
    };
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

    public enum SkillUserType
    {
        SKILL_USER_PLAYER = 0,
        SKILL_USER_MONSTER,
        SKILL_USER_NPC,
        SKILL_USER_SUMMONED,
        SKILL_USER_FOLLOWER,
        SKILL_USER_ACTION,
        SKILL_USER_EMOTICON
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

    public enum AbilityID
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
        kCharStateIncreaseHeal = 310, // Ä¡À¯·® Áõ°¡ »óÅÂ
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
    public enum StyleEnum
    {

        STYLE_BERSERKER_PUNCH = 60000, // ¸Ç¼Õ°ø°Ý ½ºÅ¸ÀÏ 
        STYLE_DRAGON_PUNCH = 60199, // ¸Ç¼Õ°ø°Ý ½ºÅ¸ÀÏ 
        STYLE_SHADOW_PUNCH = 60400,
        STYLE_VALKYRIE_PUNCH = 60600, // ¸Ç¼Õ°ø°Ý ½ºÅ¸ÀÏ 
        STYLE_MAGICIAN_PUNCH = 60800, // ¸Ç¼Õ°ø°Ý ½ºÅ¸ÀÏ 

        STYLE_TWOHANDAXE_NORMAL = 60100,
        STYLE_FUSS_BREAKER = 60101,//eSTYLE_TWOHANDAXE_DOWN  
        STYLE_HACKSTER_KNOCKBACK_AXE = 60111,//eSTYLE_TWOHANDAXE_DAMAGE
        STYLE_ROLLANDS_DOWN = 60121,//eSTYLE_TWOHANDAXE_STUN  

        STYLE_TWOHANDSWORD_NORMAL = 60001,
        STYLE_BALTURS_DEFENCE = 60011,//eSTYLE_TWOHANDSWORD_DEFENCE
        STYLE_HACKSTER_KNOCKBACK_TWOHAND = 60021,//eSTYLE_TWOHANDSWORD_DOWN   
        STYLE_RUDBIGS_STUN = 60031,//eSTYLE_TWOHANDSWORD_DAMAGE 

        STYLE_ONEHANDSWORD_NORMAL = 60200,
        STYLE_RESTROS_SPEED = 60201,//eSTYLE_ONEHANDSWORD_SPEED   
        STYLE_TORES_CRITICAL = 60211,//eSTYLE_ONEHANDSWORD_CRITICAL
        STYLE_ELEMEOUS_KNOCKBACK_ONEHAND = 60221,//eSTYLE_ONEHANDSWORD_DAMAGE  

        STYLE_SPEAR_NORMAL = 60300,
        STYLE_ALRESTER_DAMAGE = 60301,//eSTYLE_SPEAR_CRITICAL
        STYLE_ELEMEOUS_KNOCKBACK_LANCE = 60311,//eSTYLE_SPEAR_DOWN    
        STYLE_FLABIOUS_PIERCING = 60321,//eSTYLE_SPEAR_PIERCING

        STYLE_ONEHANDCROSSBOW_NORMAL = 60601,
        STYLE_ETHER_NORMAL = 60702,

        STYLE_STAFF_NORMAL = 60801,
        STYLE_ORB_NORMAL = 60901,

        STYLE_DRAGON_TRANSFORM1 = 61001,
        STYLE_DRAGON_TRANSFORM2 = 61002,

        STYLE_SHADOW_DAGGER_NORMAL = 60401,
        STYLE_SHADOW_WHIP_NORMAL = 60402,

        STYLE_MYSTIC_PUNCH = 60403, // _NA_004965_20120613_NEW_CHARACTER_MYSTIC
        STYLE_MYSTIC_GUNTLET_NORMAL = 60404, // _NA_004965_20120613_NEW_CHARACTER_MYSTIC
        STYLE_MYSTIC_POLEARM_NORMAL = 60405, // _NA_004965_20120613_NEW_CHARACTER_MYSTIC

        STYLE_HELLROID_PUNCH = 60406, //_NA_000000_20130812_NEW_CHARACTER_HELLROID
        STYLE_HELLROID_WEAPON1 = 60407, //_NA_000000_20130812_NEW_CHARACTER_HELLROID
        
        STYLE_WITCHBLADE_PUNCH = 60408, //_NA_007514_20140828_NEW_CHARACTER_WITCHBLADE
        STYLE_WITCHBLADE_ARCBLADE = 60409, //_NA_007514_20140828_NEW_CHARACTER_WITCHBLADE
    };

    public enum StatType
    {
        STAT_TYPE_STR = 1, // Èû
        STAT_TYPE_DEX,                 // ¹ÎÃ¸¼º
        STAT_TYPE_VIT,                 // Ã¼·Â
        STAT_TYPE_SPR,                 // Á¤½Å·Â
        STAT_TYPE_INT,                 // Áö·Â
    };
    public enum AbilityType
    {
        ABILITY_TYPE_ACTIVE,
        ABILITY_TYPE_PASSIVE,
        ABILITY_TYPE_EFFECT,
        ABILITY_TYPE_MANUAL,
        ABILITY_TYPE_ACTIVE_AND_EFFECT,
        ABILITY_TYPE_MAX
    };
    public enum StateType
    {
        STATE_TYPE_ABNORMAL = 1,       // »óÅÂÀÌ»ó
        STATE_TYPE_WEAKENING = 2,      // »óÅÂ¾àÈ­
        STATE_TYPE_STRENGTHENING = 3,      // »óÅÂ°­È­
        STATE_TYPE_SPECIALITY = 4,     // Æ¯¼ö
    };
    public enum SkillAreaType
    {
        SRF_FOWARD_ONE = 1,
        SRF_FOWARD_120,
        SRF_FOWARD_160,
        SRF_FOWARD_360,
        SRF_PIERCE,
        SRF_AREA_POSITION,      // Å¸°ÙÀÌ ¾øÀÌ ÁÂÇ¥¸¸ ÀÖ´Â ½ºÅ³ÀÌ´Ù.
        SRF_MAX
    };
    public enum AttackResist
    {
        ATTACK_RESIST_NOMAL = 0,
        ATTACK_RESIST_SKILL,
        ATTACK_RESIST_ALL,
        //_NA_008486_20150914_TOTAL_BALANCE
        ATTACK_RESIST_SKILL_DOT_DAMAGE,    //DoTµ¥¹ÌÁö ½ºÅ³ (Áö¼Ó ÇÇÇØ»óÅÂ)
        ATTACK_RESIST_MAX,
    };
    public enum SDApply
    {
        SD_APPLY_NOT = 0,
        SD_APPLY_DO,
        SD_APPLY_MAX,
        SD_APPLY_EMPTY,
    };
    public enum IncreaseHealAbilityType
    {
        SKILL = 1, // ½ºÅ³ »ç¿ë½Ã¿¡¸¸ Áõ°¡
        ITEM = 2, // ¾ÆÀÌÅÛ »ç¿ë½Ã¿¡¸¸ Áõ°¡
        SKILL_AND_ITEM = 3 // ½ºÅ³°ú ¾ÆÀÌÅÛ µÑ´Ù »ç¿ë½Ã Áõ°¡
    }
    public enum RecoverType
    {
        RECOVER_TYPE_NORMAL = 0,
        RECOVER_TYPE_AUTO_HP = 1,          //ÀÚµ¿À¸·Î HPÈ¸º¹
        RECOVER_TYPE_AUTO_MP = 2,          //ÀÚµ¿À¸·Î MPÈ¸º¹
        RECOVER_TYPE_AUTO_HPMP = 3,            //ÀÚµ¿À¸·Î HP ¹× MPÈ¸º¹
        RECOVER_TYPE_IGNORE_RESERVE_HP = 4,        //HPÀû¸³ ¹«½ÃÇÏ°í HPÈ¸º¹
    };
    public enum FieldeffectType
    {
        EFFECT_TYPE_PERIODIC_DAMAGE = 0,
        EFFECT_TYPE_BOMB = 1,
        EFFECT_TYPE_SELF_DESTRUCTION = 2,   //__NA00XXXX_080922_TASK_SSQ_NPC_SELF_DESTRUCTION__
        EFFECT_TYPE_PERIODIC_SKILL = 3,
    };

    [Flags]
    public enum PlayerStatEvent
    {
        NONE=0,
        CHANGED_HP = 1<<0,
        CHANGED_MP = 1<<1,
        CHANGED_POS = 1<<2,
        CHANGED_SD = 1<<3
    }
}
