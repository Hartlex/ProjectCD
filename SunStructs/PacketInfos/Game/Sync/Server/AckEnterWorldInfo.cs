using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class AckEnterWorldInfo : ServerPacketInfo
    {
        public readonly float PosX, PosY, PosZ;
        public readonly ushort TransformCode;
        public AckEnterWorldInfo(SunVector position)
        {
            PosX = position.GetX();
            PosY = position.GetY();
            PosZ = position.GetZ();
            TransformCode = 0;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteFloat(PosX);
            buffer.WriteFloat(PosY);
            buffer.WriteFloat(PosZ);
            buffer.WriteUInt16(TransformCode);
        }
    }
}
