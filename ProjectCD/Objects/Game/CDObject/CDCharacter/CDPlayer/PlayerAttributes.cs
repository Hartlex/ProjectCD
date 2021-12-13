using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrCalcType;
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
            int recoverHP = 10;
            int recoverMP = 10;
            int recoverSD = 10;

            _attributes = new();
            var strength = unchecked((ushort) reader.GetInt16(9));
            var vitality = unchecked((ushort) reader.GetInt16(10));
            var agility = unchecked((ushort) reader.GetInt16(11));
            var intelligence = unchecked((ushort) reader.GetInt16(12));
            var spirit = unchecked((ushort) reader.GetInt16(13));
            var skillStat1 = unchecked((ushort) reader.GetInt16(14));
            var skillStat2 = unchecked((ushort) reader.GetInt16(15));


            _attributes[ATTR_STR][ABSOLUTE][BASE] = strength;
            _attributes[ATTR_VIT][ABSOLUTE][BASE] = vitality;
            _attributes[ATTR_DEX][ABSOLUTE][BASE] = agility;
            _attributes[ATTR_INT][ABSOLUTE][BASE] = intelligence;
            _attributes[ATTR_SPR][ABSOLUTE][BASE] = spirit;

            _attributes[ATTR_STR].Update();
            _attributes[ATTR_VIT].Update();
            _attributes[ATTR_DEX].Update();
            _attributes[ATTR_INT].Update();
            _attributes[ATTR_SPR].Update();

            _attributes[ATTR_EXPERTY1][ABSOLUTE][BASE] = skillStat1;
            _attributes[ATTR_EXPERTY2][ABSOLUTE][BASE] = skillStat2;

            _attributes[ATTR_EXPERTY1].Update();
            _attributes[ATTR_EXPERTY2].Update();

            _attributes[ATTR_RECOVERY_HP][ABSOLUTE][BASE] = recoverHP;
            _attributes[ATTR_RECOVERY_MP][ABSOLUTE][BASE] = recoverMP;
            _attributes[ATTR_RECOVERY_SD][ABSOLUTE][BASE] = recoverSD;

            _attributes[ATTR_MAX_HP][ABSOLUTE][BASE] = (int) CalcHP(GetCharType(),GetLevel(),(ushort) _attributes[(int)ATTR_VIT]);
            _attributes[ATTR_MAX_MP][ABSOLUTE][BASE] = (int) CalcMP(GetCharType(),GetLevel(),(ushort) _attributes[(int)ATTR_SPR]);
            _attributes[ATTR_MAX_SD][ABSOLUTE][BASE] = (int) CalcSD(GetLevel());




            _attributes[ATTR_RECOVERY_HP].Update();
            _attributes[ATTR_RECOVERY_MP].Update();
            _attributes[ATTR_RECOVERY_SD].Update();

            _attributes[ATTR_MAX_HP].Update();
            _attributes[ATTR_MAX_MP].Update();
            _attributes[ATTR_MAX_SD].Update();

            _hp = (uint) _attributes[(int) ATTR_MAX_HP];
            _mp = (uint)_attributes[(int)ATTR_MAX_MP];
            _sd = (uint)_attributes[(int)ATTR_MAX_SD];

        }

        public override ushort GetSTR() { return (ushort)_attributes[(int) ATTR_STR]; }
        public override ushort GetVIT() { return (ushort)_attributes[(int) ATTR_VIT]; }
        public override ushort GetDEX() { return (ushort)_attributes[(int) ATTR_DEX]; }
        public override ushort GetINT() { return (ushort)_attributes[(int) ATTR_INT]; }
        public override ushort GetSPR() { return (ushort)_attributes[(int) ATTR_SPR]; }

        public override uint GetHP() { return _hp; }
        public override uint GetMP() { return _mp; }
        public uint GetSD() { return _sd; }

        public override uint GetMaxHP() { return (uint)_attributes[(int) ATTR_MAX_HP]; }
        public override uint GetMaxMP() { return (uint)_attributes[(int) ATTR_MAX_MP]; }
        public uint GetMaxSD(){ return (uint)_attributes[(int)ATTR_MAX_SD]; }

        public ushort GetExpert1(){ return (ushort)_attributes[(int)ATTR_EXPERTY1]; }
        public ushort GetExpert2(){ return (ushort)_attributes[(int)ATTR_EXPERTY2]; }
        
    }
}
