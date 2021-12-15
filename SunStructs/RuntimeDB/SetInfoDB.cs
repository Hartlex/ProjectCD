using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items.SetSystem;

namespace SunStructs.RuntimeDB
{
    public class SetInfoDB : Singleton<SetInfoDB>
    {
        private Dictionary<ushort, SetInfo> _setInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new SetInfoParser();
            _setInfos = parser.ParseAllInfos(dataFolderPath);
            Logger.Instance.LogOnLine($"{_setInfos.Count} SetInfos loaded!\n", LogType.SUCCESS);
        }

        public bool TryGetSetInfo(ushort code, out SetInfo? info)
        {
            return _setInfos.TryGetValue(code, out info);
        }
    }
}
