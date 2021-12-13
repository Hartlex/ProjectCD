using System.Data.SqlClient;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using static SunStructs.Definitions.Const;

namespace SunStructs.PacketInfos.Game.Object.Character.Player
{
    public class FullCharacterInfo : ServerPacketInfo
    {
        public readonly ulong Exp;
        public readonly uint RemainSkillPoint;
        public readonly uint RemainStatPoint;
        public readonly ulong Money;
        public readonly ushort SelectedStyle;
        public readonly ushort MaxHp;
        public readonly ushort Hp;
        public readonly ushort MaxMp;
        public readonly ushort Mp;
        public readonly ushort MoveSpeed;
        public readonly ushort AttackSpeed;
        public readonly ulong StateTime;
        public readonly string TitleId;
        public readonly ulong TitleTime;
        public readonly int InventoryLock;
        public readonly ushort Strength;
        public readonly ushort Vitality;
        public readonly ushort Agility;
        public readonly ushort Intelligence;
        public readonly ushort Spirit;
        public readonly ushort SkillStat1;
        public readonly ushort SkillStat2;
        public readonly uint UpPoints;
        public readonly GMStateInfo GMStateInfo;
        public readonly uint PlayLimitedTime;
        public readonly InvisFlagInfo InvisOption;
        public readonly uint GuildID;
        public readonly GuildDuty GuildDuty;
        public readonly string GuildName;
        public readonly ChaosState ChaosState;
        public readonly ExtraSlotInfo ExtraSlotInfo;
        public readonly int WhisperFlag;
        public readonly int TradeFlag;
        public readonly byte FreeInitCount;
        public readonly SummonedPetInfo SummonedPetInfo;
        public readonly byte PetItemPosition;
        public readonly uint MaxOptionRemainTime;
        public readonly byte ActiveEtherDevice;
        public readonly byte EtherBulletsPos;
        public readonly ushort MaxSDShield;
        public readonly ushort SDShield;


        public FullCharacterInfo(ulong exp, uint remainSkillPoint, uint remainStatPoint, ulong money, ushort selectedStyle, ushort maxHp,
            ushort hp, ushort maxMp, ushort mp, ushort moveSpeed, ushort attackSpeed, ulong stateTime, string titleId, ulong titleTime,
            byte inventoryLock,ushort strength, ushort vitality, ushort agility, ushort intelligence, ushort spirit, ushort skillStat1, 
            ushort skillStat2,uint upPoints, GMStateInfo gmStateInfo, uint playLimitedTime, InvisFlagInfo invisOption,
            uint guildID, GuildDuty guildDuty, string guildName, ChaosState chaosState, ExtraSlotInfo extraSlotInfo, 
            int whisperFlag, int tradeFlag, byte freeInitCount, SummonedPetInfo summonedPetInfo, byte petItemPosition, uint maxOptionRemainTime, byte activeEtherDevice, byte etherBulletsPos, ushort maxSdShield, ushort sdShield)
        {
            Exp = exp;
            RemainSkillPoint = remainSkillPoint;
            RemainStatPoint = remainStatPoint;
            Money = money;
            SelectedStyle = selectedStyle;
            MaxHp = maxHp;
            Hp = hp;
            MaxMp = maxMp;
            Mp = mp;
            MoveSpeed = moveSpeed;
            AttackSpeed = attackSpeed;
            StateTime = stateTime;
            TitleId = titleId;
            TitleTime = titleTime;
            InventoryLock = inventoryLock;
            Strength = strength;
            Vitality = vitality;
            Agility = agility;
            Intelligence = intelligence;
            Spirit = spirit;
            SkillStat1 = skillStat1;
            SkillStat2 = skillStat2;
            UpPoints = upPoints;
            GMStateInfo = gmStateInfo;
            PlayLimitedTime = playLimitedTime;
            InvisOption = invisOption;
            GuildID = guildID;
            GuildDuty = guildDuty;
            GuildName = guildName;
            ChaosState = chaosState;
            ExtraSlotInfo = extraSlotInfo;
            WhisperFlag = whisperFlag;
            TradeFlag = tradeFlag;
            FreeInitCount = freeInitCount;
            SummonedPetInfo = summonedPetInfo;
            PetItemPosition = petItemPosition;
            MaxOptionRemainTime = maxOptionRemainTime;
            ActiveEtherDevice = activeEtherDevice;
            EtherBulletsPos = etherBulletsPos;
            MaxSDShield = maxSdShield;
            SDShield = sdShield;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt64(Exp);
            buffer.WriteUInt32(RemainStatPoint);
            buffer.WriteUInt32(RemainSkillPoint);
            buffer.WriteUInt64(Money);
            buffer.WriteUInt16(SelectedStyle);
            buffer.WriteUInt16(Hp);
            buffer.WriteUInt16(Hp);
            buffer.WriteUInt16(Mp);
            buffer.WriteUInt16(Mp);
            buffer.WriteUInt16(MoveSpeed);
            buffer.WriteUInt16(AttackSpeed);
            buffer.WriteUInt64(StateTime);
            buffer.WriteString(TitleId, MAX_TITLE_ID_LENGTH);
            buffer.WriteUInt64(TitleTime);
            buffer.WriteInt32(InventoryLock);
            buffer.WriteUInt16(Strength);
            buffer.WriteUInt16(Agility);
            buffer.WriteUInt16(Vitality);
            buffer.WriteUInt16(Intelligence);
            buffer.WriteUInt16(Spirit);
            buffer.WriteUInt16(SkillStat1);
            buffer.WriteUInt16(SkillStat2);
            buffer.WriteUInt32(UpPoints);
            GMStateInfo.GetBytes(ref buffer);
            buffer.WriteUInt32(PlayLimitedTime);
            InvisOption.GetBytes(ref buffer);
            buffer.WriteUInt32(GuildID);
            buffer.WriteByte((byte)GuildDuty);
            buffer.WriteString(GuildName, MAX_GUILD_NAME_LENGTH);
            buffer.WriteByte((byte)ChaosState);
            ExtraSlotInfo.GetBytes(ref buffer);
            buffer.WriteInt32(WhisperFlag);
            buffer.WriteInt32(TradeFlag);
            buffer.WriteByte(FreeInitCount);
            SummonedPetInfo.GetBytes(ref buffer);
            buffer.WriteByte(PetItemPosition);
            buffer.WriteUInt32(MaxOptionRemainTime);
            buffer.WriteByte(ActiveEtherDevice);
            buffer.WriteByte(EtherBulletsPos);
            buffer.WriteUInt16(MaxSDShield);
            buffer.WriteUInt16(SDShield);
        }
        
    }

