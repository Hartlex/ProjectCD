using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth.Client
{
    public class AskServerSelectInfo : ClientPacketInfo
    {
        public readonly byte ServerId;
        public readonly byte ChannelId;

        public AskServerSelectInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            ServerId = buffer.ReadByte();
            ChannelId = buffer.ReadByte();
        }


    }
}
