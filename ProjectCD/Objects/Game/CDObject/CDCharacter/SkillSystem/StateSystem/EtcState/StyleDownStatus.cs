using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    internal class StyleDownStatus : EtcStatus
    {
        public override void Start()
        {
            base.Start();

            var owner = GetOwner();
            if (owner == null) return;

            AIMsgKnockDown msg = new(DateTime.Now.Ticks, GetApplicationTime());
            owner.OnAiMessage(msg);

            owner.StopMoving();

            owner.SetActionDelay(0);
        }

        public override void End()
        {
            var owner = GetOwner();
            if (owner != null)
            {
                AIMsgKnockDown msg = new(DateTime.Now.Ticks, 0);
                owner.OnAiMessage(msg);
            }

            base.End();

        }
    }
}
