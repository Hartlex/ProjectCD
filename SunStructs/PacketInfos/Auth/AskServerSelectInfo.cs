using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AskServerSelectInfo :PacketInfo
    {
        public readonly byte ServerId;
        public readonly byte ChannelId;

        public AskServerSelectInfo(ref ByteBuffer buffer)
        {
            ServerId = buffer.ReadByte();
            ChannelId = buffer.ReadByte();
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(ServerId);
            buffer.WriteByte(ChannelId);
        }
    }
}
