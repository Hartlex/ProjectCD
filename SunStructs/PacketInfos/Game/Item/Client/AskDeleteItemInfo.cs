using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Client
{
    public class AskDeleteItemInfo
    {
        public readonly int Pos;

        public AskDeleteItemInfo(ref ByteBuffer buffer)
        {
            Pos = buffer.ReadByte();
        }
    }
}
