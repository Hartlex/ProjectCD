using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Skill.Server
{
    public class FullSkillInfo : ServerPacketInfo
    {
        private readonly byte[] _data;

        public FullSkillInfo(byte[] data)
        {
            _data = data;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteBlock(_data);
        }
    }
}
