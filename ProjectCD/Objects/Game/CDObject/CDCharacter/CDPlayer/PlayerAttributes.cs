using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Formulas.Char.CommonCharacterFormulas;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private PlayerAttr _attributes;
        private uint _hp;
        private uint _mp;
        private uint _sd;
        public void PlayerAttributesInit(ref SqlDataReader reader)
        {
            uint recoverHP = 10;
            uint recoverMP = 10;
            uint recoverSD = 10;

            _attributes = new();
            var strength = unchecked((ushort) reader.GetInt16(9));
            var vitality = unchecked((ushort) reader.GetInt16(10));
            var agility = unchecked((ushort) reader.GetInt16(11));
            var intelligence = unchecked((ushort) reader.GetInt16(12));
            var spirit = unchecked((ushort) reader.GetInt16(13));
            var skillStat1 = unchecked((ushort) reader.GetInt16(14));
            var skillStat2 = unchecked((ushort) reader.GetInt16(15));


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

            _hp =  _attributes[ATTR_MAX_HP].GetValue32();
            _mp =  _attributes[ATTR_MAX_MP].GetValue32();
            _sd =  _attributes[ATTR_MAX_SD].GetValue32();

        }

        public override ushort GetSTR() { return _attributes[ATTR_STR].GetValue16(); }
        public override ushort GetVIT() { return _attributes[ATTR_VIT].GetValue16(); }
        public override ushort GetDEX() { return _attributes[ATTR_DEX].GetValue16(); }
        public override ushort GetINT() { return _attributes[ATTR_INT].GetValue16(); }
        public override ushort GetSPR() { return _attributes[ATTR_SPR].GetValue16(); ; }

        public override uint GetHP() { return _hp; }
        public override uint GetMP() { return _mp; }
        public uint GetSD() { return _sd; }

        public override uint GetMaxHP() { return _attributes[ATTR_MAX_HP].GetValue32(); }
        public override uint GetMaxMP() { return _attributes[ATTR_MAX_MP].GetValue32(); }
        public uint GetMaxSD(){ return _attributes[ATTR_MAX_SD].GetValue32(); }

        public ushort GetExpert1(){ return _attributes[ATTR_EXPERTY1].GetValue16(); }
        public ushort GetExpert2(){ return _attributes[ATTR_EXPERTY2].GetValue16(); }

        public PlayerAttr GetAttributes()
        {
            return _attributes;
        }
    }
}
