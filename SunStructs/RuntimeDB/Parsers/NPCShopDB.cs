using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.PacketInfos.Game.Item.Client;
using SunStructs.ServerInfos.General.Object.Character.NPC;

namespace SunStructs.RuntimeDB.Parsers
{
    public class NPCShopDB : Singleton<NPCShopDB>
    {
        private Dictionary<uint, Dictionary<int, Dictionary<byte, NPCShopItemInfo>>> _shopInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new NPCShopParser();
            _shopInfos = parser.ParseAllInfos(dataFolderPath);
            int count=0;
            foreach (var shopInfo in _shopInfos.Values) 
            {
                foreach (var shopTab in shopInfo.Values)
                {
                    count += shopTab.Count;
                }
            }
            Logger.Instance.LogOnLine($"{count} NPCShopItems loaded!\n", LogType.SUCCESS);

        }

        public bool TryGetItemCode(AskBuyItemInfo info, out NPCShopItemInfo? itemInfo)
        {
            itemInfo = null;
            return _shopInfos.TryGetValue(info.ShopId, out var shop) &&
                   (shop.TryGetValue(info.ShopPage, out var infos) && 
                   infos.TryGetValue(info.ItemIndex, out itemInfo));
        }
    }
}
