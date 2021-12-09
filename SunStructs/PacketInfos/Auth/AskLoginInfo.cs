using System.Text;
using CDShared.ByteLevel;
using CherryDragon.Prog.Helpers;

namespace SunStructs.PacketInfos.Auth
{
    public class AskLoginInfo : PacketInfo
    {
        public readonly uint UserId;
        public readonly string UserName;
        public readonly string Password;
        public AskLoginInfo(ref ByteBuffer buffer, int key)
        {
            UserId = buffer.ReadUInt32();
            UserName = Encoding.ASCII.GetString(ByteUtils.CutTail(buffer.ReadBlock(50)));
            var b = buffer.ReadByte();
            var encPassword = buffer.ReadBlock(24);
            var keyBytes = ByteUtils.ToSbytes(BitConverter.GetBytes(key));
            var decPwBytes = TEA.passwordDecodeSBytes(ByteUtils.ToSbytes(encPassword),keyBytes) ;
            Password = Encoding.ASCII.GetString(ByteUtils.ToByteArray(decPwBytes));
        }

        public AskLoginInfo(string userName, string pw, int key)
        {
            UserName = userName;
            Password = pw;
            
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
        }
    }
}
