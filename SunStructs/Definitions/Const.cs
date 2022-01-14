using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
    public static class Const
    {
        public const int INFO_MAX_LENGTH = 64;
        public const int IP_MAX_LENGTH = 32;
        public const int ID_MAX_LENGTH = 24;
        public const int PW_MAX_LENGTH = 24;
        public const int MAX_SERVER = 32;
        public const int MAX_SERVER_NAME_LENGTH = 32;
        public const int MAX_CHANNEL_NAME_LENGTH = 32;
        public const int MAX_CHANNEL = 254;
        public const int G_LOG_KEY_LENGTH = 9;
        public const int MAX_CHAR_NAME_LENGTH = 16;
        public const int SHORT_DATE_LENGTH = 16;
        public const int MAX_GUILD_NAME_LENGTH = 16;
        public const int MAX_TITLE_ID_LENGTH = 16;

        public const int MAX_PLAYERS_ON_MAP = 1000;
        public const int MAX_OBJECTS_ON_MAP = 100000;

        public const int MAX_INVENTORY_SLOT_NUM = 75 * 2;
        public const int MAX_TMP_INVENTORY_SLOT_NUM = 20;
        public const int MAX_SKILL_SLOT_NUM = 100;
        public const int MAX_WAREHOUSE_SLOT_NUM = 5 * 5 * 5;
        public const int MAX_QUICK_SLOT_NUM = 48;
        public const float SPEED_MULTIPLIER = 0.001f;

        public const float DISTANCE_SPACE_GET_ITEM = 7f;
        public const int MAX_FIELDITEM_INFO_SIZE = 80;
        public const int MAX_PLAYER_RENDER_INFO_SIZE = 50;
        public const int MAX_PET_NAME_LENGTH = 10;

        public const int MAX_PACKET_DELAY_TIME = 500;

        public const long BASE_EXPIRE_TIME_INFINITY = -1;

        //BitDefinitions
        public const byte CHAR_ACTION_CONDITION_NONE = 0;
        public const byte CHAR_ACTION_CONDITION_MOVING = 1;
        public const byte CHAR_ACTION_CONDITION_FIGHTING = 2;

        #region TileBits

        public const ushort PTA_SAFETY_ZONE = 0x0001;
        public const ushort PTA_ONLY_JUMP = 0x0002;
        public const ushort PTA_NO_WALK = 0x0004;
        public const ushort PTA_EXTRA_TILE = 0x0008;
        public const ushort PTA_CONFLICT_TILE = 0x0010;
        public const ushort PTA_FREE_CONFLICT_TILE = 0x0020;
        public const ushort PTA_PK_TILE = 0x0040;
        public const ushort PTA_PLAYER_JUMP_TILE = 0x0080;
        public const ushort PTA_PICK = 0x0100;
        public const ushort PTA_PLAYER_FALLDOWN_TILE = 0x0200;
        public const ushort PTA_DOMINATION_WAR_TILE = 0x0400;
        public const ushort PTA_JUMP_CONTROL_A = 0x0800;
        public const ushort PTA_JUMP_CONTROL_B = 0x1000;

        #endregion



    }
}
