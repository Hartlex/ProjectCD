using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.StateSystem
{
    public class BaseStatus
    {
        private Character _character;
        private CharStateType _stateType;
        private int _period;
        private int _applicationTime;
        private long _executionTime;
        private long _expireTimer;
        private bool _requestRemove;

        public bool SendStatusAddBRD()
        {
            Logger.Instance.Log($"Added Status[{_stateType}] to Player[{_character.GetKey()}]");
            return true;
        }
    }
}
