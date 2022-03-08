using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using static CDShared.Generics.SunCalc;
using Timer = System.Timers.Timer;

namespace CDShared.Generics
{
    public class SunTimer
    {
        #region Properties

        private long _expireTime;
        private int _baseInterval;
        private int _bonusInterval;
        private bool _enabled;


        #endregion

        #region Setter
        public void SetTimer(int currentTime)
        {
            _baseInterval = currentTime;
            _bonusInterval = 0;
            Reset();
        }

        public void SetBonusInterval(int bonusInterval) { _bonusInterval = bonusInterval; }


        #endregion

        #region Getter
        public int GetBaseIntervalTime(){ return _baseInterval; }
        public int GetBonusIntervalTime(){ return _bonusInterval; }
        public int GetIntervalTime() { return Min(0,_baseInterval + _bonusInterval); }

        //public float GetProgressRatio()
        //{
        //    var processTicks = DateTime.Now.Ticks - (_expireTime - GetIntervalTime());
        //    return Max(1.0f,(float)processTicks / GetIntervalTime());
        //}

        public long GetRemainingTime()
        {
            var ticks = DateTime.Now.Ticks;
            if (_enabled && _expireTime > ticks) return _expireTime-ticks;
            
            return 0;
        }

        //public long GetProcessTime()
        //{
        //    var process = DateTime.Now.Ticks - (_expireTime - GetIntervalTime());
        //    return process > 0 ? process : 0;
        //}
        #endregion

        #region Methods

        public void Reset()
        {
            _expireTime = DateTime.Now.AddMilliseconds(GetIntervalTime()).Ticks;
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

            if (reset) { _expireTime = DateTime.Now.Millisecond + _baseInterval; }
            return true;
        }

        public bool IsExpiredManual(bool reset = false)
        {
            var ticks = DateTime.Now.Ticks;
            if (!_enabled) return false;
            if (ticks < _expireTime) return false;

            if (reset)
            {
                _expireTime = DateTime.Now.AddMilliseconds(_baseInterval).Ticks;
            }
            Disable();
            return true;
        }

        //public void InitCoolTime(long time)
        //{
        //    _expireTime = time;
        //}
        #endregion



    }

    public class TimerBase
    {
        private Timer? _timer;
        private bool _isElapsed;


        public void SetTimer(int delay,bool start=true,bool autoReset=false)
        {
            _isElapsed = false;
            if (_timer == null)
            {
                _timer = new Timer(delay);
                _timer.AutoReset = autoReset;
                _timer.Enabled = start;
                _timer.Elapsed += (sender, args) => _isElapsed = true;

            }

            _timer.Interval = delay;
            if (start) _timer.Start();
        }

        public bool IsExpired()
        {
            return _isElapsed;
        }

        public void Reset()
        {
            _isElapsed = false;
            _timer!.Start();
        }

        public void Stop()
        {
            _timer!.Stop();
        }
    }

}
