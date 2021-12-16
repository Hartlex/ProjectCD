using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Item.Dual;
using SunStructs.PacketInfos.Game.Item.Server;

namespace SunStructs.Packets.GameServerPackets.Item
{
    public class ItemPacket : Packet
    {
        public ItemPacket(byte packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.ITEM, packetSubType, info)
        {
        }
    }
    public class AckItemMove : ItemPacket
    {
        public AckItemMove(ItemMoveInfo info) : base(5, info) { }
    }
    public class AckItemPickup : ItemPacket
    {
        public AckItemPickup(AckItemPickupInfo info) : base(196, info) { }
    }
    public class AckSkillToQuick : ItemPacket
    {
        public AckSkillToQuick(BindSkillToQuickInfo info) : base(247, info) { }
    }

    public class AckItemToQuick : ItemPacket
    {
        public AckItemToQuick(BindItemToQuickInfo info) : base(61, info) { }
    }

    public class AckUnbindQuick : ItemPacket
    {
        public AckUnbindQuick(UnbindQuickInfo info) : base(151, info) { }
    }

    public class AckMoveQuick : ItemPacket
    {
        public AckMoveQuick(MoveQuickInfo info) : base(107, info) { }
    }


}
