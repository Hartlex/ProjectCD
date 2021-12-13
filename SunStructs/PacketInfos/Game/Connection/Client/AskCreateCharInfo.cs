using System.Text;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Connection.Client
{
    public class AskCreateCharInfo : ClientPacketInfo
    {
        public readonly byte[] Unk1;
        public readonly byte ClassCode;
        public readonly byte[] Unk2;
        public readonly string CharName;
        public readonly byte HeightCode;
        public readonly byte FaceCode;
        public readonly byte HairCode;

        public AskCreateCharInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Unk1 = buffer.ReadBlock(15);
            ClassCode = buffer.ReadByte();
            Unk2 = buffer.ReadBlock(4);
            CharName = buffer.ReadString(16);
            HeightCode = buffer.ReadByte();
            FaceCode = buffer.ReadByte();
            HairCode = buffer.ReadByte();
        }
        
    }
}
