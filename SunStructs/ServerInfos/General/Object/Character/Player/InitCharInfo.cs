using System.Data.SqlClient;

namespace SunStructs.ServerInfos.General.Object.Character.Player
{
    public class InitCharInfo
    {
        public byte CharCode;
        public byte ClassCode;
        public string ClassName;
        public ushort Level;
        public uint UserPoint;
        public uint MaxHp;
        public uint MaxMp;
        public ulong Money;
        public ulong Exp;
        public uint RemainStat;
        public uint RemainSkill;
        public uint SelectedStyle;
        public uint Region;
        public float LocationX;
        public float LocationY;
        public float LocationZ;
        public ushort Strength;
        public ushort Vitality;
        public ushort Dexterity;
        public ushort Intelligence;
        public ushort Spirit;
        public ushort SkillStat1;
        public ushort SkillStat2;
        public byte[] InventoryItem;
        public byte[] TmpInventoryItem;
        public byte[] Equipment;
        public byte[] Skill;
        public byte[] Quick;
        public byte[] Style;
        public byte[] Quest;
        public byte[] Mission;

        public InitCharInfo(byte charCode, byte classCode, string className, ushort level, uint userPoint, uint maxHp, uint maxMp, ulong money, ulong exp, uint remainStat, uint remainSkill, uint selectedStyle, uint region, float locationX, float locationY, float locationZ, ushort strength, ushort vitality, ushort dexterity, ushort intelligence, ushort spirit, ushort skillStat1, ushort skillStat2, byte[] inventoryItem, byte[] tmpInventoryItem, byte[] equipment, byte[] skill,byte[] quick,byte[] style, byte[] quest, byte[] mission)
        {
            CharCode = charCode;
            ClassCode = classCode;
            ClassName = className;
            Level = level;
            UserPoint = userPoint;
            MaxHp = maxHp;
            MaxMp = maxMp;
            Money = money;
            Exp = exp;
            RemainStat = remainStat;
            RemainSkill = remainSkill;
            SelectedStyle = selectedStyle;
            Region = region;
            LocationX = locationX;
            LocationY = locationY;
            LocationZ = locationZ;
            Strength = strength;
            Vitality = vitality;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Spirit = spirit;
            SkillStat1 = skillStat1;
            SkillStat2 = skillStat2;
            InventoryItem = inventoryItem;
            TmpInventoryItem = tmpInventoryItem;
            Equipment = equipment;
            Skill = skill;
            Quick = quick;
            Style = style;
            Quest = quest;
            Mission = mission;
        }

        public InitCharInfo(ref SqlDataReader reader)
        {
            CharCode = reader.GetByte(0);
            ClassCode = reader.GetByte(1);
            ClassName = reader.GetString(2);
            Level = unchecked((ushort) reader.GetInt16(3));
            UserPoint = unchecked((uint) reader.GetInt32(4));
            MaxHp = unchecked((uint)reader.GetInt64(5));
            MaxMp =unchecked( (uint)reader.GetInt64(6));
            Money = unchecked((ulong)reader.GetInt64(7));
            Exp = unchecked((ulong) reader.GetInt64(8));
            RemainStat = unchecked((uint) reader.GetInt32(9));
            RemainSkill = unchecked((uint) reader.GetInt32(10));
            SelectedStyle = unchecked((uint) reader.GetInt32(11));
            Region = unchecked((uint) reader.GetInt32(12));
            LocationX = reader.GetFloat(13);
            LocationY = reader.GetFloat(14);
            LocationZ = reader.GetFloat(15);
            Strength = unchecked((ushort) reader.GetInt16(16));
            Vitality =unchecked( (ushort) reader.GetInt16(17));
            Dexterity =unchecked( (ushort) reader.GetInt16(18));
            Spirit =unchecked( (ushort) reader.GetInt16(20));
            SkillStat1 =unchecked( (ushort) reader.GetInt16(21));
            SkillStat2 = unchecked((ushort) reader.GetInt16(22));
            InventoryItem = (byte[])reader[23];
            TmpInventoryItem = (byte[])reader[24];
            Equipment = (byte[])reader[25];
            Skill = (byte[])reader[26];
            Quick = (byte[])reader[27];
            Style = (byte[])reader[28];
            Quest = (byte[])reader[29];
            Mission = (byte[])reader[30];

        }
    }
}
