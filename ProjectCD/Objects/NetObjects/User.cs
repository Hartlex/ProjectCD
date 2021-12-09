using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkCommsDotNet.Connections;

namespace ProjectCD.Objects.NetObjects
{
    internal class User
    {
        private UserConnectionState _connectionState;
        private readonly Connection _authConnection;
        private Connection _gameServerConnection;
        private Connection _worldServerConnection;
        private byte[] _clientSerial=Array.Empty<byte>();
        public readonly uint UserID;

        public User(uint userID, Connection authConnection)
        {
            UserID = userID;
            _authConnection = authConnection;
            _connectionState = UserConnectionState.LOGGED_IN;
            GenerateSerial();
        }

        public bool IsLoggedIn()
        {
            return _connectionState >= UserConnectionState.LOGGED_IN;
        }

        public void SetState(UserConnectionState state)
        {
            _connectionState = state;
        }

        public void SetGameServerConnection(Connection connection){ _gameServerConnection = connection;}
        public void SetWorldServerConnection(Connection connection) { _worldServerConnection = connection;}

        private void GenerateSerial()
        {
            if (_clientSerial == Array.Empty<byte>())
            {
                Random rnd = new Random();
                byte[] b = new byte[32]; 
                rnd.NextBytes(b);
                _clientSerial = b;
            }
        }

        public byte[] GetClientSerial()
        {
            return _clientSerial;
        }
    }

    internal enum UserConnectionState
    {
        UNDEFINED,
        CONNECTED,
        LOGGED_IN,
        AT_CHAR_SELECT,
        IN_GAME
    }
}
