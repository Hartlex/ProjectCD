using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem;
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

        protected int ShieldHP;
        protected int ShieldMP;
        protected float DecreaseMPRatio;
        protected float ShieldAbsorbRatio;
        protected int FightingEnergyCount;
        protected int UsedFightingEnergySize;

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
    }


}
