

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public class AttrValue
    {
        private readonly int[] _values = new int[4];

        public void Update()
        {
            _values[3] = _values[0] + _values[1] + _values[2];
        }
        public int this[AttrValueType key]
        {
            get => _values[(int)key];
            set => _values[(int)key] = value;
        }

        public int GetValue()
        {
            return _values[(int)AttrValueType.CALC];
        }
    }
}