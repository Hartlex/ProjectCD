using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC;
using ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem;
using SunStructs.Definitions;
using SunStructs.Formulas.Char;
using SunStructs.PacketInfos.Game.Status.Server;
using SunStructs.RuntimeDB;
using static SunStructs.Definitions.UserRelationType;

namespace ProjectCD.Formulas
{
    internal static class CharacterFormulas
    {
        internal static bool IsStatusHit(Character attacker, Character target, int successRatio, ushort stateID, Skill skill)
        {
            if (attacker.IsFriend(target) == USER_RELATION_FRIEND) return true;

            float calcRatio = successRatio;

            if (attacker.IsObjectType(ObjectType.PLAYER_OBJECT) && target.IsObjectType(ObjectType.PLAYER_OBJECT))
                calcRatio /= 10;
            else
            {
                float gradeRatio = 1.0f;
                if (target is NPC npc)
                {
                    gradeRatio = NumericValues.GetStatusRatioAsNPCGrade(npc.GetGrade());
                }

                calcRatio = successRatio * gradeRatio / 10;
            }

            var stateInfo = StateInfoDB.Instance.GetStateInfo(stateID);
            if (stateInfo.Type is 3 or 4)
            {
                calcRatio = 100;
            }
            else
            {
                calcRatio -= target.GetResistBadStatusRatio(stateID);
            }


            return GlobalRandom.IsSuccess((int)calcRatio);

        }
    }
}
