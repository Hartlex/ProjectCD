using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.Items;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Item.Dual;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private byte _inventoryTabs;
        private Inventory _inventory;
        private Equipment _equipment;

        public void PlayerInventoryInit(ref SqlDataReader reader)
        {
            var inventoryBytes = (byte[])reader[38];
            var equipBytes = (byte[]) reader[40];
            _inventoryTabs = 10;
            _inventory = new (_inventoryTabs, inventoryBytes, this);
            _equipment = new (equipBytes, this);
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

    }
}
