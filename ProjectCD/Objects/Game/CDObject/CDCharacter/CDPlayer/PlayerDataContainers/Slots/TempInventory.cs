using ProjectCD.Objects.Game.Slots.Items;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots
{
    public class TempInventory : ItemSlotContainer
    {
        public TempInventory(int count, byte[] data, Player owner) : base(count, data, owner)
        {
        }
    }
}
