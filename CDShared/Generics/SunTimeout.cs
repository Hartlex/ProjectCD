using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDShared.Generics
{
    public class SunTimeout
    {
        public long ExpireTick { get; private set; }
        private int _delay;

        public SunTimeout(long expireTick)
        {
            ExpireTick = expireTick;
        }

        public SunTimeout(int delay)
        {
            ExpireTick = DateTime.Now.AddMilliseconds(delay).Ticks;
            _delay = delay;
        }
        public bool IsExpired(){ return DateTime.Now.Ticks > ExpireTick; }

        public void Reset(int delay = 0)
        {
            ExpireTick = DateTime.Now.AddMilliseconds(delay == 0 ? _delay : delay).Ticks;
        }

        

    }
}
