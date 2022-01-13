using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Server;

public class MonsterRenderInfos : ServerPacketInfo
{
    public readonly byte Count;
    public readonly MonsterRenderInfo[] RenderInfos;

    public MonsterRenderInfos(byte count, MonsterRenderInfo[] renderInfos)
    {
        Count = count;
        RenderInfos = renderInfos;
    }

    public MonsterRenderInfos(MonsterRenderInfo info)
    {
        Count = 1;
        RenderInfos = new[] {info};
    }

    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteByte(Count);
        foreach (var monsterRenderInfo in RenderInfos)
        {
            monsterRenderInfo.GetBytes(ref buffer);
        }
    }

}

public class MonsterRenderInfo : ServerPacketInfo
{
    public readonly uint ObjCode;
    public readonly ushort MonsterId;
    public readonly SunVector Pos;
    public readonly uint HP;
    public readonly uint MaxHP;
    public readonly ushort MsRatio;
    public readonly ushort AsRatio;
    public readonly ushort Unk;
    public readonly TotalStateInfo StateInfo;
    public MonsterRenderInfo(uint objCode, ushort monsterId, SunVector pos, uint hp, uint maxHp,
        ushort msRatio, ushort asRatio, ushort unk)
    {
        ObjCode = objCode;
        MonsterId = monsterId;
        Pos = pos;
        HP = hp;
        MaxHP = maxHp;
        MsRatio = msRatio;
        AsRatio = asRatio;
        Unk = unk;
        StateInfo = new ();
    }

    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteUInt32(ObjCode);
        buffer.WriteUInt16(MonsterId);
        Pos.GetBytes(ref buffer);
        buffer.WriteUInt32(HP);
        buffer.WriteUInt32(MaxHP);
        buffer.WriteUInt16(MsRatio);
        buffer.WriteUInt16(AsRatio);
        buffer.WriteUInt16(Unk);
        StateInfo.GetBytes(ref buffer);
        //buffer.WriteByte(1); //number of unk
        //buffer.WriteUInt32(0); //unk1
        //buffer.WriteUInt32(0); //unk2
        //buffer.WriteByte(1); //number of states
        //buffer.WriteUInt16(6); //state id
        //buffer.WriteUInt32(5000); //time
    }
}