using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem
{
    public class SkillManager
    {
        private Character _owner;
        public SkillManager(Character owner)
        {
            _owner = owner;
        }

        public bool Update()
        {
            return true;
        }
    }
}
