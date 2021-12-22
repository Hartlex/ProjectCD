namespace SunStructs.ServerInfos.General.World
{
    public class AreaInfo
    {
        public uint MapCode { get; }
        private readonly Dictionary<string, SunVector> _areaCodes;

        public AreaInfo(uint mapCode) 
        {
            MapCode = mapCode;
            _areaCodes = new Dictionary<string, SunVector>();
        }

        public void AddArea(string id, SunVector pos)
        {
            _areaCodes.TryAdd(id, pos);
        }

        public bool TryGetArea(string id,out SunVector pos)
        {
            return _areaCodes.TryGetValue(id, out pos);
        }
    }


}
