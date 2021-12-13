using System.Text;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Connection.Client
{
    public class AskDeleteCharInfo : ClientPacketInfo
    {
        public readonly byte Slot;
        public readonly string DelCheck;

        public AskDeleteCharInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Slot = buffer.ReadByte();

            DelCheck = buffer.ReadString(10);
        }

    }
}
