
namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public class Attribute
    {
        private readonly AttrValue[] _values = new AttrValue[2];
        private int _totalValue;
        public Attribute()
        {
            _values[0] = new AttrValue();
            _values[1] = new AttrValue();
        }

        public int GetValue()
        {
            return _totalValue;
        }

        public AttrValue this[AttrCalcType key]
        {
            get { return _values[(int)key]; }
        }

        public void Update()
        {
            _values[0].Update();
            _values[1].Update();
            _totalValue = (int)(_values[0].GetValue() * ((float)(_values[1].GetValue()+100) / 100));
        }
    }
}