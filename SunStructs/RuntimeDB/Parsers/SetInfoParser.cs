using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using SunStructs.ServerInfos.General.Object.Items.SetSystem;

namespace SunStructs.RuntimeDB.Parsers
{
    internal class SetInfoParser
    {
        private readonly Dictionary<ushort, SetInfo> _infos = new();

        public Dictionary<ushort, SetInfo> ParseAllInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\SetItemOptionInfo.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _infos;
        }

        private List<string> ReadAllLines(string path)
        {
            var allLines = File.ReadAllLines(path);
            List<string> noCommentLines = new List<string>();
            for (var i = 8; i < allLines.Length; i++)
            {
                var line = allLines[i];
                if (!line.StartsWith("//")) noCommentLines.Add(line);
            }

            noCommentLines.RemoveAt(0);
            return noCommentLines;
        }

        private void ParseLine(string line)
        {
            var info = new SetInfo(line.Split('\t'));
            _infos.Add(info.SetCode,info);
#if DEBUG
            Logger.Instance.LogOnLine($"Loaded SetInfo[{info.SetCode}]");
#endif
        }
    }
}
