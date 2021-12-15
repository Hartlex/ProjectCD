using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.Items;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    internal class Equipment : ItemSlotContainer
    {
        public Equipment(byte[] bytes, Player owner) : base(24, bytes, owner)
        {
        }
        public override bool InsertItem(Item item, int pos = byte.MaxValue, bool force = true)
        {
            if (GetItem(pos) != null)
                UnEquipItem(GetSlot(pos));
            base.InsertItem(item, pos, force);
            EquipItem(GetSlot(pos));
            return true;
        }

        private void EquipItem(ItemSlot slot)
        {
            Logger.Instance.Log("Equiping Item");
            ItemAttributeCalculator itemCalc = new ItemAttributeCalculator(Owner.GetAttributes(), this,true);
            itemCalc.Equip(slot,true,false);

        }

        private void UnEquipItem(ItemSlot slot)
        {
            Logger.Instance.Log("Unequiping Item");
            ItemAttributeCalculator itemCalc = new ItemAttributeCalculator(Owner.GetAttributes(), this, true);
            itemCalc.UnEquip(slot, true, false);
        }


    }
}