using System.Net;
using CD.Network.Server.Config;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;

namespace CD.Network.Server
{
    public abstract class CDServer
    {
        private readonly ServerConfig _config;
        private TCPConnectionListener _listener;
        protected CDServer(ServerConfig config)
        {
            _config = config;
        }

        ~CDServer()
        {
            StopListening();
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
        private TCPConnectionListener StartListening()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _config.GetPort());
            SendReceiveOptions optionsToUse = new SendReceiveOptions<NullSerializer>();
            var listener = new TCPConnectionListener(optionsToUse, ApplicationLayerProtocolStatus.Disabled);
            listener.AppendIncomingUnmanagedPacketHandler(PacketHandler.Instance.ParsePacket);
            Connection.StartListening(listener, endPoint);
            return listener;
        }

        private void StopListening()
        {
            Connection.StopListening(_listener);
        }
    }
}