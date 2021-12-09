using CDShared.Generics;

namespace SunStructs.ServerInfos.General
{
    public class GlobalRand : Singleton<GlobalRand>
    {
        private readonly Random _random=new();
        public bool IsSuccess(int probability)
        {
            var r = _random.Next(1, 101);
            return r <= probability;
        }
        public bool IsSuccess(float probability)
        {
            var r = _random.NextDouble();
            return r < probability;
        }


        public int Random(int start, int end)
        {
            return _random.Next(start, end);
        }
        public float Random(float start,float end)
        {
            double val = (_random.NextDouble() * (end - start) + start);
            return (float)val;
        }

        public double RandomDouble()
        {
            return _random.NextDouble();
        }
    }
}
