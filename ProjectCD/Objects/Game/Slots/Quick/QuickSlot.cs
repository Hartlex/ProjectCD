using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.Slots.Quick
{
    public class QuickSlot
    {
        public readonly byte Pos;
        private SlotContainerIndex _index;
        private ushort _code;
        private byte _refPos;

        public QuickSlot(byte pos)
        {
            Pos = pos;
            _index = SlotContainerIndex.SI_TEMPINVENTORY;
        }
        public QuickSlot(ref ByteBuffer buffer)
        {
            Pos = buffer.ReadByte();
            _index  = (SlotContainerIndex)buffer.ReadByte();
            _code = buffer.ReadUInt16();
            _refPos = buffer.ReadByte();
        }

        public byte[] GetBytes()
        {
            ByteBuffer buffer = new(4);
            GetBytes(ref buffer);
            return buffer.GetData();
        }

        public void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Pos);
            buffer.WriteByte((byte)_index);
            buffer.WriteUInt16(_code);
            buffer.WriteByte(_refPos);
        }

        public void SetSkillRef(ushort skillCode)
        {
            _index = SlotContainerIndex.SI_SKILL;
            _code = skillCode;
        }

        public void SetItemRef(byte slotPos,ushort itemId)
        {
            _index = SlotContainerIndex.SI_INVENTORY;
            _code = itemId;
            _refPos = slotPos;
        }

        public void Clear()
        {
            _index = SlotContainerIndex.SI_TEMPINVENTORY;
            _code = 0;
            _refPos = 0;
        }
        public bool IsEmpty()
        {
            return _index == SlotContainerIndex.SI_TEMPINVENTORY;
        }

        public void SwapContent(QuickSlot slot2)
        {
            var tempIndex = slot2._index;
            var tempCode = slot2._code;
            var tempRefPos = slot2._refPos;

            slot2._index = _index;
            slot2._code = _code;
            slot2._refPos = _refPos;

            _index = tempIndex;
            _code = tempCode;
            _refPos = tempRefPos;
        }
        
    }


}
