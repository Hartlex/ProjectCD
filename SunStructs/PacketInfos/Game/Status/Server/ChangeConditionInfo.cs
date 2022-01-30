using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class ChangeConditionInfo : ServerPacketInfo
    {
        public readonly uint ObjectKey;
        public readonly byte ConditionType;

        public ChangeConditionInfo(byte conditionType, uint objectKey)
        {
            ConditionType = conditionType;
            ObjectKey = objectKey;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteByte(ConditionType);
        }
    }
}
