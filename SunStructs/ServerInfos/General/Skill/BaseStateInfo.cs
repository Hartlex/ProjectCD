using CDShared.Parsing;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Skill
{
    public class BaseStateInfo
    {
        public CharStateType StateID;							
        public string StateName;
        public uint NameCode;				
        public uint DescCode;			
        public uint	IconCode;
        public int GKind;
        public byte DelType;
        public StateType Type;
        public SDApply SDApply;
        public byte RidingApply;
        public string EffectID;                
        public byte EffectPos;

        public BaseStateInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            StateID = (CharStateType)sb.ReadInt();
            sb.Skip();
            StateName = sb.ReadString();
            NameCode = sb.ReadUint();
            DescCode = sb.ReadUint();
            IconCode = sb.ReadUint();
            sb.Skip(2);
            GKind = sb.ReadInt();
            DelType = sb.ReadByte();
            Type = (StateType) sb.ReadInt();
            SDApply = (SDApply)sb.ReadInt();
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
