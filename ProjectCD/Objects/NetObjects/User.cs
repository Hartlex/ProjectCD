using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Server;
using ProjectCD.GlobalManagers.DB;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Servers.Game;
using ProjectCD.Servers.World;
using SunStructs.PacketInfos.Game.Object.Character.Player;
using SunStructs.Packets;

namespace ProjectCD.Objects.NetObjects
{
    public class User
    {
        private UserConnectionState _connectionState;
        private byte[] _clientSerial=Array.Empty<byte>();
        public readonly uint UserID;

        private Connection _gameServerConnection;

        private GameServer _gameServer;
        private WorldServer _worldServer;

        public Player Player { get; private set; }
        public User(uint userID)
        {
            UserID = userID;
            _connectionState = UserConnectionState.LOGGED_IN;
            GenerateSerial();
        }

        public bool IsLoggedIn()
        {
            return _connectionState >= UserConnectionState.LOGGED_IN;
        }

        public void SelectCharacter(Player player)
        {
            Player = player;
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

        public ClientCharacterPart[] GetCharacters()
        {
            return Database.Instance.GetCharactersForCharSelect(UserID);
        }

        public void SetGameServer(GameServer server,Connection connection)
        {
            _gameServer = server;
            _gameServerConnection = connection;
        }

        public void SendPacket(Packet packet, ServerType type = ServerType.GAME)
        {
            switch (type)
            {
                case ServerType.LOGIN:
                    break;
                case ServerType.GAME:
                    _gameServerConnection.Send(packet);
                    return;
                case ServerType.WORLD:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        public GameServer GetConnectedGameServer()
        {
            return _gameServer;
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
