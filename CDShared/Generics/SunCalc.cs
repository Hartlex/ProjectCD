using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDShared.Generics
{
    public static class SunCalc
    {
        //public static T Max<T>(T max, T value) where T:IEquatable<T>
        //{
        //    //return max.CompareTo(value) > 0 ?  max : value;
        //    return value > max ? max : value;
        //}

        public static float Max(float max, float value)
        {
            return value > max ? max : value;
        }
        public static float Min(float min, float value)
        {
            return value < min ? min : value;
        }

        public static int Max(int max, int value)
        {
            return value > max ? max : value;
        }
        public static int Min(int min, int value)
        {
            return value < min ? min : value;
        }

        public static uint Max(uint max, uint value)
        {
            return value > max ? max : value;
        }
        public static uint Min(uint min, uint value)
        {
            return value < min ? min : value;
        }

        public static long Max(long max, long value)
        {
            return value > max ? max : value;
        }
        public static long Min(long min, long value)
        {
            return value < min ? min : value;
        }

        public static ulong Max(ulong max, ulong value)
        {
            return value > max ? max : value;
        }
        public static ulong Min(ulong min, ulong value)
        {
            return value < min ? min : value;
        }


    }
}
