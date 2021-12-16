using System.Data.SqlClient;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    /// <summary>
    /// Contains Info about Player Versus Player Stats
    /// </summary>
    public class PlayerPVPInfo
    {
        public int PVPPoint;
        public int PVPScore;
        public byte PVPGrade;
        public int PVPRanking;
        public int PVPMaxSeries;
        public int PVPMaxKill;
        public int PVPMaxDeath;
        public int PVPTotalKill;
        public int PVPTotalDeaths;
        public int PVPTotalDraw;
        
        /// <summary>
        /// Creates an object of type PlayerPVPInfo
        /// </summary>
        /// <param name="pvpPoint">Value of PVP points</param>
        /// <param name="pvpScore">Value of PVP score</param>
        /// <param name="pvpGrade">Grade of PVP</param>
        /// <param name="pvpRanking">Position in PVP ranking</param>
        /// <param name="pvpMaxSeries">Highest kill series without dying</param>
        /// <param name="pvpMaxKill">Highest kill count without dying</param>
        /// <param name="pvpMaxDeath">Most deaths in PVP</param>
        /// <param name="pvpTotalKill">Total number of kills in PVP</param>
        /// <param name="pvpTotalDeaths">Total number of deaths in PVP</param>
        /// <param name="pvpTotalDraw">Total number of draws in PVP</param>
        public PlayerPVPInfo(int pvpPoint, int pvpScore, byte pvpGrade, int pvpRanking, int pvpMaxSeries, int pvpMaxKill, int pvpMaxDeath, int pvpTotalKill, int pvpTotalDeaths, int pvpTotalDraw)
        {
            PVPPoint = pvpPoint;
            PVPScore = pvpScore;
            PVPGrade = pvpGrade;
            PVPRanking = pvpRanking;
            PVPMaxSeries = pvpMaxSeries;
            PVPMaxKill = pvpMaxKill;
            PVPMaxDeath = pvpMaxDeath;
            PVPTotalKill = pvpTotalKill;
            PVPTotalDeaths = pvpTotalDeaths;
            PVPTotalDraw = pvpTotalDraw;
        }

        public PlayerPVPInfo(ref SqlDataReader reader)
        {
            PVPPoint = reader.GetInt32(47);
            PVPScore = reader.GetInt32(48);
            PVPGrade = reader.GetByte(49);
            PVPRanking = reader.GetInt32(50);
            PVPMaxSeries = reader.GetInt32(51);
            PVPMaxKill = reader.GetInt32(52);
            PVPMaxDeath = reader.GetInt32(53);
            PVPTotalKill = reader.GetInt32(54);
            PVPTotalDeaths = reader.GetInt32(55);
            PVPTotalDraw = reader.GetInt32(56);
        }
    }
}