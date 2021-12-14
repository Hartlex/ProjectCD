using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Item.Server
{
    public class ItemSlotInfo : ServerPacketInfo
    {
        public readonly byte Pos;
        public readonly byte[] Bytes;

        public ItemSlotInfo(byte pos, byte[] bytes)
        {
            Pos = pos;
            Bytes = bytes;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Pos);
            buffer.WriteBlock(Bytes);
        }
    }
}
