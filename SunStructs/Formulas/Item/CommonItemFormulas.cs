using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Formulas.Char;
using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;

namespace SunStructs.Formulas.Item
{
    public static class CommonItemFormulas
    {
        static readonly int[] _levelWeightMap = new int[]
            { 2, 2, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

        public static int CalcAttackPower(byte enchant, ushort level)
        {
            return GetWeaponEnchantWeightForEnchant(enchant) +
                   enchant * GetWeaponEnchantWeightForLv(level);
        }

        public static int GetWeaponEnchantWeightForEnchant(byte enchant)
        {
            switch (enchant)
            {
                case 0: return 0;
                case 1: return 0;
                case 2: return 0;
                case 3: return 1;
                case 4: return 2;
                case 5: return 3;
                case 6: return 5;
                case 7: return 7;
                case 8: return 10;
                case 9: return 13;
                case 10: return 18;
                case 11: return 24;
                case 12: return 31;
                case 13: return 43;
                case 14: return 60;
                case 15: return 82;
            };
            return 0;
        }

        public static int GetWeaponEnchantWeightForLv(ushort level)
        {
            return _levelWeightMap[level-1];
        }

        public static int GetArmorEnchantWeightForEnchant(byte enchant)
        {
            switch (enchant)
            {
                case 0: return 0;
                case 1: return 0;
                case 2: return 0;
                case 3: return 1;
                case 4: return 2;
                case 5: return 3;
                case 6: return 5;
                case 7: return 7;
                case 8: return 10;
                case 9: return 13;
                case 10: return 18;
                case 11: return 24;
                case 12: return 31;
                case 13: return 43;
                case 14: return 60;
                case 15: return 82;
            };
            return 0;
        }

        public static int GetArmorEnchantWeightForLV(ushort level)
        {
            return 1;
        }

        public static int CalcPhyDef(int phyDef, byte enchant, ushort level)
        {
            return phyDef + GetArmorEnchantWeightForEnchant(enchant) + enchant * GetArmorEnchantWeightForLV(level);
        }

        public static uint GetItemPriceForBuy(ushort level, Rank rank, int enchant, byte divine)
        {
            var rankPrice = NumericValues.GetPriceWeightForRank(rank);
            var enchantPrice = NumericValues.GetPriceWeightForEnchant(enchant);
            float price = rankPrice * enchantPrice * level;
            if (divine != 0)
                price *= 4;
            return (uint) price;
        }
    }
}
