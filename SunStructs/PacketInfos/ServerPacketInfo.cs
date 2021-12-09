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
}
