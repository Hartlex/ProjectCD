using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Connection.Server
{
    public class AckEnterGameInfo : ServerPacketInfo
    {
        public readonly byte[] CharId;
        public readonly byte[] Mask;

        public AckEnterGameInfo(uint userId)
        {
            CharId = BitConverter.GetBytes(userId<<4);
            //Mask = BitConverter.GetBytes(0 >> 28);
            Mask = new byte[] {00, 00, 00, 00};
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteBlock(CharId);
            buffer.WriteBlock(Mask);
        }
    }
}
