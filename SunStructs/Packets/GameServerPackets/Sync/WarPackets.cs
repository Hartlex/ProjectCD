using SunStructs.PacketInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using static SunStructs.Packets.GameServerPackets.Sync.SyncProtocol;

namespace SunStructs.Packets.GameServerPackets.Sync
{
    public enum WarProtocol
    {
        MOVE_THRUST_BRD=61,
        KBD_MOVE_BRD=69,
        PLAYER_JUMP_BRD=44,
        MOVE_STOP=140,
        TARGET_MOVE_BRD =19,
        MOVE_BRD = 169
    }
    public class ComposeWarPacket : SyncPacket
    {
        public ComposeWarPacket(ComposeWarPacketInfo info) : base(WAR_MESSAGE, info)
        {
        }
    }


}
