

using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using CDShared.Logging;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public class Attribute
    {
        private readonly int[] _values = new int[7];
        private readonly AttrType _type = AttrType.ATTR_TYPE_INVALID;
        public Attribute(){}
        public Attribute(AttrType type)
        {
            _type = type;
        }
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

        public int GetValue(AttrValueType type = CALC)
        {
            return _values[(int)CALC];
        }

        public int GetRatio()
        {
            return _values[(int) CALC_RATIO];
        }

        public void AddValue(int value, AttrValueType type = BASE)
        {
            if (value == 0) return;
            //Logger.Instance.Log($"[{_type}] added value [{type}][{value}] oldValue[{_values[(int)type]}] newValue[{_values[(int)type] + value}]");
            _values[(int) type] += value;
        }
        public void SubtractValue(int value, AttrValueType type = BASE)
        {
            if (value == 0) return;

            //Logger.Instance.Log($"[{_type}] subtract value [{type}][{value}] oldValue[{_values[(int)type]}] newValue[{_values[(int)type] - value}]");

            _values[(int)type] -= value;
        }
        public void SetValue(int value, AttrValueType type = BASE)
        {
            //Logger.Instance.Log($"[{_type}] set value [{type}][{value}] oldValue[{_values[(int)type]}] newValue[{value}]");

            _values[(int) type] = value;
        }
        public void SetValue(ushort value,AttrValueType type = BASE)
        {
            //Logger.Instance.Log($"[{_type}] set value [{type}][{value}] oldValue[{_values[(int)type]}] newValue[{value}]");

            _values[(int) type] = value;
        }
        public void SetValue(uint value, AttrValueType type = BASE)
        {
            //Logger.Instance.Log($"[{_type}] set value [{type}][{value}] oldValue[{_values[(int)type]}] newValue[{value}]");

            _values[(int)type] = (int) value;
        }

        private void UpdateAbsValues()
        {
            _values[(int) CALC] = _values[(int) BASE] + _values[(int) ITEM] + _values[(int) SKILL];
        }
        private void UpdateRatValues()
        {
            _values[(int) CALC_RATIO] =  _values[(int) ITEM_RATIO] + _values[(int) SKILL_RATIO];
        }
        private void UpdateAll()
        {
            UpdateAbsValues();
            UpdateRatValues();
            //_values[(int) CALC] += _values[(int) CALC_RATIO] * _values[(int) CALC]+100 / 100; //100 = 10%
        }
        public void Clear()
        {
            for (int i = 0; i < _values.Length; i++)
            {
                _values[i] = 0;
            }
        }
    }

    public enum AttributeUpdateType
    {
        UPDATE_TYPE_NOTHING,
        UPDATE_TYPE_NO_RATIO,
        UPDATE_TYPE_SUM_RATIO,
        UPDATE_TYPE_MAX
    }


}