using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Connection;
using SunStructs.PacketInfos.Game.Connection.Server;

namespace SunStructs.Packets.GameServerPackets.Connection
{

    public class ConnectionPacket : Packet
    {
        public ConnectionPacket(byte packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.CONNECTION, packetSubType, info)
        {
        }
    }
    public class AckEnterCharSelect : ConnectionPacket
    {
        public AckEnterCharSelect(AckEnterCharSelectInfo info) : base(152, info) { }
    }
    public class AckEnterGame : ConnectionPacket
    {
        public AckEnterGame(AckEnterGameInfo info) : base(131, info) { }
    }
    public class ConnectToWorldCmd : ConnectionPacket
    {
        public ConnectToWorldCmd(ConnectToWorldInfo info) : base(21, info) { }
    }
    public class AckBackToCharSelect : ConnectionPacket
    {
        public AckBackToCharSelect(EmptyPacketInfo info) : base(143, info) { }
        public AckBackToCharSelect() : base(143, new EmptyPacketInfo()) { }
    }
}
