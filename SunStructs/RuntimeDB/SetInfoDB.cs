using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items;
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

        public SetItemOptionLevel GetLevel(int numberOfSetItems)
        {
            if (numberOfSetItems < 2) return SetItemOptionLevel.SET_ITEM_OPTION_LEVEL_NONE;
            if (numberOfSetItems < 4) return SetItemOptionLevel.SET_ITEM_OPTION_LEVEL_FIRST;
            if (numberOfSetItems < 6) return SetItemOptionLevel.SET_ITEM_OPTION_LEVEL_SECOND;
            return SetItemOptionLevel.SET_ITEM_OPTION_LEVEL_THIRD;
        }

        public AttrInfo? GetSetOption(SetInfo info,int pos, SetItemOptionLevel level)
        {
            for (int i = 0; i < 8; i++)
            {
                var option = info.PartOptions[i];
                if (option.EquipPosition == (EquipContainerPos) pos)
                {
                    return option.Options[(int)level - 1];
                }
            }

            return null;
        }
    }
}
