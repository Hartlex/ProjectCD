using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using ProjectCD.Objects.Game.Slots.Items;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Object.Items.EnchantSystem;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;
using static SunStructs.Definitions.ItemTradesellType;

namespace ProjectCD.Objects.Game.Items
{
    public class Item
    {
        private ushort _itemCode;
        private int _durability; //amount
        private ItemParseType _type;
        private ItemOption _option;
        private readonly BaseItemInfo _info;
        public Item(ref ByteBuffer buffer)
        {
            _itemCode = buffer.ReadUInt16();
            _durability = buffer.ReadByte();
            _type = (ItemParseType)buffer.ReadByte();
            _option = new (ref buffer,this);
            BaseItemDB.Instance.TryGetBaseItemInfo(_itemCode,out _info);
        }
        public Item(BaseItemInfo info)
        {
            _itemCode = info.BaseItemId;
            _info = info;
            _durability = info.Durability == 0 ? 1 : info.Durability;
            _type = ItemParseType.EQUIP;
            _option = new ItemOption(this);
        }

        public byte[] GetBytes(ItemByteType type = ItemByteType.MAX)
        {
            var buffer = new ByteBuffer();
            GetBytes(ref buffer,type);
            return buffer.GetData();
        }
        public void GetBytes(ref ByteBuffer buffer, ItemByteType type =ItemByteType.MAX)
        {
            switch (type)
            {
                case ItemByteType.MIN:
                    GetBaseBytes(ref buffer);
                    break;
                case ItemByteType.TWENTY:
                case ItemByteType.MAX:
                    GetBaseBytes(ref buffer);
                    _option.GetBytes(ref buffer,type);
                    break;
                case ItemByteType.RENDER:
                    buffer.WriteUInt16(_itemCode);
                    buffer.WriteByte(GetEnchant());
                    buffer.WriteByte(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void GetBaseBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(_itemCode);
            buffer.WriteByte(_durability);
            buffer.WriteByte((byte)_type);
        }
        public bool HasOptions()
        {
            return _type == ItemParseType.EQUIP;
        }

        public ushort GetItemId()
        {
            return _itemCode;
        }
        public void SetAmount(byte value)
        {
            _durability = value;
        }
        public int GetAmount()
        {
            return _durability;
        }
        public byte GetStackNumber()
        {
            return _info.DupNumber;
        }
        public bool IsStackable()
        {
            return _info.DupNumber > 1;
        }
        public bool IncreaseAmount(int value)
        {
            if (_durability + value > GetStackNumber()) return false;
            _durability += value;
            return true;

        }
        public bool DecreaseAmount(int value)
        {
            if (_durability < value) return false;
            _durability -= value;
            return true;
        }


        public ItemType GetItemType()
        {
            return _info.ItemType;
        }

        public RankInfo[]? GetRankValues()
        {
            return _option.GetRankValues();
        }

        public void SetRankOption(Rank rank, RankOption option)
        {
            _option.SetRankOption(rank,option);
        }

        public SocketInfo[]? GetSockets()
        {
            return _option.GetSockets();
        }

        public BaseItemInfo GetBaseInfo()
        {
            return _info;
        }

        public byte GetEnchant()
        {
            return (byte) _option.GetEnchant();
        }

        public void SetEnchant(EnchantGrade grade)
        {
            _option.SetEnchant(grade);
        }
        public bool IsDivine()
        {
            return _option.IsDivine();
        }

        public void SetDivine(byte b)
        {
            _option.SetDivine(b);
        }

        public Rank GetRank()
        {
            return _option.GetRank();
        }

        public byte GetDivine()
        {
            return (byte) (_option.IsDivine() ? 1 :0);
        }

        public bool CanTradeSellDrop(ItemTradesellType type)
        {
            var calcSet = _info.TradeSellType;

            if (IsEtheria() || IsShell())
                calcSet |= (ushort) ITEM_TRADESELL_SELL;
            if (type == ITEM_TRADESELL_DOALL) return true;
            if (type == ITEM_TRADESELL_DONTALL) return false;

            return (calcSet & (int) type) == 0;

        }

        private bool IsEtheria()
        {
            return false;
        }

        private bool IsShell()
        {
            return false;
        }
    }
}
