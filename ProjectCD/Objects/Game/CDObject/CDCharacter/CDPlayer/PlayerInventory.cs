using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Objects.Game.Slots.Items;
using ProjectCD.Objects.Game.Slots.Quick;
using SunStructs.Definitions;
using SunStructs.Formulas.Item;
using SunStructs.PacketInfos.Game.Item.Client;
using SunStructs.PacketInfos.Game.Item.Dual;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.RuntimeDB;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items;
using static SunStructs.Definitions.Const;
using static SunStructs.Definitions.ItemResult;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private byte _inventoryTabs;
        private Inventory _inventory;
        private Equipment _equipment;
        private TempInventory _tmpInventory;
        private QuickSlotContainer _quickSlots;
        private ulong _money;

        public void PlayerInventoryInit(ref SqlDataReader reader)
        {
            _money = unchecked((ulong)reader.GetInt64(22));
            var inventoryBytes = (byte[])reader[38];
            var equipBytes = (byte[]) reader[40];
            var tmpInvBytes = (byte[])reader[39];
            var quickBytes = (byte[])reader[42];
            _inventoryTabs = 10;
            _inventory = new (_inventoryTabs, inventoryBytes, this);
            _equipment = new (equipBytes, this);
            _tmpInventory = new(MAX_TMP_INVENTORY_SLOT_NUM, tmpInvBytes,this);
            _quickSlots = new(MAX_QUICK_SLOT_NUM, quickBytes);
        }

        public bool ItemMove(ItemMoveInfo info)
        {
            var container1 = GetItemSlotContainer(info.SlotIdFrom);
            var container2 = GetItemSlotContainer(info.SlotIdTo);
            if (container1 == null || container2 == null)
                return false;
            container1.MoveItem(container2, info.PositionFrom, info.PositionTo, info.AmountToMove);
            return true;
        }

        private ItemSlotContainer GetItemSlotContainer(SlotContainerIndex index)
        {
            switch (index)
            {
                case SlotContainerIndex.SI_INVENTORY:
                    return _inventory;
                case SlotContainerIndex.SI_EQUIPMENT:
                    return _equipment;
            }

            return null;
        }

        public Inventory GetInventory()
        {
            return _inventory;
        }

        public ulong IncreaseMoney(ulong money)
        {
            _money += money;
            return _money;
        }
        public ulong GetMoney(){ return _money;}

        public bool TryDecreaseMoney(ulong money)
        {
            if (_money < money) return false;
            _money -= money;
            return true;
        }

        public QuickSlotContainer GetQuickSlotContainer()
        {
            return _quickSlots;
        }

        public bool TryBuyItem(AskBuyItemInfo info,out AckBuyItemInfo? outInfo)
        {
            outInfo = null;

            if (!NPCShopDB.Instance.TryGetItemCode(info, out var itemInfo)) return false;
            Item item;
            if (!ItemConverter.Instance.TryGetItemFromItemType(itemInfo!.ItemCode, itemInfo.ItemType, out item))
            {
                if (!BaseItemDB.Instance.TryGetBaseItemInfo(itemInfo.ItemCode, out var baseInfo)) return false;
                item = new Item(baseInfo!);
            }
            byte durability = 0;
            if (item.IsStackable())
                durability = (byte)(info.Count == 0 ? 1 : info.Count);
            else if (item.GetBaseInfo().Durability > 0)
                durability = item.GetBaseInfo().Durability;
            item.SetAmount(durability);
            //Item Done

            //var price = CommonItemFormulas.GetItemPriceForBuy(item.GetBaseInfo().Level, item.GetRank(), item.GetEnchant(), item.GetDivine());
            var price = item.GetBaseInfo().ItemSellMoney * (ulong) item.GetAmount();

            Logger.Instance.Log("CalculatedItemPrice :"+price);

            if (!TryDecreaseMoney(price)) return false;

            if (_inventory.InsertItem(item, out var slotInfo))
            {
                outInfo = new (GetMoney(), slotInfo);
                return true;
            }

            return false;
        }

        public ItemResult TrySellItem(AskSellItemInfo info, out AckSellItemInfo? ackInfo)
        {
            ackInfo = null;
            //Logger.Instance.Log(info.ShopID);
            //for (int i = 0; i < info.Unk.Length; i++)
            //{
            //    Logger.Instance.Log(info.Unk[i]);
            //}

            var item = _inventory.GetItem(info.AtPos);
            if (item == null) return RC_ITEM_FAILED;

            var price = item.GetBaseInfo().ItemSellMoney * info.Amount;

            IncreaseMoney(price);
            var amount = info.Amount == 0 ? item.GetAmount() : info.Amount;
            if (!_inventory.TrySpentItemAmount(item.GetBaseInfo().BaseItemId, amount)) return RC_ITEM_FAILED;
            ackInfo = new AckSellItemInfo(GetKey(),info, GetMoney());
            return RC_ITEM_SUCCESS;

        }

        public ItemResult TryDeleteItem(AskDeleteItemInfo info)
        {
            if (_inventory.GetSlot(info.Pos).IsEmpty()) return RC_ITEM_FAILED;

            _inventory.DeleteItem(info.Pos);

            return RC_ITEM_SUCCESS;
        }

        public ItemResult TryDropItem(AskDropItemInfo info,out Item? droppedItem)
        {
            droppedItem = null;
            var container = GetItemSlotContainer(info.Index);
            var slot = container.GetSlot(info.Pos);
            if (slot.IsEmpty()) return RC_ITEM_INVALIDPOS;

            var item = slot.GetItem();
            if (item == null) return RC_ITEM_INVALIDPOS;

            if (!item.CanTradeSellDrop(ItemTradesellType.ITEM_TRADESELL_DROP)) return RC_ITEM_CANNOT_DROP_ITEM;

            _inventory.DeleteItem(info.Pos);
            droppedItem = item;
            return RC_ITEM_SUCCESS;

        }
    }
}
