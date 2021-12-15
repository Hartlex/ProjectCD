using CDShared.ByteLevel;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;

namespace ProjectCD.Objects.Game.Items
{
    internal class ItemSlotContainer
    {
        protected Player Owner;
        private readonly Dictionary<int, ItemSlot> _slots;

        public ItemSlotContainer(int count, byte[] data, Player owner)
        {
            Owner = owner;

            _slots = new (count);
            for (int i = 0; i < count; i++)
            {
                _slots.Add(i,new(i));
            }
            Deserialize(data);
        }

        public byte[] Serialize()
        {
            ByteBuffer buffer = new();
            byte count = 0;
            foreach (var itemSlot in _slots.Values)
            {
                if(itemSlot.IsEmpty()) continue;
                itemSlot.GetBytes(ref buffer);
                count++;
            }
            buffer.InsertByte(count);
            return buffer.GetData();
        }
        public void Deserialize(byte[] data)
        {
            var buffer = new ByteBuffer(data);
            var filledSlotCount = buffer.ReadByte();
            for (int i = 0; i < filledSlotCount; i++)
            {
                var pos = buffer.ReadByte();
                var item = new Item(ref buffer);
                //_slots[pos].SetItem(ref buffer);
                InsertItem(item, pos, true);
            }
        }

        public byte[] GetShiftedBytes()
        {
            return BitShifter.Shift(this);
        }
        public int GetMaxSlotNum()
        {
            return _slots.Count;
        }

        public ItemSlot GetSlot(int pos)
        {
            return _slots[pos];
        }

        public virtual bool InsertItem(Item item, out ItemSlot slot, int pos = byte.MaxValue, bool force = false)
        {
            slot = null;
            if (!InsertItem(item, pos, force)) return false;
            slot = _slots[pos];
            return true;

        }
        public virtual bool InsertItem(Item item, int pos = byte.MaxValue, bool force = false)
        {
            if (pos == byte.MaxValue) { pos = GetFirstFreeSlot(); }
            //If no free slot is found
            if (pos == byte.MaxValue) return false;
            if (!_slots[pos].IsEmpty() && !force) return false;
            _slots[pos].SetItem(item);
            return true;
        }
        protected int GetFirstFreeSlot()
        {
            foreach (var itemSlot in _slots.Values)
            {
                if (itemSlot.IsEmpty()) return itemSlot.Pos;
            }
            return int.MaxValue;
        }
        public Item? GetItem(int pos)
        {
            return pos >= GetMaxSlotNum() ? null : _slots[pos].GetItem();
        }
        public void DeleteItem(int pos)
        {
            _slots[pos].RemoveItem();
        }
        public bool IsEmpty(int pos)
        {
            return _slots[pos].IsEmpty();
        }
        protected bool HasFreeSlots(int amount = 1)
        {
            while (amount > 0)
            {
                foreach (var itemSlot in _slots.Values)
                {
                    if (itemSlot.IsEmpty()) amount--;
                    if (amount >= 0) return true;
                }
            }

            return false;
        }

        public bool MoveItem(ItemSlotContainer container2, in int posFrom, in int posTo, in int amountToMove)
        {
            if (container2.GetSlot(posTo).IsEmpty())
            {
                container2.InsertItem(GetItem(posFrom), out var slot, posTo);
                DeleteItem(posFrom);
                return true;
            }

            var itemTo = container2.GetItem(posTo);
            var itemFrom = GetItem(posFrom);
            if (itemTo.GetItemId() == itemFrom.GetItemId())
            {
                if (itemTo.GetAmount() + itemFrom.GetAmount() <= 255)
                {
                    itemTo.IncreaseAmount(itemFrom.GetAmount());
                    DeleteItem(posFrom);
                    return true;
                }

                return false;
            }

            container2.InsertItem(itemFrom, posFrom, true);
            InsertItem(itemTo, posTo, true);
            return false;
        }
    }

}
