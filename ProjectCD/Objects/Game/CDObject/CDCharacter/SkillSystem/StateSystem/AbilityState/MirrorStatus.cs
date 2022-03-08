using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class MirrorStatus : AbilityStatus
    {
        private float _absorbRatio;
        private int _option2;
        private SkillInfo _skillInfo;
        private BaseAbilityInfo _baseAbilityInfo;

        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);

            _baseAbilityInfo = ability.GetBaseAbilityInfo();
            _absorbRatio = _baseAbilityInfo.option1 / 1000f;
            _option2 = _baseAbilityInfo.option2;
        }

        public override void Start() { }
        public override void Execute() { }

        public override void DamageMirror(Character attacker, int damage)
        {
            var field = GetOwner()?.GetCurrentField();
            if (field == null) return;

            if (attacker.IsDead() || !attacker.CanBeAttacked()) return;


        }
    }
}
