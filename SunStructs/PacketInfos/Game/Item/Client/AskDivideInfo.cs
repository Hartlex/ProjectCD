using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Client
{
    public class AskDivideInfo : ClientPacketInfo
    {
        public readonly int FromPos;
        public readonly int ToPos;
        public readonly int FromCount;
        public readonly int ToCount;

        public AskDivideInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            FromPos = buffer.ReadByte();
            ToPos = buffer.ReadByte();
            FromCount = buffer.ReadByte();
            ToCount = buffer.ReadByte();
        }
    }

}
