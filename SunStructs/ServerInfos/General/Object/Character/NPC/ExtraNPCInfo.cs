using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Object.Character.NPC;

public class ExtraNPCInfo
{
    public uint MapCode;
    public uint FieldId;
    public NPCType NPCType;
    public uint NPCCode;
    public SunVector NPCPos;
    public SunVector NPCDir;
    public int MoveType;
    public SunVector MovePos;
    public float Range;

    public ExtraNPCInfo(string[] info)
    {
        var sb = new StringBuffer(info);
        MapCode = sb.ReadUint();
        FieldId = sb.ReadUint();
        NPCType = (NPCType) sb.ReadByte();
        NPCCode = sb.ReadUint();
        sb.Skip(2);
        NPCPos = new SunVector(sb.ReadFloat(), sb.ReadFloat(), sb.ReadFloat());

    }
}