using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Auth.Server;

namespace SunStructs.Packets.AuthServerPackets
{
    public class AuthPacket : AuthServerPacket
    {
        public AuthPacket(byte subType,ServerPacketInfo serverPacketInfo) : base(AuthPacketType.AUTH,subType,serverPacketInfo){}
    }

    public class Hello : AuthPacket { public Hello(HelloInfo info) : base(0, info) { } }
    public class AckConnect : AuthPacket { public AckConnect(AckConnectInfo info) : base(2, info) { } }
    public class AckLogin : AuthPacket { public AckLogin(AckLoginInfo info) : base(14, info) { } }
    public class AnsServerList : AuthPacket { public AnsServerList(AnsServerListInfo info) : base(17, info) { } }
    public class AnsChannelList : AuthPacket { public AnsChannelList(AnsChannelListInfo info) : base(18, info) { } }
    public class AckServerSelect : AuthPacket { public AckServerSelect(AckServerSelectInfo info) : base(26, info) { } }
}
