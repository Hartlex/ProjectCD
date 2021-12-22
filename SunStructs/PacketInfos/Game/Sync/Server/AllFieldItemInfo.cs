using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class AllFieldItemInfo :ServerPacketInfo
    {
        public readonly byte Count;
        public readonly ItemRenderInfo[] RenderInfos;

        public AllFieldItemInfo(ItemRenderInfo[] infos)
        {
            Count = (byte) infos.Length;
            RenderInfos = infos;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Count);
            foreach (var itemRenderInfo in RenderInfos)
            {
                itemRenderInfo.GetBytes(ref buffer);
            }
        }
    }
}
