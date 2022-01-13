using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Sync.Server;
using static SunStructs.Packets.GameServerPackets.Sync.SyncProtocol;

namespace SunStructs.Packets.GameServerPackets.Sync
{
    public enum SyncProtocol
    {
        ALL_PLAYERS_GUILD_INFO=234,
        ALL_PLAYERS_EQUIP_INFO=15,
        ASK_ENTER_FIELD = 141,
        ACK_ENTER_WORLD =31,
        ITEM_ENTER_FIELD_BRD=93,
        ALL_FIELD_ITEM_INFO=97,
        ITEM_LEAVE_FIELD=2, //Obj leave field
        ALL_PLAYER_RENDER_INFO=122,
        PLAYER_LEAVE_FIELD=2, //Obj leave field
        WAR_MESSAGE=167,
        MONSTERS_ENTER = 174,
        ALL_MONSTER_INFO =114,
        ON_KEYBOARD_MOVE = 43,
        ON_JUMP = 115,
        ON_MOUSE_MOVE = 202,
        ON_JUMP_END = 69,
        ON_MOVE_STOP = 123,
        ON_TARGET_MOVE = 95,
        ACTION_EXPIRED_CMD =32

    }
    public class SyncPacket : Packet
    {
        public SyncPacket(SyncProtocol packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.SYNC, (byte)packetSubType, info)
        {
        }
    }
    public class AllPlayersGuildInfoCmd : SyncPacket
    {
        public AllPlayersGuildInfoCmd(TestPacketInfo bytes) : base(ALL_PLAYERS_GUILD_INFO, bytes) { }
    }

    public class AllPlayersEquipInfoCmd : SyncPacket
    {
        public AllPlayersEquipInfoCmd(AllPlayerEquipInfo bytes) : base(ALL_PLAYERS_EQUIP_INFO, bytes) { }
    }

    public class AckEnterWorld : SyncPacket
    {
        public AckEnterWorld(AckEnterWorldInfo info) : base(ACK_ENTER_WORLD, info) { }
    }

    public class ItemEnterFieldBrd : SyncPacket
    {
        public ItemEnterFieldBrd(ItemEnterFieldInfo info) : base(ITEM_ENTER_FIELD_BRD, info) { }
    }

    public class AllFieldItemInfoBrd : SyncPacket
    {
        public AllFieldItemInfoBrd(AllFieldItemInfo info) : base(ALL_FIELD_ITEM_INFO, info){ }
    }
    public class ItemLeaveFieldBrd : SyncPacket
    {
        public ItemLeaveFieldBrd(ItemLeaveFieldInfo info) : base(ITEM_LEAVE_FIELD, info) { }
    }

    public class AllPlayerRenderInfoCmd : SyncPacket
    {
        public AllPlayerRenderInfoCmd(AllPlayerRenderInfo info):base(ALL_PLAYER_RENDER_INFO, info){}
    }

    public class PlayerLeaveFieldBrd : SyncPacket
    {
        public PlayerLeaveFieldBrd(PlayerLeaveFieldInfo info) : base(PLAYER_LEAVE_FIELD, info){}
    }
    public class BrdMonsterEnter : SyncPacket
    {
        public BrdMonsterEnter(MonsterRenderInfos info) : base(MONSTERS_ENTER, info) { }
    }

    public class AllMonsterInfoCmd : SyncPacket
    {
        public AllMonsterInfoCmd(MonsterRenderInfos info) : base(ALL_MONSTER_INFO, info) { }
    }
    public class ActionExpiredCmd : SyncPacket
    {
        public ActionExpiredCmd(ActionExpiredInfo info) : base(ACTION_EXPIRED_CMD, info) { }
    }


}
