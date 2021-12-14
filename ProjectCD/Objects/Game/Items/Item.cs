﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items;

namespace ProjectCD.Objects.Game.Items
{
    internal class Item
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
            _option = new (ref buffer);
        }
        public Item(BaseItemInfo info)
        {
            _info = info;
            _durability = info.Durability;
            _type = ItemParseType.EQUIP;
            _option = new ItemOption();
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


    }
}
