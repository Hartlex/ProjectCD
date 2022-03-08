using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Status.Client
{
    public class AskIncreaseAttribute : ClientPacketInfo
    {
        public readonly AttrType AttrType;
        public AskIncreaseAttribute(ref ByteBuffer buffer) : base(ref buffer)
        {
            AttrType = (AttrType) buffer.ReadByte();
        }
    }
}
