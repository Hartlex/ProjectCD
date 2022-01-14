using SunStructs.ServerInfos.General.Object.Items;
using SunStructs.ServerInfos.General.Skill;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.StateSystem.GeneralStatusFlags;
using static SunStructs.Definitions.AbilityRangeType;
using static SunStructs.Definitions.SkillTargetType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.StateSystem;


public class GeneralStatusFlag
{
    private uint _flags;
    private MatchCheckCodeFilters? _filters;

    public GeneralStatusFlag()
    {
        _flags = (uint) DISABLE_ALL;
        _filters = null;
    }

    #region Getters

    public uint GetFlags() { return _flags; }
    public bool IsDragonTransforming(){ return (_flags &  (uint) ENABLE_DRAGON_TRANSFORMING)  !=0; }
    public bool IsGMTransOn() { return (_flags & (uint)ENABLE_GM_TRANSPARENT) != 0; }
    public bool IsPlayerTransOn() { return (_flags & (uint)ENABLE_CHARACTER_TRANSPARENT) != 0; }
    public bool IsRidingRider() { return (_flags & (uint)ENABLE_SUMMONED_AND_RIDING) != 0; }
    public bool IsObserverModeOn() { return (_flags & (uint)ENABLE_OBSERVER_MODE) != 0; }
    public bool IsSpreadWings() { return (_flags & (uint)ENABLE_SPREAD_WINGS) != 0; }

    public bool IsPassConstraints(Character character, BaseSkillInfo info)
    {
        var checkingField = (uint)ENABLE_ONLY_SKILL_TARGET_ME | (uint)ENABLE_FILTER_SKILL_GROUP | (uint)ENABLE_FILTER_ITEM_TYPE;

        return (checkingField & _flags) == 0 || _IsPassConstraint(character, info);
    }

    public bool IsPassConstraints(Character character, BaseAbilityInfo info)
    {
        var checkingField = (uint) ENABLE_ONLY_SKILL_TARGET_ME;

        return (checkingField & _flags) == 0 || _IsPassConstraint(character, info);
    }

    public bool IsPassConstraints(Character character, BaseItemInfo info)
    {
        var checkingField = (uint)ENABLE_ONLY_SKILL_TARGET_ME | (uint)ENABLE_FILTER_SKILL_GROUP | (uint)ENABLE_FILTER_ITEM_TYPE;

        return (checkingField & _flags) == 0 || _IsPassConstraint(character, info);
    }

    #endregion

    #region Setters

    public void AddFlag(uint flag)
    {
        _flags |= flag;
    }

    public void SetAllFlags(uint flag)
    {
        _flags = flag;
    }

    public void RemoveFlag(uint flag)
    {
        _flags ^= flag;
    }

    #endregion


    #region Events

