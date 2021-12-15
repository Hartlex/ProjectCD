using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;

namespace SunStructs.ServerInfos.General.Object.Items
{
    public class AttrInfo
    {
        public readonly AttrType AttrType;
        public readonly AttrValueKind ValueKind;
        public readonly int Value;

        public AttrInfo(AttrType attrType, AttrValueKind valueKind, int value)
        {
            AttrType = attrType;
            ValueKind = valueKind;
            Value = value;
        }
    }
}
