using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Object.Character.Player;

namespace SunStructs.PacketInfos.Game.Connection.Server
{
    public class AckEnterCharSelectInfo : ServerPacketInfo
    {
        public readonly uint UserId;
        public readonly ClientCharacterPart[] CharInfos;
        public AckEnterCharSelectInfo(uint userId, ClientCharacterPart[] charInfos)
        {
            UserId = userId;
            CharInfos = charInfos;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(UserId); //not true
            buffer.WriteByte(0); //not true
            buffer.WriteByte((byte)CharInfos.Length);
            foreach (var charInfo in CharInfos)
            {
                charInfo.GetBytes(ref buffer);
            }
        }
    }
}
