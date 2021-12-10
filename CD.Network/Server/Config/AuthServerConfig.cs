using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Connections;
using CDShared.ByteLevel;

namespace CD.Network.Server.Config
{
    public class AuthServerConfig : ServerConfig
    {
        public AuthServerConfig(IPEndPoint ipEndPoint, int acceptedSessions, Action<ByteBuffer, Connection> handlePacket) : base(ipEndPoint, acceptedSessions, handlePacket)
        {
        }
    }
}
