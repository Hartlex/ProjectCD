using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    internal class SteelStatus : EtcStatus
    {
        public override void End()
        {
            base.End();
            SendStatusDelBRD();
        }


        public override bool IsNotifyStatus()
        {
            return true;
        }
    }

}
