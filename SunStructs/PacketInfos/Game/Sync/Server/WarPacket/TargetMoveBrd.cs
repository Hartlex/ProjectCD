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
    public class TargetMoveBrd : WarPacketInfo
    {
        public readonly uint TargetKey;
        public readonly ushort PlayerKey;
        public SunVector CurrentPosition;
        public SunVector DestinationPosition;
        public TargetMoveBrd(ushort playerKey, TargetMoveInfo info) : base(TARGET_MOVE_BRD)
        {
            TargetKey = info.TargetKey;
            PlayerKey = playerKey;
            CurrentPosition = info.CurrentPosition;
            DestinationPosition = info.DestinationPosition;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(TargetKey);
            buffer.WriteUInt16(PlayerKey);
            CurrentPosition.GetBytes(ref buffer);
            DestinationPosition.GetBytes(ref buffer);
        }
    }
}
