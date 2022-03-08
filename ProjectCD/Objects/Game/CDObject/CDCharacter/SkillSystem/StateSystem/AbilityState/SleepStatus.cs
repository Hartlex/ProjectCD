using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class SleepStatus : AbilityStatus
    {
        public override void Start()
        {
            var owner = GetOwner();
            owner!.StopMoving();
            owner.SetActionDelay(0);
        }

        public override bool CanRemove()
        {
            long leftTick = GetExpireTime() - DateTime.Now.Ticks;

            int processTick = GetApplicationTime() - (int)(leftTick / TimeSpan.TicksPerMillisecond);

            return processTick >= 1000;
        }
    }
}
