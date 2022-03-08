using SunStructs.Definitions;
using static SunStructs.Definitions.AttrValueKind;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class AbsorbStatus : AbilityStatus
    {
        public AbsorbStatus(){}

        public override void Execute() { }
        public override void AttackAbsorb(int damage)
        {
            var value = AbilityValue;
            if (AbilityValueType == VALUE_TYPE_PERCENT_PER_MAX) value = (int) (damage * (value / 1000f));
            else if (AbilityValueType == VALUE_TYPE_PERCENT_PER_CUR) value = (int) (damage * (value / 1000f));

            if(AbilityID == AbilityID.ABILITY_ATTACK_DAMAGE_HP_ABSORPTION) GetOwner()!.OnRecover(value,0,0);
            else if(AbilityID == AbilityID.ABILITY_ATTACK_DAMAGE_MP_ABSORPTION) GetOwner()!.OnRecover(0,value,0);
        }

        public override void AttackedAbsorb(AttackType attackType, int damage)
        {
            var value = AbilityValue;
            if (AbilityValueType == VALUE_TYPE_PERCENT_PER_MAX) value = (int) (damage * (value / 1000f));
            else if (AbilityValueType == VALUE_TYPE_PERCENT_PER_CUR) value = (int) (damage * (value / 1000f));

            if(AbilityID == AbilityID.ABILITY_ATTACKED_DAMAGE_HP_ABSORPTION) GetOwner()?.OnRecover(value,0,0);
            else if(AbilityID == AbilityID.ABILITY_ATTACKED_DAMAGE_MP_ABSORPTION) GetOwner()?.OnRecover(0,value,0);
        }
    }
}
