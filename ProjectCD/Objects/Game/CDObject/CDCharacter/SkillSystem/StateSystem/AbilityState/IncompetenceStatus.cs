using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class IncompetenceStatus : AbilityStatus
    {
        public override void Execute() { }

        public override void Start()
        {
            if(!GetOwner().IsObjectType(ObjectType.PLAYER_OBJECT))
                GetOwner().ChangeState(AIStateID.STATE_ID_IDLE);

            base.Start();
        }
    }
}
