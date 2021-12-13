

using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public class Attribute
    {
        private readonly int[] _values = new int[7];

        public void Update()
        {
            UpdateAll();
        }

        public uint GetValue32(AttrValueType type= CALC)
        {
            return (uint) _values[(int) CALC];
        }
        public ushort GetValue16(AttrValueType type = CALC)
        {
            return (ushort) _values[(int) CALC];
        }

        public int GetValues(AttrValueType type = CALC)
        {
            return _values[(int)CALC];
        }
        public void SetValue(ushort value,AttrValueType type = BASE)
        {
            _values[(int) type] = value;
        }
        public void SetValue(uint value, AttrValueType type = BASE)
        {
            _values[(int)type] = (int) value;
        }

        private void UpdateAbsValues()
        {
            _values[(int) CALC] = _values[(int) BASE] + _values[(int) ITEM] + _values[(int) SKILL];
        }
        private void UpdateRatValues()
        {
            _values[(int) CALC_RATIO] = _values[(int) ITEM_RATIO] + _values[(int) SKILL_RATIO];
        }
        private void UpdateAll()
        {
            UpdateAbsValues();
            UpdateRatValues();
            _values[(int) CALC] += _values[(int) CALC_RATIO] * _values[(int) CALC] / 10000; //100 = 10%
        }

    }



}