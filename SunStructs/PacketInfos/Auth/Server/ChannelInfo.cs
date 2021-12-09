using CDShared.ByteLevel;
using static SunStructs.Definitions.Const;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class ChannelInfo : ServerPacketInfo
    {
        private readonly string _name;
        private readonly byte _channelNr;
        private readonly byte _belongToServerNr;
        private readonly byte _crowdGrade;
        private readonly ServerState _state;

        public ChannelInfo(string name, int channelNr, int belongToServerNr)
        {
            _name = name;
            _channelNr = (byte) channelNr;
            _belongToServerNr = (byte) belongToServerNr;
            _crowdGrade = 1;
            _state = ServerState.CONNECTED;
        }

        
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteString(_name,MAX_CHANNEL_NAME_LENGTH+1);

            buffer.WriteBlock(new []
            {
                _belongToServerNr,
                _channelNr,
                _crowdGrade,
                (byte)_state
            });
        }
    }
}
