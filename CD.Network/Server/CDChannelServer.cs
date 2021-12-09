using CD.Network.Server.Config;

namespace CD.Network.Server;

public abstract class CDChannelServer : CDServer
{
    protected CDChannelServer(ServerConfig config) : base(config)
    {
    }
}