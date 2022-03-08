using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class StunStatus : AbilityStatus
    {
        public override void Start()
        {
            var owner = GetOwner();
            if (owner == null) return;

            owner.OnAiMessage(new AIMsgKnockDown(DateTime.Now.Ticks,GetApplicationTime()));

            owner.StopMoving();

            owner.SetActionDelay(0);
        }

        public override void End()
        {
            var owner = GetOwner();
            if (owner != null)
            {
                owner.OnAiMessage(new AIMsgKnockDown(DateTime.Now.Ticks, 0));
            }
            base.End();
        }
    }
}
