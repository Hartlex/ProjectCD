using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Client
{
   
    public class AskPickupMoneyInfo
    {
        public readonly uint ObjectKey;

        public AskPickupMoneyInfo(ref ByteBuffer buffer)
        {
            buffer.Skip(2); //rnd
            ObjectKey = buffer.ReadUInt32();
        }
    }
}
