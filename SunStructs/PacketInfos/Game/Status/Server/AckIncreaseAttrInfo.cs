using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class AckIncreaseAttrInfo : ServerPacketInfo
    {
        public readonly uint UserId;
        public readonly byte AttType;
        public readonly int NewValue;
        public AckIncreaseAttrInfo(uint userId, byte attType, int newValue)
        {
            UserId = userId;
            AttType = attType;
            NewValue = newValue;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(UserId);
            buffer.WriteByte(AttType);
            buffer.WriteInt32(NewValue);
        }
    }
}
