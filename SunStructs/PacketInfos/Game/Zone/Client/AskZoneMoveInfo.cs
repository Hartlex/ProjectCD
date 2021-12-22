using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Zone.Client
{
    public class AskZoneMoveInfo : ClientPacketInfo
    {
        public readonly ushort PortalID;
        public AskZoneMoveInfo(ref ByteBuffer buffer): base(ref buffer)
        {
            var src = buffer.ReadUInt64();
            PortalID = BitManip.Get14to29(src);
        }
    }
}
