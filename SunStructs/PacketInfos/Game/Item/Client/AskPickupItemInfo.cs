using CDShared.ByteLevel;
using CDShared.Logging;

namespace SunStructs.PacketInfos.Game.Item.Client;

public class AskPickupItemInfo
{
    public readonly uint ObjectKey;

    public AskPickupItemInfo(ref ByteBuffer buffer)
    {
        ObjectKey = BitManip.Get12to43(buffer.ReadUInt64());
    }
}