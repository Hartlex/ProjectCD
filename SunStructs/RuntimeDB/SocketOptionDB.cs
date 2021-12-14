﻿using CDShared.Generics;
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
            foreach (var socketItemOption in _socketItemOptions.Values)
            {
                var key = (byte) socketItemOption.AttrIndex;
                if (_socketOptions.ContainsKey(key))
                {
                    _socketOptions[key].Value[(int)socketItemOption.Level] = socketItemOption.Value;
                }
                else
                {
                    var info = new SocketOption(socketItemOption);
                    _socketOptions.Add((byte)info.AttrIndex,info);
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