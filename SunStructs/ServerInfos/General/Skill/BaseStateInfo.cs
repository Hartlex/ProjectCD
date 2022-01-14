using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Skill
{
    public class BaseStateInfo
    {
        public ushort StateID;							
        public string StateName;
        public uint NameCode;				
        public uint DescCode;			
        public uint	IconCode;
        public byte DelType;
        public byte Type;
        public byte SDApply;
        public byte RidingApply;
        public string EffectID;                
        public byte EffectPos;

        public BaseStateInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            StateID = sb.ReadUshort();
            sb.Skip();
            StateName = sb.ReadString();
            NameCode = sb.ReadUint();
            DescCode = sb.ReadUint();
            IconCode = sb.ReadUint();
            sb.Skip(3);
            DelType = sb.ReadByte();
            Type = sb.ReadByte();
            SDApply = sb.ReadByte();
            RidingApply = sb.ReadByte();
            EffectID = sb.ReadString();
            EffectPos = sb.ReadByte();

        }
    }

    public class StateInfo
    {
        public ushort SkillCode;
        public ushort AbilityCode;
        public byte Reflect;
    }
}
