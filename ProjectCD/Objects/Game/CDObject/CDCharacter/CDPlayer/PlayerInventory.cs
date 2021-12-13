using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private byte _inventoryTabs;
        private Inventory _inventory;
        public void PlayerInventoryInit(ref SqlDataReader reader)
        {
            var inventoryBytes = (byte[])reader[38];
            _inventoryTabs = 10;
            _inventory = new(_inventoryTabs, inventoryBytes, this);
        }
    }
}
