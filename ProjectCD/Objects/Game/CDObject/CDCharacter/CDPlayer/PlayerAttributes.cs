using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.Packets.GameServerPackets.Status;
using static CDShared.Generics.SunCalc;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Definitions.Const;
using static SunStructs.Formulas.Char.CommonCharacterFormulas;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private PlayerAttr _attributes;

        public void PlayerAttributesInit(ref SqlDataReader reader)
        {
            _attributes = new(this);
            SetBaseAttributes(_attributes);
            var strength = unchecked((ushort) reader.GetInt16(9));
            var vitality = unchecked((ushort) reader.GetInt16(10));
            var agility = unchecked((ushort) reader.GetInt16(11));
            var intelligence = unchecked((ushort) reader.GetInt16(12));
            var spirit = unchecked((ushort) reader.GetInt16(13));
            var skillStat1 = unchecked((ushort) reader.GetInt16(14));
            var skillStat2 = unchecked((ushort) reader.GetInt16(15));

            var charType = GetCharType();
            var condition = StatusManager.GetCondition();
            var level = GetLevel();

            var recoverHP = CalcHPRecover(charType, vitality, condition, level);
            var recoverMP = CalcMPRecover(charType, spirit, condition);
            var recoverSD = CalcSDRecover(charType,condition,Const.CHAR_ACTION_CONDITION_NONE,level);


            _attributes[ATTR_STR].SetValue(strength);
            _attributes[ATTR_VIT].SetValue(vitality);
            _attributes[ATTR_DEX].SetValue(agility);
            _attributes[ATTR_INT].SetValue(intelligence);
            _attributes[ATTR_SPR].SetValue(spirit);

            _attributes[ATTR_STR].Update();
            _attributes[ATTR_VIT].Update();
            _attributes[ATTR_DEX].Update();
            _attributes[ATTR_INT].Update();
            _attributes[ATTR_SPR].Update();

            _attributes[ATTR_EXPERTY1].SetValue(skillStat1);
            _attributes[ATTR_EXPERTY2].SetValue(skillStat2);

            _attributes[ATTR_EXPERTY1].Update();
            _attributes[ATTR_EXPERTY2].Update();

            _attributes[ATTR_RECOVERY_HP].SetValue(recoverHP);
            _attributes[ATTR_RECOVERY_HP].SetValue(recoverMP);
            _attributes[ATTR_RECOVERY_HP].SetValue(recoverSD);
;

            _attributes[ATTR_MAX_HP].SetValue(CalcHP(GetCharType(),GetLevel(), _attributes[ATTR_VIT].GetValue16()));
            _attributes[ATTR_MAX_MP].SetValue(CalcMP(GetCharType(),GetLevel(), _attributes[ATTR_SPR].GetValue16()));
            _attributes[ATTR_MAX_SD].SetValue(CalcSD(GetLevel()));





            _attributes[ATTR_RECOVERY_HP].Update();
            _attributes[ATTR_RECOVERY_MP].Update();
            _attributes[ATTR_RECOVERY_SD].Update();

            _attributes[ATTR_MAX_HP].Update();
            _attributes[ATTR_MAX_MP].Update();
            _attributes[ATTR_MAX_SD].Update();

            SetHP(_attributes[ATTR_MAX_HP].GetValue());
            SetMP(_attributes[ATTR_MAX_MP].GetValue());
            SetSD(_attributes[ATTR_MAX_SD].GetValue());

            _attributes.Update();

            if (charType == CharType.CHAR_BERSERKER)
            {
                SetMP(0);

                SendPacket(new StatusRecoverMpBrd(new (GetKey(),(uint) GetMP())));
            }

        }

        public ushort GetSTR() { return _attributes[ATTR_STR].GetValue16(); }
        public ushort GetVIT() { return _attributes[ATTR_VIT].GetValue16(); }
        public ushort GetDEX() { return _attributes[ATTR_DEX].GetValue16(); }
        public ushort GetINT() { return _attributes[ATTR_INT].GetValue16(); }
        public ushort GetSPR() { return _attributes[ATTR_SPR].GetValue16(); }
        public ushort GetExpert1(){ return _attributes[ATTR_EXPERTY1].GetValue16(); }
        public ushort GetExpert2(){ return _attributes[ATTR_EXPERTY2].GetValue16(); }

        public override int GetMPSpendIncValue()
        {
            return _attributes[ATTR_MP_SPEND_INCREASE].GetValue();
        }

        public override float GetMPSpendIncRatio()
        {
            return _attributes[ATTR_MP_SPEND_INCREASE].GetValue() / 100f;
        }

        public override int GetSkillRangeBonus()
        {
            return _attributes[ATTR_SKILL_ATTACK_RANGE].GetValue() / 10;
        }

        public override int GetSkillRangeBonusRatio()
        {
            return _attributes[ATTR_SKILL_ATTACK_RANGE].GetValue();
        }

        public override PlayerAttr GetAttributes()
        {
            return _attributes;
        }

        public override int GetPhysicalAvoidValue()
        {
            return GetLevel() / 5 + _attributes[ATTR_PHYSICAL_ATTACK_BLOCK_RATIO].GetValue();
        }

        public override void UpdateCalcRecover(bool hpUpdated, bool mpUpdated, bool sdUpdated)
        {
            var charType = GetCharType();
            var condition = StatusManager.GetCondition();

            int hpRecover = 0;
            int mpRecover = 0;
            int sdRecover = 0;

            if (hpUpdated)
            {
                var vit = GetVIT();
                hpRecover = CalcHPRecover(charType, vit, condition, GetLevel());
            }

            if (mpUpdated)
            {
                var spi = GetSPR();
                mpRecover = CalcMPRecover(charType, spi, condition);
            }

            if (sdUpdated)
            {
                byte moveFlag = IsMoving() ? CHAR_ACTION_CONDITION_MOVING : CHAR_ACTION_CONDITION_NONE;
                byte fightFlag = StatusManager.FindStatus(CharStateType.CHAR_STATE_FIGHTING) ? CHAR_ACTION_CONDITION_FIGHTING : CHAR_ACTION_CONDITION_NONE;

                sdRecover = CalcSDRecover(charType, condition, (moveFlag | fightFlag), GetLevel());
            }

            if (hpUpdated || mpUpdated || sdUpdated)
            {
                _attributes.UpdateChangedRecoveries(
                        hpUpdated,hpRecover,
                        mpUpdated,mpRecover,
                        sdUpdated,sdRecover
                );
            }
        }
    }
}
