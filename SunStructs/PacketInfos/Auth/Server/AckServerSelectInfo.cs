using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class AckServerSelectInfo : ServerPacketInfo
    {
        public readonly uint UserId;
        public readonly byte[] ClientSerial;
        public readonly string ServerIp;
        public readonly int Port;
        public readonly AuthResultType Result;
        public readonly byte[] LogKey;
        public AckServerSelectInfo(AuthResultType result, uint userId, string serverIp, int port,byte[] clientSerial, byte[] logKey)
        {
            UserId = userId;
            ClientSerial = clientSerial;
            ServerIp = serverIp;
            Port = port;
            Result = result;
            LogKey = logKey;
            //LogKey = new byte[] {0x33, 0x36, 0x65, 0x36, 0x65, 0x6b, 0x6f, 0x37, 0x00};

        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(UserId);
            buffer.WriteBlock(ClientSerial);
            buffer.WriteString(ServerIp,32);
            buffer.WriteInt32(Port);
            buffer.WriteByte((byte)Result);
            buffer.WriteBlock(LogKey);


            //var bytes = new List<byte>();
            //bytes.AddRange(BitConverter.GetBytes(UserId));
            //bytes.AddRange(new byte[]
            //{
            //    0xe1, 0xc2, 0xa3, 0x84, 
            //    0x65, 0x46, 0x27, 0x08, 
            //    0xe9, 0xca, 0xab, 0x8c, 
            //    0x6d, 0x4e, 0x2f, 0x10, 
            //    0xf1, 0xd2, 0xb3, 0x94, 
            //    0x75, 0x56, 0x37, 0x18, 
            //    0xf9, 0xda, 0xbb, 0x9c, 
            //    0x7d, 0x5e, 0x3f, 0x20
            //});
            //bytes.AddRange(ByteUtils.ToByteArray(ServerIp, 32));
            //bytes.AddRange(BitConverter.GetBytes(Port)); //port
            //bytes.Add(Result);
            //bytes.AddRange(new byte[]{0x33,0x36,0x65,0x36,0x65,0x6b,0x6f,0x37,0x00}); //logkey 8+1

            //buffer.WriteBlock(bytes.ToArray());

        }
    }
}
