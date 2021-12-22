using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Zone.Server
{
    public class AckZoneMoveInfo : ServerPacketInfo
    {
        public readonly ushort PortalId;

        public AckZoneMoveInfo(ushort portalId)
        {
            PortalId = portalId;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(PortalId);
            buffer.WriteBlock(new byte[6]);
        }
    }
}
