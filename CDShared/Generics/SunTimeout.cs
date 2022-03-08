using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDShared.Generics
{
    public class SunTimeout
    {
        public long ExpireTick { get; init; }

        public SunTimeout(long expireTick)
        {
            ExpireTick = expireTick;
        }

        public SunTimeout(int delay)
        {
            ExpireTick = DateTime.Now.AddMilliseconds(delay).Ticks;
        }
        public bool IsExpired(){ return DateTime.Now.Ticks > ExpireTick; }
        

    }
}
