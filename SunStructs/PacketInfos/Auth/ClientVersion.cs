using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class ClientVersion :PacketInfo
    {
        public readonly byte HighVersion;
        public readonly byte MiddleVersion;
        public readonly byte LowVersion;

        public ClientVersion(byte highVersion, byte middleVersion, byte lowVersion)
        {
            this.HighVersion = highVersion;
            this.MiddleVersion = middleVersion;
            this.LowVersion = lowVersion;
        }
        public ClientVersion(ref ByteBuffer buffer)
        {
            HighVersion = buffer.ReadByte();
            MiddleVersion = buffer.ReadByte();
            LowVersion = buffer.ReadByte();
        }

        public ClientVersion(string clientVersionString)
        {
            var split = clientVersionString.Split('.');
            HighVersion = byte.Parse(split[0]);
            MiddleVersion = byte.Parse(split[1]);
            LowVersion = byte.Parse(split[2]);
        }



        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(HighVersion);
            buffer.WriteByte(MiddleVersion);
            buffer.WriteByte(LowVersion);
        }

        public bool Equals(ClientVersion other)
        {
            return HighVersion == other.HighVersion && MiddleVersion == other.MiddleVersion && LowVersion == other.LowVersion;
        }
        public override bool Equals(object obj)
        {
            return obj is ClientVersion other && Equals(other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = HighVersion.GetHashCode();
                hashCode = (hashCode * 397) ^ MiddleVersion.GetHashCode();
                hashCode = (hashCode * 397) ^ LowVersion.GetHashCode();
                return hashCode;
            }
        }
    }
}
