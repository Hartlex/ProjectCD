using System.Text;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Connection
{
    public class AskEnterCharSelectInfo : ClientPacketInfo
    {
        public readonly byte[] Unk1; //2
        public readonly uint UserId;
        public readonly byte Unk2;
        public readonly string Username;
        public readonly byte[] Unk3; //25
        public readonly byte[] ClientSerial;
        public readonly byte[] MolaCheck;

        public AskEnterCharSelectInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Unk1 = buffer.ReadBlock(2);
            UserId = buffer.ReadUInt32();
            Unk2 = buffer.ReadByte();
            Username = Encoding.ASCII.GetString(ByteUtils.CutTail(buffer.ReadBlock(50)));
            Unk3 = buffer.ReadBlock(25);
            ClientSerial = buffer.ReadBlock(32);
            MolaCheck = buffer.ReadBlock(4);
        }
    }
}
