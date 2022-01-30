using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem
{
    public class ActiveSkillManager
    {
        private Character _owner;

        private readonly Dictionary<ushort, SkillBase> _skills;
        public ActiveSkillManager(Character owner)
        {
            _owner = owner;
            _skills = new(10);
        }


        public bool Update()
        {
            var curTick = DateTime.Now.Ticks;
            foreach (var skill in _skills.Values)
            {
                if (skill.RequestCancel)
                {
                    skill.CancelExecute();
                    _skills.Remove(skill.GetSkillCode());
                }
                else if (curTick <= skill.ExecuteTick || skill.RequestRemove)
                {
                    skill.EndExecute();
                    if (_owner.IsObjectType(ObjectType.PLAYER_OBJECT) &&
                        skill.GetSkillClassCode() != (ushort)SkillEnum.SKILL_HIDE)
                    {
                        var player = (Player) _owner;
                        player.TransOff();
                    }

                    _skills.Remove(skill.GetSkillCode());
                }
            }
            return true;
        }

        private void AddActiveSkill(SkillBase skill)
        {
            var code = skill.GetSkillCode();
            if (_skills.ContainsKey(code))
                _skills.Remove(code);

            skill.StartExecute();

            _skills.Add(code,skill);
        }

        public void CancelActiveSkill(ushort skillCode)
        {
            if (_skills.TryGetValue(skillCode, out var skill))
                skill.RequestCancel = true;
        }

        public void CancelAllSkill()
        {
            foreach (var skill in _skills.Values)
            {
                skill.RequestCancel = true;
            }
        }

        public bool RegisterSkill(SkillType type, ref SkillInfo skillInfo)
        {
            if (type == SkillType.SKILL_TYPE_PASSIVE) return false;

            var skill = SkillFactory.Instance.AllocSkill(type, skillInfo.RootSkillInfo);

            skill.Init(_owner,ref skillInfo,skillInfo.RootSkillInfo);

            AddActiveSkill(skill);
            return true;
        }
    }
}
