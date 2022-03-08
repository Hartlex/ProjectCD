using ProjectCD.Objects.NetObjects;

namespace ProjectCD.Commands
{
    internal class Command
    {
        private string _rawString;
        private CommandType _type;
        private readonly int _cmdParamCount;
        private readonly List<string> _cmdParams;
        private readonly Action<List<string>, User> CommandAction;
        private readonly User _owner;
        public Command(string rawString,User owner)
        {
            _owner = owner;
            _rawString = rawString;
            var split = rawString.Split(' ').ToList();
            split.RemoveAt(0); //remove CMD:

            SetType(split[0]);
            split.RemoveAt(0);

            var param1 = split[0];
            split.RemoveAt(0);

            _cmdParamCount = split.Count;
            _cmdParams = split;
            
            CommandAction = CommandActions.Instance.FindAction(_type, param1);
        }

        public void Execute()
        {
            CommandAction?.Invoke(_cmdParams, _owner);
        }
        private CommandType SetType(string strType)
        {
            _type = strType switch
            {
                "player" => CommandType.Player,
                "map" => CommandType.Map,
                _ => CommandType.Invalid
            };
            return _type;
        }
        
    }


    public enum CommandType
    {
        Invalid,
        Player,
        Map,

    }
}
