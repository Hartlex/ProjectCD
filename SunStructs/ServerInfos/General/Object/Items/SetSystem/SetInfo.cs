using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Parsing;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Items.SetSystem
{
    public class SetInfo
    {
        public readonly ushort SetCode;
        public readonly byte SubType;
        public readonly byte FullOptionNum;
        public readonly SetPartOptionInfos[] PartOptions = new SetPartOptionInfos[8]; //3
        public readonly OptionInfo[] FullOptions = new OptionInfo[6];
        public readonly ushort FullSetChangeItemCode;
        public readonly ushort SpecialItemCode;
        public readonly SetPartOptionInfos SpecialOption;   //5

        public SetInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            SetCode = sb.ReadUshort();
            SubType = sb.ReadByte();
            FullOptionNum = sb.ReadByte();
            for (int i = 0; i < 8; i++)
            {
                PartOptions[i] = new (3, ref sb);
            }

            for (int i = 0; i < 6; i++)
            {
                FullOptions[i] = new (ref sb);
            }
            FullSetChangeItemCode = sb.ReadUshort();
            SpecialItemCode = sb.ReadUshort();
            SpecialOption = new (6, ref sb);
        }

    }

    public class SetPartOptionInfos
    {
        public readonly EquipContainerPos EquipPosition;
        public readonly OptionInfo[] Options;

        public SetPartOptionInfos(int count, ref StringBuffer sb)
        {
            Options = new OptionInfo[count];
            EquipPosition = (EquipContainerPos) sb.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Options[i] = new (ref sb);
            }
        }
    }

    public class OptionInfo
    {
        public readonly AttrType AttrType;
        public readonly byte UseType;
        public readonly int Value;

        public OptionInfo(ref StringBuffer sb)
        {
            AttrType = (AttrType) sb.ReadByte();
            UseType = sb.ReadByte();
            Value = sb.ReadByte();
        }
    }

}
