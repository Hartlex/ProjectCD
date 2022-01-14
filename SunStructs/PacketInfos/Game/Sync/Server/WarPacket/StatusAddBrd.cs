using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using static SunStructs.Packets.GameServerPackets.Sync.WarProtocol;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class StatusAddBrd : WarPacketInfo
    {
        public readonly uint TargetKey;
        public readonly ushort StateType;


        public StatusAddBrd(uint targetKey,CharStateType type) : base(STATUS_ADD)
        {
            TargetKey = targetKey;
            StateType = (ushort)type;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt32(TargetKey);
            buffer.WriteUInt16(StateType);
        }
    }
}
