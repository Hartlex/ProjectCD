using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class MagicShieldStatus : AbilityStatus
    {
        private int _shieldHP;
        private int _decreaseMP;
        private float _decreaseMpRatio;
        private float _absorbRatio;


        public override void Execute() {}

        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);

            var baseInfo = ability.GetBaseAbilityInfo();
            _shieldHP = baseInfo.Params[1];
            _decreaseMP = baseInfo.option2;
            _decreaseMpRatio = 0;
            _absorbRatio = baseInfo.Params[0] / 1000f;
        }

        public override void Start()
        {
            var owner = GetOwner();
            if (owner == null) return;

            owner.SetShield(_shieldHP,_decreaseMP,_absorbRatio,_decreaseMpRatio);
        }

        public override void End()
        {
            var owner = GetOwner();
            if (owner == null) return;

            owner.SetShield(0,0,0,0);
            base.End();
        }
    }
}
