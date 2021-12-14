﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Item.Dual;

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
}
