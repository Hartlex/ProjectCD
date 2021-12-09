using System.Text;
using CDShared.ByteLevel;
using SunStructs.PacketInfos.Auth.Server;
using static SunStructs.Definitions.Const;

namespace SunStructs.PacketInfos.Auth.Client
{
    public class AskConnectInfo : ClientPacketInfo
    {
        public readonly ClientVersion ClientVersion;
        public readonly string IpAddress;

        public AskConnectInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            ClientVersion = new ClientVersion(ref buffer);
            IpAddress = buffer.ReadString(IP_MAX_LENGTH);
        }

    }
}
