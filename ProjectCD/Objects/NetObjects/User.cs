using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.NetworkBase.Connections;

namespace ProjectCD.Objects.NetObjects
{
    public class User
    {
        private UserConnectionState _connectionState;
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

    public enum UserConnectionState
    {
        UNDEFINED,
        CONNECTED,
        LOGGED_IN,
        AT_CHAR_SELECT,
        IN_GAME
    }
}
