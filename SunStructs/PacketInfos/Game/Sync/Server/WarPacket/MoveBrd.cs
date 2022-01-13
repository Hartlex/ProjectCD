using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;
using static SunStructs.Packets.GameServerPackets.Sync.WarProtocol;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class MoveBrd : WarPacketInfo
    {
        public readonly uint ObjectKey;
        public readonly byte State;
        public readonly byte Forced;
        public readonly SunVector CurrentPos;
        public readonly SunVector DestinationPos;


        public MoveBrd(uint objectKey, byte state, byte forced, SunVector currentPos, SunVector destinationPos) : base(MOVE_BRD)
        {
            ObjectKey = objectKey;
            State = state;
            Forced = forced;
            CurrentPos = currentPos;
            DestinationPos = destinationPos;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteByte(State);
            buffer.WriteByte(Forced);
            CurrentPos.GetBytes(ref buffer);
            DestinationPos.GetBytes(ref buffer);
        }
    }
}
