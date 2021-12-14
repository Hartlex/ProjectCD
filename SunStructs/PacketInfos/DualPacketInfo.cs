using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos
{
    public abstract class DualPacketInfo : ServerPacketInfo
    {
        protected DualPacketInfo(ref ByteBuffer buffer)
        {

        }
    }
}
