using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.EtherSystem;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Skill;
using SunStructs.ServerInfos.General.Object.AI;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.SkillTypes;

public abstract class SkillBase
{
    #region Properties

    public Character? Owner { get; private set; }
    protected Field? Field { get; private set; }
        
    private RootSkillInfo? RootSkillInfo { get; set; }

    #region Flags
    public long ExecuteTick { get; private set; }
    protected int Interval { get; set; }
    protected byte SkillAttribution { get; private set; }
    protected bool DidMiss { get; set; }
    protected bool TargetIsOwner { get; }
    public bool RequestCancel { get; set; }
    public bool RequestRemove { get; }
    protected bool IsInvokedInSafeArea { get; private set; }
    protected bool PassiveApplied { get; }
    #endregion
        
    protected List<Ability> Abilities { get; private set; }
    public SkillInfo SkillInfo { get; private set; }

    #region EtherBullet
    public EtherBulletInfo? EtherBulletInfo { get; protected set; }
    protected bool ApplyEtherBullet { get; }
    public int EtherComboCount { get; protected set; }

    #endregion

    #region Targets

    public int AddedAttackPowerPerStatus { get; protected set; } 
    protected BonusAbilityEffect? BonusAbilityEffect;
    protected int NumberOfTargetsHit;
    protected int NumberOfEffects;

    #endregion

    #region Results

    protected SkillResultBase[] SkillResults { get; private set; }
    protected SkillResultEffect[] EffectResults { get; private set; }

    #endregion


    #endregion

    public BaseSkillInfo? GetBaseSkillInfo()
    {
        if (RootSkillInfo!.IsSkill()) return (BaseSkillInfo) RootSkillInfo;
        return null;
    }

    public BaseStyleInfo? GetBaseStyleInfo()
    {
        if (RootSkillInfo!.IsStyle()) return (BaseStyleInfo) RootSkillInfo;
        return null;
    }

    public ushort GetSkillCode() { return RootSkillInfo.SkillCode; }
    public ushort GetSkillClassCode() { return RootSkillInfo.SkillClassCode; }
    public byte GetSkillStatType() { return 0; }

    #region AbstractMethods

    protected abstract void SetExecutionInterval();
    public abstract SkillType GetSkillType();
    protected abstract bool CheckMainTarget(out BattleResult result);

    #endregion

    #region ProtectedMethods

    protected virtual void ConfigureAnimationDelay() { }
    protected virtual void AddAbilities(){ }
    protected virtual void DecreaseHPMP(){ }

    protected void RemoveAbilities(){ Abilities.Clear(); }

    protected void InitResultMsg()
    {
        NumberOfEffects = 0;
        NumberOfTargetsHit = 0;
    }
    protected void SetAttribution()
    {
        switch ( (SkillEnum) GetSkillClassCode())
        {
            case SkillEnum.SKILL_DOUBLE_ATTACK:
            case SkillEnum.SKILL_AIRBLOW:
            case SkillEnum.SKILL_BATTLERHONE:
                SkillAttribution |= Const.SKILL_ATTRIBUTION_TARGETFLYING;
                break;
            case SkillEnum.SKILL_ILLUSION_DANCE:
                SkillAttribution |= Const.SKILL_ATTRIBUTION_TARGETSTOP;
                break;
        }
    }

    protected bool ExecuteAbilities(Character target, out SkillResultBase skillResultBase)
    {
        skillResultBase = new SkillResultBase(target.GetKey());
        SkillInfo.SkillEffect = 0;
        for (var i = 0; i < Abilities.Count; i++)
        {
            var ability = Abilities[i];
            if (!ability.CanExecute(Owner, target, SkillInfo.MainTargetKey, SkillInfo.MainTargetPosition)) continue;
            ability.SetBonusEffect(BonusAbilityEffect!);

            if (ability.Execute(target, out var result))
            {
                skillResultBase.SkillResultAbility[skillResultBase.AbilityCount] = result!;
                skillResultBase.AbilityCount++;
            }

            if (BonusAbilityEffect!.TargetKey != 0) BonusAbilityEffect.Reset();
        }

        
        return skillResultBase.AbilityCount != 0;
    }

    protected byte ExecuteEffectAbilities(ref SkillResultBase skillResultBase)
    {
        for (var i = 0; i < Abilities.Count; i++)
        {
            if(!(Abilities[i].GetAbilityType() is AbilityType.ABILITY_TYPE_EFFECT or AbilityType.ABILITY_TYPE_ACTIVE_AND_EFFECT)) continue;

            if (Abilities[i].ExecuteEffect(out var result))
            {
                skillResultBase.SkillResultEffects[skillResultBase.EffectCount] = result!;
                skillResultBase.EffectCount++;

            }
        }

        return skillResultBase.EffectCount;
    }

