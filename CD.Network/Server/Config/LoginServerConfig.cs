using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using NetworkCommsDotNet.Connections;

namespace CD.Network.Server.Config
{
    public class LoginServerConfig : ServerConfig
    {
        public LoginServerConfig(IPEndPoint ipEndPoint, int acceptedSessions, Action<ByteBuffer, Connection> handlePacket) : base(ipEndPoint, acceptedSessions, handlePacket)
        {
        }
    }
}
