using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class AllPlayerRenderInfo :ServerPacketInfo
    {
        public readonly byte Count;
        public readonly PlayerRenderInfo[] RenderInfos;

        public AllPlayerRenderInfo(PlayerRenderInfo[] infos) 
        {
            Count = (byte) infos.Length;
            RenderInfos = infos;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Count);
            foreach (var playerRenderInfo in RenderInfos)
            {
                playerRenderInfo.GetBytes(ref buffer);
            }
        }
    }
}
