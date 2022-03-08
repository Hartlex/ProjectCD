using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using static SunStructs.Definitions.Const;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem
{
    internal class BaseStatus
    {
        private Character? _owner;
        private CharStateType _stateType;
        private int _period;
        private int _applicationTime;
        private long _executionTime;
        private long _expireTime;
        private bool _requestRemove;

        public virtual void Init(Character owner, CharStateType stateType, int applicationTime, int period)
        {
            _owner = owner;
            _requestRemove = false;
            _stateType = stateType;
            _applicationTime = applicationTime;
            _period = period;
            _executionTime = DateTime.Now.Ticks;
            if (applicationTime == BASE_EXPIRE_TIME_INFINITY)
                _expireTime = BASE_EXPIRE_TIME_INFINITY;
            else
                _expireTime = new DateTime(_executionTime).AddMilliseconds(_applicationTime).Ticks;
        }
        public virtual void Start(){}

        public virtual void Execute()
        {
            _executionTime = DateTime.Now.AddMilliseconds(_period).Ticks;
        }
        public virtual void End(){}
        public virtual bool Update(long tick)
        {
            if (_requestRemove) return false;
            if (IsExpired(tick)) return false;
            if(IsExecutionTime(tick)) Execute();

            return true;
        }


        #region Getters

        public long GetLeavedTime()
        {
            var tick = DateTime.Now.Ticks;
            if (IsExpired(tick)) return 0;
            if (_expireTime == BASE_EXPIRE_TIME_INFINITY) return BASE_EXPIRE_TIME_INFINITY;

            return _expireTime - tick;
        }
        public bool IsPeriodicStatus() { return _period != 0; }
        public int GetPeriodTime() { return _period; }
        public int GetApplicationTime() { return _applicationTime; }
        public long GetExpireTime(){ return _expireTime; }
        public CharStateType GetStateType() { return _stateType; }
        public Character? GetOwner() { return _owner; }
        public virtual bool IsNotifyStatus(){ return false; }
        public virtual bool IsAbilityStatus(){ return false; }
        public virtual bool CanRemove(){ return true; }

        #endregion

        #region Setters
        
        public void SetStateID(CharStateType stateType) { _stateType = stateType; }
        public void SetExpiredTime(long expireTime){ _expireTime = expireTime; }
        public virtual void SetRegenInfo(int regenHP = 0, int regenMP = 0) { }

        #endregion




        public void StopStatus(){ _requestRemove = true; }
        public void CancelRequestStop(){ _requestRemove = false; }

        public virtual bool SendStatusAddBRD()
        {
#if DEBUG
            Logger.Instance.Log($"Added Status[{_stateType}] to Player[{_owner.GetKey()}]");
#endif
            _owner?.GetCurrentField()?.QueueWarPacketInfo(new StatusAddBrd(_owner.GetKey(),_stateType));
            return true;
        }

        public virtual bool SendStatusDelBRD()
        {
#if DEBUG
            Logger.Instance.Log($"Removed Status[{_stateType}] from Player[{_owner.GetKey()}]");
#endif
            _owner?.GetCurrentField()?.QueueWarPacketInfo(new StatusRemoveBrd(_owner.GetKey(), _stateType));
            return true;
        }

#region Private

        private bool IsExecutionTime(long tick) { return tick >= _executionTime && IsPeriodicStatus(); }
        public bool IsExpired(long tick) { return _expireTime != BASE_EXPIRE_TIME_INFINITY && _expireTime<=tick; }

#endregion
    }
}
