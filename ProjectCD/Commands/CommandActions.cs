using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Commands.CmdActions;
using ProjectCD.Objects.NetObjects;

namespace ProjectCD.Commands
{
    public class CommandActions : Singleton<CommandActions>
    {
        private readonly Dictionary<string, Action<List<string>, User>> _playerActions = new();

        public void Init()
        {
            InitPlayerActions();
        }

        public Action<List<string>,User> FindAction(CommandType type, string param1)
        {
            try
            {
                switch (type)
                {
                    case CommandType.Invalid:
                        break;
                    case CommandType.Player:
                        return _playerActions[param1];
                    case CommandType.Map:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }

                return null;
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e);
                return null;
            }

        }


        private void InitPlayerActions()
        {
            _playerActions.Add("addItem",PlayerCmdActions.AddItem);
            _playerActions.Add("updateDB",PlayerCmdActions.Save);
            //_playerActions.Add("spawnMob", PlayerCmdActions.SpawnMob);
        }
    }
}
