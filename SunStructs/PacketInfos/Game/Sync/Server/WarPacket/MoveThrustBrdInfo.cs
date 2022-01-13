using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class MoveThrustBrdInfo : WarPacketInfo
    {
        public uint ObjectKey;
        public byte MoveState;
        public SunVector CurrentPosition;
        public SunVector DestinationPosition;


        public MoveThrustBrdInfo(uint objectKey, byte moveState, SunVector currentPosition, SunVector destinationPosition) : base(WarProtocol.MOVE_THRUST_BRD)
        {
            ObjectKey = objectKey;
            MoveState = moveState;
            CurrentPosition = currentPosition;
            DestinationPosition = destinationPosition;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteByte(MoveState);
            CurrentPosition.GetBytes(ref buffer);
            DestinationPosition.GetBytes(ref buffer);
        }
    }
}
