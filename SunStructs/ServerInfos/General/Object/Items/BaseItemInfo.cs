using SunStructs.Definitions;
using static SunStructs.Definitions.EquipContainerPos;
using static SunStructs.Definitions.ItemMaterialType;
using static SunStructs.Definitions.ItemType;

namespace SunStructs.ServerInfos.General.Object.Items
{
    /// <summary>
    /// Base Class for All Items.
    /// All Items have all these Attributes. Maybe change this later
    /// </summary>
    public class BaseItemInfo
    {
        #region Attributes
        public ushort BaseItemId;
        public ushort ChargeType;
        public ushort ChargeSubType;
        public uint NameCode1;
        public ushort NameColorType;
        public string NameColorCode;
        public uint NameCode2;
        public uint NameCode3;
        public uint OnCharModelCode;
        public uint IconCode;
        public uint DropModelCode;
        public ItemType ItemType;
        public ushort EType;
        public ushort SoundId;
        public ushort EffectPosition;
        public string EffectCode;
        public string RotBone;
        public string BoneName;
        public string SaBoneType;
        public ItemSubType SubType;
        public SetItemOption SetOptionType;
        public ushort SetType;
        public ushort Level;
        public byte Durability; //Count
        public uint DuraStrength;
        public ushort StrengthPenalty;
        public ulong ItemSellMoney;
        public ulong ItemSellMoneyMax;
        public byte Popup; 
        public ItemMaterialType MaterialType;
        public ushort TradeSellType;
        public byte Mixture;
        public byte ReversionType; 
        public byte ExtractType;
        public ushort RequiredLevel;
        public ushort MaxUseLevel;
        public ItemRequirementInfo RequirementInfo;

        public ItemAttackDefInfo AttackDefInfo;
        public ushort PhysicalAttackRate;
        public ushort PhysicalAttackSpeed;
        public ushort PhysicalAvoid;
        public AttackType BaseAttackType;
        public AttackType MagicAttackType;
        public MeleeType MeleeType;
        public float AttackRange;
        public ArmorType ArmorType;

        public ushort MagicAttackSpeed;

        public ushort Speed;
        public bool EqRidingClass;
        public bool EqClass1;//Berserker
        public bool EqClass2;//Dragon Knight
        public bool EqClass3;//Valkyrie
        public bool EqClass4;//Elementalist
        public bool EqClass5;//Shadow
        public bool EqClass6;//Mystic
        public bool EqClass7;//Helroid
        public bool EqClass8;//Witchblade
        public EquipContainerPos EquipPosition;
        public ushort MaxRank;
        public byte SocketUse;
        public ushort SocketNumber;
        public ExerciseEffect[] ExerciseEffects; //5
        public ExerciseEffect[] PCExerciseEffects; //5 //TODO both can be fused together probably
        public ushort Missile;
        public ushort HeadType;
        public ushort Customize;
        public byte DupNumber;
        public ushort DubEquipNumber;
        public ushort DubEquipType;
        public ushort DubEquipTypeNumber;
        public ushort DubEquipGroup;

        public WasteType WasteType;
        public byte CoolTimeType;
        public uint HealHP;
        public uint ExpHP;
        public uint HealTime;
        public ushort HealTimeNumber;
        public uint CoolTime;
        public ushort ChaosTimeDec;
        public uint QuestCode;
        public ushort MaterialCode;
        public ushort SkillCode;
        public uint ExchangedItem;
        public ItemRequirementInfo DivineRequirementInfo;
        public ItemAttackDefInfo DivineAttackDefInfo;

        public ushort ACCode;
        public ushort ACReferenceId;

        public ItemAttackDefInfo EliteAttackDefInfo;
        public ItemAttackDefInfo UniqueAttackDefInfo;

        public byte ItemListType;
        public byte UseItemDistribution;



