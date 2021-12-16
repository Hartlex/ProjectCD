using System.Text;
using CDShared.ByteLevel;
using SunStructs.PacketInfos.World.Chat.Client;

namespace SunStructs.PacketInfos.World.Chat.Server
{
    public class ChatMessageInfo : ServerPacketInfo
    {
        public readonly string CharName;
        public readonly byte MessageSize;
        public readonly string Message;

        public ChatMessageInfo(string charName, byte messageSize, string message)
        {
            CharName = charName;
            MessageSize = messageSize;
            Message = message;
        }

        public ChatMessageInfo(string charName, AskPostChatInfo info)
        {
            CharName = charName;
            MessageSize = info.Size;
            Message = info.Message;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteString(CharName,16);
            buffer.WriteByte('\0');
            buffer.WriteByte(Message.Length+1);
            buffer.WriteString(Message,MessageSize);
        }
    }
}
