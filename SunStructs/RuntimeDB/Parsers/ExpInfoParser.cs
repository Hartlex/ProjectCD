namespace SunStructs.RuntimeDB.Parsers
{
    public class ExpInfoParser
    {
        private readonly Dictionary<ushort, ulong> _expValues = new();

        public Dictionary<ushort, ulong> ParseExpValues(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\ExpValueInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _expValues;
        }
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 4; i < allLines.Length; i++)
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
            var level = ushort.Parse(info[1]);
            var requiredExp = ulong.Parse(info[2]);
            _expValues.Add(level,requiredExp);
        }
    }
}
