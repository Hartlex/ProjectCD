using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class TotalStateInfo : ServerPacketInfo
    {
        public readonly byte Count;
        public readonly StateInfo[] StateInfos;

        public TotalStateInfo(StateInfo[] stateInfos)
        {
            Count = (byte) stateInfos.Length;
            StateInfos = stateInfos;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Count);
            foreach (var stateInfo in StateInfos)
            {
                stateInfo.GetBytes(ref buffer);
            }
        }
    }

    public class StateInfo :ServerPacketInfo
    {
        public readonly ushort StateCode;
        public readonly uint StateTime;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(StateCode);
            buffer.WriteUInt32(StateTime);
        }
    }
}
