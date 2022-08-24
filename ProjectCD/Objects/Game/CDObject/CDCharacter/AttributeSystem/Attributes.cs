using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeUpdateType;
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

            RegisterAll();

            RegisterBonusDefenseRatio();
            RegisterBonusDefense();
            RegisterMagicAttackPower();
            RegisterMagicalDefPower();
            RegisterReduceDamage();
            RegisterBonusDamage();
            RegisterBonusDamageRatio();
        }

        private void RegisterAll()
        {
            Register(ATTR_STR,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEX,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_VIT,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_INT,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_SPR,UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_EXPERTY1,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_EXPERTY2,UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_MAX_HP,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAX_MP,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_CUR_HP,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_CUR_MP,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RECOVERY_HP,UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RECOVERY_MP,UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_BASE_MELEE_MIN_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_MELEE_MAX_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_RANGE_MIN_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_RANGE_MAX_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_MAGICAL_MIN_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_MAGICAL_MAX_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_OPTION_PHYSICAL_ATTACK_POWER, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_OPTION_MAGICAL_ATTACK_POWER, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_OPTION_ALL_ATTACK_POWER, UPDATE_TYPE_NO_RATIO);

            Register(ATTR_MAGICAL_WATER_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_FIRE_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_WIND_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_EARTH_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_DARKNESS_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_DIVINE_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_MAGICAL_ALL_ATTACK_POWER, UPDATE_TYPE_NO_RATIO);

            Register(ATTR_ADD_SKILL_ATTACK_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_SKILL_DAMAGE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_MELEE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_RANGE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BASE_MAGICAL_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_OPTION_PHYSICAL_DEFENSE_POWER, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_OPTION_MAGICAL_DEFENSE_POWER, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_OPTION_ALL_DEFENSE_POWER, UPDATE_TYPE_NO_RATIO);

            Register(ATTR_MAGICAL_WATER_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_FIRE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_WIND_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_EARTH_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_DARKNESS_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAGICAL_DIVINE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_MAGICAL_ALL_DEFENSE_POWER, UPDATE_TYPE_NO_RATIO);

            Register(ATTR_ADD_ALL_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_MELEE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_RANGE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_WATER_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_FIRE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_WIND_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_EARTH_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_DARKNESS_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_DIVINE_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_PHYSICAL_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_MAGICAL_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_MAGICAL_ALL_DEFENSE_POWER, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_DEL_ALL_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_MELEE_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_RANGE_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_WATER_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_FIRE_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_WIND_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_EARTH_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_DARKNESS_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_DIVINE_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_PHYSICAL_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_MAGICAL_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_MAGICAL_ALL_TARGET_DEFENSE_RATIO, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_ADD_ARMOR_HARD_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_ARMOR_MEDIUM_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_ARMOR_SOFT_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_ARMOR_SIEGE_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_ARMOR_UNARMOR_DAMAGE, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_ADD_RATIO_ARMOR_HARD_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_RATIO_ARMOR_MEDIUM_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_RATIO_ARMOR_SOFT_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_RATIO_ARMOR_SIEGE_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_RATIO_ARMOR_UNARMOR_DAMAGE, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_DEL_ALL_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_MELEE_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_RANGE_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_WATER_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_FIRE_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_WIND_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_EARTH_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_DARKNESS_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_DIVINE_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_PHYSICAL_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_MAGICAL_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DEL_MAGICAL_ALL_DAMAGE, UPDATE_TYPE_SUM_RATIO);


            Register(ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_MOVE_SPEED, UPDATE_TYPE_NOTHING);
            Register(ATTR_ATTACK_SPEED, UPDATE_TYPE_NOTHING);

            Register(ATTR_ALL_ATTACK_RANGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_NORMAL_ATTACK_RANGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_SKILL_ATTACK_RANGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_SIGHT_RANGE, UPDATE_TYPE_SUM_RATIO);


            Register(ATTR_CRITICAL_RATIO_CHANGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_MAGICAL_CRITICAL_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_ALL_CRITICAL_RATIO, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_CRITICAL_DAMAGE_CHANGE, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_ADD_ATTACK_INC_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_DEFENSE_INC_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_INCREASE_SKILL_LEVEL, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_DECREASE_LIMIT_STAT, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MP_SPEND_INCREASE, UPDATE_TYPE_NO_RATIO);

            Register(ATTR_ABSORB_HP, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ABSORB_MP, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_REFLECT_DAMAGE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BONUS_MONEY_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BONUS_EXP_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_AREA_ATTACK_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BONUS_CASTING_TIME, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_BONUS_SKILL_COOL_TIME, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_DECREASE_DAMAGE, UPDATE_TYPE_NO_RATIO);

            Register(ATTR_RESURRECTION_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DOUBLE_DAMAGE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_LUCKMON_INC_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_COPOSITE_INC_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_BYPASS_DEFENCE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_INCREASE_MIN_DAMAGE, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_INCREASE_MAX_DAMAGE, UPDATE_TYPE_NO_RATIO);
            Register(ATTR_DECREASE_ITEMDURA_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RESISTANCE_BADSTATUS_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_INCREASE_SKILLDURATION, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DECREASE_SKILL_SKILLDURATION, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_OPTION_ETHER_DAMAGE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_OPTION_ETHER_PvE_DAMAGE_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_INCREASE_RESERVE_HP, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_RESIST_HOLDING, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RESIST_SLEEP, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RESIST_POISON, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RESIST_KNOCKBACK, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RESIST_DOWN, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RESIST_STUN, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_DECREASE_PVPDAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ADD_DAMAGE, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_AUTO_ITEM_PICK_UP, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_INCREASE_ENCHANT_RATIO, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_MAX_SD, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_RECOVERY_SD, UPDATE_TYPE_SUM_RATIO);
            Register(ATTR_ENEMY_CRITICAL_RATIO_CHANGE, UPDATE_TYPE_SUM_RATIO);

            Register(ATTR_PREMIUMSERVICE_PCBANG, UPDATE_TYPE_SUM_RATIO);

        }

        private void Register(AttrType type, AttributeUpdateType updateType)
        {
            switch (updateType)
            {
                case UPDATE_TYPE_NOTHING:
                    Attrs[(int) type] = new NoUpdateAttribute(type);
                    return;
                case UPDATE_TYPE_NO_RATIO:
                    Attrs[(int)type] = new NoRatioAttribute(type);
                    return;
                case UPDATE_TYPE_SUM_RATIO:
                    Attrs[(int)type] = new FullUpdateAttribute(type);
                    return;
                case UPDATE_TYPE_MAX:
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(updateType), updateType, null);
            }
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
            BonusDefense[(int)AttackType.ATTACK_TYPE_MAGIC] = new ();
        }
        private void RegisterMagicAttackPower()
        {
            MagicalAttPower[(int) AttackType.ATTACK_TYPE_ALL_OPTION] = new ();
            MagicalAttPower[(int) AttackType.ATTACK_TYPE_MELEE] = new ();
            MagicalAttPower[(int) AttackType.ATTACK_TYPE_RANGE] = new();
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_MAGICAL_WATER_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_MAGICAL_FIRE_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_MAGICAL_WIND_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_MAGICAL_EARTH_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_MAGICAL_DARKNESS_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_MAGICAL_DIVINE_ATTACK_POWER];
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = new();
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = new();
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = new();
            MagicalAttPower[(int)AttackType.ATTACK_TYPE_MAGIC] = new();

        }
        private void RegisterMagicalDefPower()
        {
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_ALL_OPTION] = new();
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_MELEE] = new();
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_RANGE] = new();
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_WATER] = Attrs[(int)ATTR_MAGICAL_WATER_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_FIRE] = Attrs[(int)ATTR_MAGICAL_FIRE_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_WIND] = Attrs[(int)ATTR_MAGICAL_WIND_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_EARTH] = Attrs[(int)ATTR_MAGICAL_EARTH_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_DARKNESS] = Attrs[(int)ATTR_MAGICAL_DARKNESS_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_DIVINE] = Attrs[(int)ATTR_MAGICAL_DIVINE_DEFENSE_POWER];
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_PHYSICAL_OPTION] = new();
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_MAGIC_OPTION] = new();
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_ALL_MAGIC] = new();
            MagicalDefPower[(int)AttackType.ATTACK_TYPE_MAGIC] = new();
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
            ReduceDefenseRate[(int) AttackType.ATTACK_TYPE_MAGIC] = new();
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
            ReduceDamage[(int) AttackType.ATTACK_TYPE_MAGIC] = new();
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

        public int GetReduceDefenseRate(AttackType type)
        {
            return ReduceDefenseRate[(int) type].GetValue();
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
