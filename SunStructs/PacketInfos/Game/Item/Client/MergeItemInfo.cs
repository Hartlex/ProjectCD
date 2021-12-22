using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Item.Client;

public class MergeItemInfo : DualPacketInfo
{
    public readonly SlotContainerIndex FromIndex;
    public readonly SlotContainerIndex ToIndex;
    public readonly int FromPos;
    public readonly int ToPos;
    public int Amount;

    public MergeItemInfo(ref ByteBuffer buffer) : base(ref buffer)
    {
        FromIndex = (SlotContainerIndex) buffer.ReadByte();
        ToIndex = (SlotContainerIndex) buffer.ReadByte();
        FromPos = buffer.ReadByte();
        ToPos = buffer.ReadByte();
        Amount = buffer.ReadByte();
    }

    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteByte((byte) FromIndex);
        buffer.WriteByte((byte)ToIndex);
        buffer.WriteByte(FromPos);
        buffer.WriteByte(ToPos);
        buffer.WriteByte(Amount);
    }
}