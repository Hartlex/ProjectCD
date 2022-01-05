using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Server
{
    public class AckMoneyPickupInfo :ServerPacketInfo
    {
        public readonly ulong Money;

        public AckMoneyPickupInfo(ulong money)
        {
            Money = money;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt64(Money);
        }
    }
}
