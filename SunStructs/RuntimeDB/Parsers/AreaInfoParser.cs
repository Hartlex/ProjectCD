using CDShared.Logging;
using CDShared.Parsing;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.World;

namespace SunStructs.RuntimeDB.Parsers
{
    public class AreaInfoParser
    {
        private Dictionary<uint, AreaInfo> _areaInfos;
        private List<AreaPosInfo> _areaPosInfos;
        public Dictionary<uint,AreaInfo> ParseAllInfos(string dataFolderPath)
        {
            _areaPosInfos = new List<AreaPosInfo>();
            var lines = ReadAllLines(dataFolderPath + "\\AreaDBInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }
            SortInfos();
            return _areaInfos;
        }

        private void SortInfos()
        {
            _areaInfos = new Dictionary<uint, AreaInfo>();
            foreach (var areaPosInfo in _areaPosInfos)
            {
                var mapCode = areaPosInfo.MapCode;
                if(!_areaInfos.ContainsKey(mapCode))
                    _areaInfos.Add(mapCode,new AreaInfo(mapCode));
                _areaInfos[mapCode].AddArea(areaPosInfo.ID,areaPosInfo.Pos);
            }
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 0; i < allLines.Length; i++)
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
            var areaPosInfo = new AreaPosInfo(info);
            _areaPosInfos.Add(areaPosInfo);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded AreaInfo[{areaPosInfo.MapCode}]");
#endif
        }
    }

    class AreaPosInfo
    {
        public uint MapCode { get; }
        public string ID { get; }
        public SunVector Pos { get; }

        public AreaPosInfo(string[] infos)
        {
            var sb = new StringBuffer(infos);
            MapCode = sb.ReadUint();
            ID = sb.ReadString();
            Pos = new SunVector(
                sb.ReadFloat(),
                sb.ReadFloat(),
                sb.ReadFloat()
            );
        }
    }
}
