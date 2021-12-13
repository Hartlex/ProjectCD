using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Sync.Server;

namespace SunStructs.Packets.GameServerPackets.Sync
{
    public class SyncPacket : Packet
    {
        public SyncPacket(byte packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.SYNC, packetSubType, info)
        {
        }
    }
    public class AllPlayersGuildInfoCmd : SyncPacket
    {
        public AllPlayersGuildInfoCmd(TestPacketInfo bytes) : base(234, bytes) { }
    }

    public class AllPlayersEquipInfoCmd : SyncPacket
    {
        public AllPlayersEquipInfoCmd(TestPacketInfo bytes) : base(15, bytes) { }
    }

    public class AckEnterWorld : SyncPacket
    {
        public AckEnterWorld(AckEnterWorldInfo info) : base(31, info) { }
    }

    public class MoveSyncBrd : SyncPacket
    {
        public MoveSyncBrd(KeyboardMoveBrdInfo info) : base(61, info) { }
    }

}
