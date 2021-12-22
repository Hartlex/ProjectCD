using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Item.Client
{
    public class AskSellItemInfo : ClientPacketInfo
    {
        public readonly SlotContainerIndex SlotIndex;
        public readonly byte ShopID;
        public readonly byte Amount;
        public readonly byte AtPos;
        public readonly byte[] Unk;

        public AskSellItemInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            SlotIndex = (SlotContainerIndex) buffer.ReadByte();
            ShopID = buffer.ReadByte();
            Amount = buffer.ReadByte();
            AtPos = buffer.ReadByte();
            Unk = buffer.ReadBlock(4);
        }
    }
}
