using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using ProjectCD.Objects.Game.Slots.Quick;
using ProjectCD.Objects.Game.Slots.Skill;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.PacketInfos.Game.Style.Server;
using SunStructs.Packets.GameServerPackets.Style;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Definitions.AttrValueKind;
using static SunStructs.Definitions.CharType;
using static SunStructs.Definitions.ItemType;
using static SunStructs.Definitions.SkillResult;
using static SunStructs.Definitions.SkillType;
using static SunStructs.Definitions.StyleEnum;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.SkillMan
{
    internal class PlayerSkillManager
    {
        private Player _owner;
        private SkillContainer _skillContainer;
        private QuickSlotContainer _quickContainer;
        private BaseStyleInfo _selectedStyle;

        private Dictionary<ushort, Skill> _passiveSkillList = new Dictionary<ushort, Skill>();

        public PlayerSkillManager(Player owner, SkillContainer skillContainer, QuickSlotContainer quickContainer, ushort styleCode)
        {
            _owner = owner;
            _skillContainer = skillContainer;
            _quickContainer = quickContainer;
            _selectedStyle = BaseSkillDB.Instance.GetBaseStyleInfo(styleCode);

            foreach (var passiveSkillInfo in skillContainer.GetPassiveSkills())
            {
                AddAttrForPassiveSkill(passiveSkillInfo);
            }

        }

        public void UpdatePassiveSkillList()
        {
            foreach (var skill in _passiveSkillList.Values.ToList())
            {
                if (_owner.CanApplyPassiveSkill(skill.GetBaseSkillInfo()!))
                    skill.StartExecute();
                else
                    skill.EndExecute();
            }
        }

        public int GetCurrentStyleCode(){ return _selectedStyle.SkillCode; }

        #region LearnSkills
  
        public SkillResult CanLearnSkill(BaseSkillInfo newSkillInfo)
        {
            if (_owner.GetSkillPoints() < newSkillInfo.RequireSkillPoint) return RC_SKILL_REMAIN_SKILLPOINT_LACK;
            if (_owner.GetLevel() < newSkillInfo.RequireLevel) return RC_SKILL_REQUIRE_LEVEL_LIMIT;
            if (_owner.GetAttributes()[ATTR_EXPERTY1].GetValue() < newSkillInfo.RequireSkillStat[0])
                return RC_SKILL_REQUIRE_SKILLSTAT_LIMIT;
            if (_owner.GetAttributes()[ATTR_EXPERTY2].GetValue() < newSkillInfo.RequireSkillStat[1])
                return RC_SKILL_REQUIRE_SKILLSTAT_LIMIT;

            return RC_SKILL_SUCCESS;
        }

        public SkillResult CanLearnStyle(BaseStyleInfo newStyleInfo)
        {

            if (_owner.GetSkillPoints() < newStyleInfo.RequireSkillPoint) return RC_SKILL_REMAIN_SKILLPOINT_LACK;
            if (_owner.GetLevel() < newStyleInfo.RequireLevel) return RC_SKILL_REQUIRE_LEVEL_LIMIT;

            return RC_SKILL_SUCCESS;
        }
        private SkillResult CanLearnSkill(BaseSkillInfo oldSkillInfo, BaseSkillInfo newSkillInfo)
        {

            if (_skillContainer.TryGetSkillSlot(newSkillInfo.SkillClassCode, out var slot))
            {
                if (oldSkillInfo.SkillLevel >= newSkillInfo.SkillLevel)
                    return RC_SKILL_ALREADY_EXIST_SKILL;
            }

            return CanLearnSkill(newSkillInfo);
        }
        private SkillResult CanLearnStyle(BaseStyleInfo oldStyleInfo, BaseStyleInfo newStyleInfo)
        {
            if (_skillContainer.TryGetSkillSlot(oldStyleInfo.SkillClassCode, out var slot))
            {
                if (oldStyleInfo.StyleLevel >= newStyleInfo.StyleLevel)
                    return RC_SKILL_ALREADY_EXIST_SKILL;
            }

            return CanLearnStyle(newStyleInfo);
        }

        public SkillResult CanLevelUpSkill(ushort skillCode, out BaseSkillInfo? newSkillInfo)
        {
            newSkillInfo = null;
            if (!_skillContainer.TryGetSkillSlot(skillCode, out var skillSlot))
                return RC_SKILL_DOES_NOT_HAVE;

            var skillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(skillSlot.GetSlotInfo().SkillCode);
            if (skillInfo == null) return RC_SKILL_BASEINFO_NOTEXIST;
            if (skillInfo.IsMaxLevel()) return RC_SKILL_MAX_LEVEL_LIMIT;
            newSkillInfo = BaseSkillDB.Instance.GetBaseSkillInfo((ushort) (skillCode+1));
            return CanLearnSkill(skillInfo, newSkillInfo);
        }
        public SkillResult CanLevelUpStyle(ushort curStyleCode, out BaseStyleInfo? newStyleInfo)
        {
            newStyleInfo = null;
            if (!_skillContainer.TryGetSkillSlot(curStyleCode, out var skillSlot))
                return RC_SKILL_DOES_NOT_HAVE;

            var baseStyleInfo = BaseSkillDB.Instance.GetBaseStyleInfo(skillSlot.GetSlotInfo().SkillCode);
            if (baseStyleInfo == null) return RC_SKILL_BASEINFO_NOTEXIST;
            if (baseStyleInfo.IsMaxLevel()) return RC_SKILL_MAX_LEVEL_LIMIT;
            newStyleInfo = BaseSkillDB.Instance.GetBaseStyleInfo((ushort)(curStyleCode + 1));
            return CanLearnStyle(baseStyleInfo, newStyleInfo);
        }

        public void LevelUpSkill(ushort curSkillCode, BaseSkillInfo newBaseInfo, out SkillSlotInfo slotInfo)
        {
            _skillContainer.UpdateSkill(curSkillCode, newBaseInfo, out slotInfo);

            RemovePassiveSkill(curSkillCode);
            AddAttrForPassiveSkill(newBaseInfo);


        }
        public void LevelUpStyle(ushort curStyleCode, BaseStyleInfo newBaseInfo, out SkillSlotInfo slot)
        {
            _skillContainer.UpdateSkill(curStyleCode, newBaseInfo, out slot);

            SelectNewStyle(newBaseInfo);
        }

        public void LearnSkill(ushort newSkillCode, out SkillSlotInfo slotInfo)
        {
            var baseInfo = BaseSkillDB.Instance.GetBaseSkillInfo(newSkillCode);
            _skillContainer.AddSkill(baseInfo, out var slot);
            slotInfo = slot.GetSlotInfo();

            AddAttrForPassiveSkill(baseInfo);
        }
        public void LearnStyle(ushort newStyleCode, out SkillSlotInfo slotInfo)
        {
            var baseInfo = BaseSkillDB.Instance.GetBaseStyleInfo(newStyleCode);
            _skillContainer.AddSkill(baseInfo, out var slot);
            slotInfo = slot.GetSlotInfo();
        }

        #endregion

        private bool AddAttrForPassiveSkill(BaseSkillInfo info)
        {
            if (info.SkillType != SKILL_TYPE_PASSIVE) return false;

            var skill = SkillFactory.Instance.AllocSkill(SKILL_TYPE_PASSIVE, info);
            if (skill == null) return false;

            var skillInfo = new SkillInfo();
            skillInfo.SkillCode = info.SkillCode;
            skill.Init(_owner,ref skillInfo,info);
            Logger.Instance.Log($"Passive Skill added [{skillInfo.SkillCode}]");
            AddPassiveSkill((Skill) skill);

            return true;
        }

        private void SelectNewStyle(BaseStyleInfo info)
        {
            var oldCode = _selectedStyle.SkillCode;
            ReleaseStyleBuff(_selectedStyle);
            ApplyStyleBuff(info);
            _selectedStyle = info;
            var styleChangeInfo = new ChangeStyleInfo(_owner.GetKey(), oldCode, info.SkillCode);
            var packet = new ChangeStyleBRD(styleChangeInfo);

            _owner.SendPacketAround(packet);
        }

        private void ReleaseStyleBuff(BaseStyleInfo baseStyleInfo)
        {
            var calc = new SkillAttrCalc(_owner.GetAttributes());

            if (baseStyleInfo.AttackRate != 0)
                calc.DeleteAttribute(ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, VALUE_TYPE_VALUE, baseStyleInfo.AttackRate);

            if (baseStyleInfo.AvoidRate != 0)
                calc.DeleteAttribute(ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, VALUE_TYPE_VALUE, baseStyleInfo.AvoidRate);

            if (baseStyleInfo.AttackSpeed != 0)
                calc.DeleteAttribute(ATTR_ATTACK_SPEED, VALUE_TYPE_VALUE, baseStyleInfo.AttackSpeed);

            if (baseStyleInfo.BonusDefense != 0)
                calc.DeleteAttribute(ATTR_OPTION_ALL_DEFENSE_POWER, VALUE_TYPE_VALUE, baseStyleInfo.BonusDefense);

            if (baseStyleInfo.CriticalBonus != 0)
                calc.DeleteAttribute(ATTR_ADD_ALL_CRITICAL_RATIO, VALUE_TYPE_VALUE, baseStyleInfo.CriticalBonus);
        }

        private void ApplyStyleBuff(BaseStyleInfo baseStyleInfo)
        {
            var calc = new SkillAttrCalc(_owner.GetAttributes());

            if (baseStyleInfo.AttackRate != 0)
                calc.AddAttribute(ATTR_PHYSICAL_ATTACK_SUCCESS_RATIO, VALUE_TYPE_VALUE, baseStyleInfo.AttackRate);

            if (baseStyleInfo.AvoidRate != 0)
                calc.AddAttribute(ATTR_PHYSICAL_ATTACK_BLOCK_RATIO, VALUE_TYPE_VALUE, baseStyleInfo.AvoidRate);

            if (baseStyleInfo.AttackSpeed != 0)
                calc.AddAttribute(ATTR_ATTACK_SPEED, VALUE_TYPE_VALUE, baseStyleInfo.AttackSpeed);

            if (baseStyleInfo.BonusDefense != 0)
                calc.AddAttribute(ATTR_OPTION_ALL_DEFENSE_POWER, VALUE_TYPE_VALUE, baseStyleInfo.BonusDefense);

            if (baseStyleInfo.CriticalBonus != 0)
                calc.AddAttribute(ATTR_ADD_ALL_CRITICAL_RATIO, VALUE_TYPE_VALUE, baseStyleInfo.CriticalBonus);
        }

        public void SelectStyle(StyleEnum style)
        {
            var styleInfo = BaseSkillDB.Instance.GetBaseStyleInfo((ushort) style);
            if (styleInfo == null) return;

            SelectNewStyle(styleInfo);
        }

        public void SelectBaseStyle()
        {
            var styleCode = GetDefaultStyle(_owner.GetWeaponItemType());
            if(CanSelectStyle((ushort) styleCode)==RC_SKILL_SUCCESS)
                SelectStyle(styleCode);
        }
        public SkillResult CanSelectStyle(ushort newStyleCode)
        {
            if (!_skillContainer.TryGetSkillSlot(newStyleCode, out var skillSlot))
                 return RC_SKILL_DOES_NOT_HAVE;

            var baseStyleInfo = BaseSkillDB.Instance.GetBaseStyleInfo(skillSlot.GetSlotInfo().SkillCode);
            if (baseStyleInfo == null) return RC_SKILL_BASEINFO_NOTEXIST;

            if (_owner.GetCharType() != (CharType)baseStyleInfo.ClassDefine)
                return RC_SKILL_CHAR_CLASS_LIMIT;

            if (baseStyleInfo.WeaponDefine != -1)
            {
                var type = _owner.GetWeaponItemType();
                if (type != (ItemType)baseStyleInfo.WeaponDefine) return RC_SKILL_WEAPON_LIMIT;

            }

            return RC_SKILL_SUCCESS;
        }

        public StyleEnum GetPunchStyleCode()
        {
            switch (_owner.GetCharType())
            {
                case CHAR_BERSERKER:
                    return STYLE_BERSERKER_PUNCH;
                case CHAR_DRAGON:
                    return STYLE_DRAGON_PUNCH;
                case CHAR_SHADOW:
                    return STYLE_SHADOW_PUNCH;
                case CHAR_VALKYRIE:
                    return STYLE_VALKYRIE_PUNCH;
                case CHAR_MAGICIAN:
                    return STYLE_MAGICIAN_PUNCH;
                case CHAR_TYPE_MAX:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return STYLE_BERSERKER_PUNCH;
        }
        public StyleEnum GetDefaultStyle(ItemType weaponType)
        {
            if (weaponType == 0) return GetPunchStyleCode();

            return weaponType switch
            {
                ITEMTYPE_TWOHANDSWORD => STYLE_TWOHANDSWORD_NORMAL,
                ITEMTYPE_TWOHANDAXE => STYLE_TWOHANDAXE_NORMAL,
                ITEMTYPE_ONEHANDSWORD => STYLE_ONEHANDSWORD_NORMAL,
                ITEMTYPE_SPEAR => STYLE_SPEAR_NORMAL,
                ITEMTYPE_STAFF => STYLE_STAFF_NORMAL,
                ITEMTYPE_ORB => STYLE_ORB_NORMAL,
                ITEMTYPE_ONEHANDCROSSBOW => STYLE_ONEHANDCROSSBOW_NORMAL,
                ITEMTYPE_ETHERWEAPON => STYLE_ETHER_NORMAL,
                _ => GetPunchStyleCode()
            };
        }
        private bool IsPunchStyle(ushort styleCode)
        {
            return (StyleEnum)styleCode
                is STYLE_BERSERKER_PUNCH
                or STYLE_DRAGON_PUNCH
                or STYLE_SHADOW_PUNCH
                or STYLE_VALKYRIE_PUNCH
                or STYLE_MAGICIAN_PUNCH
                ;
        }

        public void AddPassiveSkill(Skill skill)
        {
            if(_passiveSkillList.ContainsKey(skill.GetSkillCode()))
                RemovePassiveSkill(skill.GetSkillCode());
            _passiveSkillList.Add(skill.GetSkillCode(),skill);
            skill.StartExecute();
        }

        public void RemovePassiveSkill(ushort skillCode)
        {
            if (!_passiveSkillList.TryGetValue(skillCode, out var skill)) return;
            Logger.Instance.Log($"Passive Skill removed [{skillCode}]");
            skill.EndExecute();
            _passiveSkillList.Remove(skillCode);
        }

        public void OnWeaponChange(ItemType itemType)
        {
            var styleCode = GetDefaultStyle(itemType);

            UpdatePassiveSkillList();
            SelectStyle(styleCode);


        }
    }

}
