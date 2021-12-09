using System.Text;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth.Client
{
    public class AskLoginInfo : ClientPacketInfo
    {
        public readonly uint UserId;
        public readonly string UserName;
        public readonly string Password;
        public AskLoginInfo(ref ByteBuffer buffer, int key) : base(ref buffer)
        {
            UserId = buffer.ReadUInt32();
            UserName = Encoding.ASCII.GetString(ByteUtils.CutTail(buffer.ReadBlock(50)));
            var b = buffer.ReadByte();
            var encPassword = buffer.ReadBlock(24);
            var keyBytes = ByteUtils.ToSbytes(BitConverter.GetBytes(key));
            var decPwBytes = TEA.passwordDecodeSBytes(ByteUtils.ToSbytes(encPassword),keyBytes) ;
            Password = Encoding.ASCII.GetString(ByteUtils.ToByteArray(decPwBytes));
        }
    }
}
