using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Objects.Game.Slots.Items;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots.EquipGroup;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots
{
    internal class Equipment : ItemSlotContainer
    {
        private static EquipGroup[] _equipGroups = new[]
        {
            EQUIPGROUP_WEAPON, // eEQUIPCONTAINER_WEAPON      = 0,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_ARMOR       = 1,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_PROTECTOR   = 2,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_HELMET      = 3,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_PANTS       = 4,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_BOOTS       = 5,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_GLOVE       = 6,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_BELT        = 7,
            EQUIPGROUP_ARMOR, // eEQUIPCONTAINER_SHIRTS      = 8,
            EQUIPGROUP_RING, // eEQUIPCONTAINER_RING1       = 9,
            EQUIPGROUP_RING, // eEQUIPCONTAINER_RING2       = 10,
            EQUIPGROUP_INVALID, // eEQUIPCONTAINER_NECKLACE    = 11,
            EQUIPGROUP_INVALID, // eEQUIPCONTAINER_BOW         = 12,
            EQUIPGROUP_SPECIAL_ACCESSORY, // eEQUIPCONTAINER_SACCESSORY1 = 13,
            EQUIPGROUP_SPECIAL_ACCESSORY, // eEQUIPCONTAINER_SACCESSORY2 = 14,
            EQUIPGROUP_SPECIAL_ACCESSORY, // eEQUIPCONTAINER_SACCESSORY3 = 15,
            EQUIPGROUP_CASH_ITEM, // eEQUIPCONTAINER_CHARGE1     = 16,
            EQUIPGROUP_CASH_ITEM, // eEQUIPCONTAINER_CHARGE2     = 17,
            EQUIPGROUP_CASH_ITEM, // eEQUIPCONTAINER_CHARGE3     = 18,
            EQUIPGROUP_CASH_ITEM, // eEQUIPCONTAINER_CHARGE4     = 19,
            EQUIPGROUP_CASH_ITEM, // eEQUIPCONTAINER_CHARGE5     = 20,
            EQUIPGROUP_PC_ROOM_ITEM, // eEQUIPCONTAINER_PC_ROOM1    = 21,
            EQUIPGROUP_PC_ROOM_ITEM, // eEQUIPCONTAINER_PC_ROOM2    = 22,
            EQUIPGROUP_PC_ROOM_ITEM, // eEQUIPCONTAINER_PC_ROOM3    = 23,
        };

        private static (EquipContainerPos, EquipContainerPos) GetEquipRange(EquipContainerPos pos)
        {
            var group = _equipGroups[(int) pos];
            switch (group)
            {
                case EQUIPGROUP_INVALID:
                    break;
                case EQUIPGROUP_WEAPON:
                    return (EquipContainerPos.EQUIPCONTAINER_WEAPON, EquipContainerPos.EQUIPCONTAINER_WEAPON);
                case EQUIPGROUP_ARMOR:
                    return (EquipContainerPos.EQUIPCONTAINER_ARMOR, EquipContainerPos.EQUIPCONTAINER_SHIRTS);
                case EQUIPGROUP_RING:
                    return (EquipContainerPos.EQUIPCONTAINER_RING1, EquipContainerPos.EQUIPCONTAINER_RING2); 
                case EQUIPGROUP_SPECIAL_ACCESSORY:
                    return (EquipContainerPos.EQUIPCONTAINER_SACCESSORY1, EquipContainerPos.EQUIPCONTAINER_SACCESSORY3);
                case EQUIPGROUP_CASH_ITEM:
                    return (EquipContainerPos.EQUIPCONTAINER_CHARGE1, EquipContainerPos.EQUIPCONTAINER_CHARGE5);
                case EQUIPGROUP_PC_ROOM_ITEM:
                    return (EquipContainerPos.EQUIPCONTAINER_PC_ROOM1, EquipContainerPos.EQUIPCONTAINER_PC_ROOM3);
                case EQUIPGROUP_MAX:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                
            }

            return (0, 0);
        }
        public Equipment(byte[] bytes, Player owner) : base((int)EquipContainerPos.EQUIPCONTAINER_MAX, bytes, owner)
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

        public override void DeleteItem(int pos)
        {
            UnEquipItem(GetSlot(pos));
            base.DeleteItem(pos);
        }

        private void EquipItem(ItemSlot slot)
        {
            //Logger.Instance.Log("Equiping Item");
            ItemAttributeCalculator itemCalc = new ItemAttributeCalculator(Owner.GetAttributes(), this,true);
            itemCalc.Equip(slot,true,false);

        }

        private void UnEquipItem(ItemSlot slot)
        {
            //Logger.Instance.Log("Unequiping Item");
            ItemAttributeCalculator itemCalc = new ItemAttributeCalculator(Owner.GetAttributes(), this, true);
            itemCalc.UnEquip(slot, true, false);
        }

        public override bool TryGetItemOfTypeAt(EquipContainerPos pos, ushort code, out ItemSlot? slot)
        {
            slot = null;
            var range = GetEquipRange(pos);

            for (EquipContainerPos index = range.Item1; index <= range.Item2; index++)
            {
                if (GetItem((int)index)?.GetItemId() == code)
                {
                    slot = GetSlot((int) index);
                    return true;
                }
            }

            return false;
        }


    }
    public enum EquipGroup 
    {
        EQUIPGROUP_INVALID = 0,         
        EQUIPGROUP_WEAPON,             
        EQUIPGROUP_ARMOR,              
        EQUIPGROUP_RING,                
        EQUIPGROUP_SPECIAL_ACCESSORY,   
        EQUIPGROUP_CASH_ITEM,          
        EQUIPGROUP_PC_ROOM_ITEM,        
        EQUIPGROUP_MAX
    };

}