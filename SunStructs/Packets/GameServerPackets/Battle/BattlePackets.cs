using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;

namespace SunStructs.Packets.GameServerPackets.Battle
{
    public enum BattleProtocol
    {
        ASK_PLAYER_ATTACK =12
    }
    public class BattlePacket : Packet
    {
        public BattlePacket(byte packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.BATTLE, packetSubType, info)
        {
        }
    }
}
