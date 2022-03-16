using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.EtcState
{
    internal class StyleStunStatus : EtcStatus
    {
        public override void Start()
        {
            base.Start();

            var owner = GetOwner();
            if (owner == null) return;

            AIMsgStun msg = new(GetApplicationTime());
            owner.OnAiMessage(msg);

            owner.StopMoving();

            owner.SetActionDelay(0);
        }

        public override void End()
        {

            base.End();

            var owner = GetOwner();
            if (owner != null)
            {
                var packet = new StatusRemoveBrd(owner.GetKey(), CharStateType.CHAR_STATE_STUN);
                owner.GetCurrentField()?.QueueWarPacketInfo(packet);
            }


        }
    }
}
