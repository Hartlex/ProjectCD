using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;


namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public abstract class Attributes
    {
        private readonly Attribute[] _attributes;

        protected Attributes(AttrProfile profile)
        {
            _attributes = new Attribute[(int) AttrType.ATTR_MAX];
            foreach (var attribute in profile.GetAttrTypes())
            {
                _attributes[(int) attribute] = new ();
            }
        }

        public Attribute this[AttrType key] => _attributes[(int)key];

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
            _attributes[(int) key].SetValue(value);
        }
        public void SetBaseValue(AttrType key, uint value)
        {
            _attributes[(int)key].SetValue(value);
        }

        public void Update()
        {
            foreach (var attribute in _attributes)
            {
                attribute.Update();
            }
        }
    }
}
