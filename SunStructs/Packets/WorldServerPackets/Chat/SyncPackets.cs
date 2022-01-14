using SunStructs.PacketInfos;
using SunStructs.Packets.GameServerPackets.Sync;

namespace SunStructs.Packets.WorldServerPackets.Chat
{

    public class SyncPackets : Packet
    {
        public SyncPackets(SyncProtocol packetSubType, ServerPacketInfo packetStruct) : base((byte)WorldPacketType.SYNC, (byte) packetSubType, packetStruct)
        {

        }
    }
}
