using CDShared.ByteLevel;

namespace SunStructs.PacketInfos
{
    public abstract class ServerPacketInfo
    {
        public byte[] GetBytes()
        {
            ByteBuffer buffer = new();
            GetBytes(ref buffer);
            return buffer.GetData();
        }
        public abstract void GetBytes(ref ByteBuffer buffer);
    }
    public class EmptyPacket : ServerPacketInfo
    {
        public override void GetBytes(ref ByteBuffer buffer)
        {
        }
    }

    public class TestPacketInfo : ServerPacketInfo
    {
        private readonly byte[] _bytes;

        public TestPacketInfo(byte[] bytes)
        {
            _bytes = bytes;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteBlock(_bytes);
        }
    }
}
