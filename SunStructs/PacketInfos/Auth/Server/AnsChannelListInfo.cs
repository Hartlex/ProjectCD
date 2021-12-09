using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class AnsChannelListInfo : ServerPacketInfo
    {
        private readonly ChannelInfo[] _channelInfos;

        public AnsChannelListInfo(ChannelInfo[] channelInfos)
        {
            _channelInfos = channelInfos;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte)_channelInfos.Length);
            foreach (var channelInfo in _channelInfos)
            {
                channelInfo.GetBytes(ref buffer);
            }
        }
    }
}