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

        public StatusManager(Character owner, int maxPoolSize = 10)
        {
            _owner = owner;
            _statusMap = new(maxPoolSize);
            _charCondition = CHAR_CONDITION_STANDUP;
        }

        public CharCondition GetCondition()
        {
            return _charCondition;
        }

        public bool FindStatus(CharStateType charStateFighting, out BaseStatus? status)
        {
            status = null;
            return false;
        }
    }
}
