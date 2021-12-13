using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrCalcType;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrValueType;
using Attribute = ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.Attribute;

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

        public int this[int key]
        {
            get => _attributes[key].GetValue();
            set => _attributes[key][ABSOLUTE][BASE] = value;
        }
        public int GetValue(AttrType key)
        {
            return this[key].GetValue();
        }

        public void SetBaseValue(AttrType key, int value)
        {
            _attributes[(int) key][ABSOLUTE][BASE] = value;
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
