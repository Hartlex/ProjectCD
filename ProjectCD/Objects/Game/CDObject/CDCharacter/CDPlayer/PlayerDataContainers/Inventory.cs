using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.Items;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    internal class Inventory : ItemSlotContainer
    {
        public Inventory(int tabCount, byte[] data, Player owner) : base(tabCount*15, data, owner)
        {
        }
    }
}
