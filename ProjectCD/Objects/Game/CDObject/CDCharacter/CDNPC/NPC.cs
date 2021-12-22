using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.ServerInfos.General.Object.Character.NPC;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC
{
    internal class NPC : Character
    {
        private BaseNPCInfo _info;
        public BaseNPCInfo GetBaseInfo(){ return _info;}

        public NPC(uint key) : base(key)
        {
        }
    }
}
