using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class DragonTransStartInfo : ServerPacketInfo
    {
        public uint PlayerKey;
        public ushort SkillCode;
        public ushort StatusCode;
        public int StatusTime;
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(PlayerKey);
            buffer.WriteUInt16(SkillCode);
            buffer.WriteUInt16(StatusCode);
            buffer.WriteInt32(StatusTime);
        }
    }
}
