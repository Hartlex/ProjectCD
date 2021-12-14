using SunStructs.ServerInfos.General.Object.Items.SocketSystem;

namespace SunStructs.RuntimeDB.Parsers
{
    class SocketInfoParser
    {
        private Dictionary<ushort, SocketItemOption> _socketItemOptions = new();
        
        public Dictionary<ushort, SocketItemOption> ParseAllOptions(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath+"\\SocketOptionInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _socketItemOptions;
        }
        
        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 3; i < allLines.Length; i++)
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
            var socketItemOption = new SocketItemOption(info);
            _socketItemOptions.Add(socketItemOption.SocketItemCode,socketItemOption);
        }
    }
}
