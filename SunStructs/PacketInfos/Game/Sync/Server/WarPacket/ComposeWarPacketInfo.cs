using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Packets.GameServerPackets.Sync;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    
    public class ComposeWarPacketInfo :ServerPacketInfo
    {
        private readonly WarPacketInfo[] _packetInfos;
        public ComposeWarPacketInfo(WarPacketInfo[] packetInfos)
        {
            _packetInfos = packetInfos;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            foreach (var warPacketInfo in _packetInfos)
            {
                warPacketInfo.GetBytes(ref buffer);
            }
            buffer.InsertSize();
        }
    }

    public abstract class WarPacketInfo : ServerPacketInfo
    {
        protected WarProtocol Protocol;

        protected WarPacketInfo(WarProtocol protocol)
        {
            Protocol = protocol;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte) Protocol);
        }

    }
}
