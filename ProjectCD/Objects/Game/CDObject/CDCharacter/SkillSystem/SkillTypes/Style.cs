using CDShared.Logging;
using ProjectCD.Formulas;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Style.Server;
using SunStructs.Packets.GameServerPackets.Style;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.Const;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;

internal class Style : SkillBase
{
    private BaseStyleInfo _baseStyleInfo;
    private byte _effect;
    private int _damage;
    //private ushort _mainTargetDamage;


    private SunVector _playerPos;
    private SunVector _targetPos;
    private SunVector _thrustPos;

    private StylePlayerAttackResultInfo _result;

    private void CommonExecute()
    {
        if ((SkillAttribution & SKILL_ATTRIBUTION_INVISIBLE) != 0)
        {
            Owner.GetStatusManager().AllocStatus(CharStateType.CHAR_STATE_ETC_DISABLE_VISION, out var status);
        }

        if (_baseStyleInfo.KnockBackRate != 0 && GlobalRandom.IsSuccess(_baseStyleInfo.KnockBackRate))
        {
            _effect |= SKILL_EFFECT_KNOCKBACK;
        }
    }

    private void CommonRelease()
    {
        if ((SkillAttribution & SKILL_ATTRIBUTION_INVISIBLE) != 0)
        {
            Owner.GetStatusManager().Remove(CharStateType.CHAR_STATE_ETC_DISABLE_VISION);
        }
    }

    private bool CalcDamage(Character target)
    {
        var weaponAttackType = Owner.GetWeaponBaseAttackType();
        var magicAttackType = Owner.GetWeaponMagicAttackType();

        _damage = CharacterFormulas.CalcNormalDamage(Owner, target, weaponAttackType, magicAttackType,
            (int) _baseStyleInfo.CriticalBonus, ref SkillInfo.SkillEffect, _baseStyleInfo.DefenseIgnore);

        float ratio = 1+  _baseStyleInfo.DamagePercent[2];
        int addDamage = _baseStyleInfo.AddDamage[2];

        _damage = (int) (_damage * ratio + addDamage);

        if (ApplyEtherBullet && EtherBulletInfo != null)
        {
            SkillInfo.SkillEffect |= EtherBulletInfo.EffectCode;
        }

        var damageArgs = new DamageArgs();
        damageArgs.attacker = Owner;
        damageArgs.attackType = weaponAttackType;
        damageArgs.IsCrit = (SkillInfo.SkillEffect & SKILL_EFFECT_CRITICAL) != 0;
        damageArgs.SDApply = SDApply.SD_APPLY_DO;
        damageArgs.Damage = _damage;

        target.Damaged(damageArgs);


        _damage = damageArgs.Damage;
        //if (target.GetKey() == SkillInfo.MainTargetKey)
        //    _mainTargetDamage = _damage;

        return _damage!=0;
    }

    private void ApplyEffect(Character target)
    {
        var statusManager = target.GetStatusManager();

        var knockdownExecute = false;
        var isRiding = statusManager.GetStatusFlag().IsRidingRider();

        if (_baseStyleInfo.PierceRate != 0 && GlobalRandom.IsSuccess(_baseStyleInfo.PierceRate))
            SkillInfo.SkillEffect |= SKILL_EFFECT_PIERCE;
        if (isRiding == false && _baseStyleInfo.StunRate != 0 && GlobalRandom.IsSuccess(_baseStyleInfo.StunRate))
        {
            SkillInfo.SkillEffect |= SKILL_EFFECT_STUN;
            statusManager.AllocStatus(CharStateType.CHAR_STATE_STYLE_STUN, out var status, _baseStyleInfo.StunTime, 0);
        }

        if (isRiding == false && _baseStyleInfo.DownRate != 0 && GlobalRandom.IsSuccess(_baseStyleInfo.DownRate))
        {
            SkillInfo.SkillEffect |= SKILL_EFFECT_KNOCKDOWN;
            knockdownExecute = true;
        }

        var aiCommon = AiParameterDb.Instance.GetAiParamInfo();
        if (isRiding == false && (SkillInfo.SkillEffect & SKILL_EFFECT_KNOCKBACK) != 0)
        {
            var normV = SunVector.GetDistanceVector(_targetPos, _playerPos);
            normV.Normalize();
            normV *= _baseStyleInfo.KnockBackRange;

            if (target.ExecuteThrust(true, normV, ref _thrustPos, _baseStyleInfo.KnockBackRange, knockdownExecute))
            {
                if (statusManager.AllocStatus(CharStateType.CHAR_STATE_STYLE_THRUST,out var status , aiCommon.ThrustTime))
                {
                    //TODO ETCSTATUS
                }

                knockdownExecute = false;
            }
            else
            {
                SkillInfo.SkillEffect ^= SKILL_EFFECT_KNOCKBACK;
            }

        }

        if (isRiding == false && knockdownExecute)
            statusManager.AllocStatus(CharStateType.CHAR_STATE_STYLE_DOWN,out var status, aiCommon.KnockdownTime, 0);
    }

    private void BroadcastStyleResult()
    {
        var packet = new StyleAttackResultBRD(_result);
        Field.SendToAll(packet);
    }

    public override SkillType GetSkillType()
    {
        return SkillType.SKILL_TYPE_STYLE;
    }

