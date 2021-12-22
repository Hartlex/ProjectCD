using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Object.Character.NPC
{
    internal class NPCShopInfo
    {
        public readonly uint ShopCode;
        public readonly string Name;
        public readonly int LottoRatio;
        public readonly int ShopTab;
        public readonly NPCShopItemInfo[] ItemInfos;

        public NPCShopInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            ShopCode = sb.ReadUint();
            Name = sb.ReadString();
            LottoRatio = sb.ReadInt();
            ShopTab = sb.ReadInt();
            ItemInfos = new NPCShopItemInfo[25];
            for (int i = 0; i < 25; i++)
            {
                ItemInfos[i] = new NPCShopItemInfo(ref sb);
            }
        }

    }

    public class NPCShopItemInfo
    {
        public readonly ushort ItemCode;
        public readonly byte ItemNum;
        public readonly int ItemType;

        public NPCShopItemInfo(ref StringBuffer sb)
        {
            ItemCode = sb.ReadUshort();
            ItemNum = sb.ReadByte();
            ItemType = sb.ReadInt();
        }
    }
}
