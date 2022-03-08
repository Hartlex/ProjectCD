using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using static SunStructs.Definitions.PlayerStatEvent;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    internal partial class Player
    {
        private int _partyEventFlag;


        public void NotifyChangedStatus(PlayerStatEvent flag)
        {
            if (flag != NONE)
            {
                _partyEventFlag |= (int) flag;
            }
            else
            {
                _partyEventFlag =  (int) NONE;
            }
        }
    }
}
