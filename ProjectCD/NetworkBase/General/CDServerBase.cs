using System.Net;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;

namespace ProjectCD.NetworkBase.General
{
    internal abstract class CDServerBase
    {
        private ClientListener _listener;
        private readonly ServerConfig _config;
        protected CDServerBase(ServerConfig config)
        {
            _config = config;
            _listener = new ClientListener(config.GetIpEndPoint().Address, config.GetPort(),OnConnect, config.GetHandlePacket());
            Logger.Instance.Log($"Server on EndPoint: {config.GetPort()} started!",LogType.SUCCESS);
        }


        protected abstract void OnConnect(Connection connection);

        public IPEndPoint GetLocalEndPoint()
        {
            return _config.GetIpEndPoint();
        }


    }
}
