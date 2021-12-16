using System.Net;
using System.Net.Sockets;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;

namespace ProjectCD.NetworkBase.General
{
    public class ClientListener
    {

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private readonly Action<Connection> _onConnect;
        private readonly Action<ByteBuffer, Connection> _onReceive;
        public ClientListener(int port, Action<Connection> onConnect, Action<ByteBuffer, Connection> onReceive)
        {
            _onConnect = onConnect;
            _onReceive = onReceive;
            Task.Factory.StartNew(() => StartListening(port));
        }


        public void StartListening(int port)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen();

                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    allDone.WaitOne();
                }
                // Start an asynchronous socket to listen for connections.  


                
            }
            catch (Exception e)
            {
                Logger.Instance.Log("Connection closed unexpectedly!");
                Logger.Instance.Log(e);
            }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            try
            {

                
                // Create the state object.  
                Connection connection = new Connection();
                connection.workSocket = handler;

                _onConnect(connection);

                handler.BeginReceive(connection.buffer, 0, Connection.BufferSize, 0,
                    new AsyncCallback(ReadCallback), connection);

            }
            catch (Exception e)
            {
                Logger.Instance.Log("Connection Closed!");
               
            }

        }

        public void ReadCallback(IAsyncResult ar)
        {
            Connection connection = (Connection)ar.AsyncState;
            Socket handler = connection.workSocket;

            try
            {            
                // Retrieve the state object and the handler socket  
                // from the asynchronous state object.  


                int bytesRead = handler.EndReceive(ar);
                if (bytesRead > 0)
                {
                    var rec = new byte[bytesRead];
                    Buffer.BlockCopy(connection.buffer, 0, rec, 0, bytesRead);

                    _onReceive(new(rec), connection);

                    handler.BeginReceive(connection.buffer, 0, Connection.BufferSize, 0,
                        new AsyncCallback(ReadCallback), connection);
                }


            }
            catch (Exception e)
            {
                Logger.Instance.Log("Error at ReadCallback!");
                Logger.Instance.Log(e);

            }


        }

        private void Send(Socket handler, byte[] data)
        {
           
            // Begin sending the data to the remote device.  
            handler.BeginSend(data, 0, data.Length, 0,
                new AsyncCallback(SendCallback), handler);
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
                Logger.Instance.Log("Failed to send data!");
            }
        }


    }
}
