using System.Net.Sockets;
using System.Timers;
using CDShared.Logging;
using ProjectCD.Objects.NetObjects;
using SunStructs.Packets;

namespace ProjectCD.NetworkBase.Connections
{
    public class Connection : IDisposable
    {
        public ConnectionState State { get; private set; }

        public User User { get; private set; }

        // Size of receive buffer.  
        public const int BufferSize = 1024;

        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];

        // Client socket.
        public Socket workSocket = null;
        public readonly Guid ID;

        private System.Timers.Timer _timer;

        private readonly List<Action<Connection>> _onCloseHandlers = new();

        public Connection()
        {
            ID = Guid.NewGuid();
            State = ConnectionState.UNDEFINED;
            _timer = new System.Timers.Timer(1000);
            _timer.AutoReset = true;
            _timer.Elapsed += delegate(object? sender, ElapsedEventArgs args) { ConnectionCheck(); };
            _timer.Start();
        }

        public void Send(Packet packet)
        {
            var bytes = packet.GetBytes();
            workSocket.BeginSend(bytes, 0, bytes.Length, 0,
                new AsyncCallback(SendCallback), workSocket);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket) ar.AsyncState;

                // Complete sending the data to the remote device.  
                handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Logger.Instance.Log("Error sending data");
            }
        }

        public void AppendCloseHandler(Action<Connection> onCloseAction)
        {
            _onCloseHandlers.Add(onCloseAction);
        }

        public void OnLogin(User user)
        {
            State = ConnectionState.LOGGED_IN;
            User = user;
            user.SetState(UserConnectionState.LOGGED_IN);
        }

        public void OnGameServerConnect(User user)
        {
            User = user;
            State = ConnectionState.CONNECTED;
        }

        public void EstablishConnection()
        {
            State = ConnectionState.ESTABLISHED;
        }

        private void ConnectionCheck()
        {
            if (IsConnected()) return;

            workSocket.Shutdown(SocketShutdown.Both);
            workSocket.Close();
            _timer.Stop();
            Logger.Instance.Log($"Connection[{ID}] Closed!");
            foreach (var onCloseHandler in _onCloseHandlers)
            {
                onCloseHandler(this);
                Dispose();
            }
        }

        private bool IsConnected()
        {
            try
            {
                return !(workSocket.Poll(1, SelectMode.SelectRead) && workSocket.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void Dispose()
        {
            workSocket.Dispose();
            _timer.Dispose();
        }
    }
}