        #endregion
        public BaseItemInfo(string[] info)
        {
            BaseItemId = ushort.Parse(info[1]);
            ChargeType = ushort.Parse(info[2]);
            ChargeSubType = ushort.Parse(info[3]);
            NameCode1 = uint.Parse(info[5]);
            NameColorType = ushort.Parse(info[6]);
            NameColorCode = info[7];
            NameCode2 = uint.Parse(info[8]);
            NameCode3 = uint.Parse(info[9]);
            OnCharModelCode = uint.Parse(info[10]);
            IconCode = uint.Parse(info[11]);
            DropModelCode = uint.Parse(info[12]);
            ItemType = (ItemType) ushort.Parse(info[13]);
            EType = ushort.Parse(info[14]);
            SoundId = ushort.Parse(info[15]);
            EffectPosition = ushort.Parse(info[16]);
            EffectCode = info[17];
            RotBone = info[18];
            BoneName = info[19];
            SaBoneType = info[20];
            SubType =(ItemSubType) int.Parse(info[21]);
            SetOptionType = (SetItemOption) ushort.Parse(info[22]);
            SetType = ushort.Parse(info[23]);
            Level = ushort.Parse(info[24]);
            Durability = byte.Parse(info[25]);
            DuraStrength = (uint)double.Parse(info[26]);
            StrengthPenalty = (ushort)double.Parse(info[27]);
            ItemSellMoney = (ulong)double.Parse(info[28]);
            ItemSellMoneyMax =(ulong)double.Parse(info[29]);
            Popup = byte.Parse(info[30]);
            MaterialType =(ItemMaterialType) byte.Parse(info[31]);
            TradeSellType = ushort.Parse(info[32]);
            Mixture = byte.Parse(info[33]);
            ReversionType = byte.Parse(info[34]);
            ExtractType = byte.Parse(info[35]);
            RequiredLevel = ushort.Parse(info[36]);
            MaxUseLevel = ushort.Parse(info[37]);
            RequirementInfo = new ItemRequirementInfo(ref info, 38);
            AttackDefInfo = new ItemAttackDefInfo(
                ushort.Parse(info[45]),
                ushort.Parse(info[46]),
                ushort.Parse(info[56]),
                ushort.Parse(info[57]),
                ushort.Parse(info[49]),
                ushort.Parse(info[59])
            );
            PhysicalAttackRate = ushort.Parse(info[47]);
            PhysicalAttackSpeed = ushort.Parse(info[48]);
            PhysicalAvoid = ushort.Parse(info[50]);
            BaseAttackType = (AttackType) int.Parse(info[51]);
            MagicAttackType = (AttackType) int.Parse(info[52]);
            MeleeType = (MeleeType)int.Parse(info[53]);
            AttackRange = float.Parse(info[54]);
            ArmorType =(ArmorType) ushort.Parse(info[55]);
            MagicAttackSpeed = ushort.Parse(info[58]);
            Speed = ushort.Parse(info[60]);
            EqRidingClass = info[61]=="1";
            EqClass1 = info[62] == "1";
            EqClass2 = info[63] == "1";
            EqClass3 = info[64] == "1";
            EqClass4 = info[65] == "1";
            EqClass5 = info[66] == "1";
            EquipPosition =(EquipContainerPos) byte.Parse(info[67]);
            MaxRank = ushort.Parse(info[68]);
            SocketUse = byte.Parse(info[69]);
            SocketNumber = ushort.Parse(info[70]);
            ExerciseEffects = new ExerciseEffect[5];
            for (int i = 0; i < ExerciseEffects.Length; i++)
            {
                ExerciseEffects[i] = new ExerciseEffect(ref info,71+i*4);
            }

            PCExerciseEffects = new ExerciseEffect[5];
            for (int i = 0; i < PCExerciseEffects.Length; i++)
            {
                PCExerciseEffects[i] = new ExerciseEffect(ref info, 91 + i * 4);
            }
            Missile = ushort.Parse(info[111]);
            HeadType = ushort.Parse(info[112]);
            Customize = ushort.Parse(info[113]);
            DupNumber = byte.Parse(info[114]);
            DubEquipNumber = ushort.Parse(info[115]);
            DubEquipType = ushort.Parse(info[116]);
            DubEquipTypeNumber = ushort.Parse(info[117]);
            DubEquipGroup = ushort.Parse(info[118]);
            WasteType = (WasteType)byte.Parse(info[119]);
            CoolTimeType = byte.Parse(info[120]);
            HealHP = uint.Parse(info[121]);
            ExpHP = uint.Parse(info[122]);
            HealTime = uint.Parse(info[123]);
            HealTimeNumber = ushort.Parse(info[124]);
            CoolTime = uint.Parse(info[125]);
            ChaosTimeDec = ushort.Parse(info[126]);
            QuestCode = uint.Parse(info[127]);
            MaterialCode = ushort.Parse(info[128]);
            SkillCode = ushort.Parse(info[129]);
            ExchangedItem = uint.Parse(info[130]);
            DivineRequirementInfo = new ItemRequirementInfo(ref info,131);
            DivineAttackDefInfo = new ItemAttackDefInfo(ref info, 138);
            ACCode = ushort.Parse(info[144]);
            ACReferenceId = ushort.Parse(info[145]);
            EliteAttackDefInfo = new ItemAttackDefInfo(ref info,146);
            UniqueAttackDefInfo = new ItemAttackDefInfo(ref info,152);
            ItemListType = byte.Parse(info[158]);
            UseItemDistribution = byte.Parse(info[159]);

        }
        public BaseItemInfo() { }

