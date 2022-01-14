using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.World.Sync.Client
{
    public class ChangeSectorInfo : ClientPacketInfo
    {
        public readonly uint SectorID;
        public readonly uint MapID;


        public ChangeSectorInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            SectorID = buffer.ReadUInt32();
            MapID = buffer.ReadUInt32();
        }
    }
}
