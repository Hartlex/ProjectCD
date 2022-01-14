using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Skill
{
    public class SkillInfo
    {
        public ushort SkillCode;
        public uint ClientSerial;
        public SunVector CurPos;
        public SunVector DestPos;
        public AttackSequence AttackType;
        public uint MainTargetKey;
        public SunVector MainTargetPos;
        public byte SkillEffect;
    }
}
