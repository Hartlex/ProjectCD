using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
