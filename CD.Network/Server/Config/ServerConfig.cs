using System.Net;

namespace CD.Network.Server.Config
{
    public class ServerConfig
    {
        private readonly IPEndPoint _myIpEndPoint;
        private readonly int _acceptedSessions;

        public ServerConfig(IPEndPoint ipEndPoint, int acceptedSessions)
        {
            _myIpEndPoint = ipEndPoint;
            _acceptedSessions = acceptedSessions;
        }
        public IPEndPoint GetIpEndPoint()
        {
            return _myIpEndPoint;
        }

        public int GetAcceptedSessions()
        {
            return _acceptedSessions;
        }

        public int GetPort()
        {
            return _myIpEndPoint.Port;
        }
    }
}
