using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class AttrChangeInfo : ServerPacketInfo
    {
        public readonly uint ObjKey;
        public readonly AttrType AttrType;
        public readonly int Value;

        public AttrChangeInfo(uint objKey, AttrType attrType, int value)
        {
            ObjKey = objKey;
            AttrType = attrType;
            Value = value;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ObjKey);
            buffer.WriteByte((byte)AttrType);
            buffer.WriteInt32(Value);
        }
    }
}
