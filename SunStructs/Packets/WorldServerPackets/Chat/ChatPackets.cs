using SunStructs.PacketInfos;
using SunStructs.PacketInfos.World.Chat.Server;

namespace SunStructs.Packets.WorldServerPackets.Chat
{
    public class ChatPacket : Packet
    {
        public ChatPacket(byte packetSubType, ServerPacketInfo packetStruct) : base((byte)WorldPacketType.CHAT, packetSubType, packetStruct)
        {

        }

        public class AckPostChatMessage : ChatPacket
        {
            public AckPostChatMessage(ChatMessageInfo info) : base(34, info) { }
        }
    }
}
