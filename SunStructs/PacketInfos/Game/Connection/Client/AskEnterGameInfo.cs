using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Connection.Client
{
    public class AskEnterGameInfo
    {
        public readonly byte Unk1;
        public readonly byte[] CharSlotBytes;
        public readonly byte CharSlot;
        public AskEnterGameInfo(ref ByteBuffer buffer)
        {
            Unk1 = buffer.ReadByte();
            CharSlotBytes = buffer.ReadBlock(2);
            CharSlot = (byte) (BitConverter.ToInt16(CharSlotBytes, 0)/128);
        }
    }
}
