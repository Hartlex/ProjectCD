using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Items.RankSystem
{
    public class RankInfo : AttrInfo
    {
        public RankInfo(AttrType attrType, AttrValueKind valueKind, int value) : base(attrType, valueKind, value)
        {
        }
    }
}
