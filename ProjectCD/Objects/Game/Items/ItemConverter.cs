using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;

namespace ProjectCD.Objects.Game.Items
{
    public class ItemConverter : Singleton<ItemConverter>
    {
        public bool TryGetItemFromItemType(ushort itemCode, int itemTypeCode,out Item? item)
        {
            item = null;
            if (ItemTypeDB.Instance.TryGetItemType(itemTypeCode, out var itemTypeInfo))
            {
                if (BaseItemDB.Instance.TryGetBaseItemInfo(itemCode, out var baseItemInfo))
                {
                    item = new (baseItemInfo!);

                    item.SetEnchant(itemTypeInfo!.EnchantGrade);
                    for (Rank rank = Rank.RANK_D; rank <= itemTypeInfo.Rank; rank++)
                    {
                        var options = RankOptionDB.Instance.GetRandomRankOption(baseItemInfo!.ItemType, rank);
                        item.SetRankOption(rank,options);

                    }
                    if (itemTypeInfo.Divine is ItemTypeKind.DIVINE or ItemTypeKind.ETHERIA_DIVINE)
                        item.SetDivine(1);
                    return true;
                }
            }

            return false;
        }
    }
}
