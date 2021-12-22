using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Objects.Game.Slots.Items;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Object.Items.SetSystem;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Formulas.Item.CommonItemFormulas;
using static SunStructs.ServerInfos.General.Object.Items.SetSystem.SetItemOptionLevel;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    internal class ItemAttributeCalculator
    {
        private readonly PlayerAttr _attr;
        private readonly ItemSlotContainer _equip;
        private readonly bool _autoUpdate;
        public ItemAttributeCalculator(PlayerAttr attr, ItemSlotContainer equipment, bool autoUpdate)
        {
            _attr  = attr;
            _equip = equipment;
            _autoUpdate = autoUpdate;
        }

        public void Equip(ItemSlot slot,bool isPcRoom, bool useUpdateEx)
        {
            var info = slot.GetBaseInfo();
            var needApply = info?.IsEquipment();
            if (needApply == false)
            {
                Logger.Instance.Log("Item has effects from Inventory");
                return;
            }

            CalcRoot(slot,info,true,isPcRoom);

            if (_autoUpdate)
            {
                if (useUpdateEx)
                    _attr.UpdateEx();
                else _attr.Update();
            }

        }

        public void UnEquip(ItemSlot slot, bool isPcRoom, bool useUpdateEx)
        {
            var info = slot.GetBaseInfo();
            var needApply = info?.IsEquipment();
            if (needApply == false)
            {
                Logger.Instance.Log("Item has effects from Inventory");
                return;
            }

            CalcRoot(slot, info, false, isPcRoom);

            if (_autoUpdate)
            {
                if (useUpdateEx)
                    _attr.UpdateEx();
                else _attr.Update();
            }
        }

        private void CalcRoot(ItemSlot slot, BaseItemInfo info, bool add, bool isPcRoom)
        {

            CalcGenericFirst(info, add);

            if (info.IsArmor()) CalcAttributeArmor(slot, info,add);
            else if (info.IsAccessory()) CalcAttributeAccessory(slot, info,add);
            else if (info.IsWeapon()) CalcAttributeWeapon(slot, info,add);

            CalcGenericAttrSecond(slot, info,add,isPcRoom);

            //  CalcSetItem(slot,info,add);
            CalcSetItemCustom(slot,info,add);
        }

        private void CalcSetItemCustom(ItemSlot slot, BaseItemInfo itemInfo, bool isAdd)
        {
            if (!SetInfoDB.Instance.TryGetSetInfo(itemInfo.SetType, out var setInfo)) return;

            var setEquipCount = _equip.GetItemCountOfSet(setInfo!.SetCode);

            var curEquipLevel = SetInfoDB.Instance.GetLevel(setEquipCount);

            var isFull = false;

            if (isAdd)
            {
                isFull = setInfo.IsFull(setEquipCount);
            }
            else
            {
                if (itemInfo.SetOptionType != SetItemOption.SET_ITEM_SPECIAL)
                {
                    isFull = setInfo.IsFull(setEquipCount + 1);
                }
            }
            if (isFull && itemInfo.SetOptionType == SetItemOption.SET_ITEM_ACTIVE)
            {
                ApplySetItemFullOption(setInfo, isAdd);
            }

            int changeType = itemInfo.SetOptionType == SetItemOption.SET_ITEM_SPECIAL ? (byte)0 : GetSetItemChangeType(setEquipCount, isAdd);

            if (changeType == 1)
            {
                if (curEquipLevel > SET_ITEM_OPTION_LEVEL_NONE)
                {
                    for (SetItemOptionLevel level = SET_ITEM_OPTION_LEVEL_FIRST; level <= curEquipLevel; level++)
                    {
                        ApplySetItemOption(setInfo, slot.Pos, level, isAdd);
                    }
                }
            }

            
            if (changeType == 2)
            {
                SetItemOptionLevel optionLevel;
                if (isAdd)
                {
                    optionLevel = curEquipLevel;
                }
                else
                {
                    optionLevel = curEquipLevel + 1;
                }
                for (SetItemOptionLevel level = SET_ITEM_OPTION_LEVEL_FIRST; level <= optionLevel; level++)
                {
                    ApplySetItemOption(setInfo, slot.Pos, level, isAdd);
                }
                for (int i = 0; i < (int)EquipContainerPos.EQUIPCONTAINER_MAX; i++)
                {
                    if(i == slot.Pos) continue;
                    if (_equip.GetSlot(i).GetBaseInfo()?.SetType == setInfo.SetCode)
                        ApplySetItemOption(setInfo, i, optionLevel, isAdd);
                }
            }

            if (isFull)
            {
                if (itemInfo.BaseItemId == setInfo.SpecialOption.SpecialItemCode)
                {
                    ApplySpecialSetItemOption(setInfo, isAdd);
                }
                else
                {
                    if (_equip.TryGetItemOfTypeAt(setInfo.SpecialOption.EquipPosition,
                            setInfo.SpecialOption.SpecialItemCode, out var specialSlot))
                    {
                            ApplySpecialSetItemOption(setInfo, isAdd);
                    }
                }
            }
        }

        private void CalcSetItem(ItemSlot slot,BaseItemInfo itemInfo,bool isAdd)
        {
            if (!SetInfoDB.Instance.TryGetSetInfo(itemInfo.SetType, out var setInfo)) return;

            var setEquipCount = _equip.GetItemCountOfSet(setInfo!.SetCode);
            

            var sameSetResult = _equip.GetSameSetItemSlots(itemInfo, isAdd, out var resultSlots);
            if (sameSetResult.Item2 == 0) return;

            if (sameSetResult.Item1 != setInfo.SetCode)
                if (!SetInfoDB.Instance.TryGetSetInfo(sameSetResult.Item1, out setInfo))
                    return;

            int tempSetItemCount = sameSetResult.Item2;
            int realSetItemCount = 0;
            var realItemSlots = new ItemSlot[150];

            for (int i = 0; i < tempSetItemCount; i++)
            {
                int pos = resultSlots[i].Pos;
                if (!_equip.GetSlot(pos).IsEmpty())
                {
                    realItemSlots[realSetItemCount] = resultSlots[i];
                    realSetItemCount++;
                }
            }

            var curEquipLevel = SetInfoDB.Instance.GetLevel(realSetItemCount);

            var isFull = false;

            if (isAdd)
            {
                isFull = setInfo.IsFull(realSetItemCount);
            }
            else
            {
                if (itemInfo.SetOptionType != SetItemOption.SET_ITEM_SPECIAL)
                {
                    isFull = setInfo.IsFull(realSetItemCount+1);
                }
            }

            if ( itemInfo.SetOptionType == SetItemOption.SET_ITEM_ACTIVE)
            {
                ApplySetItemFullOption(setInfo,isAdd);
            }

            byte changeType = 0;
            changeType = itemInfo.SetOptionType == SetItemOption.SET_ITEM_SPECIAL ? (byte) 0 : GetSetItemChangeType(setEquipCount, isAdd);

            if (changeType == 1)
            {
                if (curEquipLevel > SET_ITEM_OPTION_LEVEL_NONE)
                {
                    for (SetItemOptionLevel level = SET_ITEM_OPTION_LEVEL_FIRST; level <= curEquipLevel; level++)
                    {
                        ApplySetItemOption(setInfo,slot.Pos,level,isAdd);
                    }
                }
            }

            if (changeType == 2)
            {
                SetItemOptionLevel optionLevel;
                if (isAdd)
                {
                    optionLevel = curEquipLevel;
                }
                else
                {
                    optionLevel = curEquipLevel + 1;
                }
                for (SetItemOptionLevel level = SET_ITEM_OPTION_LEVEL_FIRST; level <= optionLevel; level++)
                {
                    ApplySetItemOption(setInfo, slot.Pos, level, isAdd);
                }

                for (int i = 0; i < (int) EquipContainerPos.EQUIPCONTAINER_MAX; i++)
                {
                    if(_equip.GetSlot(i)?.GetBaseInfo()!.SetType == setInfo.SetCode)
                        ApplySetItemOption(setInfo, slot.Pos, optionLevel, isAdd);
                }
            }

            if (isFull)
            {
                if (itemInfo.BaseItemId == setInfo.SpecialOption.SpecialItemCode)
                {
                    ApplySpecialSetItemOption(setInfo,isAdd);
                }
                else
                {
                    if (_equip.TryGetItemOfTypeAt(setInfo.SpecialOption.EquipPosition,
                            setInfo.SpecialOption.SpecialItemCode, out var specialSlot))
                    {
                        if(realItemSlots[specialSlot!.Pos]!=null)
                            ApplySpecialSetItemOption(setInfo, isAdd);
                    }
                }
            }

        }

        private byte GetSetItemChangeType(int count, bool isAdd)
        {
            if (isAdd)
            {
                switch (count)
                {
                    case 1: return 0;
                    // ÀåÂø½Ã
                    case 2: case 4: case 6: return 2;
                    default: return 1;
                }
            }
            else
            {
                switch (count)
                {
                    case 0: return 0;
                    // »¬½Ã..
                    case 1: case 3: case 5: return 2;
                    default: return 1;
                }
            }

        }
        private void ApplySetItemFullOption(SetInfo info, bool isAdd)
        {
            if (isAdd)
                foreach (var infoFullOption in info.FullOptions)
                {
                    PlusOptionAttribute(infoFullOption);
                }
            else
                foreach (var infoFullOption in info.FullOptions)
                {
                    MinusOptionAttribute(infoFullOption);
                }
        }

        private void ApplySpecialSetItemOption(SetInfo info, bool isAdd)
        {
            if (isAdd)
                foreach (var infoFullOption in info.SpecialOption.Options)
                {
                    PlusOptionAttribute(infoFullOption);
                }
            else
                foreach (var infoFullOption in info.SpecialOption.Options)
                {
                    MinusOptionAttribute(infoFullOption);
                }
        }
        private void ApplySetItemOption(SetInfo info, int pos, SetItemOptionLevel level, bool isAdd)
        {
            var attrInfo = SetInfoDB.Instance.GetSetOption(info, pos, level);
            if (attrInfo != null)
            {
                if(isAdd) PlusOptionAttribute(attrInfo);
                else MinusOptionAttribute(attrInfo);
            }
        }
        private void CalcGenericFirst(BaseItemInfo info,bool add)
        {
            if (add)
            {
                AddAttr(ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, info.PhysicalAttackRate);
                AddAttr(ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, info.PhysicalAvoid);
                AddAttr(ATTR_ATTACK_SPEED, info.PhysicalAttackSpeed);
                AddAttr(ATTR_MOVE_SPEED, info.Speed);
            }
            else
            {
                SubAttr(ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, info.PhysicalAttackRate);
                SubAttr(ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, info.PhysicalAvoid);
                SubAttr(ATTR_ATTACK_SPEED, info.PhysicalAttackSpeed);
                SubAttr(ATTR_MOVE_SPEED, info.Speed);
            }

        }

        private void CalcGenericAttrSecond(ItemSlot slot, BaseItemInfo info,bool add,bool isPcRoom)
        {
            if (add)
            {
                foreach (var eff in info.ExerciseEffects)
                {
                    PlusOptionAttribute(eff.AttrInfo);
                }

                if (isPcRoom)
                {
                    foreach (var eff in info.PCExerciseEffects)
                    {
                        PlusOptionAttribute(eff.AttrInfo);
                    }
                }
            }
            else
            {
                foreach (var eff in info.ExerciseEffects)
                {
                    MinusOptionAttribute(eff.AttrInfo);
                }
                if (isPcRoom)
                {
                    foreach (var eff in info.PCExerciseEffects)
                    {
                        MinusOptionAttribute(eff.AttrInfo);
                    }
                }
            }

        }

        private void CalcAttributeWeapon(ItemSlot slot, BaseItemInfo info, bool add)
        {
            var weaponValues = new WeaponValues();
            var weightDamage = CalcAttackPower(slot.GetEnchant(), info.Level);
            ItemAttackDefInfo weaponInfo = info.AttackDefInfo;
            if (slot.GetItem()!.IsDivine())
            {
                weaponInfo = info.DivineAttackDefInfo;
            }
            else if (info.IsElite())
            {
                weaponInfo = info.EliteAttackDefInfo;
            }
            else if (info.IsUnique())
            {
                weaponInfo = info.UniqueAttackDefInfo;
            }
            
            weaponValues.SetValues(weaponInfo);
            weaponValues.AddValues(weightDamage);
            weaponValues.ApplyStrengthPenalty(0);
            //TODO strength penalty

            if (add)
            {
                AddAttr(ATTR_BASE_MELEE_MIN_ATTACK_POWER, weaponValues.LastPhyMinDamage);
                AddAttr(ATTR_BASE_MELEE_MAX_ATTACK_POWER, weaponValues.LastPhyMaxDamage);
                AddAttr(ATTR_BASE_MAGICAL_MIN_ATTACK_POWER, weaponValues.LastMagicMinDamage);
                AddAttr(ATTR_BASE_MAGICAL_MAX_ATTACK_POWER, weaponValues.LastMagicMaxDamage);
            }
            else
            {
                SubAttr(ATTR_BASE_MELEE_MIN_ATTACK_POWER, weaponValues.LastPhyMinDamage);
                SubAttr(ATTR_BASE_MELEE_MAX_ATTACK_POWER, weaponValues.LastPhyMaxDamage);
                SubAttr(ATTR_BASE_MAGICAL_MIN_ATTACK_POWER, weaponValues.LastMagicMinDamage);
                SubAttr(ATTR_BASE_MAGICAL_MAX_ATTACK_POWER, weaponValues.LastMagicMaxDamage);
            }

            ForeachAttrByRank(slot,add);
            ForeachAttrBySocket(slot,add);
        }

        private void CalcAttributeAccessory(ItemSlot slot, BaseItemInfo info,bool add)
        {
            ForeachAttrByRank(slot,add); 
        }
        private void CalcAttributeArmor(ItemSlot slot, BaseItemInfo info,bool add)
        {
            var armorValues = new ArmorValues();
            ItemAttackDefInfo armorInfo = info.AttackDefInfo;
            if (slot.GetItem()!.IsDivine())
            {
                armorInfo = info.DivineAttackDefInfo;
            }
            else if (info.IsElite())
            {
                armorInfo = info.EliteAttackDefInfo;
            }
            else if (info.IsUnique())
            {
                armorInfo = info.UniqueAttackDefInfo;
            }
            armorValues.SetValues(armorInfo);

            var enchant = slot.GetEnchant();
            var level = info.Level;

            armorValues.LastPhyDef = CalcPhyDef(armorValues.ItemPhyDef, enchant, level);
            armorValues.LastMagicDef = CalcPhyDef(armorValues.ItemMagicDef, enchant, level);

            if (add)
            {
                AddAttr(ATTR_BASE_MELEE_DEFENSE_POWER, armorValues.LastPhyDef);
                AddAttr(ATTR_BASE_RANGE_DEFENSE_POWER, armorValues.LastPhyDef);
                AddAttr(ATTR_BASE_MAGICAL_DEFENSE_POWER, armorValues.LastMagicDef);
            }
            else
            {
                SubAttr(ATTR_BASE_MELEE_DEFENSE_POWER, armorValues.LastPhyDef);
                SubAttr(ATTR_BASE_RANGE_DEFENSE_POWER, armorValues.LastPhyDef);
                SubAttr(ATTR_BASE_MAGICAL_DEFENSE_POWER, armorValues.LastMagicDef);
            }

            ForeachAttrByRank(slot, add);
            ForeachAttrBySocket(slot, add);

        }
        private void ForeachAttrByRank(ItemSlot slot, bool isAdd)
        {
            var rankInfos = slot.GetRankValues();
            if (rankInfos == null) return;
            foreach (var rankInfo in rankInfos)
            {
                if (isAdd)
                {
                    PlusOptionAttribute(rankInfo);
                }
                else
                {
                    MinusOptionAttribute(rankInfo);

                }
            }
        }

        private void ForeachAttrBySocket(ItemSlot slot, bool isAdd)
        {
            var sockets = slot.GetSockets();
            if(sockets == null) return;
            foreach (var socket in sockets)
            {
                if (isAdd)
                {
                    PlusOptionAttribute(socket);
                }
                else
                {
                    MinusOptionAttribute(socket);

                }
            }
        }

        private void MinusOptionAttribute(AttrInfo info)
        {
            if (info.AttrType == ATTR_TYPE_INVALID || info.AttrType == ATTR_MAX || info.Value == 0) return;

            AttrValueType valueType = AttrValueType.ITEM;
            if (info.ValueKind is AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR or AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                valueType = AttrValueType.ITEM_RATIO;
            switch (info.AttrType)
            {
                case ATTR_EXPERTY1:
                    SubAttr(ATTR_EXPERTY1, info.Value , valueType);
                    SubAttr(ATTR_EXPERTY2, info.Value, valueType);
                    break;
                case ATTR_INCREASE_STAT_POINT:
                    SubAttr(ATTR_STR, info.Value, valueType);
                    SubAttr(ATTR_DEX, info.Value, valueType);
                    SubAttr(ATTR_VIT, info.Value, valueType);
                    SubAttr(ATTR_INT, info.Value, valueType);
                    SubAttr(ATTR_SPR, info.Value, valueType);
                    break;
                default:
                    SubAttr(info.AttrType, info.Value, valueType);
                    break;
            }
        }

        private void PlusOptionAttribute(AttrInfo info)
        {
            if (info.AttrType == ATTR_TYPE_INVALID || info.AttrType == ATTR_MAX || info.Value == 0) return;

            AttrValueType valueType = AttrValueType.ITEM;
            if (info.ValueKind is AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR or AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                valueType = AttrValueType.ITEM_RATIO;

            switch (info.AttrType)
            {
                case ATTR_EXPERTY1:
                    AddAttr(ATTR_EXPERTY1, info.Value, valueType);
                    AddAttr(ATTR_EXPERTY2, info.Value, valueType);
                    break;
                case ATTR_INCREASE_STAT_POINT:
                    AddAttr(ATTR_STR, info.Value, valueType);
                    AddAttr(ATTR_DEX, info.Value, valueType);
                    AddAttr(ATTR_VIT, info.Value, valueType);
                    AddAttr(ATTR_INT, info.Value, valueType);
                    AddAttr(ATTR_SPR, info.Value, valueType);
                    break;
                default:
                    AddAttr(info.AttrType, info.Value, valueType);
                    break;
            }
        }
        private void AddAttr(AttrType type, int value, AttrValueType valueType = AttrValueType.ITEM)
        {
            //Logger.Instance.Log($"Added Attribute[{type}][{value}][{valueType}]");
            _attr[type].AddValue(value, valueType);
        }

        private void SubAttr(AttrType type, int value, AttrValueType valueType = AttrValueType.ITEM)
        {
            //Logger.Instance.Log($"Removed Attribute[{type}][{value}]");

            _attr[type].SubtractValue(value, valueType);

        }

    }
    class WeaponValues
    {
        public int LastPhyMinDamage;
        public int LastPhyMaxDamage;
        public int LastMagicMinDamage;
        public int LastMagicMaxDamage;

        public void SetValues(ItemAttackDefInfo info)
        {
            LastPhyMinDamage = info.PhysicalMinDamage;
            LastPhyMaxDamage = info.PhysicalMaxDamage;
            LastMagicMinDamage = info.MagicalMinDamage;
            LastMagicMaxDamage = info.MagicalMaxDamage;
        }

        public void AddValues(int value)
        {
            LastPhyMinDamage += value;
            LastPhyMaxDamage += value;
            LastMagicMinDamage += value;
            LastMagicMaxDamage += value;
        }

        public void ApplyStrengthPenalty(float penalty)
        {

        }
    }
    class ArmorValues
    {
        public int LastPhyDef;
        public int ItemPhyDef;
        public int LastMagicDef;
        public int ItemMagicDef;

        public void SetValues(ItemAttackDefInfo info)
        {
            ItemPhyDef = info.PhysicalDef;
            ItemMagicDef = info.MagicalDef;
        }

        public void AddValues(int value)
        {
            LastPhyDef += value;
            ItemPhyDef += value;
            LastMagicDef += value;
            ItemMagicDef += value;
        }

        public void ApplyStrengthPenalty(float penalty)
        {

        }
    }
}
