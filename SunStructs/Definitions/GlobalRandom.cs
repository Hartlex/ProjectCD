using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Definitions
{
    public static class GlobalRandom
    {
        private static Random _random = new Random();

        public static int Rand(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
