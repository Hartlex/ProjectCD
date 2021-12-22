using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Item.Client;

namespace SunStructs.PacketInfos.Game.Item.Server
{
    public class AckSellItemInfo : ServerPacketInfo
    {
        public readonly uint PlayerKey;
        public readonly AskSellItemInfo AskInfo;
        public readonly ulong Money;

        public AckSellItemInfo(uint playerKey,AskSellItemInfo askInfo, ulong money)
        {
            PlayerKey = playerKey;
            AskInfo = askInfo;
            Money = money;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(PlayerKey);
            
            buffer.WriteByte((byte) AskInfo.SlotIndex);
            buffer.WriteByte(AskInfo.AtPos);
            buffer.WriteByte(AskInfo.Amount);
            buffer.WriteByte(AskInfo.ShopID);
            buffer.WriteUInt64(Money);
        }
    }
}
