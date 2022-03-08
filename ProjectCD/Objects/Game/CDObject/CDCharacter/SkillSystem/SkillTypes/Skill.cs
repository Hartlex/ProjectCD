using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.BattleResult;
using static SunStructs.Definitions.Const;
using static SunStructs.Definitions.SkillAreaType;
using static SunStructs.Definitions.SkillTargetType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes
{
    internal abstract class Skill : SkillBase
    {
        private BaseSkillInfo? _baseSkillInfo;

        public override void SetupDefault(Character owner, ref SkillInfo skillInfo, RootSkillInfo rootSkillInfo)
        {

            if (rootSkillInfo is BaseSkillInfo styeInfo)
            {
                _baseSkillInfo = styeInfo;
            }
            else
            {
                Logger.Instance.Log($"Skill initialize with wrong Info!", LogType.ERROR);
            }
            base.SetupDefault(owner, ref skillInfo, rootSkillInfo);
        }

        protected override void ConfigureAnimationDelay()
        {
            var delayTick = _baseSkillInfo.CSSyncDelay;
            if (delayTick == 0) return;
            if (Owner is Player player)
            {
                player.GetStatusManager().AnimationDelayController
                    .SetAnimationDelay(this, delayTick);
            }
        }

        protected override void AddAbilities()
        {
            var eventCode = SkillInfo.EventCode;
            foreach (var baseAbilityInfo in _baseSkillInfo.BaseAbilityInfos)
            {
                var abilityID = baseAbilityInfo.AbilityId;
                var ability = AbilityFactory.Instance.AllocAbility(abilityID, GetSkillType());
                if (ability == null) continue;

                ability.Init(this,baseAbilityInfo);
                ability.SetEventCode(eventCode);

                Abilities.Add(ability);
            }
        }

        protected override void DecreaseHPMP()
        {
            var mpSpent = (float)_baseSkillInfo.MPCost;
            mpSpent *= Owner.GetMPSpendIncRatio();
            mpSpent += Owner.GetMPSpendIncValue();
            mpSpent = SunCalc.Min(0, mpSpent);

            Owner.DecreaseHP((int) _baseSkillInfo.HPCost);
            Owner.DecreaseMP((int) mpSpent);
        }

        protected override bool CheckMainTarget(out BattleResult result)
        {
            result = RC_BATTLE_SUCCESS;
            if (Field == null || _baseSkillInfo == null)
            {
                result = RC_BATTLE_INVALID_MAINTARGET;
                return false;
            }

            var targetType =(SkillTargetType) _baseSkillInfo.TargetType;
            Character? mainTarget = null;
            if (targetType== SKILL_TARGET_SUMMON)
            {
                return true;
            }

            var range = _baseSkillInfo.SkillRange / 10f;
            if (targetType == SKILL_TARGET_ME)
            {
                SkillInfo.MainTargetKey = Owner!.GetKey();
                SkillInfo.MainTargetPosition = SkillInfo.CurrentPosition;
            }
            else if (targetType == SKILL_TARGET_AREA)
            {

            }
            else if (_baseSkillInfo.AttackRangeForm == (byte) SRF_PIERCE)
            {
                range += 1;
            }
            else
            {
                mainTarget = Field!.FindCharacter(SkillInfo.MainTargetKey);
                if (mainTarget != null)
                    SkillInfo.MainTargetPosition = mainTarget.GetPos();
            }

            if (mainTarget == null) return true;

            var rangeCheck = Owner!.CheckSkillRange(mainTarget, SkillInfo.MainTargetPosition, range);
            if (rangeCheck) return true;

            result = RC_BATTLE_OUT_OF_RANGE;
            return false;

        }

        protected bool ExecuteSkill()
        {
            InitResultMsg();

            bool multiSelect = false;
            int foundTargets = MAX_TARGET_COUNT;
            uint exceptTargetKey = 0;
            var mainTarget = Field?.FindCharacter(SkillInfo.MainTargetKey);
            if (_baseSkillInfo.AttackRangeForm == (byte) SRF_FOWARD_ONE)
            {
                if (mainTarget != null)
                {
                    if (!ReferenceEquals(mainTarget, Owner))
                    {
                        if (ExecuteAbilities(Owner, out var ownerResult))
                        {
                            SkillResults[NumberOfTargetsHit] = ownerResult;
                            NumberOfTargetsHit++;
                            foundTargets--;
                        }

                        if (ExecuteAbilities(mainTarget, out var mainTargetResult))
                        {
                            SkillResults[NumberOfTargetsHit] = mainTargetResult;
                            NumberOfTargetsHit++;
                            foundTargets--;

                            exceptTargetKey = mainTarget.GetKey();
                            Owner.ForcedAttack(mainTarget);

                            SendAIMessage(mainTarget);
                        }
                    }
                    else
                    {
                        if (ExecuteAbilities(Owner, out var ownerResult))
                        {
                            SkillResults[NumberOfTargetsHit] = ownerResult;
                            NumberOfTargetsHit++;
                            foundTargets--;
                        }
                    }

                }
            }
            else if (_baseSkillInfo.TargetType == SKILL_TARGET_SUMMON)
            {
            }
            else if (_baseSkillInfo.AttackRangeForm == (byte) SRF_AREA_POSITION)
            {
            }
            else if (_baseSkillInfo.TryGetAbilityInfo(AbilityID.ABILITY_RANDOM_AREA_ATTACK,out var info))
            {
            }

            else
            {
                multiSelect = true;
            }

            if (!multiSelect)
            {
            }
            else
            {
                foundTargets = _baseSkillInfo.MaxTargetNum;
                var targets = Field.FindTargets(
                    (SkillTargetType) _baseSkillInfo.TargetType,
                    (SkillAreaType) _baseSkillInfo.AttackRangeForm,
                    Owner,
                    SkillInfo.MainTargetPosition,
                    _baseSkillInfo.SkillArea / 10f,
                    foundTargets,
                    exceptTargetKey
                );
                Logger.Instance.Log($"Found [{targets.Length}] Targets");
                foreach (var target in targets)
                {
                    if (target == null) break;
                    if (!ExecuteAbilities(target, out var ownerResult)) continue;
                    ownerResult.SkillEffect = SkillInfo.SkillEffect;
                    SkillResults[NumberOfTargetsHit] = ownerResult;
                    NumberOfTargetsHit++;

                    Owner.ForcedAttack(mainTarget);

                    SendAIMessage(mainTarget);

                    if (NumberOfTargetsHit == MAX_TARGET_COUNT) break;
                }
            }

            //if (SkillResults[0] != null)
            //{
            NumberOfEffects = ExecuteEffectAbilities();
            //}


            Owner!.OnAttack(mainTarget, _baseSkillInfo.SkillCode, 0);

            return true;
        }
    }
}
