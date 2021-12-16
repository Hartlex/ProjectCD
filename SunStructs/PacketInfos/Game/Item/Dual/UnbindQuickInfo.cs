using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Dual
{
    public class UnbindQuickInfo :DualPacketInfo
    {
        public readonly byte Pos;
        public UnbindQuickInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Pos = buffer.ReadByte();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Pos);
        }
    }
}
