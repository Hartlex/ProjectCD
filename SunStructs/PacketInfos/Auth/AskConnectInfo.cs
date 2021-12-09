using System.Text;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AskConnectInfo : PacketInfo
    {
        public readonly ClientVersion ClientVersion;
        public readonly byte[] IpAddressBytes;
        public readonly string IpAddress;
        public byte[] unk1;
        public AskConnectInfo(ref ByteBuffer buffer)
        {
            ClientVersion = new ClientVersion(ref buffer);
            IpAddressBytes = buffer.ReadBlock(15);
            IpAddress = Encoding.ASCII.GetString(ByteUtils.CutTail(IpAddressBytes));
            unk1 = new byte[16];
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            ClientVersion.GetBytes(ref buffer);
            buffer.WriteBlock(IpAddressBytes);
            buffer.WriteBlock(unk1);

        }
    }
}
