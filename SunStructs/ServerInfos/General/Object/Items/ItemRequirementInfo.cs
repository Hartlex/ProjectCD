namespace SunStructs.ServerInfos.General.Object.Items
{
    /// <summary>
    /// Contains Info about the requirements an Item has to equip it
    /// </summary>
    public class ItemRequirementInfo
    {

        public ushort RequiredStrength;
        public ushort RequiredVitality;
        public ushort RequiredAgility;
        public ushort RequiredIntelligence;
        public ushort RequiredSpirit;
        public ushort RequiredSkillStat1;
        public ushort RequiredSkillStat2;

        public ItemRequirementInfo(ushort requiredStrength, ushort requiredVitality, ushort requiredAgility, ushort requiredIntelligence, ushort requiredSpirit, ushort requiredSkillStat1, ushort requiredSkillStat2)
        {
            RequiredStrength = requiredStrength;
            RequiredVitality = requiredVitality;
            RequiredAgility = requiredAgility;
            RequiredIntelligence = requiredIntelligence;
            RequiredSpirit = requiredSpirit;
            RequiredSkillStat1 = requiredSkillStat1;
            RequiredSkillStat2 = requiredSkillStat2;
        }
        /// <summary>
        /// Creates an object of Type ItemRequirementInfo.
        /// has 7 fields
        /// </summary>
        /// <param name="info"></param>
        /// <param name="start"></param>
        public ItemRequirementInfo(ref string[] info,int start)
        {
            RequiredStrength =(ushort)float.Parse(info[start]);
            RequiredAgility = (ushort)float.Parse(info[start+1]);
            RequiredVitality = (ushort)float.Parse(info[start+2]);
            RequiredIntelligence = (ushort)float.Parse(info[start+3]);
            RequiredSpirit = (ushort)float.Parse(info[start+4]);
            RequiredSkillStat1 = (ushort)float.Parse(info[start+5]);
            RequiredSkillStat2 = (ushort)float.Parse(info[start+6]);
        }
    }
}