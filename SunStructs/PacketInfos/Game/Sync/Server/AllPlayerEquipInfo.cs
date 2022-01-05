using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class AllPlayerEquipInfo : ServerPacketInfo
    {
        public byte Count;
        public EquipRenderInfo[] RenderInfos;

        public AllPlayerEquipInfo(EquipRenderInfo[] infos)
        {
            Count = (byte) infos.Length;
            RenderInfos = infos;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Count);
            foreach (var equipRenderInfo in RenderInfos)
            {
                equipRenderInfo.GetBytes(ref buffer);
            }
        }
    }

    public class EquipRenderInfo :ServerPacketInfo
    {
        public uint PlayerKey;
        public byte[] EquipmentInfo;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(PlayerKey);
            buffer.WriteBlock(EquipmentInfo);
        }
    }
}
