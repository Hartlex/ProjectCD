using ProjectCD.Objects.Game.Items;
using ProjectCD.Objects.Game.Slots.Items;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots
{
    public class Inventory : ItemSlotContainer
    {
        public Inventory(int tabCount, byte[] data, Player owner) : base(tabCount*15, data, owner)
        {
        }
        public bool InsertItems(List<Item> items, out ItemSlotInfo[] outInfos)
        {
            outInfos = null;
            if (!HasFreeSlots(items.Count)) return false;
            var result = new List<ItemSlotInfo>();
            foreach (var item in items)
            {
                InsertItem(item, out var infos);
                result.AddRange(infos);
            }

            outInfos = result.ToArray();
            return true;

        }
        public bool InsertItem(ushort itemId, int count, out ItemSlotInfo[] slotInfos)
        {
            var items = new List<Item>();
            var itemInfo = BaseItemDB.Instance.GetBaseItemInfo(itemId);
            while (count > 0)
            {
                var item = new Item(itemInfo);
                if (count <= 255)
                {
                    item.SetAmount((byte)count);
                    items.Add(item);
                    count -= count;
                }
                else
                {
                    item.SetAmount(255);
                    items.Add(item);
                    count -= 255;
                }
            }

            return InsertItems(items, out slotInfos);

        }
        public bool HasItemAmount(ushort itemId, int count)
        {
            for (byte i = 0; i < GetMaxSlotNum(); i++)
            {
                var slot = GetSlot(i);
                if (slot.IsEmpty()) continue;
                if (slot.GetItem().GetItemId() != itemId) continue;
                count -= slot.GetItem().GetAmount();
                if (count <= 0) return true;
            }

            return false;

        }
        public bool InsertItem(Item item, out ItemSlotInfo[] slots)
        {
            var result = new List<ItemSlotInfo>();
            for (byte i = 0; i < GetMaxSlotNum(); i++)
            {
                var slot = GetSlot(i);
                if (slot.IsEmpty()) continue;
                if (slot.GetCode() != item.GetItemId()) continue;
                if (!slot.GetItem().IsStackable()) continue;
                if (slot.GetItem().GetAmount() + item.GetAmount() <= 255)
                {
                    var incAmount = item.GetAmount();
                    slot.GetItem().IncreaseAmount(incAmount);
                    item.DecreaseAmount(incAmount);
                    result.Add(slot.GetItemSlotInfo());
                    break;
                }
                else
                {
                    var dif = 255 - slot.GetItem().GetAmount();
                    slot.GetItem().SetAmount(255);
                    result.Add(slot.GetItemSlotInfo());
                    item.DecreaseAmount((byte)dif);
                }
            }

            if (item.GetAmount() > 0)
            {
                var pos = GetFirstFreeSlot();
                InsertItem(item, pos);
                result.Add(GetSlot(pos).GetItemSlotInfo());
            }

            slots = result.ToArray();
            return true;

        }
        public bool TrySpentItemAmount(ushort itemId, int amount)
        {
            if (!HasItemAmount(itemId, amount)) return false;
            for (byte i = 0; i < GetMaxSlotNum(); i++)
            {
                var slot = GetSlot(i);
                if (slot.IsEmpty()) continue;
                if (slot.GetItem().GetItemId() != itemId) continue;
                if (slot.GetItem().GetAmount() >= amount)
                {
                    slot.GetItem().DecreaseAmount((byte)amount);
                }
                else
                {
                    amount -= slot.GetItem().GetAmount();
                    slot.RemoveItem();
                }
            }

            return true;
        }
    }
}
