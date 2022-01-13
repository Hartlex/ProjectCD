using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Sync.Client;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;
using static SunStructs.Packets.GameServerPackets.Sync.WarProtocol;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class PlayerJumpBrd : WarPacketInfo
    {
        public uint PlayerKey;
        public SunVector LandingPos;
        public int Direction;
        public PlayerJumpBrd(uint playerKey,JumpInfo info) : base(PLAYER_JUMP_BRD)
        {
            PlayerKey = playerKey;
            LandingPos = info.LandPosition;
            Direction = info.Direction;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(PlayerKey);
            LandingPos.GetBytes(ref buffer);
            buffer.WriteInt32(Direction);
        }
    }
}
