using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class ChannelInfo : PacketInfo
    {
        private readonly string name;
        private readonly byte channelNr;
        private readonly byte belongToServerNr;
        public ChannelInfo(string name, int channelNr, int belongToServerNr)
        {
            this.name = name;
            this.channelNr = (byte)channelNr;
            this.belongToServerNr = (byte)belongToServerNr;
        }

        
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteString(name,32);
            //buffer.WriteByte(1);
            //buffer.WriteByte(belongToServerNr);
            //buffer.WriteByte(channelNr);
            //buffer.WriteByte(1); //State
            //buffer.WriteByte(0); 

            buffer.WriteBlock(new byte[]
            {
                1,
                belongToServerNr,
                channelNr,
                1,
                0
            });
        }
    }
}
