using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;


namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public abstract class Attributes
    {
        private readonly Attribute[] _attributes;
        private readonly Attribute[] _reduceDefenseRate = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        private readonly Attribute[] _magicalAttPower = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        private readonly Attribute[] _bonusDefense = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        private readonly Attribute[] _magicalDefPower = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        private readonly Attribute[] _bonusDamage = new Attribute[(int )ArmorType.ARMOR_TYPE_MAX];
        private readonly Attribute[] _bonusDamagePercent = new Attribute[(int )ArmorType.ARMOR_TYPE_MAX];
        private readonly Attribute[] _reduceDamage = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];

        protected Attributes(AttrProfile profile)
        {
            _attributes = new Attribute[(int) AttrType.ATTR_MAX];
            foreach (var attribute in profile.GetAttrTypes())
            {
                _attributes[(int) attribute] = new ();
            }
            RegisterBonusDefenseRatio();
            RegisterBonusDefense();
            RegisterMagicAttackPower();
            RegisterMagicalDefPower();
            RegisterReduceDamage();
            RegisterBonusDamage();
            RegisterBonusDamageRatio();
        }

        private void RegisterBonusDamage()
        {
            _bonusDamage[(int) ArmorType.ARMOR_HARD] = _attributes[(int) AttrType.ATTR_ADD_ARMOR_HARD_DAMAGE];
            _bonusDamage[(int) ArmorType.ARMOR_MEDIUM] = _attributes[(int) AttrType.ATTR_ADD_ARMOR_MEDIUM_DAMAGE];
            _bonusDamage[(int) ArmorType.ARMOR_SOFT] = _attributes[(int) AttrType.ATTR_ADD_ARMOR_SOFT_DAMAGE];
            _bonusDamage[(int) ArmorType.ARMOR_SIEGE] = _attributes[(int) AttrType.ATTR_ADD_ARMOR_SIEGE_DAMAGE];
            _bonusDamage[(int) ArmorType.ARMOR_UNARMOR] = _attributes[(int) AttrType.ATTR_ADD_ARMOR_UNARMOR_DAMAGE];
            
        }
        private void RegisterBonusDamageRatio()
        {
            _bonusDamagePercent[(int)ArmorType.ARMOR_HARD] = _attributes[(int)AttrType.ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE];
            _bonusDamagePercent[(int)ArmorType.ARMOR_MEDIUM] = _attributes[(int)AttrType.ATTR_ADD_RATIO_ARMOR_MEDIUM_DAMAGE];
            _bonusDamagePercent[(int)ArmorType.ARMOR_SOFT] = _attributes[(int)AttrType.ATTR_ADD_RATIO_ARMOR_SOFT_DAMAGE];
            _bonusDamagePercent[(int)ArmorType.ARMOR_SIEGE] = _attributes[(int)AttrType.ATTR_ADD_RATIO_ARMOR_SIEGE_DAMAGE];
            _bonusDamagePercent[(int)ArmorType.ARMOR_UNARMOR] = _attributes[(int)AttrType.ATTR_ADD_RATIO_ARMOR_UNARMOR_DAMAGE];

        }
        private void RegisterBonusDefense()
        {
            _bonusDefense[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = _attributes[(int)AttrType.ATTR_ADD_ALL_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_MELEE] = _attributes[(int)AttrType.ATTR_ADD_MELEE_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_RANGE] = _attributes[(int)AttrType.ATTR_ADD_RANGE_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_WATER] = _attributes[(int)AttrType.ATTR_ADD_WATER_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_FIRE] = _attributes[(int)AttrType.ATTR_ADD_FIRE_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_WIND] = _attributes[(int)AttrType.ATTR_ADD_WIND_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_EARTH] = _attributes[(int)AttrType.ATTR_ADD_EARTH_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_DARKNESS] = _attributes[(int)AttrType.ATTR_ADD_DARKNESS_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_DIVINE] = _attributes[(int)AttrType.ATTR_ADD_DIVINE_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = _attributes[(int)AttrType.ATTR_ADD_PHYSICAL_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = _attributes[(int)AttrType.ATTR_ADD_MAGICAL_DEFENSE_POWER];
            _bonusDefense[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = _attributes[(int)AttrType.ATTR_ADD_ALL_DEFENSE_POWER];
        }
        private void RegisterMagicAttackPower()
        {
            _magicalAttPower[(int)AttackType.ATTACK_TYPE_WATER] = _attributes[(int)AttrType.ATTR_MAGICAL_WATER_ATTACK_POWER];
            _magicalAttPower[(int)AttackType.ATTACK_TYPE_FIRE] = _attributes[(int)AttrType.ATTR_MAGICAL_FIRE_ATTACK_POWER];
            _magicalAttPower[(int)AttackType.ATTACK_TYPE_WIND] = _attributes[(int)AttrType.ATTR_MAGICAL_WIND_ATTACK_POWER];
            _magicalAttPower[(int)AttackType.ATTACK_TYPE_EARTH] = _attributes[(int)AttrType.ATTR_MAGICAL_EARTH_ATTACK_POWER];
            _magicalAttPower[(int)AttackType.ATTACK_TYPE_DARKNESS] = _attributes[(int)AttrType.ATTR_MAGICAL_DARKNESS_ATTACK_POWER];
            _magicalAttPower[(int)AttackType.ATTACK_TYPE_DIVINE] = _attributes[(int)AttrType.ATTR_MAGICAL_DIVINE_ATTACK_POWER];
        }
        private void RegisterMagicalDefPower()
        {
            _magicalDefPower[(int)AttackType.ATTACK_TYPE_WATER] = _attributes[(int)AttrType.ATTR_MAGICAL_WATER_DEFENSE_POWER];
            _magicalDefPower[(int)AttackType.ATTACK_TYPE_FIRE] = _attributes[(int)AttrType.ATTR_MAGICAL_FIRE_DEFENSE_POWER];
            _magicalDefPower[(int)AttackType.ATTACK_TYPE_WIND] = _attributes[(int)AttrType.ATTR_MAGICAL_WIND_DEFENSE_POWER];
            _magicalDefPower[(int)AttackType.ATTACK_TYPE_EARTH] = _attributes[(int)AttrType.ATTR_MAGICAL_EARTH_DEFENSE_POWER];
            _magicalDefPower[(int)AttackType.ATTACK_TYPE_DARKNESS] = _attributes[(int)AttrType.ATTR_MAGICAL_DARKNESS_DEFENSE_POWER];
            _magicalDefPower[(int)AttackType.ATTACK_TYPE_DIVINE] = _attributes[(int)AttrType.ATTR_MAGICAL_DIVINE_DEFENSE_POWER];
        }
        private void RegisterBonusDefenseRatio()
        {
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_MELEE] = _attributes[(int)AttrType.ATTR_DEL_MELEE_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_RANGE] = _attributes[(int)AttrType.ATTR_DEL_RANGE_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_WATER] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_FIRE] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_WIND] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_EARTH] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_DARKNESS] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_DIVINE] = _attributes[(int)AttrType.ATTR_DEL_DIVINE_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            _reduceDefenseRate[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = _attributes[(int)AttrType.ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
        }
        private void RegisterReduceDamage()
        {
            _reduceDamage[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = _attributes[(int)AttrType.ATTR_DEL_ALL_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_MELEE] = _attributes[(int)AttrType.ATTR_DEL_MELEE_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_RANGE] = _attributes[(int)AttrType.ATTR_DEL_RANGE_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_WATER] = _attributes[(int)AttrType.ATTR_DEL_WATER_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_FIRE] = _attributes[(int)AttrType.ATTR_DEL_FIRE_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_WIND] = _attributes[(int)AttrType.ATTR_DEL_WIND_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_EARTH] = _attributes[(int)AttrType.ATTR_DEL_EARTH_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_DARKNESS] = _attributes[(int)AttrType.ATTR_DEL_DARKNESS_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_DIVINE] = _attributes[(int)AttrType.ATTR_DEL_DIVINE_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = _attributes[(int)AttrType.ATTR_DEL_PHYSICAL_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = _attributes[(int)AttrType.ATTR_DEL_MAGICAL_DAMAGE];
            _reduceDamage[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = _attributes[(int)AttrType.ATTR_DEL_MAGICAL_ALL_DAMAGE];
        }
        public Attribute this[AttrType key] => _attributes[(int)key];

        public ushort GetValue16(AttrType key)
        {
            return this[key].GetValue16();
        }
        public uint GetValue32(AttrType key)
        {
            return this[key].GetValue32();
        }
        public void SetBaseValue(AttrType key, ushort value)
        {
            _attributes[(int) key].SetValue(value);
        }
        public void SetBaseValue(AttrType key, uint value)
        {
            _attributes[(int)key].SetValue(value);
        }

        public void Update()
        {
            foreach (var attribute in _attributes)
            {
                attribute?.Update();
            }
        }

        public int GetBonusDamage(ArmorType type)
        {
            return _bonusDamage[(int) type].GetValue();
        }

        public int GetBonusPercentDamage(ArmorType type)
        {
            return _bonusDamagePercent[(int) type].GetValue();
        }

        public int GetReducePhysicalTargetDefenseRatio()
        {
            return _attributes[(int)AttrType.ATTR_DEL_PHYSICAL_TARGET_DEFENSE_RATIO].GetValue();
        }

        public int GetReduceDamage(AttackType type)
        {
            return _reduceDamage[(int) type].GetValue();
        }

        public int GetMagicalAttackPower(AttackType type, AttrValueType valueType = CALC)
        {
            return _magicalAttPower[(int) type].GetValue(valueType);
        }

        public int GetMagicalDefense(AttackType attackType, AttrValueType valueType = CALC)
        {
            return _magicalDefPower[(int)attackType].GetValue(valueType);
        }

        public int GetBonusDefense(AttackType type)
        {
            return _bonusDefense[(int)type].GetValue();
        }
        public int GetBonusDefenseRatio(AttackType type)
        {
            return _bonusDamagePercent[(int)type].GetValue();
        }



    }
}
