using CDShared.Logging;
using SunStructs.ServerInfos.General.World;

namespace SunStructs.RuntimeDB.Parsers
{
    public class BasePortalParser
    {
        private readonly Dictionary<ushort, BasePortalInfo> _portalInfos = new();

        public Dictionary<ushort, BasePortalInfo> ParseBasePortalInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\MapEntrancePortal.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _portalInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 19; i < allLines.Length; i++)
            {
                var line = allLines[i];
                if (!line.StartsWith("//")) noCommentLines.Add(line);
            }

            noCommentLines.RemoveAt(0);
            return noCommentLines;
        }
        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            if (info[1].StartsWith("//")) return;
            var portalInfo = new BasePortalInfo(info);
            _portalInfos.Add(portalInfo.PortalId,portalInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded Portal[{portalInfo.PortalId}]");
#endif
        }
    }
}
