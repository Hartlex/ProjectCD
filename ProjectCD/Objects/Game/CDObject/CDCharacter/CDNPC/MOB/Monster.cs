using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.MOB
{
    internal class Monster : NPC
    {
        public Monster(uint key) : base(key)
        {
            SetObjectType(ObjectType.MONSTER_OBJECT);
        }




    }
}
