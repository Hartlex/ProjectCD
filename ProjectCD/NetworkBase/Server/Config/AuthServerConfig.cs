using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using ProjectCD.NetworkBase.Connections;

namespace CD.Network.Server.Config
{
    internal class AuthServerConfig : ServerConfig
    {
        public AuthServerConfig(IPEndPoint ipEndPoint, int acceptedSessions, Action<ByteBuffer, Connection> handlePacket) : base(ipEndPoint, acceptedSessions, handlePacket)
        {
        }
    }
}
