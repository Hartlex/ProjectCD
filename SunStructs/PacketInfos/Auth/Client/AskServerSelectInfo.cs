using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth.Client
{
    public class AskServerSelectInfo : ClientPacketInfo
    {
        public readonly byte ServerGroupId;
        public readonly byte ChannelId;

        public AskServerSelectInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            ServerGroupId = buffer.ReadByte();
            ChannelId = buffer.ReadByte();
        }


    }
}
