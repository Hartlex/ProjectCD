using CDShared.Logging;
using ProjectCD.Objects.Game.Items;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers
{
    internal class Equipment : ItemSlotContainer
    {
        public Equipment(byte[] bytes, Player owner) : base(24, bytes, owner)
        {
        }


        private void EquipItem(ItemSlot slot)
        {
            Logger.Instance.Log("Equiping Item");

        }

        private void UnEquipItem(ItemSlot slot)
        {
            Logger.Instance.Log("Unequiping Item");
        }


    }
}