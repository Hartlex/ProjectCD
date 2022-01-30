using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Map.Server
{
    public class ObjectTeleportInfo : ServerPacketInfo
    {
        public readonly bool Forced;
        public readonly uint ObjectId;
        public readonly SunVector Position;

        public ObjectTeleportInfo(bool forced, uint objectId, SunVector position)
        {
            Forced = forced;
            ObjectId = objectId;
            Position = position;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteBool(Forced);
            buffer.WriteUInt32(ObjectId);
            Position.GetBytes(ref buffer);
        }
    }
}
