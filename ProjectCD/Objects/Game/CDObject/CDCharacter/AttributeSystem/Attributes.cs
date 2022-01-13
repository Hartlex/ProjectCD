using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;
using static SunStructs.Definitions.AttrType;


namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public abstract class Attributes
    {
        protected readonly Attribute[] Attrs;
        protected readonly Attribute[] ReduceDefenseRate = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        protected readonly Attribute[] MagicalAttPower = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        protected readonly Attribute[] BonusDefense = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        protected readonly Attribute[] MagicalDefPower = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];
        protected readonly Attribute[] BonusDamage = new Attribute[(int )ArmorType.ARMOR_TYPE_MAX];
        protected readonly Attribute[] BonusDamagePercent = new Attribute[(int )ArmorType.ARMOR_TYPE_MAX];
        protected readonly Attribute[] ReduceDamage = new Attribute[(int )AttackType.ATTACK_TYPE_MAX];

        protected Attributes(AttrProfile profile)
        {
            Attrs = new Attribute[(int) ATTR_MAX];
            foreach (var attribute in profile.GetAttrTypes())
            {
                Attrs[(int) attribute] = new ();
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
            BonusDamage[(int) ArmorType.ARMOR_HARD] = Attrs[(int) ATTR_ADD_ARMOR_HARD_DAMAGE];
            BonusDamage[(int) ArmorType.ARMOR_MEDIUM] = Attrs[(int) ATTR_ADD_ARMOR_MEDIUM_DAMAGE];
            BonusDamage[(int) ArmorType.ARMOR_SOFT] = Attrs[(int) ATTR_ADD_ARMOR_SOFT_DAMAGE];
            BonusDamage[(int) ArmorType.ARMOR_SIEGE] = Attrs[(int) ATTR_ADD_ARMOR_SIEGE_DAMAGE];
            BonusDamage[(int) ArmorType.ARMOR_UNARMOR] = Attrs[(int) ATTR_ADD_ARMOR_UNARMOR_DAMAGE];
            
        }
        private void RegisterBonusDamageRatio()
        {
            BonusDamagePercent[(int)ArmorType.ARMOR_HARD] = Attrs[(int)ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE];
            BonusDamagePercent[(int)ArmorType.ARMOR_MEDIUM] = Attrs[(int)ATTR_ADD_RATIO_ARMOR_MEDIUM_DAMAGE];
            BonusDamagePercent[(int)ArmorType.ARMOR_SOFT] = Attrs[(int)ATTR_ADD_RATIO_ARMOR_SOFT_DAMAGE];
            BonusDamagePercent[(int)ArmorType.ARMOR_SIEGE] = Attrs[(int)ATTR_ADD_RATIO_ARMOR_SIEGE_DAMAGE];
            BonusDamagePercent[(int)ArmorType.ARMOR_UNARMOR] = Attrs[(int)ATTR_ADD_RATIO_ARMOR_UNARMOR_DAMAGE];

        }
        private void RegisterBonusDefense()
        {
            BonusDefense[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = Attrs[(int)ATTR_ADD_ALL_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_MELEE] = Attrs[(int)ATTR_ADD_MELEE_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_RANGE] = Attrs[(int)ATTR_ADD_RANGE_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_ADD_WATER_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_ADD_FIRE_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_ADD_WIND_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_ADD_EARTH_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_ADD_DARKNESS_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_ADD_DIVINE_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = Attrs[(int)ATTR_ADD_PHYSICAL_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = Attrs[(int)ATTR_ADD_MAGICAL_DEFENSE_POWER];
            BonusDefense[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = Attrs[(int)ATTR_ADD_ALL_DEFENSE_POWER];
        }
        private void RegisterMagicAttackPower()
        {
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_MAGICAL_WATER_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_MAGICAL_FIRE_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_MAGICAL_WIND_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_MAGICAL_EARTH_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_MAGICAL_DARKNESS_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_MAGICAL_DIVINE_ATTACK_POWER];
        }
        private void RegisterMagicalDefPower()
        {
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_MAGICAL_WATER_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_MAGICAL_FIRE_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_MAGICAL_WIND_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_MAGICAL_EARTH_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_MAGICAL_DARKNESS_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_MAGICAL_DIVINE_DEFENSE_POWER];
        }
        private void RegisterBonusDefenseRatio()
        {
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_MELEE] = Attrs[(int)ATTR_DEL_MELEE_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_RANGE] = Attrs[(int)ATTR_DEL_RANGE_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_DEL_DIVINE_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
            ReduceDefenseRate[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = Attrs[(int)ATTR_DEL_ALL_TARGET_DEFENSE_RATIO];
        }
        private void RegisterReduceDamage()
        {
            ReduceDamage[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = Attrs[(int)ATTR_DEL_ALL_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_MELEE] = Attrs[(int)ATTR_DEL_MELEE_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_RANGE] = Attrs[(int)ATTR_DEL_RANGE_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_DEL_WATER_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_DEL_FIRE_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_DEL_WIND_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_DEL_EARTH_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_DEL_DARKNESS_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_DEL_DIVINE_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = Attrs[(int)ATTR_DEL_PHYSICAL_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = Attrs[(int)ATTR_DEL_MAGICAL_DAMAGE];
            ReduceDamage[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = Attrs[(int)ATTR_DEL_MAGICAL_ALL_DAMAGE];
        }
        public Attribute this[AttrType key] => Attrs[(int)key];

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
            Attrs[(int) key].SetValue(value);
        }
        public void SetBaseValue(AttrType key, uint value)
        {
            Attrs[(int)key].SetValue(value);
        }

        public void SetBaseAndUpdate(AttrType key, int value)
        {
            this[key].SetValue(value);
            this[key].Update();
        }
        public abstract void Update();

        public abstract void UpdateEx();
        public void FullUpdate()
        {
            foreach (var attribute in Attrs)
            {
                attribute?.Update();
            }
        }

        public int GetBonusDamage(ArmorType type)
        {
            return BonusDamage[(int) type].GetValue();
        }

        public int GetBonusPercentDamage(ArmorType type)
        {
            return BonusDamagePercent[(int) type].GetValue();
        }

        public int GetReducePhysicalTargetDefenseRatio()
        {
            return Attrs[(int)ATTR_DEL_PHYSICAL_TARGET_DEFENSE_RATIO].GetValue();
        }

        public int GetReduceDamage(AttackType type)
        {
            return ReduceDamage[(int) type].GetValue();
        }

        public int GetMagicalAttackPower(AttackType type, AttrValueType valueType = CALC)
        {
            return MagicalAttPower[(int) type].GetValue(valueType);
        }

        public int GetMagicalDefense(AttackType attackType, AttrValueType valueType = CALC)
        {
            return MagicalDefPower[(int)attackType].GetValue(valueType);
        }

        public int GetBonusDefense(AttackType type)
        {
            return BonusDefense[(int)type].GetValue();
        }
        public int GetBonusDefenseRatio(AttackType type)
        {
            return BonusDamagePercent[(int)type].GetValue();
        }

        public void UpdateHPRecovery(int hpValue)
        {
            SetBaseAndUpdate(ATTR_RECOVERY_HP, hpValue);
        }

        public void UpdateMPRecovery(int mpValue)
        {
            SetBaseAndUpdate(ATTR_RECOVERY_MP, mpValue);
        }
        public void UpdateSDRecovery(int sdValue)
        {
            SetBaseAndUpdate(ATTR_RECOVERY_SD, sdValue);
        }
        public void UpdateChangedRecoveries(bool updateHP, int hpValue, bool updateMP, int mpValue, bool updateSD, int sdValue)
        {
            if (updateHP)
            {
                UpdateHPRecovery(hpValue);
            }

            if (updateMP)
            {
                UpdateMPRecovery(mpValue);
            }

            if (updateSD)
            {
                UpdateSDRecovery(sdValue);
            }

        }

    }
}
