using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Dual
{
    public class MoveQuickInfo : DualPacketInfo
    {
        public readonly byte Pos1;
        public readonly byte Pos2;

        public MoveQuickInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Pos1 = buffer.ReadByte();
            Pos2 = buffer.ReadByte();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Pos1);
            buffer.WriteByte(Pos2);
        }
    }
}