using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.Packet
{
    public abstract class PacketInfo
    {
        public byte[] GetBytes()
        {
            ByteBuffer buffer = new();
            GetBytes(ref buffer);
            return buffer.GetData();
        }
        public abstract void GetBytes(ref ByteBuffer buffer);
    }
}
