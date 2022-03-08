using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI
{
    internal class TargetManager
    {
        private NPC _owner;
        private Character? _target;

        public TargetManager(NPC owner)
        {
            _owner = owner;
        }

        public void SetCurrentTarget(Character? target)
        {
            _target = target;
        }

        public Character? GetCurrentTarget()
        {
            return _target;
        }

        public void RemoveTarget(uint objectKey)
        {
            if (_target != null && _target.GetKey() == objectKey)
                _target = null;
        }
    }
}
