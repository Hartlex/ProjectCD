namespace SunStructs.ServerInfos.General.Object.Items
{
    /// <summary>
    /// Contains Physical and Magical MinAttack,MaxAttack and Def
    /// </summary>
    public class ItemAttackDefInfo
    {
        public ushort PhysicalMinDamage;
        public ushort PhysicalMaxDamage;
        public ushort MagicalMinDamage;
        public ushort MagicalMaxDamage;
        public ushort PhysicalDef;
        public ushort MagicalDef;

        /// <summary>
        /// Creates object of type ItemAttackDefInfo
        /// </summary>
        /// <param name="physicalMinDamage">The minimum physical damage the item has.</param>
        /// <param name="physicalMaxDamage">The maximum physical damage the item has.</param>
        /// <param name="magicalMinDamage">The minimum magical damage the item has.</param>
        /// <param name="magicalMaxDamage">The maximum magical damage the item has.</param>
        /// <param name="physicalDef">The physical Defense the item has.</param>
        /// <param name="magicalDef">The magical Defense the item has.</param>
        public ItemAttackDefInfo(ushort physicalMinDamage, ushort physicalMaxDamage, ushort magicalMinDamage, ushort magicalMaxDamage, ushort physicalDef, ushort magicalDef)
        {
            PhysicalMinDamage = physicalMinDamage;
            PhysicalMaxDamage = physicalMaxDamage;
            MagicalMinDamage = magicalMinDamage;
            MagicalMaxDamage = magicalMaxDamage;
            PhysicalDef = physicalDef;
            MagicalDef = magicalDef;
        }

        public ItemAttackDefInfo(ref string[] info, int start)
        {
            PhysicalMinDamage =(ushort) double.Parse(info[start]);
            PhysicalMaxDamage = (ushort)double.Parse(info[start+1]);
            MagicalMinDamage = (ushort)double.Parse(info[start+2]);
            MagicalMaxDamage = (ushort)double.Parse(info[start+3]);
            PhysicalDef = (ushort)double.Parse(info[start+4]);
            MagicalDef = (ushort)double.Parse(info[start+5]);
        }
    }

}