    public void OnDragonTransformation(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint) ENABLE_DRAGON_TRANSFORMING : _flags ^ (uint)ENABLE_DRAGON_TRANSFORMING;
    }
    public void OnGMTransOn(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint)ENABLE_GM_TRANSPARENT : _flags ^ (uint)ENABLE_GM_TRANSPARENT;
    }
    public void OnGMUndeadOn(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint)ENABLE_GM_UNDEAD : _flags ^ (uint)ENABLE_GM_UNDEAD;
    }
    public void OnCharTransOn(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint)ENABLE_CHARACTER_TRANSPARENT : _flags ^ (uint)ENABLE_CHARACTER_TRANSPARENT;
    }
    public void OnGMMaxDamageOn(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint)ENABLE_GM_MAX_DAMAGE : _flags ^ (uint)ENABLE_GM_MAX_DAMAGE;
    }
    public void OnGMMaxExpOn(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint)ENABLE_GM_MAX_EXP : _flags ^ (uint)ENABLE_GM_MAX_EXP;
    }
    public void OnGMDropListAllOn(bool turnOn)
    {
        _flags = turnOn ? _flags | (uint)ENABLE_GM_DROP_LIST_ALL : _flags ^ (uint)ENABLE_GM_DROP_LIST_ALL;
    }

    public void OnFilterControl(bool isRestrictSkillTargetOnlyMe, bool isRestrictUseSkillGroupUseItemType,
        MatchCheckCodeFilters filters)
    {
        _flags = isRestrictSkillTargetOnlyMe ? _flags | (uint)ENABLE_ONLY_SKILL_TARGET_ME : _flags ^ (uint)ENABLE_ONLY_SKILL_TARGET_ME;
        _flags = isRestrictUseSkillGroupUseItemType ? 
            _flags | ((uint)ENABLE_FILTER_SKILL_GROUP   | (uint)ENABLE_FILTER_ITEM_TYPE): 
            _flags ^ ((uint)ENABLE_ONLY_SKILL_TARGET_ME | (uint)ENABLE_FILTER_ITEM_TYPE);
        _filters = filters;
    }

    #endregion

    #region Private

    private bool _IsPassConstraint(Character character, BaseSkillInfo info)
    {
        if ((_flags & (uint) ENABLE_ONLY_SKILL_TARGET_ME) != 0)
        {
            var targetType = info.Target;
            return targetType is (byte)SKILL_TARGET_FRIEND 
                              or (byte)SKILL_TARGET_ME
                              or (byte)SKILL_TARGET_REACHABLE_FRIEND 
                              or (byte)SKILL_TARGET_REACHABLE_ME;
        }

        if (_filters == null) return true;
        if ((_flags & (uint) ENABLE_FILTER_SKILL_GROUP) == 0) return true;

        return !_filters.DoesSkillFilterExist(info.SkillClassCode);
    }

    private bool _IsPassConstraint(Character character, BaseAbilityInfo info)
    {
        if ((_flags & (uint) ENABLE_ONLY_SKILL_TARGET_ME) == 0) return true;
        var targetType = info.RangeType;
        return targetType is (byte) SKILL_ABILITY_FRIEND
                          or (byte) SKILL_ABILITY_MYAREA_FRIEND
                          or (byte) SKILL_ABILITY_ME;

    }

    private bool _IsPassConstraint(Character character, BaseItemInfo info)
    {
        if(_filters==null) return true;

        if ((_flags & (uint) ENABLE_FILTER_ITEM_TYPE) == 0) return true;
        return !_filters.DoesItemFilterExist((ushort) info.ItemType);
    }
    #endregion
}
public enum GeneralStatusFlags : uint
{
    DISABLE_ALL = 0,
    ENABLE_GM_UNDEAD = 1 << 3, // GM ÇÃ·¹ÀÌ¾î '¹«Àû ÄÔ' »óÅÂ
    ENABLE_GM_TRANSPARENT = 1 << 4, // GM ÇÃ·¹ÀÌ¾î 'Åõ¸í ÄÔ' »óÅÂ
    ENABLE_DRAGON_TRANSFORMING = 1 << 5, // µå·¡°ï³ªÀÌÆ® Àü¿ë ÇÊµå, µå·¡°ï º¯½ÅÁßÀÎ »óÅÂ
    //__NA_S00015_20080828_NEW_HOPE_SHADOW
    ENABLE_CHARACTER_TRANSPARENT = 1 << 6, // Ä³¸¯ÅÍ 'Åõ¸í(Àº½Å)' »óÅÂ
    //__NA_01240_GM_CMD_ADD_SERVER_TIME
    ENABLE_GM_MAX_DAMAGE = 1 << 7,
    ENABLE_GM_MAX_EXP = 1 << 8,
    ENABLE_GM_DROP_LIST_ALL = 1 << 9,
    //__NA001390_090915_RIDING_SYSTEM__
    ENABLE_SUMMONED_AND_RIDING = 1 << 10, // Rider Summoned + Riding Status
    ENABLE_NON_PREEMPTIVE_ATTACK = 1 << 11, // ¸ó½ºÅÍ ºñ¼±°ø »óÅÂ, Å¸ÄÏ¿¡ ÀâÈ÷Áö ¾Ê´Â´Ù. // _NA001385_20090924_DOMINATION_ETC
    ENABLE_SPREAD_WINGS = 1 << 12, // CHANGES: f110315.2L, whether a player spread winds.
    //  (Special Control) - Å¸¶ôÇÑ »ç¿ø¿ëÀ¸·Î Æ¯¼ö Ãß°¡µÊ, ÀÌÈÄ ´Ù¸¥ ¿ëµµ·Î »ç¿ëÇÒ ¼ö¾ß ÀÖ°ÚÁö¸¸...
    ENABLE_OBSERVER_MODE = 1 << 25, // °üÀü ¸ðµå...__NA001187_081015_SSQ_OBSERVER_MODE__
    ENABLE_ONLY_SKILL_TARGET_ME = 1 << 26, // eSKILL_TARGET_TYPE Á¦¾à, ÀÚ½Å¸¸ Çã¿ë °¡´É »óÅÂ, Á¤Ã¥¿¡ ÀÇÇÑ Ã³¸® ¸ñÀû
    ENABLE_FILTER_SKILL_GROUP = 1 << 28, // ½ºÅ³ »ç¿ë Á¦¾à °É¸° »óÅÂ, Skill Group Array °Ë»ç ÇÊ¿ä
    ENABLE_FILTER_ITEM_TYPE = 1 << 29, // ¾ÆÀÌÅÛ Å¸ÀÔ »ç¿ë Á¦¾à °É¸° »óÅÂ, Item Type Array °Ë»ç ÇÊ¿ä
};

public class MatchCheckCodeFilters
{
    private List<ushort> _skillFilters;
    private List<ushort> _itemFilters;

    public MatchCheckCodeFilters()
    {
        _skillFilters = new(100);
        _itemFilters = new(100);
    }
    public bool DoesSkillFilterExist(ushort code)
    {
        return _skillFilters.Contains(code);
    }
    public bool DoesItemFilterExist(ushort code)
    {
        return _itemFilters.Contains(code);
    }
}