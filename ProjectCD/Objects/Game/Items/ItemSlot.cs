using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Item.Server;

namespace ProjectCD.Objects.Game.Items
{
    internal class ItemSlot
    {
        public readonly int Pos;
        private Item? _item;

        public ItemSlot(int pos)
        {
            Pos = pos;
        }

        public void SetItem(Item? item)
        {
            _item = item;
        }
        public void SetItem(ref ByteBuffer buffer)
        {
            _item = new(ref buffer);
        }
        public Item? GetItem()
        {
            return _item;
        }
        public bool Swap(ItemSlot other)
        {
            var temp = other._item;
            other.SetItem(_item);
            SetItem(temp);
            return true;
        }
        public void RemoveItem()
        {
            _item = null;
        }
        public bool IsEmpty()
        {
            return _item == null;
        }

        public byte[] GetBytes(ItemByteType type = ItemByteType.MAX)
        {
            ByteBuffer buffer = new();
            GetBytes(ref buffer,type);
            return buffer.GetData();
        }
        public void GetBytes(ref ByteBuffer buffer,ItemByteType type =ItemByteType.MAX)
        {
            buffer.WriteByte((byte)Pos);
            _item!.GetBytes(ref buffer,type);
        }

        public ushort GetCode()
        {
            return _item!.GetItemId();
        }
        public ItemSlotInfo GetItemSlotInfo()
        {
            return new ((byte)Pos, _item.GetBytes());
        }
    }

    public enum ItemByteType
    {
        MIN,
        TWENTY,
        MAX
    }
}
