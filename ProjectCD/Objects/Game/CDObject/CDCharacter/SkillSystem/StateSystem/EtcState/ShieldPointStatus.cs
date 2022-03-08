using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    internal class ShieldPointStatus : EtcStatus
    {
        public override void End()
        {
            base.End();
            SendStatusDelBRD();
        }

        public override bool CanRemove()
        {
            if (GetOwner().GetHP() == 0) return true;
            if (GetOwner().GetSD() != 0) return false;

            return true;
        }

        public override bool IsNotifyStatus()
        {
            return true;
        }
    }

}
