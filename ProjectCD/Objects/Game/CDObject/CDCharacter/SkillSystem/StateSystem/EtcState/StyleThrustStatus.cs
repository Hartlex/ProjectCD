using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    internal class StyleThrustStatus : EtcStatus
    {
        private int _downTimeAfterThrust;

        public override void Init(Character owner, CharStateType stateType, int applicationTime, int period)
        {
            base.Init(owner, stateType, applicationTime, period);
            _downTimeAfterThrust = 0;
        }

        public override void Start()
        {
            base.Start();

            var owner = GetOwner();
            if (owner == null) return;
            owner.SetActionDelay(0);
        }

        public override void End()
        {
            base.End();

            var owner = GetOwner();
            if (owner == null) return;
            if (_downTimeAfterThrust != 0)
                owner.GetStatusManager().AllocStatus(CharStateType.CHAR_STATE_STYLE_DOWN, out var status,
                    _downTimeAfterThrust);
        }
    }
}
