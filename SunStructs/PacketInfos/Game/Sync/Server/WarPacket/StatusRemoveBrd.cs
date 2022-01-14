using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.Packets.GameServerPackets.Sync;
using static SunStructs.Packets.GameServerPackets.Sync.WarProtocol;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class StatusRemoveBrd : WarPacketInfo
    {
        public readonly uint TargetKey;
        public readonly ushort StateType;
        public StatusRemoveBrd(uint targetKey, CharStateType type) : base(STATUS_REMOVE)
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
