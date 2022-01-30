using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI.States;
using SunStructs.Definitions;
using static SunStructs.Definitions.AIStateID;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.AI
{
    internal class NpcStateFactory
    {
        private WanderState _wanderState;
        private TrackState _trackState;
        private HelpState _helpState;
        private DeadState _deadState;
        private KnockdownState _knockdownState;
        private FallApartState _fallApartState;
        private RetreatState _retreatState;
        private ChaosSate _chaosSate;
        private PatrolState _patrolState;
        private IdleState _idleState;
        private AttackState _attackState;
        private ThrustState _thrustState;
        private FlyingState _flyingState;
        private JumpState _jumpState;
        private ReturnState _returnState;
        private RunAwayState _runAwayState;
        private SpawnIdleState _spawnIdleState;
        private TrackAreaState _trackAreaState;
        private StopIdleState _stopIdleState;
        private SummonIdleState _summonIdleState;
        
        public NpcStateFactory()
        {
            _wanderState = new WanderState();
            _trackState = new TrackState();
            _helpState = new HelpState();
            _deadState = new DeadState();
            _knockdownState = new KnockdownState();
            _fallApartState = new FallApartState();
            _retreatState = new RetreatState();
            _chaosSate = new ChaosSate();
            _patrolState = new PatrolState();
            _idleState = new IdleState();
            _attackState = new AttackState();
            _thrustState = new ThrustState();
            _flyingState = new FlyingState();
            _jumpState = new JumpState();
            _returnState = new ReturnState();
            _runAwayState = new RunAwayState();
            _spawnIdleState = new SpawnIdleState();
            _trackAreaState = new TrackAreaState();
            _trackState = new TrackState();
            _stopIdleState = new StopIdleState();
            _summonIdleState = new SummonIdleState();
        }
        
        public NpcState AllocNpcState(AIStateID stateId)
        {
            switch (stateId)
            {
                case STATE_ID_UNKNOWN:
                    break;
                case STATE_ID_WANDER:
                    return _wanderState;
                case STATE_ID_IDLE:
                    return _idleState;
                case STATE_ID_TRACK:
                    return _trackState;
                case STATE_ID_ATTACK:
                    return _attackState;
                case STATE_ID_HELP:
                    return _helpState;
                case STATE_ID_THRUST:
                    return _thrustState;
                case STATE_ID_DEAD:
                    return _deadState;
                case STATE_ID_FLYING:
                    return _flyingState;
                case STATE_ID_KNOCKDOWN:
                    return _knockdownState;
                case STATE_ID_JUMP:
                    return _jumpState;
                case STATE_ID_FALL_APART:
                    return _fallApartState;
                case STATE_ID_RETURN:
                    return _returnState;
                case STATE_ID_RETREAT:
                    return _retreatState;
                case STATE_ID_RUNAWAY:
                    return _runAwayState;
                case STATE_ID_CHAOS:
                    return _chaosSate;
                case STATE_ID_SUMMON_IDLE:
                    return _summonIdleState;
                case STATE_ID_PATROL:
                    return _patrolState;
                case STATE_ID_SPAWN_IDLE:
                    return _spawnIdleState;
                case STATE_ID_STOP_IDLE:
                    return _stopIdleState;
                case STATE_ID_TRACK_AREA:
                    return _trackAreaState;
                default:
                    return  _wanderState;
            }

            return _wanderState;

        }
    }
}
