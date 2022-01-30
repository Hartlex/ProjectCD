using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Battle.Server;
using static SunStructs.Packets.GameServerPackets.Battle.BattleProtocol;

namespace SunStructs.Packets.GameServerPackets.Battle
{
    public enum BattleProtocol
    {
        ASK_PLAYER_ATTACK =12,
        PLAYER_NORMAL_ATTACK_BRD = 109
    }
    public class BattlePacket : Packet
    {
        public BattlePacket(BattleProtocol packetSubType, ServerPacketInfo info) : base((byte)GamePacketType.BATTLE, (byte) packetSubType, info)
        {
        }
    }
    public class PlayerAttackBrd : BattlePacket
    {
        public PlayerAttackBrd(PlayerNormalAttackBrdInfo info) : base(PLAYER_NORMAL_ATTACK_BRD, info) { }
    }
}
