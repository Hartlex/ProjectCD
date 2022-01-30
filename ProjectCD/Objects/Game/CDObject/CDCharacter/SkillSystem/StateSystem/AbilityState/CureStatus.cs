using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    public class CureStatus : AbilityStatus
    {
        private const int STATE_NUM=4;
        private readonly int[] _states = new int[STATE_NUM];
        public override void Init(Character owner, Character? attacker, Ability ability)
        {
            base.Init(owner, attacker, ability);

            var abilityInfo = ability.GetBaseAbilityInfo();
            _states[0] =  abilityInfo.option1;
            _states[1] =  abilityInfo.option2;
            _states[2] =  abilityInfo.Params[0];
            _states[3] =  abilityInfo.Params[1];

        }

        public override void Start()
        {
            CureBadStatus();
        }

        public override void Execute()
        {
            base.Execute();
            CureBadStatus();
        }

        private void CureBadStatus()
        {
            var owner = GetOwner();
            if (owner == null) return;
            var statusManager = owner.GetStatusManager();

            if (_states[0] != 0)
            {
                for (int i = 0; i < STATE_NUM; i++)
                {
                    if (statusManager.FindStatus((CharStateType) _states[i]))
                        statusManager.Remove((CharStateType) _states[i]);
                }
            }
            else
            {
                for (int i = 1; i < STATE_NUM; i++)
                {
                    if (_states[i] != 0)
                        statusManager.CureAll((StateType) _states[i]);
                }
            }

        }
    }
}
