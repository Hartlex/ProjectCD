using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using SunStructs.ServerInfos.General.Object.Items;

namespace SunStructs.RuntimeDB.Parsers
{
    public class ItemTypeParser
    {
        private Dictionary<int, ItemTypeInfo> _typeInfos=new();

        public Dictionary<int, ItemTypeInfo> ParseAllInfos(string dataFolderPath)
        {
            var lines = ReadAllLines(dataFolderPath + "\\ItemTypeList.txt");
            foreach (var line in lines)
            {
                ParseLine(line);
            }

            return _typeInfos;
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

            return noCommentLines;
        }
        private void ParseLine(string line)
        {
            var info = line.Split('\t');
            
            var itemTypeInfo = new ItemTypeInfo(info);
            _typeInfos.Add(itemTypeInfo.ItemType,itemTypeInfo);

#if DEBUG
            Logger.Instance.LogOnLine($"Loaded ItemType[{itemTypeInfo.ItemType}]");
#endif
        }
    }
}