    protected override void SetExecutionInterval()
    {
        Interval = 0;
        if (Owner is Player player)
        {
            float interval = player.GetActionDelay();
            interval *= _baseStyleInfo.ThirdDelay;
            Interval = (int)interval;
        }
        if(Interval > 100)
            Interval-=100;
    }

    public override void Init(Character owner, ref SkillInfo skillInfo, RootSkillInfo rootSkillInfo)
    {
        base.Init(owner, ref skillInfo, rootSkillInfo);
        _baseStyleInfo = (BaseStyleInfo) rootSkillInfo;
        _result = new(SkillInfo.ClientSerial, owner.GetKey());
    }

    public override void SetupDefault(Character owner, ref SkillInfo skillInfo, RootSkillInfo rootSkillInfo)
    {
        base.SetupDefault(owner, ref skillInfo, rootSkillInfo);
        if (rootSkillInfo is BaseStyleInfo styeInfo)
        {
            _baseStyleInfo = styeInfo;
        }
        else
        {
            Logger.Instance.Log($"Skill initialize with wrong Info!",LogType.ERROR);
        }
    }

    public override bool StartExecute()
    {
        if (Field == null)
        {
            //TODO send errorPacket
        }

        if (!CheckMainTarget(out var result)) DidMiss = true;
        else CommonExecute();

        var packet = new StyleAttackBRD(new(
            Owner!.GetKey(),
            SkillInfo.AttackSequence,
            SkillInfo.SkillCode,
            SkillInfo.ClientSerial,
            SkillInfo.MainTargetKey,
            SkillInfo.CurrentPosition
        ));
        Field!.SendToAll(packet);

        return true;
    }

    public override void EndExecute()
    {
        if (DidMiss)
        {
            _result = new (SkillInfo.ClientSerial, Owner.GetKey());
            _result.NumberOfTargets = 0;
            BroadcastStyleResult();
            base.EndExecute();
            return;
        }

        var mainTarget = Field!.FindCharacter(SkillInfo.MainTargetKey);

        var otherTargets = Field!.FindTargets(
            SkillTargetType.SKILL_TARGET_ENEMY,
            (SkillAreaType) _baseStyleInfo.AttRangeForm,
            Owner,
            SkillInfo.MainTargetPosition,
            (int) _baseStyleInfo.AttRange,
            _baseStyleInfo.MaxTargetNum-1,
            SkillInfo.MainTargetKey
        );
        _playerPos = Owner.GetPos();
        _result = new StylePlayerAttackResultInfo(SkillInfo.ClientSerial, Owner.GetKey());
        var targets = new Character[otherTargets.Length + 1];
        Array.Copy(otherTargets,0,targets,1,otherTargets.Length);
        targets[0] = mainTarget;
        foreach (var target in targets)
        {
            if(target.IsDead() || Owner.IsFriend(target)!= UserRelationType.USER_RELATION_ENEMY) continue;

            Owner.ForcedAttack(target);
            if(target.CanBeAttacked() == false) continue;

            SkillInfo.SkillEffect = _effect;
            _targetPos = target.GetPos();
            _thrustPos = _targetPos;

            if (CalcDamage(target))
            {
                target.Attacked();

                SendAIMessage(target,_damage);

                ApplyEffect(target);
            }

            var statusManager = target.GetStatusManager();
            var isRiding = statusManager.GetStatusFlag().IsRidingRider();
            var targetStamp = statusManager.FindStatus(CharStateType.CHAR_STATE_STAMP);

            if (isRiding || targetStamp)
            {
                SkillInfo.SkillEffect |= (SKILL_EFFECT_KNOCKBACK | SKILL_EFFECT_KNOCKDOWN | SKILL_EFFECT_STUN);
            }

            var styleResult = new StyleAttackResult(target.GetKey(), (ushort) _damage, (uint) target.GetHP(), _targetPos, _thrustPos);
            styleResult.SkillEffect = SkillInfo.SkillEffect;
            styleResult.EtherEffect = (byte) EtherComboCount;

            _result.AttackResults[NumberOfTargetsHit] = styleResult;
            NumberOfTargetsHit++;

        }

        CommonRelease();

        Owner.OnAttack(mainTarget,SkillInfo.SkillCode,_damage);

        _result.NumberOfTargets = (byte) NumberOfTargetsHit;

        BroadcastStyleResult();

        base.EndExecute();
    }

    protected override bool CheckMainTarget(out BattleResult result)
    {
        result = BattleResult.RC_BATTLE_SUCCESS;
        var mainTarget = Field?.FindCharacter(SkillInfo.MainTargetKey);
        if (mainTarget == null)
        {
            result = BattleResult.RC_BATTLE_INVALID_MAINTARGET;
            return false;
        }

        SkillInfo.MainTargetPosition = mainTarget.GetPos();

        if (_baseStyleInfo.AttRangeForm == (int)SkillAreaType.SRF_PIERCE)
        {
            SunVector diff = SkillInfo.MainTargetPosition - SkillInfo.CurrentPosition;
            diff.Normalize();
            SkillInfo.MainTargetPosition += diff * _baseStyleInfo.StyleArea;
        }
        else
        {
            var skillRangeCheck = Owner!.CheckSkillRange(mainTarget, SkillInfo.MainTargetPosition, _baseStyleInfo.AttRange);
            if (!skillRangeCheck) return false;
        }

        return true;
    }
}