using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.ServerInfos.General;
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

        private uint _stateChangeCount;
        private long _stateChangeCheckTick;
        private bool _stateChangeSafe;
        private NPCMoveAttitude _moveType;
        private TimerBase _specialTimer;
        private TimerBase _stateChangeCheck;

        private EscapeState? _escapeState;

        public bool IsRequestHelp { get; internal set; }

        public NpcStateManager(NPC owner)
        {
            _owner = owner;
            _factory = new NpcStateFactory();
            _npcStates = new Dictionary<AIStateID, NpcState>();
            _msgQueue = new Queue<AIMsg>(10);
            _specialTimer = new TimerBase();
            _stateChangeCheck = new TimerBase();
        }

        public void Init(AIStateID stateID, NPCMoveAttitude moveType,uint moveAreaID, int param1)
        {
            _stateChangeCount = 0;
            _stateChangeCheckTick = 0;

            if (_npcStates.TryGetValue(stateID, out var state))
            {
                _currentState = state;
                _currentState.OnEnter(param1);
            }
            _stateChangeCheck.SetTimer(1000);
            _specialTimer.SetTimer(_owner.GetBaseInfo().SkillUpdateTime != 0
                ? _owner.GetBaseInfo().SkillUpdateTime
                : int.MaxValue);
        }

        public void Update(long deltaTick)
        {
            //_owner.SpecialAction();
            //_owner.StatusResist();
            if (_msgQueue.Count > 0)
            {
                _currentState.OnAIMsg(_msgQueue.Dequeue());
            }

            if (_specialTimer.IsExpired() && _owner.IsAlive())
            {
                var specialCondition = _owner.GetNextSpecialCondition();
                if(specialCondition!=null)
                    _owner.SpecialAction(specialCondition);
                
                _owner.StatusResist();
            }

            if (_escapeState != null)
            {
                var progress = _escapeState.OnUpdate(deltaTick);
                if (progress) return;

                _escapeState.OnExit();
                _escapeState = null;
            }

            _currentState.OnUpdate(deltaTick);
            
        }

        public void ResetStates()
        {
            _npcStates.Clear();
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
#if DEBUG
            Logger.Instance.Log($"[{_owner.GetKey()}] changing State from[{_currentState.GetStateID()}] to [{stateId}]");
#endif
            if (_stateChangeCount > 10)
            {
                Logger.Instance.Log("Warning too many state changes! Object: "+ _owner.GetKey());
            }

            if (DateTime.Now.Ticks - _stateChangeCheckTick >= 1000)
            {
                _stateChangeCheckTick = DateTime.Now.Ticks;
                _stateChangeCount = 0;
            }

            if (!_npcStates.TryGetValue(stateId, out var state)) return;
            if (state == _currentState) return;

            _stateChangeSafe = false;
            
            _currentState.OnExit();

            _currentState = state;
            
            _currentState.OnEnter(param1,param2,param3);

            _stateChangeSafe = true;
        }

        public void OnAiMsg(AIMsg msg)
        {
            _msgQueue.Enqueue(msg);
        }


    }

    class EscapeState
    {
        private const int ESCAPE_CHECK_TIME = 50;
        private enum TracingMethod{NONE,TILE_TRACING,DEST_POS_TRACING}

        private NPC? _owner;
        private Field? _field;
        private SunTimeout _updateTimer;
        private long _timeoutTick;
        private TracingMethod _tracingMethod;
        private int _destTileID;
        private SunVector _destPos;

        public void Init(NPC npc)
        {
            _owner = npc;
            _field = npc.GetCurrentField();
        }

        public bool OnEnter(EscapeCmd cmd)
        {
            if (_owner is null || _field is null) return false;

            var tick = DateTime.Now.Ticks;
            _updateTimer = new SunTimeout(DateTime.Now.AddMilliseconds(ESCAPE_CHECK_TIME).Ticks);
            _timeoutTick = tick + cmd.TimeoutInterval* TimeSpan.TicksPerMillisecond;

            _destTileID = cmd.DestTileID;
            _destPos = cmd.DestPos;

            var pos = _owner.GetPos();
            var moveState = _owner.MoveStateControl.GetMoveState();
            if (moveState == CharMoveState.CMS_WALK)
            {
                moveState = CharMoveState.CMS_RUN;
                _owner.MoveStateControl.SetMoveState(moveState);
            }

            var packet = new MoveBrd(_owner.GetKey(), (byte) moveState, 1, pos, _destPos);
            _field.QueueWarPacketInfo(packet);

            return true;
        }

        public bool OnUpdate(long deltaTick)
        {
            const bool updateContinue = true;
            const bool updateStop = true;

            if (!_updateTimer.IsExpired())
                return updateContinue;

            var field = _owner.GetCurrentField();
            if (field != null && !ReferenceEquals(field, _field))
                return updateStop;

            _updateTimer = new SunTimeout(DateTime.Now.AddMilliseconds(ESCAPE_CHECK_TIME).Ticks);

            var isMoving = _owner.MoveStateControl.IsMoving();

            if (!isMoving) return updateStop;

            return updateContinue;
        }

        public bool OnExit()
        {
            return false;
        }
    }

    class AiCmd
    {
        public enum CmdType{NONE,ESCAPE=1<<20}

        public readonly CmdType Type;
        public AiCmd(CmdType type){ Type =type; }


    }

    class EscapeCmd : AiCmd
    {
        public readonly int TimeoutInterval;
        public readonly int DestTileID;
        public readonly SunVector DestPos;

        public EscapeCmd(int timeoutInterval, int destTileID, SunVector destPos) : base(CmdType.ESCAPE)
        {
            TimeoutInterval = timeoutInterval;
            DestTileID = destTileID;
            DestPos = destPos;
        }
    }
}