    protected void BroadcastInstantResult()
    {
        var packetInfo = new InstantSkillResultInfo();
        packetInfo.SkillCode = SkillInfo.SkillCode;
        packetInfo.ClientSerial = SkillInfo.ClientSerial;
        packetInfo.AttackerObjKey = Owner!.GetKey();
        packetInfo.PrimeTargetObjKey = SkillInfo.MainTargetKey;
        packetInfo.PrimeTargetPosition = SkillInfo.MainTargetPosition;
        packetInfo.CurrentPos = SkillInfo.CurrentPosition;
        packetInfo.DestPos = SkillInfo.DestinationPosition;
        packetInfo.AttackerHP = (uint) Owner.GetHP();
        packetInfo.AttackerMP = (uint) Owner.GetMP();
        packetInfo.NumberOfTargets = (byte) NumberOfTargetsHit;
        packetInfo.NumberOfFieldEffects = (byte) NumberOfEffects;
        packetInfo.SkillResults = SkillResults;

        var packet = new SkillInstantResultBRD(packetInfo);

        Field!.SendToAll(packet);

    }

    protected void BroadCastDelayedResult()
    {
        var packetInfo = new ActionDelayResultInfo();
        packetInfo.SkillCode = SkillInfo.SkillCode;
        packetInfo.ClientSerial = SkillInfo.ClientSerial;
        packetInfo.AttackerObjKey = Owner!.GetKey();
        packetInfo.PrimeTargetObjKey = SkillInfo.MainTargetKey;
        packetInfo.PrimeTargetPosition = SkillInfo.MainTargetPosition;
        packetInfo.AttackerHP = (uint) Owner.GetHP();
        packetInfo.AttackerMP = (uint) Owner.GetMP();
        packetInfo.NumberOfTargets = (byte)NumberOfTargetsHit;
        packetInfo.NumberOfFieldEffects = (byte)NumberOfEffects;
        packetInfo.SkillResults = SkillResults;

        var packet = new SkillDelayResultBRD(packetInfo);

        Field!.SendToAll(packet);

    }

    protected void SendAIMessage(Character target, int damage=0)
    {
        var attackedMsg = new AIMsgAttacked(Owner.GetKey(), damage);
        target.OnAiMessage(attackedMsg);

        if ((SkillAttribution & Const.SKILL_ATTRIBUTION_TARGETFLYING) != 0)
        {
            AIMsgFlying flyMsg = new(DateTime.Now.Ticks, ExecuteTick);
            target.OnAiMessage(flyMsg);
        }
        if ((SkillAttribution & Const.SKILL_ATTRIBUTION_TARGETSTOP) != 0)
        {
            AIMsgKnockDown knockDownMsg = new(DateTime.Now.Ticks, ExecuteTick);
            target.OnAiMessage(knockDownMsg);
        }
    }
    #endregion

    #region PublicMethods

    public virtual void Init(Character owner, ref SkillInfo skillInfo, RootSkillInfo rootSkillInfo)
    {
        SetupDefault(owner,ref skillInfo,rootSkillInfo);

        AddAbilities();
        SetAttribution();
    }

    public virtual bool StartExecute(){ return true;}
    public virtual void CancelExecute(){ }
    public virtual void EndExecute()
    {
        if (Owner.IsObjectType(ObjectType.PLAYER_OBJECT))
        {
            var player = (Player) Owner;
            player.SetForceAttack(false);
        }
    }

    #endregion

    #region PrivateMethods


    #endregion
    public virtual void SetupDefault(Character owner, ref SkillInfo skillInfo, RootSkillInfo rootSkillInfo)
    {
        Abilities = new List<Ability>(5); //Max Abilities
        SkillResults = new SkillResultBase[Const.MAX_TARGET_COUNT];
        EffectResults = new SkillResultEffect[Const.MAX_EFFECT_COUNT];

        Owner = owner;
        Field = owner.GetCurrentField()!;

        RootSkillInfo = rootSkillInfo;
        SkillInfo = skillInfo;
        BonusAbilityEffect = new ();

        SetExecutionInterval();
        ConfigureAnimationDelay();

        ExecuteTick = DateTime.Now.AddMilliseconds(Interval).Ticks;

        bool isPassiveSkill=false;
        if (rootSkillInfo is BaseSkillInfo baseSkillInfo)
            isPassiveSkill = baseSkillInfo.SkillType == SkillType.SKILL_TYPE_PASSIVE;

        IsInvokedInSafeArea = false;

    }

}