using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttrProfiles;
using SunStructs.PacketInfos.Game.Object.Character.Player;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren
{
    public class PlayerAttr : Attributes
    {
        public PlayerAttr() : base(new PlayerAttrProfile())
        {

        }

    }
}
