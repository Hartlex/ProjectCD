using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.Items;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    internal class ItemAttributeCalculator
    {
        private readonly PlayerAttr _attr;
        private readonly ItemSlotContainer _equip;
        public ItemAttributeCalculator(PlayerAttr attr, ItemSlotContainer equipment, bool autoUpdate)
        {
            _attr  = attr;
            _equip = equipment;
        }
    }
}
