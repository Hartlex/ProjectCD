using CDShared.ByteLevel;

namespace ProjectCD.Objects.Game.Slots.Quick
{
    public class QuickSlotContainer
    {
        private readonly Dictionary<byte, QuickSlot> _quickSlots;

        public QuickSlotContainer(int count, byte[] bytes)
        {
            _quickSlots = new Dictionary<byte, QuickSlot>(count);
            for(byte i = 0; i < count; i++)
            {
                var quickSlot = new QuickSlot(i);
                _quickSlots.Add(i,quickSlot);
            }
            Deserialize(bytes);
        }
        private void Deserialize(byte[] bytes)
        {
            ByteBuffer buffer = new(bytes);
            var count = buffer.ReadByte();
            for (int i = 0; i < count; i++)
            {
                QuickSlot quickSlot = new(ref buffer);
                _quickSlots[quickSlot.Pos] = quickSlot;
            }
        }

        public QuickSlot GetQuickSlot(byte pos)
        {
            return _quickSlots[pos];
        }

        public void SetSkillRef(in byte pos, in ushort skillCode)
        {
            _quickSlots[pos].SetSkillRef(skillCode);
        }
        public void SetItemRef(in byte pos,in byte slotPos,ushort itemId)
        {
            _quickSlots[pos].SetItemRef(slotPos,itemId);
        }
        public void ClearSlot(byte pos)
        {
            _quickSlots[pos].Clear();
        }

        public void MoveSlot(byte pos1, byte pos2)
        {
            var slot1 = _quickSlots[pos1];
            var slot2 = _quickSlots[pos2];
            slot1.SwapContent(slot2);
        }
        public byte[] Serialize()
        {
            var result = new List<byte>();
            byte count = 0;
            foreach (var quickSlot in _quickSlots.Values)
            {
                if(quickSlot.IsEmpty()) continue;
                result.AddRange(quickSlot.GetBytes());
                count++;
            }
            result.Insert(0,count);
            return result.ToArray();

        }
    }
}
