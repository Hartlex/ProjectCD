using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem
{
    public class AnimationDelayController
    {
        private const bool NEED_SKIP = true;
        private const bool RET_NORMAL = false;
        private List<DelayInfo> _delayInfos = new List<DelayInfo>(10);


        public bool NeedSkipProcessByAnimationDelay(object obj)
        {
            if (_delayInfos.Count == 0) return RET_NORMAL;

            for (var i = 0; i < _delayInfos.Count; i++)
            {
                var delayInfo = _delayInfos[i];
                if (!delayInfo._timer.IsExpired()) break;

                if (delayInfo._obj == obj)
                {
                    _delayInfos.Remove(delayInfo);
                    return RET_NORMAL;
                }
            }

            if (_delayInfos.Count == 0) return RET_NORMAL;

            return _delayInfos[0]._obj == obj ? RET_NORMAL : NEED_SKIP;
        }

        public bool SetAnimationDelay(object obj, int delay)
        {
            if(delay ==0) return RET_NORMAL;

            var curTick = DateTime.Now.Ticks;
            var expTick = DateTime.Now.AddMilliseconds(delay).Ticks;

            for (var i = 0; i < _delayInfos.Count; i++)
            {
                if (_delayInfos[i]._timer.IsExpired())
                    _delayInfos.RemoveAt(i);
            }

            if (_delayInfos.Count == 0)
            {
                _delayInfos.Add(new DelayInfo()
                {
                    _obj = obj,
                    _timer = new SunTimeout(expTick)
                });
                return RET_NORMAL;
            }

            var lastInfo = _delayInfos[^1];
            var expiredTick = lastInfo._timer.ExpireTick;
            if (expiredTick < expTick)
            {
                _delayInfos.Add(new DelayInfo()
                {
                    _obj = obj,
                    _timer = new SunTimeout(expTick)
                });
            }

            return NEED_SKIP;
        }


    }

    internal struct DelayInfo
    {
        public object _obj;
        public SunTimeout _timer;
    }
}
