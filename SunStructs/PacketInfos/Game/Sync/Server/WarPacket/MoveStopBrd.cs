using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;
using static SunStructs.Packets.GameServerPackets.Sync.WarProtocol;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class MoveStopBrd : WarPacketInfo
    {
        public uint ObjectKey;
        public SunVector Position;


        public MoveStopBrd(uint objectKey, SunVector position) : base(MOVE_STOP)
        {
            ObjectKey = objectKey;
            Position = position;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(ObjectKey);
            Position.GetBytes(ref buffer);
        }
    }
}
