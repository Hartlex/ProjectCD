using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.World.Chat.Server;

namespace SunStructs.Packets.WorldServerPacktes.Chat
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
