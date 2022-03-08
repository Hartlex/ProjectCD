using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Object.Character.Player;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Formulas.Char.CommonCharacterFormulas;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren
{
    internal class PlayerAttr : Attributes
    {
        private readonly Player _owner;
        public PlayerAttr(Player player) : base(new PlayerAttrProfile())
        {
            _owner = player;
            
        }
        
        public override void UpdateEx()
        {
            var attackSpeedRatio = _owner.GetAttSpeedRatio();
            var moveSpeedRatio = _owner.GetMoveSpeedRatio();
            var maxHP = _owner.GetMaxHP();
            var maxMP = _owner.GetMaxMP();
            var maxSD = _owner.GetMaxSD();
            var vitality = _owner.GetVIT();
            var spirit = _owner.GetSPR();

            Update();

            var changedAttackSpeedRatio = _owner.GetAttSpeedRatio();
            var changedMoveSpeedRatio = _owner.GetMoveSpeedRatio();

            if (attackSpeedRatio != changedAttackSpeedRatio)
            {
                _owner.SendAttrChange(ATTR_ATTACK_SPEED,changedAttackSpeedRatio);
            }

            if (moveSpeedRatio != changedMoveSpeedRatio)
            {
                _owner.SendAttrChange(ATTR_MOVE_SPEED,changedMoveSpeedRatio);
            }

            var changedMaxHP = _owner.GetMaxHP();
            var changedMaxMP = _owner.GetMaxMP();
            var changedMaxSD = _owner.GetMaxSD();
            bool updateHP = false;
            bool updateMP = false;
            bool updateSD = false;


            if (maxHP != changedMaxHP)
                _owner.SendAttrChange(ATTR_MAX_HP,(int) changedMaxHP);
            if (maxMP != changedMaxMP)
                _owner.SendAttrChange(ATTR_MAX_MP, (int)changedMaxMP);
            if (maxSD != changedMaxSD)
            {
                _owner.SendAttrChange(ATTR_MAX_SD, (int)changedMaxSD);
                updateSD = true;
            }

            var changeVit = _owner.GetVIT();
            var changedSpi = _owner.GetSPR();
            if (vitality != changeVit)
                updateHP = true;
            if (spirit != changedSpi)
                updateMP = true;

            _owner.UpdateCalcRecover(updateHP,updateMP,updateSD);
        }



        public sealed override void Update()
        {
            var charType = _owner.GetCharType();
            var level = _owner.GetLevel();
            
            Attrs[(int)ATTR_STR].Update();
            Attrs[(int)ATTR_VIT].Update();
            Attrs[(int)ATTR_DEX].Update();
            Attrs[(int)ATTR_INT].Update();
            Attrs[(int)ATTR_SPR].Update();
            
            Attrs[(int)ATTR_EXPERTY1].Update();
            Attrs[(int)ATTR_EXPERTY2].Update();

            Attrs[(int)ATTR_MAX_HP].SetValue(CalcHP(charType,level,Attrs[(int)ATTR_VIT].GetValue16()));
            Attrs[(int)ATTR_MAX_MP].SetValue(CalcMP(charType,level,Attrs[(int)ATTR_SPR].GetValue16()));
            Attrs[(int)ATTR_MAX_SD].SetValue(CalcSD(level));

            Attrs[(int)ATTR_MAX_HP].Update();
            Attrs[(int)ATTR_MAX_MP].Update();
            Attrs[(int)ATTR_MAX_SD].Update();

            

            UpdateAttackPower();
            UpdateDefense();

            for (int i = 0; i < (int) AttackType.ATTACK_TYPE_MAX; i++)
            {
                BonusDefense[i]?.Update();
                ReduceDamage[i]?.Update();
                ReduceDefenseRate[i]?.Update();
            }
            for (int i = (int)ArmorType.ARMOR_HARD; i < (int)ArmorType.ARMOR_TYPE_MAX; i++)
            {
                BonusDefense[i]?.Update();
                ReduceDamage[i]?.Update();
                ReduceDefenseRate[i]?.Update();
            }
            var DEX = Attrs[(int)ATTR_DEX].GetValue();

            Attrs[(int) ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO].SetValue(CalcPhysicalAttackRateBase(charType,level,DEX));
            Attrs[(int) ATTR_PHYSICAL_ATTACK_BLOCK_RATIO].SetValue(CalcPhysicalAvoidRateBase(charType,level,DEX));

            Attrs[(int)ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO].Update();
            Attrs[(int)ATTR_PHYSICAL_ATTACK_BLOCK_RATIO].Update();
            
            
            Attrs[(int)ATTR_MOVE_SPEED].Update();
            int calcValue = CalcMoveSpeedRatio(
                DEX, 
                Attrs[(int) ATTR_MOVE_SPEED].GetValue(AttrValueType.ITEM),
                Attrs[(int) ATTR_MOVE_SPEED].GetValue(AttrValueType.SKILL)
                );
            calcValue *= 100 + Attrs[(int) ATTR_MOVE_SPEED].GetValue(AttrValueType.CALC_RATIO);
            calcValue /= 100;
            Attrs[(int) ATTR_MOVE_SPEED].SetValue(calcValue, AttrValueType.CALC);

            Attrs[(int)ATTR_ATTACK_SPEED].Update();

            calcValue = CalcAttackSpeedRatio(
                charType,
                DEX,
                Attrs[(int)ATTR_ATTACK_SPEED].GetValue(AttrValueType.ITEM),
                Attrs[(int)ATTR_ATTACK_SPEED].GetValue(AttrValueType.SKILL)
            );
            calcValue *= 100 + Attrs[(int)ATTR_ATTACK_SPEED].GetValue(AttrValueType.CALC_RATIO);
            calcValue /= 100;
            Attrs[(int)ATTR_ATTACK_SPEED].SetValue(calcValue, AttrValueType.CALC);

            for (AttrValueType i = AttrValueType.ITEM; i < AttrValueType.CALC_RATIO; i++)
            {
                var value = Attrs[(int)ATTR_ALL_ATTACK_RANGE].GetValue(i);
                if (value > 0)
                {
                    Attrs[(int)ATTR_NORMAL_ATTACK_RANGE].SetValue(value, i);
                    Attrs[(int)ATTR_SKILL_ATTACK_RANGE].SetValue(value, i);
                }
            }
            Attrs[(int)ATTR_NORMAL_ATTACK_RANGE].Update();
            Attrs[(int)ATTR_SKILL_ATTACK_RANGE].Update();

            Attrs[(int)ATTR_ALL_ATTACK_RANGE].Clear();

            Attrs[(int)ATTR_SIGHT_RANGE].Update();

            var SPR = Attrs[(int)ATTR_SPR].GetValue();

            Attrs[(int) ATTR_CRITICAL_RATIO_CHANGE].SetValue(CalcPhyCriticalBaseRatio(charType, DEX));
            Attrs[(int) ATTR_ADD_MAGICAL_CRITICAL_RATIO].SetValue(CalcMagicCriticalBaseRatio(charType, SPR));

            for (AttrValueType i = AttrValueType.ITEM; i < AttrValueType.CALC_RATIO; i++)
            {
                var value = Attrs[(int)ATTR_ADD_ALL_CRITICAL_RATIO].GetValue(i);
                if (value > 0)
                {
                    Attrs[(int)ATTR_CRITICAL_RATIO_CHANGE].SetValue(value, i);
                    Attrs[(int)ATTR_ADD_MAGICAL_CRITICAL_RATIO].SetValue(value, i);
                }
            }
            Attrs[(int)ATTR_CRITICAL_RATIO_CHANGE].Update();
            Attrs[(int)ATTR_ADD_MAGICAL_CRITICAL_RATIO].Update();

            Attrs[(int)ATTR_ADD_ALL_CRITICAL_RATIO].Clear();

            Attrs[(int)ATTR_CRITICAL_DAMAGE_CHANGE].Update();

            Attrs[(int)ATTR_ADD_SKILL_ATTACK_POWER].Update();
            Attrs[(int)ATTR_ADD_SKILL_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_ABSORB_HP].Update();
            Attrs[(int)ATTR_ABSORB_MP].Update();

            Attrs[(int)ATTR_BONUS_CASTING_TIME].Update();
            Attrs[(int)ATTR_BONUS_SKILL_COOL_TIME].Update();
            Attrs[(int)ATTR_DECREASE_SKILL_SKILLDURATION].Update();
            Attrs[(int)ATTR_INCREASE_SKILLDURATION].Update();

            Attrs[(int)ATTR_ADD_ATTACK_INC_RATIO].Update();
            Attrs[(int)ATTR_ADD_DEFENSE_INC_RATIO].Update();
            Attrs[(int)ATTR_AREA_ATTACK_RATIO].Update();
            Attrs[(int)ATTR_REFLECT_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_DECREASE_DAMAGE].Update();
            Attrs[(int)ATTR_DOUBLE_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_INCREASE_MIN_DAMAGE].Update();
            Attrs[(int)ATTR_INCREASE_MAX_DAMAGE].Update();
            Attrs[(int)ATTR_ADD_DAMAGE].Update();

            Attrs[(int)ATTR_OPTION_ETHER_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_OPTION_ETHER_PvE_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_DECREASE_PVPDAMAGE].Update();
            Attrs[(int)ATTR_LUCKMON_INC_DAMAGE].Update();
            Attrs[(int)ATTR_BYPASS_DEFENCE_RATIO].Update();

            Attrs[(int)ATTR_INCREASE_RESERVE_HP].Update();
            Attrs[(int)ATTR_MP_SPEND_INCREASE].Update();
            Attrs[(int)ATTR_RESISTANCE_BADSTATUS_RATIO].Update();

            Attrs[(int)ATTR_INCREASE_SKILL_LEVEL].Update();
            Attrs[(int)ATTR_DECREASE_LIMIT_STAT].Update();
            Attrs[(int)ATTR_DECREASE_ITEMDURA_RATIO].Update();
            Attrs[(int)ATTR_BONUS_MONEY_RATIO].Update();
            Attrs[(int)ATTR_BONUS_EXP_RATIO].Update();
            Attrs[(int)ATTR_AUTO_ITEM_PICK_UP].Update();
            Attrs[(int)ATTR_INCREASE_ENCHANT_RATIO].Update();

            Attrs[(int)ATTR_RESIST_HOLDING].Update();
            Attrs[(int)ATTR_RESIST_SLEEP].Update();
            Attrs[(int)ATTR_RESIST_POISON].Update();
            Attrs[(int)ATTR_RESIST_KNOCKBACK].Update();
            Attrs[(int)ATTR_RESIST_DOWN].Update();
            Attrs[(int)ATTR_RESIST_STUN].Update();


            Attrs[(int)ATTR_PREMIUMSERVICE_PCBANG].Update();

            Attrs[(int)ATTR_ENEMY_CRITICAL_RATIO_CHANGE].Update();
            Attrs[(int)ATTR_ATTACK_DAMAGE_ABSORB_HP_RATIO].Update();
            Attrs[(int)ATTR_ATTACK_DAMAGE_ABSORB_SD_RATIO].Update();

            Attrs[(int)ATTR_CRAFT_COST_RATIO].Update();
            Attrs[(int)ATTR_CRAFT_PREVENT_EXTINCTION_MATERIAL_RATIO].Update();
            Attrs[(int)ATTR_ENCHANT_COST_RATIO].Update();
            Attrs[(int)ATTR_ENCHANT_PREVENT_DESTROY_N_DOWNGRADE_ITEM_RATIO].Update();
            Attrs[(int)ATTR_RECOVER_POTION_COOLTIME_RATIO].Update();
            Attrs[(int)ATTR_RECOVER_POTION_RECOVERY_RATIO].Update();

            Attrs[(int)ATTR_QUEST_REWARD_EXP_RATIO].Update();
            Attrs[(int)ATTR_MAX_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_DOMINATION_MAPOBJECT_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_SHOP_REPAIR_HEIM_RATIO].Update();
            Attrs[(int)ATTR_SHOP_BUY_HEIM_RATIO].Update();
            
            Attrs[(int)ATTR_DEBUFF_DURATION].SetValue(CalcDebufDuration(SPR));
            Attrs[(int)ATTR_DEBUFF_DURATION].Update();





        }

        private void UpdateAttackPower()
        {
            var charType = _owner.GetCharType();
            var DEX = Attrs[(int)ATTR_DEX].GetValue();
            var STR = Attrs[(int) ATTR_STR].GetValue();
            var INT = Attrs[(int)ATTR_INT].GetValue();

            Attrs[(int) ATTR_BASE_MELEE_MIN_ATTACK_POWER].SetValue(CalcMinMeleeAttackPower(charType,STR,DEX));
            Attrs[(int) ATTR_BASE_MELEE_MAX_ATTACK_POWER].SetValue(CalcMaxMeleeAttackPower(charType,STR,DEX));
            Attrs[(int) ATTR_BASE_RANGE_MIN_ATTACK_POWER].SetValue(CalcMinRangeAttackPower(charType,STR,DEX));
            Attrs[(int) ATTR_BASE_RANGE_MAX_ATTACK_POWER].SetValue(CalcMaxRangeAttackPower(charType,STR,DEX));
            Attrs[(int) ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].SetValue(CalcMagicAttackPower(true,INT));
            Attrs[(int) ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].SetValue(CalcMagicAttackPower(false,INT));

            Attrs[(int)ATTR_BASE_MELEE_MIN_ATTACK_POWER].Update();
            Attrs[(int)ATTR_BASE_MELEE_MAX_ATTACK_POWER].Update();
            Attrs[(int)ATTR_BASE_RANGE_MIN_ATTACK_POWER].Update();
            Attrs[(int)ATTR_BASE_RANGE_MAX_ATTACK_POWER].Update();
            Attrs[(int)ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].Update();
            Attrs[(int)ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].Update();

            for (AttrValueType i = AttrValueType.ITEM; i < AttrValueType.CALC_RATIO ; i++)
            {
                var value = Attrs[(int) ATTR_OPTION_ALL_ATTACK_POWER].GetValue(i);
                if (value > 0)
                {
                    Attrs[(int) ATTR_OPTION_PHYSICAL_ATTACK_POWER].SetValue(value,i);
                    Attrs[(int) ATTR_OPTION_MAGICAL_ATTACK_POWER].SetValue(value,i);
                }
            }

            Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].Update();
            Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].Update();
            Attrs[(int) ATTR_OPTION_ALL_ATTACK_POWER].Clear();

            var averagePhyAttackPower = (Attrs[(int) ATTR_BASE_MELEE_MIN_ATTACK_POWER].GetValue() +
                                     Attrs[(int) ATTR_BASE_MELEE_MAX_ATTACK_POWER].GetValue() +
                                     Attrs[(int) ATTR_BASE_RANGE_MIN_ATTACK_POWER].GetValue() +
                                     Attrs[(int) ATTR_BASE_RANGE_MAX_ATTACK_POWER].GetValue())/4;

            Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].AddValue(
                (averagePhyAttackPower + Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].GetValue()) *
                Attrs[(int) ATTR_OPTION_PHYSICAL_ATTACK_POWER].GetValue(AttrValueType.CALC_RATIO) /100
                ,AttrValueType.CALC);

            var averageMagicAttackPower = (Attrs[(int) ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].GetValue() +
                                          Attrs[(int) ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].GetValue())/2;

            Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].AddValue(
                (averageMagicAttackPower + Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].GetValue()) *
                Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].GetValue(AttrValueType.CALC_RATIO) / 100
                , AttrValueType.CALC);

            
            int[] values = new int[6];
            int count = 0;
            for (AttrValueType i = AttrValueType.ITEM; i <= AttrValueType.CALC_RATIO; i++)
            {
                values[count] = Attrs[(int) ATTR_MAGICAL_ALL_ATTACK_POWER].GetValue(i);
                count++;
            }

            
            for (AttackType j = AttackType.ATTACK_TYPE_WATER; j <= AttackType.ATTACK_TYPE_DARKNESS; j++)
            {
                count = 0;
                var attr = MagicalAttPower[(int)j];
                for (AttrValueType i = AttrValueType.ITEM; i <= AttrValueType.CALC_RATIO; i++)
                {
                    attr.AddValue(values[count],i);
                    count++;
                }
                attr.Update();
            }



            Attrs[(int)ATTR_MAGICAL_ALL_ATTACK_POWER].Clear();
        }

        private void UpdateDefense()
        {
            var charType = _owner.GetCharType();
            var VIT = Attrs[(int)ATTR_VIT].GetValue();
            var SPR = Attrs[(int)ATTR_SPR].GetValue();

            var physicalDefense = CalcPhyBaseDef(charType, VIT);

            Attrs[(int) ATTR_BASE_MELEE_DEFENSE_POWER].SetValue(physicalDefense);
            Attrs[(int) ATTR_BASE_RANGE_DEFENSE_POWER].SetValue(physicalDefense);
            Attrs[(int) ATTR_BASE_MAGICAL_DEFENSE_POWER].SetValue(CalcMagicBaseDef(charType,SPR));

            Attrs[(int)ATTR_BASE_MELEE_DEFENSE_POWER].Update();
            Attrs[(int)ATTR_BASE_RANGE_DEFENSE_POWER].Update();
            Attrs[(int)ATTR_BASE_MAGICAL_DEFENSE_POWER].Update();

            for (AttrValueType i = AttrValueType.ITEM; i < AttrValueType.CALC_RATIO; i++)
            {
                var value = Attrs[(int)ATTR_OPTION_ALL_DEFENSE_POWER].GetValue(i);
                if (value > 0)
                {
                    Attrs[(int)ATTR_OPTION_PHYSICAL_DEFENSE_POWER].SetValue(value, i);
                    Attrs[(int)ATTR_OPTION_MAGICAL_DEFENSE_POWER].SetValue(value, i);
                }
            }
            Attrs[(int)ATTR_OPTION_PHYSICAL_DEFENSE_POWER].Update();
            Attrs[(int)ATTR_OPTION_MAGICAL_DEFENSE_POWER].Update();
            
            Attrs[(int)ATTR_OPTION_ALL_DEFENSE_POWER].Clear();

            int averageDefPower = (Attrs[(int)ATTR_BASE_MELEE_DEFENSE_POWER].GetValue() +
                                  Attrs[(int)ATTR_BASE_RANGE_DEFENSE_POWER].GetValue())/2;

            Attrs[(int)ATTR_OPTION_PHYSICAL_DEFENSE_POWER].AddValue(
                (averageDefPower + Attrs[(int)ATTR_OPTION_PHYSICAL_DEFENSE_POWER].GetValue()) *
                Attrs[(int)ATTR_OPTION_PHYSICAL_DEFENSE_POWER].GetValue(AttrValueType.CALC_RATIO) / 100
                , AttrValueType.CALC);

            Attrs[(int)ATTR_OPTION_MAGICAL_DEFENSE_POWER].AddValue(
                (Attrs[(int)ATTR_BASE_MAGICAL_DEFENSE_POWER].GetValue() + Attrs[(int)ATTR_OPTION_MAGICAL_DEFENSE_POWER].GetValue()) *
                Attrs[(int)ATTR_OPTION_MAGICAL_DEFENSE_POWER].GetValue(AttrValueType.CALC_RATIO) / 100
                , AttrValueType.CALC);


            int[] values = new int[6];
            int count = 0;
            for (AttrValueType i = AttrValueType.ITEM; i <= AttrValueType.CALC_RATIO; i++)
            {
                values[count] = Attrs[(int)ATTR_MAGICAL_ALL_DEFENSE_POWER].GetValue(i);
                count++;
            }


            for (AttackType j = AttackType.ATTACK_TYPE_WATER; j <= AttackType.ATTACK_TYPE_DARKNESS; j++)
            {
                count = 0;
                var attr = MagicalDefPower[(int)j];
                for (AttrValueType i = AttrValueType.ITEM; i <= AttrValueType.CALC_RATIO; i++)
                {
                    attr.AddValue(values[count], i);
                    count++;
                }
                attr.Update();
            }



            Attrs[(int)ATTR_MAGICAL_ALL_ATTACK_POWER].Clear();

        }

        
    }
}
