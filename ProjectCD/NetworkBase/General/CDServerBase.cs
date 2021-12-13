using System.Net;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;

namespace ProjectCD.NetworkBase.General
{
    public abstract class CDServerBase
    {
        private ClientListener _listener;
        private readonly ServerConfig _config;
        protected CDServerBase(ServerConfig config)
        {
            _config = config;
            Logger.Instance.Log("\nServer starting...");
            _listener = new ClientListener(config.GetPort(),OnConnect, config.GetHandlePacket());
            Logger.Instance.Log($"Server on Port:{config.GetPort()} started!",LogType.SUCCESS);
        }


        protected abstract void OnConnect(Connection connection);

        public IPEndPoint GetLocalEndPoint()
        {
            return _config.GetIpEndPoint();
        }


    }
}
