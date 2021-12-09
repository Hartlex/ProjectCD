﻿using System.Net;
using CD.Network.Server.Config;
using CDShared.ByteLevel;
using CDShared.Logging;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;

namespace CD.Network.Server
{
    public abstract class CDServerBase
    {
        private readonly ServerConfig _config;
        private readonly TCPConnectionListener? _listener;
        private readonly Action<ByteBuffer, Connection> _handlePacket;
        protected CDServerBase(ServerConfig config)
        {
            _config = config;
            _handlePacket = config.GetHandlePacket();
            _listener = StartListening();
        }

        protected abstract void OnConnect(Connection connection);
        ~CDServerBase()
        {
            StopListening();
        }

        private TCPConnectionListener StartListening()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), _config.GetPort());
            SendReceiveOptions optionsToUse = new SendReceiveOptions<NullSerializer>();
            var listener = new TCPConnectionListener(optionsToUse, ApplicationLayerProtocolStatus.Disabled);
            listener.AppendIncomingUnmanagedPacketHandler((header, connection, data) =>
            {
                _handlePacket(new ByteBuffer(data), connection);
            } );
            Connection.StartListening(listener, endPoint);
            Logger.Instance.Log("Started Listening on Endpoint: " + endPoint);
            return listener;
        }

        private void StopListening()
        {
            Connection.StopListening(_listener);
        }
    }
}