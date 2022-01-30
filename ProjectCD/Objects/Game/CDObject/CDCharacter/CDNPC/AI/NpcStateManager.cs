using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.AI;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI
{
    internal class NpcStateManager
    {
        private NPC _owner;
        private Dictionary<AIStateID, NpcState> _npcStates;
        private NpcState _currentState;
        private NpcStateFactory _factory;
        private Queue<AIMsg> _msgQueue;

        private uint StateChangeCount;
        private long StateChangeCheckTick;
        private bool StateChangeSafe;

        public NpcStateManager(NPC owner)
        {
            _owner = owner;
            _factory = new NpcStateFactory();
            _npcStates = new Dictionary<AIStateID, NpcState>();
            _msgQueue = new Queue<AIMsg>(10);
        }

        public void Init(AIStateID stateID, int param1)
        {
            StateChangeCount = 0;
            StateChangeCheckTick = 0;

            if (_npcStates.TryGetValue(stateID, out var state))
            {
                _currentState = state;
                _currentState.OnEnter(param1);
            }
        }

        public void Update(long deltaTick)
        {
            //_owner.SpecialAction();
            //_owner.StatusResist();
            if (_msgQueue.Count > 0)
            {
                _currentState.OnAIMsg(_msgQueue.Dequeue());
            }


            _currentState.OnUpdate(deltaTick);
            
        }

        public void AddStateObject(AIStateID stateId, AIStateID linkStateId)
        {
            var state = _factory.AllocNpcState(linkStateId);
            state.SetNpc(_owner);
            state.SetStateId(stateId);
            
            _npcStates.Add(stateId,state);
        }

        public void ChangeState(AIStateID stateId, int param1 = 0, int param2 = 0, int param3 = 0)
        {
            if (StateChangeCount > 10)
            {
                Logger.Instance.Log("Warning too many state changes! Object: "+ _owner.GetKey());
            }

            if (DateTime.Now.Ticks - StateChangeCheckTick >= 1000)
            {
                StateChangeCheckTick = DateTime.Now.Ticks;
                StateChangeCount = 0;
            }

            if (!_npcStates.TryGetValue(stateId, out var state)) return;
            if (state == _currentState) return;

            StateChangeSafe = false;
            
            _currentState.OnExit();

            _currentState = state;
            
            _currentState.OnEnter(param1,param2,param3);

            StateChangeSafe = true;
        }

        public void OnAiMsg(AIMsg msg)
        {
            _msgQueue.Enqueue(msg);
        }
    }
}
