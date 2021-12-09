using System.Net;
using CDShared.ByteLevel;
using NetworkCommsDotNet.Connections;

namespace CD.Network.Server.Config
{
    public class ServerConfig
    {
        private readonly IPEndPoint _myIpEndPoint;
        private readonly int _acceptedSessions;
        private readonly Action<ByteBuffer, Connection> _handlePacket;

        public ServerConfig(IPEndPoint ipEndPoint, int acceptedSessions, Action<ByteBuffer, Connection> handlePacket)
        {
            _myIpEndPoint = ipEndPoint;
            _acceptedSessions = acceptedSessions;
            _handlePacket = handlePacket;
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

        public Action<ByteBuffer, Connection> GetHandlePacket()
        {
            return _handlePacket;
        }
    }
}
