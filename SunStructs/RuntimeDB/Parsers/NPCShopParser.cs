using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using SunStructs.ServerInfos.General.Object.Character.NPC;
using SunStructs.ServerInfos.General.Quest;

namespace SunStructs.RuntimeDB.Parsers
{
    public class NPCShopParser
    {
        private readonly Dictionary<uint, Dictionary<int, Dictionary<byte, NPCShopItemInfo>>> _shopInfos=new();

        public Dictionary<uint, Dictionary<int, Dictionary<byte, NPCShopItemInfo>>> ParseAllInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\ShopInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _shopInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 5; i < allLines.Length; i++)
            {
                var line = allLines[i];
                if (line.StartsWith("//")) continue;
                if (line.StartsWith("\t//")) continue;
                noCommentLines.Add(line);

            }

            return noCommentLines;
        }
        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            var shopInfo = new NPCShopInfo(info);
            if(!_shopInfos.ContainsKey(shopInfo.ShopCode)) _shopInfos.Add(shopInfo.ShopCode,new());
            if(!_shopInfos[shopInfo.ShopCode].ContainsKey(shopInfo.ShopTab)) _shopInfos[shopInfo.ShopCode].Add(shopInfo.ShopTab,new ());
            for (int i = 0; i < shopInfo.ItemInfos.Length; i++)
            {
                if(shopInfo.ItemInfos[i].ItemCode!=0)
                    _shopInfos[shopInfo.ShopCode][shopInfo.ShopTab].Add((byte)i,shopInfo.ItemInfos[i]);
#if DEBUG
                Logger.Instance.LogOnLine($"Loaded ShopItem[{shopInfo.ItemInfos[i].ItemCode}]");
#endif
            }

        }
    }
}
