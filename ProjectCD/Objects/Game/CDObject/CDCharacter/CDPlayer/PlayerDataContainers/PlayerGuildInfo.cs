using System.Data.SqlClient;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    /// <summary>
    /// Contains info about the current Guild the Player is in
    /// </summary>
    public class PlayerGuildInfo
    {
        public int GuildId;
        public string GuildName;
        public byte GuildPosition;
        public uint UpPoints;


        /// <summary>
        /// Creates an object of type PlayerGuildInfo
        /// </summary>
        public PlayerGuildInfo(ref SqlDataReader reader)
        {
            GuildId = reader.GetInt32(56);
            GuildName = reader.GetString(59);
            GuildPosition = reader.GetByte(57);
            UpPoints =(uint) reader.GetInt32(58);
        }
    }
}