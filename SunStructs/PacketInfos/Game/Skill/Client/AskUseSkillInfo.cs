using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Skill.Client
{
    public class AskUseSkillInfo
    {
        public readonly uint ClientSerial;
        public readonly uint TargetKey;
        public readonly byte AttackPropensity;
        public readonly ushort SkillCode;
        public SunVector CurrentPos;
        public SunVector DestPos;
        public SunVector TargetPos;

        public AskUseSkillInfo(ref ByteBuffer buffer)
        {
            ClientSerial = buffer.ReadUInt32();
            TargetKey = buffer.ReadUInt32();
            AttackPropensity = buffer.ReadByte();
            SkillCode = buffer.ReadUInt16();
            CurrentPos = new SunVector(ref buffer);
            DestPos = new SunVector(ref buffer);
            TargetPos = new SunVector(ref buffer);
        }
    }
}

//49|0|
//    200|46|
//    5|0|0|0| ClientSerial
//5|0|0|0| Tagetid
//0|	byte
//37|4|	SkillCode
