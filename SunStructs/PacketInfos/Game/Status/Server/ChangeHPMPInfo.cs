using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class ChangeMPInfo : ServerPacketInfo
    {
        public readonly uint ObjectKey;
        public readonly uint TargetMP;

        public ChangeMPInfo(uint objectKey, uint targetMP)
        {
            ObjectKey = objectKey;
            TargetMP = targetMP;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteUInt32(TargetMP);
        }
    }

    public class ChangeHPInfo : ServerPacketInfo
    {
        public readonly uint ObjectKey;
        public readonly uint TargetHP;
        public readonly uint ReservedHP;

        public ChangeHPInfo(uint objectKey, uint targetHP, uint reservedHP)
        {
            ObjectKey = objectKey;
            TargetHP = targetHP;
            ReservedHP = reservedHP;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteUInt32(TargetHP);
            buffer.WriteUInt32(ReservedHP);
        }
    }
}
