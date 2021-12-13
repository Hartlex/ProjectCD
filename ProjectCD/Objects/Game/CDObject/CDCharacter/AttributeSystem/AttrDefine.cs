namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem
{
    public class AttrDefine
    {
        public const int BASE_ATTR_COUNT = 9;
    }
    public enum AttrValueType
    {
        BASE,
        ITEM,
        SKILL,
        CALC
    }

    public enum AttrCalcType
    {
        ABSOLUTE,
        PERCENT
    }

}
