using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Parsing;
using SunStructs.ServerInfos.General.Object.Items.EnchantSystem;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;

namespace SunStructs.ServerInfos.General.Object.Items
{
    public class ItemTypeInfo
    {
        public readonly int ItemType;
        public readonly ItemTypeKind Divine;
        public readonly EnchantGrade EnchantGrade;
        public readonly Rank Rank;

        public ItemTypeInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            ItemType = sb.ReadInt();
            Divine = (ItemTypeKind) sb.ReadByte();
            EnchantGrade = (EnchantGrade) sb.ReadByte();
            Rank = (Rank) sb.ReadByte();
        }
        
    }

    public enum ItemTypeKind
    {
        DEFAULT,
        DIVINE,
        ETHERIA,
        ETHERIA_DIVINE
    }
}
