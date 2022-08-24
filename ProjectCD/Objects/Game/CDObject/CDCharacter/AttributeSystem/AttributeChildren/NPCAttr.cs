using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Character.NPC;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Formulas.Char.CommonCharacterFormulas;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren
{
    internal class NPCAttr : Attributes
    {
        private readonly NPC _owner;
        public NPCAttr(NPC owner,int recoverHP,int recoverMP,int recoverSD) : base(new PlayerAttrProfile())
        {
            _owner = owner;
            var baseInfo = owner.GetBaseInfo();

            this[ATTR_MAX_HP].SetValue(baseInfo.MaxHP);
            this[ATTR_MAX_MP].SetValue(baseInfo.MaxMP);
            this[ATTR_MAX_SD].SetValue(baseInfo.MaxSD);

            this[ATTR_BASE_MELEE_MIN_ATTACK_POWER].SetValue(baseInfo.MinAttackPower);
            this[ATTR_BASE_MELEE_MAX_ATTACK_POWER].SetValue(baseInfo.MaxAttackPower);
            this[ATTR_BASE_RANGE_MIN_ATTACK_POWER].SetValue(baseInfo.MinAttackPower);
            this[ATTR_BASE_RANGE_MAX_ATTACK_POWER].SetValue(baseInfo.MaxAttackPower);

            this[ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].SetValue(baseInfo.MinAttackPower);
            this[ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].SetValue(baseInfo.MaxAttackPower);

            this[ATTR_BASE_MELEE_DEFENSE_POWER].SetValue(baseInfo.PhysicalDef);
            this[ATTR_BASE_RANGE_DEFENSE_POWER].SetValue(baseInfo.PhysicalDef);
            this[ATTR_BASE_MAGICAL_DEFENSE_POWER].SetValue(baseInfo.MagicalDef);

            MagicalDefPower[(int) AttackType.ATTACK_TYPE_WATER].SetValue(baseInfo.WaterResist);
            MagicalDefPower[(int) AttackType.ATTACK_TYPE_FIRE].SetValue(baseInfo.FireResist);
            MagicalDefPower[(int) AttackType.ATTACK_TYPE_WIND].SetValue(baseInfo.WindResist);
            MagicalDefPower[(int) AttackType.ATTACK_TYPE_EARTH].SetValue(baseInfo.EarthResist);

            this[ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO].SetValue(baseInfo.PhysicalAttRate);
            this[ATTR_PHYSICAL_ATTACK_BLOCK_RATIO].SetValue((int) baseInfo.PhysicalAvoidRate);

            this[ATTR_CRITICAL_RATIO_CHANGE].SetValue(baseInfo.CriticalRatio);
            this[ATTR_ADD_MAGICAL_CRITICAL_RATIO].SetValue(baseInfo.CriticalRatio);

            //this[ATTR_SIGHT_RANGE].SetValue((int) (baseInfo.ViewRange *10));
            this[ATTR_SIGHT_RANGE].SetValue((int) (baseInfo.ViewRange));

            this[ATTR_RECOVERY_HP].SetValue(recoverHP);
            this[ATTR_RECOVERY_MP].SetValue(recoverMP);
            this[ATTR_RECOVERY_SD].SetValue(recoverSD);


        }

        public override void Update()
        {
            this[ATTR_MAX_HP].Update();
            this[ATTR_MAX_MP].Update();
            this[ATTR_MAX_SD].Update();
            this[ATTR_RECOVERY_HP].Update();
            this[ATTR_RECOVERY_MP].Update();
            this[ATTR_RECOVERY_SD].Update();

            UpdateAttackPower();
            UpdateDefense();

            Attrs[(int)ATTR_MOVE_SPEED].Update();
            int calcValue = CalcMoveSpeedRatio(
                0,
                0,
                Attrs[(int)ATTR_MOVE_SPEED].GetValue(AttrValueType.SKILL)
            );
            calcValue *= 100 + Attrs[(int)ATTR_MOVE_SPEED].GetValue(AttrValueType.CALC_RATIO);
            calcValue /= 100;
            Attrs[(int)ATTR_MOVE_SPEED].SetValue(calcValue, AttrValueType.CALC);

            Attrs[(int)ATTR_ATTACK_SPEED].Update();
            calcValue = CalcAttackSpeedRatio(
                0,
                0,
                0,
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

            Attrs[(int) ATTR_ADD_ALL_CRITICAL_RATIO].Update();
            Attrs[(int) ATTR_CRITICAL_RATIO_CHANGE].Update();
            Attrs[(int)ATTR_CRITICAL_RATIO_CHANGE].AddValue(Attrs[(int)ATTR_CRITICAL_RATIO_CHANGE].GetValue());

            Attrs[(int)ATTR_CRITICAL_DAMAGE_CHANGE].Update();

            Attrs[(int)ATTR_ADD_SKILL_ATTACK_POWER].Update();
            Attrs[(int)ATTR_ADD_SKILL_DAMAGE_RATIO].Update();

            Attrs[(int)ATTR_ABSORB_HP].Update();
            Attrs[(int)ATTR_ABSORB_MP].Update();

            Attrs[(int)ATTR_ADD_ATTACK_INC_RATIO].Update();
            Attrs[(int)ATTR_ADD_DEFENSE_INC_RATIO].Update();
            Attrs[(int)ATTR_AREA_ATTACK_RATIO].Update();
            Attrs[(int)ATTR_REFLECT_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_DECREASE_DAMAGE].Update();
            Attrs[(int)ATTR_DOUBLE_DAMAGE_RATIO].Update();
            Attrs[(int)ATTR_INCREASE_MIN_DAMAGE].Update();
            Attrs[(int)ATTR_INCREASE_MAX_DAMAGE].Update();

            Attrs[(int)ATTR_DECREASE_PVPDAMAGE].Update();
            Attrs[(int)ATTR_BYPASS_DEFENCE_RATIO].Update();
            Attrs[(int)ATTR_RESISTANCE_BADSTATUS_RATIO].Update();
            Attrs[(int)ATTR_INCREASE_SKILL_LEVEL].Update();

            Attrs[(int)ATTR_RESIST_HOLDING].Update();
            Attrs[(int)ATTR_RESIST_SLEEP].Update();
            Attrs[(int)ATTR_RESIST_POISON].Update();
            Attrs[(int)ATTR_RESIST_KNOCKBACK].Update();
            Attrs[(int)ATTR_RESIST_DOWN].Update();
            Attrs[(int)ATTR_RESIST_STUN].Update();

        }

        private void UpdateDefense()
        {

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
                                   Attrs[(int)ATTR_BASE_RANGE_DEFENSE_POWER].GetValue()) / 2;

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

        private void UpdateAttackPower()
        {
            this[ATTR_BASE_MELEE_MIN_ATTACK_POWER].Update();
            this[ATTR_BASE_MELEE_MAX_ATTACK_POWER].Update();
            this[ATTR_BASE_RANGE_MIN_ATTACK_POWER].Update();
            this[ATTR_BASE_RANGE_MAX_ATTACK_POWER].Update();

            this[ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].Update();
            this[ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].Update();

            for (AttrValueType i = AttrValueType.ITEM; i < AttrValueType.CALC_RATIO; i++)
            {
                var value = Attrs[(int)ATTR_OPTION_ALL_ATTACK_POWER].GetValue(i);
                if (value > 0)
                {
                    Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].SetValue(value, i);
                    Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].SetValue(value, i);
                }
            }

            Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].Update();
            Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].Update();
            Attrs[(int)ATTR_OPTION_ALL_ATTACK_POWER].Clear();

            var averagePhyAttackPower = (Attrs[(int)ATTR_BASE_MELEE_MIN_ATTACK_POWER].GetValue() +
                                         Attrs[(int)ATTR_BASE_MELEE_MAX_ATTACK_POWER].GetValue() +
                                         Attrs[(int)ATTR_BASE_RANGE_MIN_ATTACK_POWER].GetValue() +
                                         Attrs[(int)ATTR_BASE_RANGE_MAX_ATTACK_POWER].GetValue()) / 4;

            Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].AddValue(
                (averagePhyAttackPower + Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].GetValue()) *
                Attrs[(int)ATTR_OPTION_PHYSICAL_ATTACK_POWER].GetValue(AttrValueType.CALC_RATIO) / 100
                , AttrValueType.CALC);

            var averageMagicAttackPower = (Attrs[(int)ATTR_BASE_MAGICAL_MIN_ATTACK_POWER].GetValue() +
                                           Attrs[(int)ATTR_BASE_MAGICAL_MAX_ATTACK_POWER].GetValue()) / 2;

            Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].AddValue(
                (averageMagicAttackPower + Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].GetValue()) *
                Attrs[(int)ATTR_OPTION_MAGICAL_ATTACK_POWER].GetValue(AttrValueType.CALC_RATIO) / 100
                , AttrValueType.CALC);

            int[] values = new int[6];
            int count = 0;
            for (AttrValueType i = AttrValueType.ITEM; i <= AttrValueType.CALC_RATIO; i++)
            {
                values[count] = Attrs[(int)ATTR_MAGICAL_ALL_ATTACK_POWER].GetValue(i);
                count++;
            }
            for (AttackType j = AttackType.ATTACK_TYPE_WATER; j <= AttackType.ATTACK_TYPE_DARKNESS; j++)
            {
                count = 0;
                var attr = MagicalAttPower[(int)j];
                for (AttrValueType i = AttrValueType.ITEM; i <= AttrValueType.CALC_RATIO; i++)
                {
                    attr.AddValue(values[count], i);
                    count++;
                }
                attr.Update();
            }

            Attrs[(int)ATTR_MAGICAL_ALL_ATTACK_POWER].Clear();
        }

        public override void UpdateEx()
        {
            var attackSpeedRatio = _owner.GetAttSpeedRatio();
            var moveSpeedRatio = _owner.GetMoveSpeedRatio();
            var maxHP = _owner.GetMaxHP();
            var maxMP = _owner.GetMaxMP();

            Update();

            if (attackSpeedRatio != _owner.GetAttSpeedRatio())
            {
                _owner.SendAttrChange(ATTR_ATTACK_SPEED,_owner.GetAttSpeedRatio());
            }

            if (moveSpeedRatio != _owner.GetMoveSpeedRatio())
            {
                _owner.SendAttrChange(ATTR_MOVE_SPEED,_owner.GetMoveSpeedRatio());
            }

            if (maxHP != _owner.GetMaxHP())
            {
                _owner.SendAttrChange(ATTR_MAX_HP,(int) _owner.GetMaxHP());
            }

            if (maxMP != _owner.GetMaxMP())
            {
                _owner.SendAttrChange(ATTR_MAX_MP,(int) _owner.GetMaxMP());
            }


        }


    }
}
