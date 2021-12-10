using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CD.Network.Connections;
using CD.Network.Server.Config;
using ProjectCD.GlobalManagers;
using SunStructs.PacketInfos.Auth.Server;
using SunStructs.Packets.AuthServerPackets;

namespace ProjectCD.Servers.Auth
{
    internal sealed class AuthServer : CDServer
    {
        public AuthServer(AuthServerConfig config) : base(config)
        {
        }


        protected override void OnConnect(Connection connection)
        {
            ConnectionManager.Instance.AddConnection(connection);
            var packet = new Hello(new HelloInfo("Cherry Dragon Sun Server", 0));
            try
            {
                connection.Send(packet);
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
