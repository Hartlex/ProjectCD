using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
    public enum BattlePointType
    {
        BATTLE_POINT_CLASS,         // ÇÃ·¹ÀÌ¾î Å¬·¡½º ¾î±×·Î Æ÷ÀÎÆ® 
        BATTLE_POINT_FIRST,         // ¼±°ø Æ÷ÀÎÆ®
        BATTLE_POINT_DISTANCE,      // ÃÖ¼Ò °Å¸® Æ÷ÀÎÆ®
        BATTLE_POINT_LEVEL,         // ÃÖ¼Ò ·¹º§ Æ÷ÀÎÆ®
        BATTLE_POINT_HP,            // ÃÖ¼Ò Ã¼·Â Æ÷ÀÎÆ®
        BATTLE_POINT_DAMAGE,        // µ¥¹ÌÁö Æ÷ÀÎÆ®
        BATTLE_POINT_ETC,           // ±âÅ¸ Æ÷ÀÎÆ® (Èú, ¹°¾à µî ¾îºô¸®Æ¼¿¡ ÀÇÇÑ Æ÷ÀÎÆ®)
        BATTLE_POINT_TOTAL,         // ÀüÃ¼ Æ÷ÀÎÆ®
        BATTLE_POINT_MAX
    };
    public enum AIStateID
    {
        STATE_ID_UNKNOWN = 0,
        STATE_ID_WANDER,
        STATE_ID_IDLE,
        STATE_ID_TRACK,
        STATE_ID_ATTACK,
        STATE_ID_HELP,
        STATE_ID_THRUST,
        STATE_ID_DEAD,
        STATE_ID_FLYING,
        STATE_ID_KNOCKDOWN,
        STATE_ID_JUMP,
        STATE_ID_FALL_APART,
        STATE_ID_RETURN,
        STATE_ID_RETREAT,
        STATE_ID_RUNAWAY,
        STATE_ID_CHAOS,
        STATE_ID_SUMMON_IDLE,
        STATE_ID_PATROL,
        STATE_ID_SPAWN_IDLE,
        STATE_ID_STOP_IDLE,
        STATE_ID_TRACK_AREA,
        STATE_ID_BLIND,
        STATE_ID_PATHLIST,          //_NA_0_20100222_UNIT_TRIGGERS_PATHLIST
        STATE_ID_FOLLOW,
        STATE_ID_NO_TRANS,          //_NA001385_20090924_DOMINATION_MAPNPC_AI_BUG
        STATE_ID_DESTROY_OBJECT,     //_NA_0_20100514_NPC_DEAD_STATE_TIME
        STATE_ID_SPECIAL_DEAD_ACTION,
        STATE_ID_UPPERBOUND,
    };
    public enum NPCMoveAttitude         // ¸ó½ºÅÍÀÇ ÀÌµ¿¼ºÇâ
    {
        MOVE_ATTITUDE_WANDER = 0,  // ÀÌµ¿Çü
        MOVE_ATTITUDE_ETERNAL_STOP = 1,    // ¿ÏÀü Á¤ÁöÇü
        MOVE_ATTITUDE_SPAWN_STOP = 2,  // ½ºÆù Á¤ÁöÇü(ÀûÀÌ ³ªÅ¸³ª±â Àü±îÁö¸¸ Á¤Áö)
        MOVE_ATTITUDE_PATROL = 3,  // ÆÐÆ®·Ñ
        MOVE_ATTITUDE_SEARCH_AREA = 4, // Æ¯Á¤ ¿µ¿ªÀ» ¿ì¼±ÀûÀ¸·Î °Ë»öÇÑ´Ù.
        MOVE_ATTITUDE_PATHLIST = 5,    // °æ·Î ÀÌµ¿Çü (¼³Á¤µÈ °æ·Î 1È¸ ÀÌµ¿)   //_NA_0_20100222_UNIT_TRIGGERS_PATHLIST
        MOVE_ATTITUDE_FOLLOW = 6,    // ÁÖÀ§ ¾Æ±º µû¶ó°¡±â
        MOVE_ATTITUDE_ETERNAL_STOP_NO_ATTACK = 7,    // ¿ÏÀü Á¤Áö(°ø°Ý ¾ÈÇÔ)   //_NA001385_20090924_DOMINATION_MAPNPC_AI_BUG
        // dead½Ã »ç¶óÁöÁö ¾ÊÀ½. : 0ÀÎ »óÅÂ·Î dead °ü·Ã Ã³¸®µÇ°í, ÇÊµå¿¡¼­ ¿ÀºêÁ§Æ® »èÁ¦ ÇÏÁö ¾Ê´Â´Ù.
        MOVE_ATTITUDE_ATTACK_GROUND = 8,    // ¾îÅÃ ±×¶ó¿îµå Çü(ÀÌµ¿¸í·É Àü±îÁö´Â ½ºÆù Á¤ÁöÇü°ú °°À½)
        MOVE_ATTITUDE_MAX
    };
    public enum AIMsgID
    {
        AI_MSG_ID_FORCE_ATTACK,
        AI_MSG_ID_ATTACKED,
        AI_MSG_ID_LEAVE_FIELD,
        AI_MSG_ID_HELP_REQUEST,
        AI_MSG_ID_THRUST,
        AI_MSG_ID_FLYING,
        AI_MSG_ID_KNOCKDOWN,
        AI_MSG_ID_STUN,
        AI_MSG_ID_GROUP_MEMBER_ATTACKED,
        AI_MSG_ID_GROUP_C0MMAND,
        AI_MSG_ID_LETSGO,
        AI_MSG_ID_ENEMY_FOUND,
        AI_MSG_ID_RUNAWAY,
        AI_MSG_ID_CHAOS,
        AI_MSG_ID_CHANGESTATE,
        AI_MSG_ID_COMMAND_FOLLOW,
        AI_MSG_ID_USE_SKILL,
        AI_MSG_ID_CHANGE_RETREATSTATE,
        AI_MSG_ID_COMMAND_NONPVP,
        AI_MSG_ID_BLIND,
        AI_MSG_ID_MAX
    };
    public enum AttackAttitude
    {
        ATTACK_ATTITUDE_AFTER = 1,	// ÈÄ°ø
        ATTACK_ATTITUDE_NEARES_FIRST = 2,	// ¼±°ø(°Å¸®)
        ATTACK_ATTITUDE_LOW_HP_FIRST = 3,	// ¼±°ø(Ã¼·Â)
        ATTACK_ATTITUDE_LOW_LEVEL_FIRST = 4,	// ¼±°ø(·¹º§)
        ATTACK_ATTITUDE_HIGH_MP_FIRST = 5,	// ¼±°ø(¸¶³ª)
        ATTACK_ATTITUDE_ONE_TARGET = 6,	// ´Ü¼ø¹«½Ä
    };
    public enum TargetSearchType
    {
        RARGET_SEARCH_NEAREST = 0,	// °¡Àå °¡±î¿î Àû ¿ì¼±
        RARGET_SEARCH_LOW_HP,			// Ã¼·ÂÀÌ °¡Àå ¾àÇÑ ´ë»ó
        RARGET_SEARCH_LOW_LEVEL,		// ·¹º§ÀÌ °¡Àå ¾àÇÑ ´ë»ó
        RARGET_SEARCH_HIGH_MP,			// ¸¶³ª°¡ °¡Àå ¸¹Àº ´ë»ó
        RARGET_SEARCH_LOW_HPRATIO,		// Ã¼·Â ºñÀ²ÀÌ °¡Àå ÀÛÀº ´ë»ó
        RARGET_SEARCH_CORPSE,			// ½ÃÃ¼
    };
    public enum AttackOrder
    {
        ATTACK_ORDER_0_PERCENT = 0,     // °ø°Ý ¸í·É±Ç ¾øÀ½
        ATTACK_ORDER_100_PERCENT = 1,       // 100ÆÛ¼¾Æ® °ø°Ý¸í·É ³»¸²
        ATTACK_ORDER_50_PERCENT = 2,		// 50ÆÛ¼¾Æ® °ø°Ý¸í·É ³»¸²
    };
    public enum HelpRequest
    {
        HELP_REQUEST_NOT = 0,       // Áö¿ø¿äÃ» ¾ÈÇÔ
        HELP_REQUEST_HP50_PERCENT = 1,		// HP°¡ 50ÆÛ¼¾Æ® ÀÌÇÏÀÌ¸é Áö¿ø¿äÃ»
    };
    public enum GroupCMD
    {
        GROUP_CMD_TYPE_ATTACK,
        GROUP_CMD_TYPE_STOP_ATTACK,
    };
    public enum NPCSpecialActionType
    {
        NPC_SPECIAL_ACTION_HELPREQUEST = 1,    // Áö¿ø¿äÃ»
        NPC_SPECIAL_ACTION_TRANSFORMATION = 2, // º¯½Å
        NPC_SPECIAL_ACTION_SKILL = 3,  // Æ¯¼ö½ºÅ³ »ç¿ë
        NPC_SPECIAL_ACTION_SELP_DESTRUCTION = 4,   // ÀÚÆø	(__NA00XXXX_080922_TASK_SSQ_NPC_SELF_DESTRUCTION__)
        NPC_SPECIAL_ACTION_MAX
    };
}
