using CDShared.ByteLevel;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.Items;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.Items;

namespace ProjectCD.Objects.Game.Slots.Items
{
    public class ItemSlotContainer
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
        public byte[] GetRenderInfo()
        {
            //return BitShifter.Shift(this, false);
            ByteBuffer buffer = new();
            byte count = 0;
            foreach (var itemSlot in _slots.Values)
            {
                if (itemSlot.IsEmpty()) continue;
                itemSlot.GetBytes(ref buffer, ItemByteType.RENDER);
                count++;
            }
            buffer.InsertByte(count);
            return buffer.GetData();
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

        public virtual void DeleteItem(int pos)
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

        public int GetItemCountOfSet(ushort setCode)
        {
            var count = 0;
            foreach (var itemSlot in _slots.Values)
            {
                if(itemSlot.IsEmpty()) continue;
                if (itemSlot.GetBaseInfo()?.SetType == setCode) count++;
            }

            return count;
        }

        public Tuple<ushort,byte> GetSameSetItemSlots(BaseItemInfo relatedInfo, bool isAdd,out ItemSlot[] resultList)
        {
            resultList = new ItemSlot[150];
            ushort resultCode = relatedInfo.SetType;
            byte resultCount=0;

            if (resultCode == 0) return new (resultCount,resultCount);

            var retryState = false;

            var isSpecial = relatedInfo.SetOptionType == SetItemOption.SET_ITEM_SPECIAL;
            var changeableState = isSpecial;

            for (int j = 0; j < _slots.Count; j += retryState == false ? 1 : 0)
            {
                retryState = false;
                var itemSlot = _slots[j];
                if(itemSlot == null) continue;
                if(itemSlot.IsEmpty()) continue;
                var itemInfo = itemSlot.GetBaseInfo();
                if (itemInfo!.SetOptionType != SetItemOption.SET_ITEM_ACTIVE) continue;
                if (itemInfo.SetType == resultCode)
                {

                    if (isAdd)
                    {
                        int i;
                        for (i = 0; i < resultCount; i++)
                        {
                            if (itemInfo.BaseItemId == resultList[resultCount].GetBaseInfo()!.BaseItemId) break;
                        }

                        if (i >= resultCount)
                        {
                            resultList[resultCount] = itemSlot;
                            resultCount++;
                        }
                    }
                    else
                    {
                        if (itemInfo.BaseItemId != relatedInfo.BaseItemId)
                        {
                            resultList[resultCount] = itemSlot;
                            resultCount++;
                        }
                    }
                }
                else if(changeableState && isSpecial)
                {
                    if (!SetInfoDB.Instance.TryGetSetInfo(relatedInfo.SetType, out var setInfo)) continue;

                    changeableState = false;

                    if (relatedInfo.BaseItemId == setInfo.SpecialOption.SpecialItemCode)
                    {
                        resultCode = itemInfo.SetType;
                        resultCount = 0;
                        resultList = new ItemSlot[150];
                        retryState = true;
                        continue;
                    }
                }

            }

            return new Tuple<ushort, byte>(resultCode, resultCount);
;        }

        public virtual bool TryGetItemOfTypeAt(EquipContainerPos pos, ushort code,out ItemSlot? slot)
        {
            slot = _slots[(int)pos];
            return _slots[(int)pos]?.GetCode() == code;
        }
    }

}
