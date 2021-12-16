using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.World;

namespace SunStructs.RuntimeDB
{
    public class PortalDB : Singleton<PortalDB>
    {
        private Dictionary<ushort, BasePortalInfo> _portalInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new BasePortalParser();
            _portalInfos = parser.ParseBasePortalInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_portalInfos.Count} Portals loaded!\n", LogType.SUCCESS);
        }

        public BasePortalInfo GetPortalInfo(ushort portalId)
        {
            try
            {
                return _portalInfos[portalId];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }
        public bool TryFindPortal(ushort portalID, out BasePortalInfo info)
        {
            info = GetPortalInfo(portalID);
            return info!=null;
        }
    }
}
