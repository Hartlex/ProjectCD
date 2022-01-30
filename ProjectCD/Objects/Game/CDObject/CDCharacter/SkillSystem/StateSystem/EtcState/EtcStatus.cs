using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    public class EtcStatus : BaseStatus
    {
        public virtual void SetDownTime(int downTime){}
    }

    public class BattleStatus : EtcStatus
    {

    }
}
