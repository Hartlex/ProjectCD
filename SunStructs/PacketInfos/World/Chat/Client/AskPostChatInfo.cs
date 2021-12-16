using System.Text;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.World.Chat.Client
{
    public class AskPostChatInfo : ClientPacketInfo
    {
        public readonly byte Size;
        public readonly string Message;

        public AskPostChatInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Size = buffer.ReadByte();
            var messageBytes = buffer.ReadBlock(Size);
            Message = Encoding.ASCII.GetString(messageBytes);
        }

    }
}
