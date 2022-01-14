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
}
