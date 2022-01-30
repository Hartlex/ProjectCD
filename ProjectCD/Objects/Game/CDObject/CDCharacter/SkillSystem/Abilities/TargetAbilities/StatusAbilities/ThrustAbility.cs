using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Effects;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    [Flags]
    enum Control
    {
        NONE =0,
        THRUST =1<<0,
        SELF_DESTRUCTION= 1<<1,
        DAMAGE_STARTED = 1<<20

    }
    internal class ThrustAbility : BaseStatusAbility
    {
        private Control _controlField;
        private Field? _field;
        private SelfDestructionDamageEffect _effect;
        private SunVector _mainTargetPos;


        public override void InitDetailed(Character attacker, ushort skillCode, ref SkillInfo skillInfo, byte skillStatType,
            BaseAbilityInfo baseInfo)
        {
            base.InitDetailed(attacker, skillCode, ref skillInfo, skillStatType, baseInfo);

            _mainTargetPos = skillInfo.MainTargetPosition;

            _field = attacker.GetCurrentField();

            switch (baseInfo.AbilityId)
            {
                case AbilityID.ABILITY_KNOCKBACK:
                case AbilityID.ABILITY_KNOCKBACK2:
                case AbilityID.ABILITY_PULLING:
                    _controlField = Control.THRUST;
                    break;
                case AbilityID.ABILITY_SELF_DESTRUCTION:
                    _controlField = Control.THRUST | Control.SELF_DESTRUCTION;
                    DamageEffect(attacker, _field);
                    break;
                default:
                    _controlField = Control.NONE;
                    Logger.Instance.Log($"[Thrust ability] Unknown Thrust Type!",LogType.ERROR);
                    break;
            }
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            result = null;
            var targetField = target?.GetCurrentField();
            bool check = targetField != null && ReferenceEquals(targetField, _field);

            if (!check) return false;

            return (_controlField & Control.THRUST) != 0 && Thrust(target!, out result);

        }

        public override bool IsValidState()
        {
            return true;
        }


        private bool Thrust(Character target, out SkillResultAbility result)
        {
            result = null;
            var attacker = GetAttacker();
            if(attacker==null) return false;

            var posResult = new SkillResultPosition();
            var statusManager = target.GetStatusManager();
            var downAfterThrust = statusManager.FindStatus(CharStateType.CHAR_STATE_DOWN);
            var moveState = downAfterThrust ? CharMoveState.CMS_KNOCKBACK_DOWN : CharMoveState.CMS_KNOCKBACK;
            int animDelay = 1000;

            var abilityInfo = GetBaseAbilityInfo();
            switch (abilityInfo.AbilityId)
            {
                case AbilityID.ABILITY_KNOCKBACK2:
                    animDelay = 4000;
                    moveState = CharMoveState.CMS_KNOCKBACK2;
                    break;
            }

            bool needSkipThrustPos = !statusManager.AnimationDelayController.SetAnimationDelay(this, animDelay);

            var knockBackLength = needSkipThrustPos ? 0 : abilityInfo.Params[1] / 10f;

            var attackPos = attacker.GetPos();
            var targetPos = target.GetPos();

            if (abilityInfo.AbilityId == AbilityID.ABILITY_PULLING)
                attackPos = _mainTargetPos;
            if (needSkipThrustPos) posResult.DestinationPosition = targetPos;
            else
            {
                var normVector = targetPos - attackPos;
                if (knockBackLength < 0)
                {
                    var distance = normVector.GetLength();
                    if (distance < -knockBackLength)
                        knockBackLength = -distance;
                }
                normVector.Normalize();

                normVector *= knockBackLength;

                var thrustResult = target.ExecuteThrust(true, normVector, ref posResult.DestinationPosition,
                    knockBackLength, downAfterThrust);

                return !thrustResult;
            }

            abilityInfo = GetBaseAbilityInfo().EditableCopy();
            abilityInfo.CharStateType = CharStateType.CHAR_STATE_THRUST;

            knockBackLength = (targetPos-posResult.DestinationPosition).GetLength();
            var moveSpeed = NumericValues.GetBaseMoveSpeedAsState(moveState);
            abilityInfo.Params[2] = (int) (knockBackLength / moveSpeed);
            int val = abilityInfo.Params[2] - 100;
            abilityInfo.Params[2] = SunCalc.Min(100, val);

            var baseSuccess = base.Execute(target, out var baseResult);
            if (!baseSuccess) return false;

            posResult.AbilityCode = baseResult!.AbilityCode;
            posResult.AbilityDuration = baseResult.AbilityDuration;
            

            posResult.CurrentPosition = targetPos;

            return true;

        }

        private bool DamageEffect(Character? attacker, Field? field)
        {
            if (attacker != null && (_controlField & Control.DAMAGE_STARTED) != 0)
            {
                _controlField |= Control.DAMAGE_STARTED;

                var effect = new SelfDestructionDamageEffect();
                effect.SetStateID((CharStateType) FieldeffectType.EFFECT_TYPE_SELF_DESTRUCTION);

                var abilityInfo = GetBaseAbilityInfo();

                SelfDestructDamageInfo info = new();
                info.Option = (DamageOpt) abilityInfo.Params[0];
                info.Damage = abilityInfo.Params[1];
                var range = abilityInfo.Params[2] / 10f;

                effect.Init(GetSkillCode(),int.MaxValue,0,attacker,attacker.GetPos(),range);
                effect.SetInformation(_field,info);
                _effect = effect;
                return true;
            }

            return true;
        }
    }
}
