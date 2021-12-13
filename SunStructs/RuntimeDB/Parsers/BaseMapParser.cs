using SunStructs.ServerInfos.General.World;

namespace SunStructs.RuntimeDB.Parsers
{
    public class BaseMapParser
    {
        private readonly Dictionary<uint, BaseFieldInfo> _baseMapInfos = new();

        public Dictionary<uint, BaseFieldInfo> ParseBaseMapInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\World.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _baseMapInfos;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 15; i < allLines.Length; i++)
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
            var mapInfo = new BaseFieldInfo(info);
            _baseMapInfos.Add(mapInfo.MapCode,mapInfo);
        }
        
    }
}
