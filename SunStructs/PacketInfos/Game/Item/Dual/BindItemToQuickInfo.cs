using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Dual
{
    public class BindItemToQuickInfo : DualPacketInfo
    {
        public readonly byte InvPos;
        public readonly byte QuickPos;

        public BindItemToQuickInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            InvPos = buffer.ReadByte();
            QuickPos = buffer.ReadByte();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(InvPos);
            buffer.WriteByte(QuickPos);
        }
    }
}
