using System.Data.SqlClient;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    public class PlayerGeneral
    {
        public readonly string Name;
        public readonly byte CharSlot;
        public readonly byte ClassCode;
        public readonly uint CharacterId;
        public ulong Experience;
        public ushort Level;
        public uint RemainSkillPoint;
        public uint RemainStatPoint;
        public ulong Money;

        public PlayerGeneral(ref SqlDataReader reader)
        {
            CharSlot = reader.GetByte(2);
            ClassCode = reader.GetByte(3);
            CharacterId = unchecked((uint)reader.GetInt32(0));
            Money = unchecked((ulong)reader.GetInt64(22));
            RemainStatPoint = unchecked((uint)reader.GetInt32(23));
            RemainSkillPoint = unchecked((uint)reader.GetInt32(24));
            Name = reader.GetString(4);
            Level = unchecked((ushort)reader.GetInt16(8));
            Experience = unchecked((ulong)reader.GetInt64(17));
        }
    }
}
