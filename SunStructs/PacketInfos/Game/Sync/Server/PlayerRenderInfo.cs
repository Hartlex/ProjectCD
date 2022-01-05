using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Server;

public class PlayerRenderInfo: ServerPacketInfo
{
    public byte IsPlayerRenderInfo; //true PlayerRenderInfo false VillageRenderInfo
    public ushort PlayerKey;
    public ushort HP;
    public ushort MaxHP;
    public ushort Level;
    public string Name; //With Size
    public SunVector Position;
    public ushort SelectedStyleCode;
    public ushort MoveSpeedRatio;
    public ushort AttackSpeedRatio;
    public uint BitField;
    public uint RenderSpecialEffects;
    public PlayerRenderPetInfo RenderPetInfo = new PlayerRenderPetInfo();
    public byte Unk1Count; // 1byte
    public byte Unk2;
    public PlayerRenderRiderInfo RenderRiderInfo = new PlayerRenderRiderInfo();
    public PlayerRenderCollectInfo RenderCollectInfo = new PlayerRenderCollectInfo();
    public byte Unk3Count; //8 bytes
    public TotalStateInfo StateInfo = new TotalStateInfo(Array.Empty<StateInfo>());
    public byte Unk4Count; //1 byte

    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteByte(1);
        buffer.WriteUInt16(PlayerKey);
        buffer.WriteUInt16(HP);
        buffer.WriteUInt16(MaxHP);
        buffer.WriteUInt16(Level);
        buffer.WriteString(Name,16,true);
        Position.GetBytes(ref buffer);
        buffer.WriteUInt16(SelectedStyleCode);
        buffer.WriteUInt16(MoveSpeedRatio);
        buffer.WriteUInt16(AttackSpeedRatio);

        #region BitField
        //var byte1 = (byte)0;
        //var byte2 = (byte)0;
        //var byte3 = (byte)0;
        //var byte4 = (byte)0;

        //byte1 = BitManip.Set0(byte1, 0); //behave state
        //byte1 = BitManip.Set1(byte1, 0); //..
        //byte1 = BitManip.Set2(byte1, 0); //..
        //byte1 = BitManip.Set3(byte1, 0); //..
        //byte1 = BitManip.Set4(byte1, 0); //behave state
        //byte1 = BitManip.Set5(byte1, 0); //pkState
        //byte1 = BitManip.Set6(byte1, 0); //pkState
        //byte1 = BitManip.Set7(byte1, 0); //purple attackable

        //byte2 = BitManip.Set0(byte2, 0); //charType
        //byte2 = BitManip.Set1(byte2, 1); //charType
        //byte2 = BitManip.Set2(byte2, 0); //charType
        //byte2 = BitManip.Set3(byte2, 0); //charState stand=0 sit=1
        //byte2 = BitManip.Set4(byte2, 0); //pc room ???
        //byte2 = BitManip.Set5(byte2, 0); //gm grade
        //byte2 = BitManip.Set6(byte2, 0); //gm grade
        //byte2 = BitManip.Set7(byte2, 0); //gm grade

        //byte3 = BitManip.Set0(byte3, 0); //hide helm
        //byte3 = BitManip.Set1(byte3, 1); //face
        //byte3 = BitManip.Set2(byte3, 0); //face
        //byte3 = BitManip.Set3(byte3, 0); //face
        //byte3 = BitManip.Set4(byte3, 0); //face
        //byte3 = BitManip.Set5(byte3, 0); //height
        //byte3 = BitManip.Set6(byte3, 1); //height
        //byte3 = BitManip.Set7(byte3, 0); //height

        //byte4 = BitManip.Set0(byte4, 0); //???
        //byte4 = BitManip.Set1(byte4, 0); //???
        //byte4 = BitManip.Set2(byte4, 0); //hair
        //byte4 = BitManip.Set3(byte4, 1); //
        //byte4 = BitManip.Set4(byte4, 0); //
        //byte4 = BitManip.Set5(byte4, 0); //
        //byte4 = BitManip.Set6(byte4, 0); //
        //byte4 = BitManip.Set7(byte4, 0); //hair



        //buffer.WriteBlock(new[] { byte1, byte2, byte3, byte4 });
        #endregion

        buffer.WriteUInt32(BitField);
        buffer.WriteUInt32(RenderSpecialEffects);
        RenderPetInfo.GetBytes(ref buffer);
        buffer.WriteByte(Unk1Count);
        buffer.WriteByte(Unk2);
        RenderRiderInfo.GetBytes(ref buffer);
        RenderCollectInfo.GetBytes(ref buffer);
        buffer.WriteByte(Unk3Count);
        StateInfo.GetBytes(ref buffer);
        buffer.WriteByte(Unk4Count);
    }

    public void SetCharType(CharType type)
    {
        BitField = BitManip.Set8to10(BitField, (uint) type);
    }

    public void SetFace(byte face)
    {
        BitField = BitManip.Set17to20(BitField, face);
    }

    public void SetHeight(byte height)
    {
        BitField = BitManip.Set21to23(BitField, height);
    }

    public void SetHair(byte hair)
    {
        BitField = BitManip.Set26to31(BitField, hair);
    }

    public void HideHelm(byte hide)
    {
        BitField = BitManip.Set16(BitField, hide);
    }
}

public class PlayerRenderPetInfo : ServerPacketInfo
{
    public bool HasPet;
    public ushort PetCode;
    public byte Health;
    public byte Loyalty;
    public string PetName;

    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteBool(HasPet);
        if (!HasPet) return;

        buffer.WriteUInt16(PetCode);
        buffer.WriteByte(Health);
        buffer.WriteByte(Loyalty);
        buffer.WriteString(PetName,Const.MAX_PET_NAME_LENGTH,true);
    }
}

public class PlayerRenderRiderInfo : ServerPacketInfo
{
    public bool IsRider;
    public byte[] RiderInfo; //probably itemStream 27 bytes

    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteBool(IsRider);
        if (!IsRider) return;

        buffer.WriteBlock(RiderInfo);
    }
}

public class PlayerRenderCollectInfo : ServerPacketInfo
{
    public bool HasCollectInfo;
    public byte[] CollectInfo; //12 bytes
    public override void GetBytes(ref ByteBuffer buffer)
    {
        buffer.WriteBool(HasCollectInfo);
        if (!HasCollectInfo) return;
        buffer.WriteBlock(CollectInfo);
    }
}