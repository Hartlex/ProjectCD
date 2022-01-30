using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.PacketInfos.Game.Status.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.Abilities.TargetAbilities.StatusAbilities
{
    internal class DragonTransformAbility : BaseStatusAbility
    {
        public override bool IsValidState()
        {
            return GetCharStateType() == CharStateType.CHAR_STATE_TRANSFORMATION;
        }

        public override bool Execute(Character? target, out SkillResultAbility? result)
        {
            if (!base.Execute(target, out result)) return false;

            var attacker = GetAttacker();
            if(attacker== null) return false;

            var transInfo = new DragonTransStartInfo();
            transInfo.PlayerKey = attacker.GetKey();
            transInfo.SkillCode = GetSkillCode();
            transInfo.StatusCode = (ushort) GetCharStateType();
            transInfo.StatusTime = (int) result.AbilityDuration;

            //SEND PACKET

            return false;
        }
    }
}
