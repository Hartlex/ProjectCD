using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Formulas;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.CDObject.CDCharacter.PartySystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Status;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.AI;
using static CDShared.Generics.SunCalc;
using static SunStructs.Definitions.AttrType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter
{
    internal abstract class Character : ObjectBase
    {
        #region Properties

        #region protected




        protected ulong DeadExp;
        protected ObjectType KillerObjectType;
        protected uint KillerObjectKey;
        protected CharDeadType DeadType;

        protected CooldownTable CooldownTable;
        public MoveStateControl MoveStateControl;
        protected StatusManager StatusManager;
        protected ActiveSkillManager ActiveSkillManager;

        protected PartyState PartyState; //TODO move to Player?
        #endregion

        #region private

        

        private int _hp;
        private int _mp;
        private int _sd;

        private uint _reserveHP;
        private uint _deadReserveHP;

        private int _shieldHP;
        private int _shieldMP;
        private float _decreaseMPRatio;
        private float _shieldAbsorbRatio;
        private int _fightingEnergyCount;
        private int _usedFightingEnergySize;

        private ulong _deadExp;
        private uint _summonerKey;
        private Attributes _attr;

        #endregion

        #endregion


        protected Character(uint key) : base(key)
        {
            SetObjectType(ObjectType.CHARACTER_OBJECT);
            DeadType = CharDeadType.CHAR_DEAD_NOT_DEAD;
        }

        protected void Initialize()
        {
            _shieldHP = 0;
            _shieldMP = 0;
            _decreaseMPRatio = 0;
            _shieldAbsorbRatio = 0;
            _fightingEnergyCount = 0;
            _usedFightingEnergySize = 0;

            _deadExp = 0;
            _summonerKey = 0;

            _reserveHP = 0;
            _deadReserveHP = 0;
            
            StatusManager = new(this);
            ActiveSkillManager = new(this);
            MoveStateControl = new(this, CharMoveState.CMS_RUN);
        }

        public override bool Update(long currentTick)
        {
            StatusManager.Update(currentTick);
            ActiveSkillManager.Update();
            MoveStateControl.Update(currentTick);
            return true;
        }

        #region Attributes

        protected void SetBaseAttributes(Attributes attr) { _attr = attr; }

        #region HP MP SD

        public int GetHP() { return _hp; }
        public int GetMP() { return _mp; }
        public int GetSD() { return _sd; }

        public int GetMaxHP() { return _attr[ATTR_MAX_HP].GetValue(); }
        public int GetMaxMP() { return _attr[ATTR_MAX_MP].GetValue(); }
        public int GetMaxSD() { return _attr[ATTR_MAX_SD].GetValue(); }
        
        public void SetHP(int value)
        {
            var maxHP = GetMaxHP();
            _hp = Min(0, Max(maxHP, value));
        }
        public void SetMP(int value)
        {
            var maxMP = GetMaxMP();
            _mp = Min(0, Max(maxMP, value));
        }
        public void SetSD(int value)
        {
            var maxSD = GetMaxSD();
            _sd = Min(0, Max(maxSD, value));
        }

        public virtual int IncreaseHP(int value)
        {
            var curHP = GetHP();
            var calcHP = curHP +value;
            var maxHP = GetMaxHP();

            var hp = Max(maxHP, calcHP);
            value = hp - curHP;

            SetHP(hp);

            if (value != 0)
                StatusManager.ChangeHP();

            return value;
        }
        public virtual int DecreaseHP(int value, int limitHP=0)
        {
            var curHp = (int)GetHP();
            bool IsDead = false;

            if (curHp == 0) return 0;

            value = ApplyMagicShield(value);
            if (limitHP > 0 && limitHP > (curHp - value))
            {
                if (curHp > limitHP)
                    value = (curHp - limitHP);
                else
                    value = 0;
            }

            if (curHp <= value)
            {
                value = curHp;
                SetHP(0);
                OnDead();
                IsDead = true;
            }
            else
            {
                var hp =  (curHp - value);
                SetHP(hp);
            }

            if (IsDead)
            {
                int chance = GlobalRandom.Rand(0, 100);
                if (chance < _attr[ATTR_RESURRECTION_RATIO].GetValue())
                {
                    OnResurrection(0, 1, 1);
                }
            }

            return value;
        }

        public virtual int IncreaseMP(int value)
        {
            var curMP = GetMP();
            var calcMP = curMP + value;
            var maxMP = GetMaxMP();

            var mp = Max(maxMP, calcMP);
            value = mp - curMP;

            SetMP(mp);

            return value;
        }
        public virtual int DecreaseMP(int value)
        {
            var curMP = GetMP();
            if (curMP <= value)
            {
                value = curMP;
                SetMP(0);
            }
            else
            {
                var mp = curMP - value;
                SetMP(mp);
            }

            return value;
        }

        public virtual int IncreaseSD(int value)
        {
            var curSD = GetSD();
            var maxSD = GetMaxSD();
            var calcSD = curSD + value;

            var newSD = Max(maxSD, calcSD);
            var allocStatus = curSD == 0 && newSD != 0;
            var realIncrement = newSD - curSD;

            SetSD(newSD);
            if (allocStatus)
            {
                if (StatusManager.AllocStatus(CharStateType.CHAR_STATE_ETC_EXIST_SHELD_POINT, out var status))
                {
                    status!.SendStatusAddBRD();
                }
            }

            return realIncrement;
        }
        public virtual int DecreaseSD(int value)
        {
            var curSD = GetSD();
            if (curSD <= value)
            {
                value = curSD;
                SetSD(0);
                StatusManager.Remove(CharStateType.CHAR_STATE_ETC_EXIST_SHELD_POINT);
            }
            else
            {
                var newSD = curSD - value;
                SetSD(newSD);
            }

            return value;
        }

        public virtual int GetRegenHP()
        {
            return _attr[ATTR_RECOVERY_HP].GetValue();
        }
        public virtual int GetRegenMP()
        {
            return _attr[ATTR_RECOVERY_MP].GetValue();
        }

        public virtual int GetRegenSD()
        {
            return _attr[ATTR_RECOVERY_SD].GetValue();
        }

        #region Shield

        public int ApplyMagicShield(int damage)
        {
            if (_shieldMP == 0) return damage;
            if (_decreaseMPRatio == 0) return damage;

            var decreaseMP = 0;

            decreaseMP = (int) (damage * _decreaseMPRatio);

            if (GetMP() < decreaseMP)
                return damage;

            int absorbDamage = (int) (damage * _shieldAbsorbRatio);

            absorbDamage = Max(_shieldHP, absorbDamage);
            absorbDamage = Min(0, absorbDamage);
            absorbDamage = Max(damage, absorbDamage);

            _shieldHP -= absorbDamage;

            SetMP((GetMP()-decreaseMP));

            if (_shieldHP <= 0)
            {
                _shieldHP = 0;
                StatusManager.Remove(CharStateType.CHAR_STATE_MAGIC_SHIELD);
            }

            return damage - absorbDamage;
        }

        public void SetShield(int shieldHP, int shieldMP, float hpRatio, float mpRatio)
        {
            _shieldHP = shieldHP;
            _shieldMP = shieldMP;
            _shieldAbsorbRatio = hpRatio;
            _decreaseMPRatio = mpRatio;
        }
        #endregion


        #endregion

        public virtual float GetPhysicalAttackSpeed(){ return _attr[ATTR_ATTACK_SPEED].GetValue() / 100f; }
        public virtual int GetAttSpeedRatio(){ return _attr[ATTR_ATTACK_SPEED].GetValue(); }
        public virtual int GetMoveSpeedRatio() { return _attr[ATTR_MOVE_SPEED].GetValue(); }
        public virtual int GetSightRange(){ return _attr[ATTR_SIGHT_RANGE].GetValue()/10; }
        public virtual float GetMPSpendIncRatio() { return 0;}
        public virtual int GetMPSpendIncValue() { return 0;}
        public virtual int GetSkillRangeBonus() { return 0;}
        public virtual int GetSkillRangeBonusRatio() { return 0;}

        public void SetAttr(AttrType type, AttrValueType kind, int value)
        {
            if (type is <= ATTR_TYPE_INVALID or >= ATTR_MAX)
            {
                Logger.Instance.Log($"Attribute[{type}] invalid!");
                return;
            }
            _attr[type].SetValue(value,kind);
            _attr.UpdateEx();
        }
        #endregion

        public void SendPacketAround(Packet packet)
        {
            GetCurrentField()?.SendToAll(packet);
        }
        public void SendAttrChange(AttrType attrType, int value)
        {
            var packet = new AttrChangeBrd(new (GetKey(), attrType, value));
            SendPacketAround(packet);
        }
        public bool IsMoving()
        {
            return MoveStateControl.IsMoving();
        }

        #region Dead/Alive/Exp

        public virtual ulong AddExp(ulong exp,uint TargetObjKey,float bonusRatio,bool sendPacket){return 0;}
        public bool IsAlive()
        {
            return GetHP() > 0;
        }

        public bool IsDead()
        {
            return !IsAlive();
        }

        public virtual void OnDead()
        {

        }

        public virtual bool OnResurrection(float recoverExpRatio, float recoverHPRatio, float recoverMPRatio, Player? healer=null)
        {
            if (IsAlive()) return false;

            ulong recoverExp = (ulong) (_deadExp * recoverExpRatio);
            AddExp(recoverExp, 0, 0, false);

            int newHP = (int) (GetMaxHP() * recoverHPRatio);
            int newMP = (int) (GetMaxMP() * recoverMPRatio);
            var newSD = GetMaxSD();

            SetHP(newHP);
            SetMP(newMP);
            SetSD(newSD);

            return true;
        }

        #endregion

        public StatusManager GetStatusManager() { return StatusManager; }


        #region Abstract SC Character

        public abstract Attributes GetAttributes();
        public abstract AttackType GetWeaponBaseAttackType();
        public abstract AttackType GetWeaponMagicAttackType();
        public abstract int GetPhysicalAvoidValue();
        public abstract ushort GetLevel();
        public abstract ushort GetDisplayLevel();
        public abstract ArmorType GetArmorType();
        public abstract MeleeType GetMeleeType();
        

        #endregion

        #region Virtual Battle Methods

        public virtual void SetActionDelay(int delay)
        {

        }

        public virtual void UpdateCalcRecover(bool hp, bool mp, bool sd)
        {

        }
        public virtual void OnRecover(int recoverHP, int recoverMP, int recoverSD, RecoverType recoverType=0, Character? attacker=null)
        {
            if (recoverHP > 0)
            {
                IncreaseHP(recoverHP);
                var packet = new StatusRecoverHpBrd(new(GetKey(), (uint) GetHP(), _reserveHP));
                SendPacketAround(packet);
            }
            if (recoverHP < 0)
                DecreaseHP(-recoverHP);

            if (recoverMP > 0)
            {
                IncreaseMP(recoverMP);
                var packet = new StatusRecoverMpBrd(new(GetKey(), (uint)GetMP()));
                SendPacketAround(packet);
            }
                
            if (recoverMP < 0)
                DecreaseMP(-recoverMP);

            if (recoverSD > 0)
                IncreaseSD(recoverSD);
            if (recoverSD < 0)
                DecreaseSD(-recoverSD);
        }
        public virtual bool ExecuteThrust(bool forced, SunVector destPos, ref SunVector posAfterThrust,
            float moveDistance, bool downAfterThrust)
        {
            return true;
        }

        public virtual void OnAttack(Character target, ushort skillCode, int damage)
        {
            StatusManager.Attack(damage);
        }

        public void ForcedAttack(Character mainTarget)
        {
            
        }
        public virtual void SetTargetChar(Character attacker)
        {

        }
        public bool CanBeAttacked()
        {
            return !IsDead() && StatusManager.CanBeAttacked();
        }

        public virtual UserRelationType IsFriend(Character target)
        {
            if (ReferenceEquals(target, this)) return UserRelationType.USER_RELATION_FRIEND;
            return UserRelationType.USER_RELATION_ENEMY;
        }

        public virtual int GetResistBadStatusRatio(ushort stateID)
        {
            return 0;
        }

        public virtual bool CanResurrect(Character target)
        {
            return true;
        }
        public bool CheckSkillRange(Character mainTarget, SunVector position, float range=0)
        {
            var aiInfo = AiParameterDb.Instance.GetAiParamInfo();
            range += aiInfo.RangeTolerance;

            if (range >= 4)
            {
                var bonus = range * GetSkillRangeBonusRatio() / 100;
                range += GetSkillRangeBonus() + bonus;
            }
            //no height check
            //Logger.Instance.Log($"Player pos[{GetPos()}] TargetPos[{position}] Distance[{SunVector.GetDistance(GetPos(), position)}]");
            return SunVector.Get2DDistance(GetPos(),position) < range;
        }

        public virtual bool IsTotemSKillAreaType(){ return true; }

        #endregion

        #region AI

        public virtual void AddBattlePoint(Character attacker, BattlePointType pointType, int value)
        {
        }

        public virtual void ChangeState(AIStateID stateID,int param1=0,int param2=0,int param3=0)
        {

        }
        public virtual void SendAiMessageAroundExceptMe(AIMsg msg){}
        public virtual void OnAiMessage(AIMsg msg){}

        protected bool CheckCondition(int condition, int param)
        {
            switch (condition)
            {
                case 1:
                    return CheckConditionUnderHP(param);
                case 2:
                    return CheckConditionUnderMP(param);
                case 3:
                    return CheckConditionSameHP(param);
                case 4:
                    return CheckConditionSameMP(param);
                case 5:
                    return IsDead();
                default:
                    return false;

            }
        }

        private bool CheckConditionUnderHP(int percent)
        {
            if (GetMaxHP() == 0) return false;
            if (IsDead()) return false;
            return GetHP() * 100 / GetMaxHP() <= percent;
        }
        private bool CheckConditionUnderMP(int percent)
        {
            if (GetMaxMP() == 0) return false;
            if (IsDead()) return false;
            return GetMP() * 100 / GetMaxMP() <= percent;
        }
        private bool CheckConditionSameHP(int percent)
        {
            if (GetMaxHP() == 0) return false;
            return GetHP() * 100 / GetMaxHP() == percent;
        }
        private bool CheckConditionSameMP(int percent)
        {
            if (GetMaxMP() == 0) return false;
            return GetMP() * 100 / GetMaxMP() == percent;
        }

        #endregion

        public void SetMoveState(CharMoveState state)
        {
            MoveStateControl.SetMoveState(state);
        }
        public uint GetSectorID()
        {
            return MoveStateControl.GetSectorID();
        }


        public virtual void Attacked()
        {
            StatusManager.Attacked();
        }

        public bool CanAttack()
        {
            if (IsDead()) return false;
            return StatusManager.CanAttack();
        }

        public void Damaged(DamageArgs damageArgs)
        {
            var attacker = damageArgs.attacker;

            if (ReferenceEquals(this, attacker) || damageArgs.IsMirror)
            {
                int curHP = (int) GetHP();
                if (curHP <= damageArgs.Damage)
                    damageArgs.Damage = (ushort) (curHP - (curHP * 0.01f));

            }

            if (attacker != null)
            {
                KillerObjectType = attacker.GetObjectType();
                KillerObjectKey = attacker.GetKey();
            }
            else
            {
                KillerObjectType = ObjectType.MAX_OBJECT;
                KillerObjectKey = 0;
            }

            if (damageArgs.IsMirror == false)
            {
                var dmg = damageArgs.Damage;
                GetStatusManager().Damaged(attacker, damageArgs.attackType, ref dmg);
                damageArgs.Damage = dmg;
            }

            damageArgs.Damage = ApplyOptionDecDamage(attacker, damageArgs.Damage, damageArgs.AttackResistKind);

            damageArgs.Damage = (int) DecreaseHP(damageArgs.Damage, damageArgs.LimitHP);

            if (damageArgs.IsMirror == false)
            {
                StatusManager.DamagedAbsorb(damageArgs.Damage);
            }
            //Logger.Instance.Log($"[{GetKey()}] damaged for {damageArgs.Damage} new Health: {GetHP()}");
            Attacked();
            StatusManager.UpdateExpireTime(CharStateType.CHAR_STATE_BATTLE, Const.STATE_BATTLE_TIME);

            //TODO BATTLERECORDRESULT
        }

        private int ApplyOptionDecDamage(Character? attacker, int damage, AttackResist attackResistKind)
        {
            var attr = GetAttributes();
            int resistValue = attr[ATTR_DECREASE_DAMAGE].GetValue();
            int resistRatio = attr[ATTR_DECREASE_DAMAGE].GetValue(AttrValueType.CALC_RATIO);

            damage = CalcDecreaseDamage(damage, resistValue, resistRatio);

            if (attacker == null || !attacker.IsObjectType(ObjectType.PLAYER_OBJECT)) return damage;

            if (!IsObjectType(ObjectType.PLAYER_OBJECT)) return damage;
            //PVP
            resistValue = attr[ATTR_DECREASE_PVPDAMAGE].GetValue();
            resistRatio = attr[ATTR_DECREASE_PVPDAMAGE].GetValue(AttrValueType.CALC_RATIO);

            damage = CalcDecreaseDamage(damage, resistValue, resistRatio);

            return damage;
        }

        private int CalcDecreaseDamage(int damage, int resistValue, int resistRatio)
        {
            if (damage == 0) return 0;

            damage -= resistValue;
            if (resistRatio != 0)
            {
                damage = damage * (1 - resistRatio / 100);
            }

            return damage < 0 ?  0 :  damage;
        }

        public void CancelAllSkill()
        {
            ActiveSkillManager.CancelAllSkill();
        }

        public void StopMoving()
        {
            
        }

        public bool HasEnoughMP(int value)
        {
            int spent = (int) (value * (1 + GetMPSpendIncRatio()) + GetMPSpendIncValue());
            spent = Min(0, spent);
            return GetMP() > spent;
        }

        public ActiveSkillManager GetActiveSkillManager()
        {
            return ActiveSkillManager;
        }
    }


}
