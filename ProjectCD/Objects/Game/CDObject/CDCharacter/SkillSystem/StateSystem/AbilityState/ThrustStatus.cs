using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class ThrustStatus : AbilityStatus
    {
        public override void Start()
        {
            GetOwner()?.SetActionDelay(0);
        }


    }
}
