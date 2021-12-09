using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;

namespace SunStructs.Packets.AuthServerPackets
{
    public class AuthPacket : AuthServerPacket
    {
        public AuthPacket(byte subType,PacketInfo packetInfo) : base(AuthPacketType.AUTH,subType,packetInfo){}
    }

    public class HelloPacket : AuthPacket
    {
        public HelloPacket(PacketInfo packetInfo) : base(0, packetInfo)
        {
        }
    }
}
