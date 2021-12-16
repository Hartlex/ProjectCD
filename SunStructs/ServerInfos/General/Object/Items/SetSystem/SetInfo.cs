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
        public readonly AttrInfo[] FullOptions = new AttrInfo[6];
        public readonly ushort FullSetChangeItemCode;

        public readonly SpecialOptionInfos SpecialOption;   //5

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
            
            SpecialOption = new (5, ref sb);
        }

        public bool IsFull(int numberOfItems)
        {
            return numberOfItems >= FullOptionNum;
        }

    }

    public class SpecialOptionInfos
    {
        public readonly ushort SpecialItemCode;
        public readonly EquipContainerPos EquipPosition;
        public readonly AttrInfo[] Options;
        public SpecialOptionInfos(int count, ref StringBuffer sb)
        {
            Options = new AttrInfo[count];
            SpecialItemCode = sb.ReadUshort();
            EquipPosition = (EquipContainerPos)sb.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Options[i] = new(ref sb);
            }
        }
    }
    public class SetPartOptionInfos
    {
        public readonly EquipContainerPos EquipPosition;
        public readonly AttrInfo[] Options;

        public SetPartOptionInfos(int count, ref StringBuffer sb)
        {
            Options = new AttrInfo[count];
            EquipPosition = (EquipContainerPos) sb.ReadByte();
            for (int i = 0; i < count; i++)
            {
                Options[i] = new (ref sb);
            }
        }
    }

    public enum SetItemOptionLevel
    {
        SET_ITEM_OPTION_LEVEL_NONE,
        SET_ITEM_OPTION_LEVEL_FIRST,
        SET_ITEM_OPTION_LEVEL_SECOND,
        SET_ITEM_OPTION_LEVEL_THIRD,
        SET_ITEM_OPTION_LEVEL_FULL,
    };



}