    public class FullCharInfoZone : ServerPacketInfo
    {
        public readonly FullCharacterInfo CharInfo;
        public readonly byte[] InventoryBytes;
        

        public FullCharInfoZone(FullCharacterInfo charInfo, byte[] inventorBytes)
        {
            CharInfo = charInfo;

            InventoryBytes = inventorBytes;
        }

        public FullCharInfoZone(ref SqlDataReader reader)
        {

        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            var unk8 = new byte[]
            {

                0,0,0,0, //guild id
                0,0,0,0,0,0,0,0, //guild name
                0,0,0,0,0,0,0,0, 
                0x00,  //guild Pos
                0x01, //pkState
                0x05, //invExpand
                0x00, 0x00, 0x00, 0x00, //whisper flag
                0x00, 0x00, 0x00, 0x00,  //trade flag
                0x00, //free init count 
                0x00, //summonedPet 
                0x00, //petItemPos
                00, 00, 00,00, //MAX option remain time
                00,//ether discharger mounted
                00, //ether bullets pos
                00,00, //max sd
                100,00 //sd
            };

            buffer.WriteBlock(CharInfo.GetBytes());
            //buffer.WriteBlock(unk8);
            buffer.WriteBlock(InventoryBytes);
        }
    }

    public class GMStateInfo
    {
        public byte GMGrade;
        public byte PCBangUser;
        public byte Condition;
        public byte PKState;
        public byte PCRoomSts;
        public byte CharState;
        private readonly ushort _data;

        public GMStateInfo(byte gmGrade,byte pcBang,byte condition,byte pk,byte pcRoom,byte charState)
        {
            _data = BitManip.Set0to2(_data, gmGrade);
            _data = BitManip.Set3(_data, pcBang);
            _data = BitManip.Set4(_data, condition);
            _data = BitManip.Set5to7(_data, pk);
            _data = BitManip.Set8(_data, pcRoom);
            _data = BitManip.Set9to15(_data,charState);
        }

        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(_data);
        }
    }

    public class InvisFlagInfo
    {
        public byte Helmet;
        public byte Cape;
        public byte Wing;
        public byte Temp;

        private readonly byte _data;

        public InvisFlagInfo(byte helmet, byte cape, byte wing)
        {
            _data = BitManip.Set0(_data, helmet);
            _data = BitManip.Set1(_data, cape);
            _data = BitManip.Set2(_data, wing);
            _data = BitManip.Set3to7(_data, 0);

        }
        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(_data);
        }
    }

    public class ExtraSlotInfo
    {
        public byte Inventory;
        public byte Cash;

        private readonly byte _data;

        public ExtraSlotInfo(byte inventory, byte cash)
        {
            _data = BitManip.Set0to5(_data, inventory);
            _data = BitManip.Set6to7(_data, cash);


        }
        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(_data);
        }
    }

    public class SummonedPetInfo
    {
        public byte IsSummoned;
        public byte MaxIntimacy;

        private readonly byte _data;

        public SummonedPetInfo(byte isSummoned, byte maxIntimacy)
        {
            _data = BitManip.Set0to3(_data, isSummoned);
            _data = BitManip.Set4to7(_data, maxIntimacy);


        }
        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(_data);
        }
    }
}
