using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class ItemLeaveFieldInfo :ServerPacketInfo
    {
        public readonly byte Count;
        public readonly uint[] ObjectKeys;

        public ItemLeaveFieldInfo(byte count, uint[] objectKeys)
        {
            Count = count;
            ObjectKeys = objectKeys;
        }

        public ItemLeaveFieldInfo(uint key)
        {
            Count = 1;
            ObjectKeys = new[] { key };
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Count);
            foreach (var objectKey in ObjectKeys)
            {
                buffer.WriteUInt32(objectKey);
            }
        }
    }
}
