using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static CDShared.Generics.SunCalc;

namespace CDShared.Generics
{
    public class SunTimer
    {
        #region Properties

        private long _expireTime;
        private long _baseInterval;
        private bool _enabled;
        private long _bonusInterval;

        #endregion

        #region Setter
        public void SetTimer(long currentTime)
        {
            _baseInterval = currentTime;
            _bonusInterval = 0;
            Reset();
        }

        public void SetBonusInterval(long bonusInterval) { _bonusInterval = bonusInterval; }


        #endregion

        #region Getter
        public long GetBaseIntervalTime(){ return _baseInterval; }
        public long GetBonusIntervalTime(){ return _bonusInterval; }
        public long GetIntervalTime() { return Min(0,_baseInterval + _baseInterval); }

        public float GetProgressRatio()
        {
            var processTicks = DateTime.Now.Ticks - (_expireTime - GetIntervalTime());
            return Max(1.0f,(float)processTicks / GetIntervalTime());
        }

        public long GetRemainingTime()
        {
            var ticks = DateTime.Now.Ticks;
            if (_enabled && _expireTime > ticks) return _expireTime - ticks;
            
            return 0;
        }

        public long GetProcessTime()
        {
            var process = DateTime.Now.Ticks - (_expireTime - GetIntervalTime());
            return process > 0 ? process : 0;
        }
        #endregion

        #region Methods

        public void Reset()
        {
            _expireTime = DateTime.Now.Ticks + GetIntervalTime();
            Enable();
        }

        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public bool IsExpired(bool reset = false)
        {
            var ticks = DateTime.Now.Ticks;
            if (!_enabled) return false;
            if (ticks < _expireTime) return false;

            if (reset) { _expireTime = ticks + _baseInterval; }
            return true;
        }

        public bool IsExpiredManual(bool reset = false)
        {
            var ticks = DateTime.Now.Ticks;
            if (!_enabled) return false;
            if (ticks < _expireTime) return false;

            if (reset) { _expireTime = ticks + _baseInterval; }
            Disable();
            return true;
        }

        public void InitCoolTime(long time)
        {
            _expireTime = time;
        }
        #endregion



    }
}
