using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.Items
{
    internal class Item
    {
        private ushort _itemCode;
        private byte _durability; //amount
        private ItemParseType _type;
        private ItemOption _option;
        public Item(ref ByteBuffer buffer)
        {
            _itemCode = buffer.ReadUInt16();
            _durability = buffer.ReadByte();
            _type = (ItemParseType)buffer.ReadByte();
            _option = new (ref buffer);
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
    }

    internal class ItemOption
    {
        private ulong _option1;
        private uint _option2;
        private uint _option3;
        private uint _option4;
        private byte[] _unkOption;

        public ItemOption(ref ByteBuffer buffer)
        {
            var mask = new byte[8];
            var bytes = buffer.ReadBlock(6);
            Buffer.BlockCopy(bytes, 0, mask, 0, 6);
            _option1 = BitConverter.ToUInt64(mask);
            _option2 = buffer.ReadUInt32();
            _option3 = buffer.ReadUInt32();
            _option4 = buffer.ReadUInt32();
            _unkOption = buffer.ReadBlock(5);
        }

        public void GetBytes(ref ByteBuffer buffer, ItemByteType type = ItemByteType.MAX)
        {
            switch (type)
            {
                case ItemByteType.MIN:
                    break;
                case ItemByteType.TWENTY:
                    var b2 = BitConverter.GetBytes(_option1);
                    buffer.WriteBlock(b2, 0, 6);
                    buffer.WriteUInt32(_option2);
                    buffer.WriteUInt32(_option3);
                    var b3 = BitConverter.GetBytes(_option4);
                    buffer.WriteBlock(b3, 0, 2);
                    break;
                case ItemByteType.MAX:
                    var b = BitConverter.GetBytes(_option1);
                    buffer.WriteBlock(b, 0, 6);
                    buffer.WriteUInt32(_option2);
                    buffer.WriteUInt32(_option3);
                    buffer.WriteUInt32(_option4);
                    buffer.WriteBlock(_unkOption);
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

        }
    }
}
