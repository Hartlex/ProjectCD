using CDShared.ByteLevel;
using ProjectCD.Objects.Game.Items;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;

namespace ProjectCD.Objects.Game.Slots.Items
{
    public class ItemSlot
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

        public RankInfo[]? GetRankValues()
        {
            return _item?.GetRankValues();
        }

        public SocketInfo[]? GetSockets()
        {
            return _item.GetSockets();
        }

        public BaseItemInfo? GetBaseInfo()
        {
            return _item?.GetBaseInfo();
        }

        public byte GetEnchant()
        {
            return _item!.GetEnchant();
        }
    }

    public enum ItemByteType
    {
        MIN,
        TWENTY,
        MAX,
        RENDER
    }
}
