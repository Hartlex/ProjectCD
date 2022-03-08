using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Formulas;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.Packets.GameServerPackets.Skill;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Skill;
using static SunStructs.Definitions.AttrType;
using static SunStructs.Definitions.CharStateType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class AbilityStatus : BaseStatus
    {
        #region Const

        const int NO_APPLICATION = 0;
        const int APPLY_DECREASE = -1;
        const int APPLY_INCREASE = 1;

        #endregion

        protected bool IsApply { get; set; }
        protected AttrValueKind AbilityValueType { get; set; }
        protected int AbilityValue { get; set; }

        protected int SumValue { get; private set; }

        public ushort SkillCode { get; private set; }


        public AbilityID AbilityID { get; private set; }
        public byte AbilityIndex { get; private set; }

        public AttrType AttrType { get; private set; }
        public float TotemRadius { get; private set; }
        public byte AbilityEventCode { get; set; }

        public SkillExtraOption SkillOption { get; private set; }
        protected Character? Attacker { get; private set; }
        public BaseAbilityInfo BaseAbilityInfo { get; private set; }

        protected int Option1;
        protected int Option2;

        protected SkillAttrCalc SkillAttrCalc;

        #region Init

        public virtual void Init(Character owner, Character? attacker, Ability ability)
        {
            IsApply = false;
            Attacker = attacker;

            var skill = ability.GetSkill();

            var skillOption = skill.SkillInfo.SkillExtraOption;
            if (skillOption == null)
                skillOption = new();
            SkillOption = new();
            RegisterSkillOption(skillOption);

            var baseInfo = ability.GetBaseAbilityInfo();

            SkillCode = ability.GetSkillCode();
            AbilityID = baseInfo.AbilityId;
            AbilityIndex = (byte) baseInfo.Index;
            AttrType = ability.GetAttrType();

            var stateID = ability.GetCharStateType();
            var applyTime = baseInfo.Params[2];
            if(skill!=null && skill.SkillInfo.SkillFactor == (int) SkillFactorType.SKILL_FACTOR_EFFECT){ }
            else
            {
                var applyType = GetDurationControlWithRelation(owner, attacker, stateID, AbilityID, applyTime);

                if (applyType == APPLY_DECREASE)
                {
                    var changed = owner.GetAttributes()[ATTR_DECREASE_SKILL_SKILLDURATION].GetValue() * 1000;
                    changed = applyTime + changed;
                    applyTime = SunCalc.Min(0, changed);
                }
                else if (applyType == APPLY_INCREASE)
                {
                    var changed = owner.GetAttributes()[ATTR_INCREASE_SKILLDURATION].GetValue() * 1000;
                    applyType += changed;
                }

                //Combo apply Time

                
            }
            base.Init(owner,stateID,applyTime,baseInfo.Params[3]);

            Option1 = baseInfo.option1;
            Option2 = baseInfo.option2;
            AbilityValueType =  (AttrValueKind) baseInfo.Params[0];
            AbilityValue = baseInfo.Params[1];
            SumValue = 0;
            TotemRadius = 0;
            BaseAbilityInfo = baseInfo;

            if (attacker != null && attacker.IsObjectType(ObjectType.TOTEMNPC_OBJECT) &&
                attacker.IsTotemSKillAreaType())
            {
                var skillInfo = BaseSkillDB.Instance.GetBaseSkillInfo(SkillCode);
                if (skillInfo != null)
                    TotemRadius = skillInfo.SkillArea / 10f;
            }

            AbilityEventCode = ability.GetEventCode();
            SkillAttrCalc = new SkillAttrCalc(owner.GetAttributes());
        }

        public virtual void Init(Character owner, CharStateType stateType, BaseAbilityInfo baseInfo, ushort skillCode,
            int applicationTime, int period)
        {
            var ability = new Ability();
            var skillInfo = new SkillInfo();
            ability.InitDetailed(owner,skillCode,ref skillInfo,0,baseInfo);
            Init(owner,null,ability);
            
            base.Init(owner,stateType,applicationTime, period);
        }

        #endregion


        public override void Start()
        {
            base.Start();

            if (IsPeriodicStatus()) return;

            if(AttrType == ATTR_CUR_HP)
                ChangeHP(true,AbilityValueType,AbilityValue,Option2);
            else if (AttrType == ATTR_CUR_MP)
                ChangeMP(true, AbilityValueType, AbilityValue);
            else if( AttrType == ATTR_CUR_SD)
                ChangeSD(true,AbilityValueType, AbilityValue);
            else if (AttrType != ATTR_TYPE_INVALID)
            {
                var owner = GetOwner();
                if (owner == null) return;

                SkillAttrCalc.AddAttribute(AttrType, AbilityValueType, AbilityValue);

                SumValue += AbilityValue;
                IsApply = true;
            }
        }

        public override void Execute()
        {
            if (AttrType == ATTR_CUR_HP)
                ChangeHP(true, AbilityValueType, AbilityValue, Option2);
            else if (AttrType == ATTR_CUR_MP)
                ChangeMP(true, AbilityValueType, AbilityValue);
            else if (AttrType == ATTR_CUR_SD)
                ChangeSD(true, AbilityValueType, AbilityValue);
            else if (AttrType != ATTR_TYPE_INVALID)
            {
                var owner = GetOwner();
                if (owner == null) return;

                SkillAttrCalc.AddAttribute(AttrType, AbilityValueType, AbilityValue);

                SumValue += AbilityValue;
                IsApply = true;
            }

            base.Execute();
        }

        public override void End()
        {
            base.End();

            if (GetStateType() != CHAR_STATE_INVALID)
            {
                SendStatusDelBRD();
            }

            if (IsApply && AttrType != ATTR_TYPE_INVALID)
            {
                var owner = GetOwner();
                if(owner==null) return;

                SkillAttrCalc.DeleteAttribute(AttrType, AbilityValueType, SumValue);
            }
        }

        public override bool Update(long tick)
        {
            if (TotemRadius > 0)
            {
                if (Attacker == null) return false;
                if (Attacker!.IsDead()) return false;

                var owner = GetOwner();
                if (owner == null) return false;

                var distance = SunVector.GetDistance(owner.GetPos(), Attacker.GetPos());
                if (distance > TotemRadius) return false;

            }

            return base.Update(tick);
        }

        public override bool IsAbilityStatus()
        {
            return true;
        }

        #region New Virtual Methods

        public virtual void AttackAbsorb(int damage) { }
        public virtual void AttackedAbsorb(AttackType attackType, int damage) { }
        public virtual void DamageMirror(Character attacker,int damage) { }

        #endregion

        public bool IsReflectStatus()
        {
            switch (GetStateType())
            {
                case CHAR_STATE_REFLECT_DAMAGE:
                case CHAR_STATE_REFLECT_SLOW:
                case CHAR_STATE_REFLECT_FROZEN:
                case CHAR_STATE_REFLECT_SLOWDOWN:
                case CHAR_STATE_REFLECT_STUN:
                case CHAR_STATE_REFLECT_FEAR:
                    return true;
                default:
                    return false;
            }
        }

        public bool ComparePriority(Ability ability)
        {
            if (GetExpireTime() == long.MaxValue) return true;

            var attrType = ability.GetAttrType();

            if (attrType == ATTR_TYPE_INVALID) return false;

            var abilityInfo = ability.GetBaseAbilityInfo();
            var valueType = (AttrValueKind) abilityInfo.Params[0];
            if (valueType != AbilityValueType) return false;

            double sumValue = AbilityValue;
            {
                long expireTime = GetExpireTime();
                long currentTick = DateTime.Now.Ticks;
                int remainMs = (int) (expireTime>currentTick ? (expireTime-currentTick)/TimeSpan.TicksPerMillisecond : 0);
                if (GetApplicationTime() != 0)
                {
                    int periodTime = GetPeriodTime();
                    if (periodTime != 0)
                    {
                        sumValue *= remainMs / periodTime;
                    }
                    else
                    {
                        sumValue *= remainMs;
                    }
                }
            }
            double sumValue2 = 0;

            {
                int inValue = abilityInfo.Params[1];
                sumValue2 = inValue;

                int applyTime = abilityInfo.Params[2];
                if (applyTime != 0)
                {
                    int period = abilityInfo.Params[3];
                    if (period != 0)
                        sumValue2 *= applyTime / period;
                    else
                        sumValue2 *= applyTime;
                }
            }

            return Math.Abs(sumValue) > Math.Abs(sumValue2);


        }

        public void RegisterSkillOption(SkillExtraOption option)
        {
            SkillOption.ApplyOption(option);
        }


        protected void ChangeHP(bool isIncrease, AttrValueKind valueType, int value, int hpLimit)
        {
            var owner = GetOwner();
            if(owner == null) return;

            int resultValue = value;

            if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                resultValue = (int) (owner.GetMaxHP() * value / 1000);
            else if(valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
                resultValue = (int) (owner.GetHP() * value / 1000);
            if (isIncrease == false)
            {
                resultValue -= resultValue;
            }

            if (isIncrease)
            {
                if (Attacker != null)
                {
                    var attackerAttr = Attacker.GetAttributes();

                    var addSkillRatio = attackerAttr[ATTR_ADD_SKILL_DAMAGE_RATIO].GetValue();
                    if (addSkillRatio != 0)
                    {
                        var calcSkillRatio = value * addSkillRatio;
                        if (calcSkillRatio != 0)
                            resultValue += calcSkillRatio;
                    }

                    var addValue = CharacterFormulas.CalcIncreaseHeal(IncreaseHealAbilityType.SKILL, resultValue, Attacker!);
                    resultValue += addValue;

                }
            }

            int tmpHpLimit = hpLimit;
            if (owner.IsObjectType(ObjectType.NPC_OBJECT) && owner is NPC npc)
            {
                if (npc.GetGrade() is NPCGrade.NPC_CRYSTAL_WARP or NPCGrade.NPC_DOMINATION_MAPOBJECT_NPC)
                    tmpHpLimit = 100;
            }

            int hpLimitRatio = SunCalc.Min(0, SunCalc.Max(100, tmpHpLimit));
            float calcHPLimit = tmpHpLimit;
            if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                calcHPLimit = owner.GetMaxHP() * (hpLimitRatio / 100f);
            else if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
                calcHPLimit = owner.GetHP() * (hpLimitRatio / 100f);

            if (resultValue < 0)
            {
                if (Attacker == null) return;
                StateInfoDB.Instance.TryGetStateInfo(GetStateType(),out var stateInfo);

                DamageArgs damageArgs = new DamageArgs()
                {
                    attacker = Attacker,
                    attackType = AttackType.ATTACK_TYPE_MELEE,
                    LimitHP = (int) calcHPLimit,
                    AttackResistKind = AttackResist.ATTACK_RESIST_SKILL,
                    SDApply = stateInfo?.SDApply ?? SDApply.SD_APPLY_NOT,
                    Damage = -resultValue
                };
                
                owner.Damaged(damageArgs);

                var dmgInfo = new PeriodicDmgInfo(Attacker.GetKey(), SkillCode,
                    new DamageInfo[] {new DamageInfo(owner.GetKey(), (ushort) damageArgs.Damage, (uint) owner.GetHP())});
                var packet = new PeriodicDamageBRD(dmgInfo);
                owner.SendPacketAround(packet);
            }
            else if (resultValue > 0)
            {
                if (Attacker == null) return;
                owner.OnRecover(resultValue,0,0,0,Attacker);
            }
        }

        protected void ChangeMP(bool isIncrease, AttrValueKind valueType, int value)
        {
            var owner = GetOwner();
            if(owner== null) return;

            int resultValue = value;
            if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                resultValue = (int) (owner.GetMaxMP() * (value / 1000f));
            else if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
                resultValue = (int) (owner.GetMP() * (value / 1000f));
            if (!isIncrease)
                resultValue = -resultValue;

            owner.OnRecover(0,resultValue,0);
        }

        protected void ChangeSD(bool isIncrease, AttrValueKind valueType, int value)
        {
            var owner = GetOwner();
            if (owner == null) return;

            int resultValue = value;
            if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_MAX)
                resultValue = (int)(owner.GetMaxSD() * (value / 1000f));
            else if (valueType == AttrValueKind.VALUE_TYPE_PERCENT_PER_CUR)
                resultValue = (int)(owner.GetSD() * (value / 1000f));
            if (!isIncrease)
                resultValue = -resultValue;

            owner.OnRecover(0, 0, resultValue);
        }

        public int GetDurationControlWithRelation(Character owner, Character attacker, CharStateType InCharState,
            AbilityID abilityID, int applicationTime)
        {

            var charState = InCharState;

            if (charState == CHAR_STATE_INVALID)
                charState = GetStateType();

            StateInfoDB.Instance.TryGetStateInfo(charState,out var stateInfo);
            if(stateInfo==null)
                return applicationTime==0 ? NO_APPLICATION : APPLY_INCREASE;

            if (applicationTime < 0) return APPLY_DECREASE;

            if (stateInfo.Type == StateType.STATE_TYPE_SPECIALITY) return NO_APPLICATION;

            var badStatus = stateInfo.Type is StateType.STATE_TYPE_SPECIALITY or StateType.STATE_TYPE_WEAKENING;

            if (ReferenceEquals(owner, attacker))
            {
                return badStatus ? APPLY_DECREASE : APPLY_INCREASE;
            }

            if (abilityID == AbilityID.ABILITY_BONUS_DAMAGE_PER_ATTACK) return NO_APPLICATION;

            return badStatus ? APPLY_DECREASE : APPLY_INCREASE;
        }
    }
}
