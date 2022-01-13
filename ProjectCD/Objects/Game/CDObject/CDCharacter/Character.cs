using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.Game.CDObject.CDCharacter.PartySystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using ProjectCD.Objects.Game.CDObject.CDCharacter.StateSystem;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Status;
using static CDShared.Generics.SunCalc;
using static SunStructs.Definitions.AttrType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter
{
    public abstract class Character : ObjectBase
    {
        #region Properties

        #region protected




        protected ulong DeadExp;
        protected ObjectType KillerObjectType;
        protected uint KillerObjectKey;
        protected CharDeadType DeadType;

        protected CooldownTable CooldownTable;
        protected StatusManager StatusManager;

        protected PartyState PartyState; //TODO move to Player?
        #endregion

        #region private

        private bool _isMoving;

        private uint _hp;
        private uint _mp;
        private uint _sd;

        private int _shieldHP;
        private int _shieldMP;
        private float _decreaseMPRatio;
        private float _shieldAbsorbRatio;
        private int _fightingEnergyCount;
        private int _usedFightingEnergySize;

        private ulong _deadExp;

        private Attributes _attr;

        #endregion

        #endregion


        protected Character(uint key) : base(key)
        {
            SetObjectType(ObjectType.CHARACTER_OBJECT);
            StatusManager = new (this);
            _isMoving = false;
        }


        #region Attributes

        protected void SetBaseAttributes(Attributes attr) { _attr = attr; }

        #region HP MP SD

        public uint GetHP() { return _hp; }
        public uint GetMP() { return _mp; }
        public uint GetSD() { return _sd; }

        public uint GetMaxHP() { return _attr[ATTR_MAX_HP].GetValue32(); }
        public uint GetMaxMP() { return _attr[ATTR_MAX_MP].GetValue32(); }
        public uint GetMaxSD() { return _attr[ATTR_MAX_SD].GetValue32(); }

        public void SetHP(uint value)
        {
            var maxHP = GetMaxHP();
            _hp = Min(0, Max(maxHP, value));
        }
        public void SetMP(uint value)
        {
            var maxMP = GetMaxMP();
            _mp = Min(0, Max(maxMP, value));
        }
        public void SetSD(uint value)
        {
            var maxSD = GetMaxSD();
            _sd = Min(0, Max(maxSD, value));
        }

        public virtual uint IncreaseHP(uint value)
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
        public virtual uint DecreaseHP(int value, int limitHP)
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
                uint hp = (uint) (curHp - value);
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

            return (uint) value;
        }

        public virtual uint IncreaseMP(uint value)
        {
            var curMP = GetMP();
            var calcMP = curMP + value;
            var maxMP = GetMaxMP();

            var mp = Max(maxMP, calcMP);
            value = mp - curMP;

            SetMP(mp);

            return value;
        }
        public virtual uint DecreaseMp(uint value)
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

        public virtual uint IncreaseSD(uint value)
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
        public virtual uint DecreaseSD(uint value)
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

            SetMP((uint) (GetMP()-decreaseMP));

            if (_shieldHP <= 0)
            {
                _shieldHP = 0;
                StatusManager.Remove(CharStateType.CHAR_STATE_MAGIC_SHIELD);
            }

            return damage - absorbDamage;
        }

        #endregion


        #endregion


        public virtual float GetPhysicalAttackSpeed(){ return _attr[ATTR_ATTACK_SPEED].GetValue() / 100f; }
        public virtual int GetAttSpeedRatio(){ return _attr[ATTR_ATTACK_SPEED].GetValue(); }
        public virtual int GetMoveSpeedRatio() { return _attr[ATTR_MOVE_SPEED].GetValue(); }

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
            return _isMoving;
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

            var newHP = (uint) (GetMaxHP() * recoverHPRatio);
            var newMP = (uint) (GetMaxMP() * recoverMPRatio);
            var newSD = GetMaxSD();

            SetHP(newHP);
            SetMP(newMP);
            SetSD(newSD);

            return true;
        }

        #endregion

    }


}
