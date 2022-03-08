using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.World
{
    internal class TargetFinder
    {
    }

    internal class TargetFinderArgs
    {
        public readonly Character Searcher;
        public readonly TargetSearchType TargetSearchType;
        public readonly SkillTargetType SkilTargetType;
        public readonly int RegenID;
        public readonly int MapObjectID;
        public readonly ushort MonsterCode;
    }
}