        public bool IsWeapon()
        {
            return EquipPosition == EQUIPCONTAINER_WEAPON;
        }

        public bool IsEquipment()
        {
            return IsWeapon() || IsArmor() || IsAccessory() || IsSpecialAccessory();
        }
        public bool IsArmor()
        {
            return (
                EquipPosition == EQUIPCONTAINER_ARMOR || EquipPosition == EQUIPCONTAINER_PROTECTOR || 
                EquipPosition == EQUIPCONTAINER_HELMET || EquipPosition == EQUIPCONTAINER_PANTS || 
                EquipPosition == EQUIPCONTAINER_BOOTS || EquipPosition == EQUIPCONTAINER_GLOVE || 
                EquipPosition == EQUIPCONTAINER_BELT	|| EquipPosition == EQUIPCONTAINER_SHIRTS );
        }
        public bool IsAccessory()
        {
            return IsRing() || IsNecklace();
        }

        public bool IsSpecialAccessory()
        {
            return ItemType is ITEMTYPE_BERSERKER_SACCESSORY or ITEMTYPE_DRAGON_SACCESSORY or
                ITEMTYPE_ELEMENTALIST_SACCESSORY or ITEMTYPE_SHADOW_SACCESSORY or ITEMTYPE_VALKYRIE_SACCESSORY;
        }
        public bool IsRing()
        {
            return ItemType is ITEMTYPE_RING or ITEMTYPE_RING;
        }
        public bool IsNecklace()
        {
            return ItemType == ITEMTYPE_NECKLACE;
        }
        public bool IsCanUserWaste()
        {
           return MaterialType == ITEM_MATERIAL_TYPE_CAN_BOTH || MaterialType == ITEM_MATERIAL_TYPE_CAN_BOTH;
        }
        public bool IsCanEquip()
        {
            return MaterialType == ITEM_MATERIAL_TYPE_CAN_EQUIP || MaterialType == ITEM_MATERIAL_TYPE_CAN_BOTH;

        }
        public bool IsPotion()
        {
            return WasteType == WasteType.ITEMWASTE_HPPOTION || WasteType == WasteType.ITEMWASTE_MPPOTION;
        }

        public CharType GetFirstChar()
        {
            if (EqClass1) return CharType.CHAR_BERSERKER;
            if (EqClass2) return CharType.CHAR_DRAGON;
            if (EqClass3) return CharType.CHAR_SHADOW;
            if (EqClass4) return CharType.CHAR_VALKYRIE;
            if (EqClass5) return CharType.CHAR_ELEMENTALIST;
            return CharType.CHAR_BERSERKER;
        }

        public ItemAttackDefInfo GetAttackDefInfo()
        {
            switch (SubType)
            {
                case ItemSubType.NORMAL:
                    return AttackDefInfo;
                case ItemSubType.ELITE:
                    return EliteAttackDefInfo;
                case ItemSubType.UNIQUE:
                    return UniqueAttackDefInfo;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool IsElite()
        {
            return SubType is ItemSubType.ELITE;
        }

        public bool IsUnique()
        {
            return SubType is ItemSubType.UNIQUE;
        }
    }
    public enum SetItemOption { SET_ITEM_NONE, SET_ITEM_ACTIVE, SET_ITEM_SPECIAL, SET_ITEM_COUNT };
}
