using System.Net.Sockets;
using CDShared.Logging;
using SunStructs.Packets;

namespace CD.Network.Connections
{
    public class Connection
    {
        public ConnectionState State { get; }
        // Size of receive buffer.  
        public const int BufferSize = 1024;

        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];

        // Client socket.
        public Socket workSocket = null;
        public readonly Guid ID;
        public Connection()
        {
            ID = Guid.NewGuid();
            State = ConnectionState.UNDEFINED;
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
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Logger.Instance.Log("Error sending data");
            }
        }
    }
}