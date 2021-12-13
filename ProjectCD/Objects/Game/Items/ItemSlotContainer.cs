using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;

namespace ProjectCD.Objects.Game.Items
{
    internal class ItemSlotContainer
    {
        private Player _owner;
        private readonly Dictionary<int, ItemSlot> _slots;

        public ItemSlotContainer(int count, byte[] data, Player owner)
        {
            _owner = owner;

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
                _slots[pos].SetItem(ref buffer);
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

        public ItemSlot GetSlot(byte b)
        {
            return _slots[b];
        }
    }

}
