using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using static SunStructs.Definitions.CharCondition;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.StateSystem
{
    public class StatusManager
    {
        private readonly Character _owner;
        private Dictionary<CharStateType, BaseStatus> _statusMap;
        private CharCondition _charCondition;
        private readonly GeneralStatusFlag _flags;

        public StatusManager(Character owner, int maxPoolSize = 10)
        {
            _owner = owner;
            _statusMap = new(maxPoolSize);
            _charCondition = CHAR_CONDITION_STANDUP;
            _flags = new();
        }

        public CharCondition GetCondition()
        {
            return _charCondition;
        }
        public GeneralStatusFlag GetStatusFlag(){ return _flags; }
        public bool FindStatus(CharStateType charState, out BaseStatus? status)
        {
            status = null;
            return false;
        }

        public bool FindStatus(CharStateType charState)
        {
            return false;
        }

        public void ChangeHP()
        {
            
        }

        public bool Remove(CharStateType charState)
        {
            return false;
        }

        public bool AllocStatus(CharStateType charState, out BaseStatus? status)
        {
            status = null;
            return false;
        }

        public bool Update(long currentTick)
        {
            return true;
        }

        public bool CanBeAttacked()
        {
            return true;
        }

        public bool IsImmunityDamageState()
        {
            return FindStatus(CharStateType.CHAR_STATE_IMMUNITY_DAMAGE) || FindStatus(CharStateType.CHAR_STATE_TRANSPARENT);
        }
    }
}
