using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;

namespace SunStructs.RuntimeDB
{
    public class SocketOptionDB :Singleton<SocketOptionDB>
    {
        private Dictionary<ushort, SocketItemOption> _socketItemOptions = new();
        private Dictionary<byte, SocketOption> _socketOptions = new();
        

        public void Init(string dataFolderPath)
        {

            var parser = new SocketInfoParser();
            _socketItemOptions = parser.ParseAllOptions(dataFolderPath);
            Logger.Instance.LogOnLine($"{_socketItemOptions.Count} SocketOptions loaded!\n", LogType.SUCCESS);

            foreach (var socketItemOption in _socketItemOptions.Values)
            {
                var key = (byte) socketItemOption.AttrOptionIndex;
                if (_socketOptions.ContainsKey(key))
                {
                    _socketOptions[key].Value[(int)socketItemOption.Level] = socketItemOption.Value;
                }
                else
                {
                    var info = new SocketOption(socketItemOption);
                    _socketOptions.Add((byte)info.AttrOptionIndex,info);
                }

            }
        }

        public SocketOption GetSocketOption(byte optionIndex)
        {
            return _socketOptions[optionIndex];
        }

        public SocketItemOption GetSocketItemOption(ushort itemCode)
        {
            return _socketItemOptions[itemCode];
        }
        
    }
}
