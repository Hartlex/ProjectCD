using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using ProjectCD.Objects.Game.Slots.Quick;
using ProjectCD.Objects.Game.Slots.Skill;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.SkillResult;
using static SunStructs.Definitions.SkillType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Skill
{
    internal class PlayerSkillManager
    {
        private Player _owner;
        private SkillContainer _skillContainer;
        private QuickSlotContainer _quickContainer;
        private BaseStyleInfo _selectedStyle;

        private Dictionary<ushort, SkillBase> _passiveSkillList = new Dictionary<ushort, SkillBase>();

        public PlayerSkillManager(Player owner, SkillContainer skillContainer, QuickSlotContainer quickContainer, ushort styleCode)
        {
            _owner = owner;
            _skillContainer = skillContainer;
            _quickContainer = quickContainer;
            _selectedStyle = BaseSkillDB.Instance.GetBaseStyleInfo(styleCode);
        }
        
        public int GetCurrentStyleCode(){ return _selectedStyle.SkillCode; }

        public SkillResult CanLearnSkill(BaseSkillInfo newSkillInfo)
        {
            if (_owner.GetSkillPoints() < newSkillInfo.RequireSkillPoint) return RC_SKILL_REMAIN_SKILLPOINT_LACK;
            if (_owner.GetLevel() < newSkillInfo.RequireLevel) return RC_SKILL_REQUIRE_LEVEL_LIMIT;
            if (_owner.GetAttributes()[AttrType.ATTR_EXPERTY1].GetValue() < newSkillInfo.RequireSkillStat[0])
                return RC_SKILL_REQUIRE_SKILLSTAT_LIMIT;
            if (_owner.GetAttributes()[AttrType.ATTR_EXPERTY2].GetValue() < newSkillInfo.RequireSkillStat[1])
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

            DeletePassiveSkill(curSkillCode);
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


        private void DeletePassiveSkill(ushort skillCode)
        {

        }

        private void AddAttrForPassiveSkill(BaseSkillInfo info)
        {

        }

        private void SelectNewStyle(BaseStyleInfo info)
        {
            ReleaseStyleBuff(_selectedStyle);
            ApplyStyleBuff(info);
            _selectedStyle = info;
        }

        private void ReleaseStyleBuff(BaseStyleInfo info)
        {

        }

        private void ApplyStyleBuff(BaseStyleInfo info)
        {

        }
    }
}
