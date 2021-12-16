using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Objects.Game.Slots.Items;
using ProjectCD.Objects.Game.Slots.Quick;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Item.Dual;
using static SunStructs.Definitions.Const;

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

        public QuickSlotContainer GetQuickSlotContainer()
        {
            return _quickSlots;
        }
    }
}
