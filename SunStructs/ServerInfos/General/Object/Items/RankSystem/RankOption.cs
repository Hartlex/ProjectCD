using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Parsing;
using SunStructs.Definitions;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Definitions.ItemType;
using static SunStructs.ServerInfos.General.Object.Items.RankSystem.RankOptionItemType;

namespace SunStructs.ServerInfos.General.Object.Items.RankSystem
{
    public class RankOption
    {

        public ItemType Type;
        public readonly byte AttrOptionIndex;
        public readonly string OptionName;
        public readonly uint OptionNameCode;
        public readonly AttrValueKind ValueKind;
        public readonly int[] RankValues;
        public RankOption(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            Type =(ItemType) sb.ReadInt();
            AttrOptionIndex = sb.ReadByte();
            OptionName = sb.ReadString();
            OptionNameCode = sb.ReadUint();
            ValueKind = (AttrValueKind) sb.ReadByte();
            RankValues = new int[9];
            for (int i = 0; i < 9; i++)
            {
                RankValues[i] = sb.ReadInt();
            }
        }

        public static RankOptionItemType GetRankOptionItemType(ItemType itemInfoType)
        {
            RankOptionItemType rankItemType = RANK_OPTION_ITEM_TYPE_MAX;
            switch (itemInfoType)
            {
                case ITEMTYPE_TWOHANDAXE:
                case ITEMTYPE_TWOHANDSWORD:
                case ITEMTYPE_ONEHANDSWORD:
                case ITEMTYPE_SPEAR:
                case ITEMTYPE_WHIP:
                case ITEMTYPE_ETHERCLAW:
                case ITEMTYPE_ONEHANDCROSSBOW:
                case ITEMTYPE_ETHERWEAPON:
                case ITEMTYPE_STAFF:
                case ITEMTYPE_ORB: { rankItemType = RANK_OPTION_ITEM_WEAPON; } break;

                case ITEMTYPE_ARMOR:
                case ITEMTYPE_PROTECTOR:
                case ITEMTYPE_HELMET:
                case ITEMTYPE_PANTS:
                case ITEMTYPE_BOOTS:
                case ITEMTYPE_GLOVE:
                case ITEMTYPE_BELT:
                case ITEMTYPE_SHIRTS: { rankItemType = RANK_OPTION_ITEM_ARMOR; } break;
                case ITEMTYPE_RING: { rankItemType = RANK_OPTION_ITEM_RING; } break;
                case ITEMTYPE_NECKLACE: { rankItemType = RANK_OPTION_ITEM_NECKLACE; } break;

                case ITEMTYPE_BERSERKER_SACCESSORY: { rankItemType = RANK_OPTION_ITEM_SACCESSORY_BERSERKER; } break;
                case ITEMTYPE_DRAGON_SACCESSORY: { rankItemType = RANK_OPTION_ITEM_SACCESSORY_DRAGON; } break;
                case ITEMTYPE_VALKYRIE_SACCESSORY: { rankItemType = RANK_OPTION_ITEM_SACCESSORY_SHADOW; } break;
                case ITEMTYPE_SHADOW_SACCESSORY: { rankItemType = RANK_OPTION_ITEM_SACCESSORY_VALKYRIE; } break;
                case ITEMTYPE_ELEMENTALIST_SACCESSORY: { rankItemType = RANK_OPTION_ITEM_SACCESSORY_ELEMENTALIST; } break;
                default: return 0;
            }
            return rankItemType;
        }

    }

}
