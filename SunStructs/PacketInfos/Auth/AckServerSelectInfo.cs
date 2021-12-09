using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AckServerSelectInfo : PacketInfo
    {
        public readonly uint UserId;
        public readonly byte[] ClientSerial;
        public readonly string ServerIp;
        public readonly int Port;
        public readonly byte Result;
        public readonly byte[] LogKey;
        public AckServerSelectInfo(uint userId, string serverIp, int port)
        {
            UserId = userId;
            ClientSerial = new byte[]
            {
                1, 2, 3, 4,
                5, 6, 7, 8,
                0xe9, 0xca, 0xab, 0x8c,
                0x6d, 0x4e, 0x2f, 0x10,
                0xf1, 0xd2, 0xb3, 0x94,
                0x75, 0x56, 0x37, 0x18,
                0xf9, 0xda, 0xbb, 0x9c,
                0x7d, 0x5e, 0x3f, 0x20
            };

            ServerIp = serverIp;
            Port = port;
            Result = 0;
            LogKey = new byte[] {0x33, 0x36, 0x65, 0x36, 0x65, 0x6b, 0x6f, 0x37, 0x00};

        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(UserId);
            buffer.WriteBlock(ClientSerial);
            buffer.WriteBlock(ByteUtils.ToByteArray(ServerIp, 32));
            buffer.WriteInt32(Port);
            buffer.WriteByte(Result);
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
