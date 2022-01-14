using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Parsing;
using Microsoft.VisualBasic;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;
using static SunStructs.Definitions.AttrType;

namespace SunStructs.ServerInfos.General.Object.Items
{
    public class AttrInfo
    {
        public readonly AttrType AttrType;
        public readonly AttrValueKind ValueKind;
        public readonly int Value;

        public AttrInfo(byte type, AttrValueKind valueKind, int value)
        {

            AttrType = GlobalItemOption.GetItemAttrOption(type);
            ValueKind = valueKind;
            Value = value;
        }
        public AttrInfo(ref StringBuffer sb)
        {
            var type = sb.ReadByte();
            AttrType = GlobalItemOption.GetItemAttrOption(type);
            ValueKind = (AttrValueKind) sb.ReadByte();
            Value = sb.ReadInt();
        }
    }
}
