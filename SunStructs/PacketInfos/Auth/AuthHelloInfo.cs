using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AuthHelloInfo : PacketInfo
    {
        public readonly byte[] unk1;
        public readonly int Key;
        public AuthHelloInfo(int key)
        {
            unk1 = new byte[64];
            Key = key;
        }

        public AuthHelloInfo(ref ByteBuffer buffer, string message)
        {
            unk1 = buffer.ReadBlock(64);
            Key = buffer.ReadInt32();
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteBlock(unk1);
            buffer.WriteInt32(Key);
        }
    }
}
