using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server;

public class ActionExpiredInfo :ServerPacketInfo
{
    public uint ObjectId;

    public ActionExpiredInfo(uint objectId)
    {
        ObjectId = objectId;
    }


    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteUInt32(ObjectId);
    }
}