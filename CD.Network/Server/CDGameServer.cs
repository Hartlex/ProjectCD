using CD.Network.Server.Config;

namespace CD.Network.Server;

public abstract class CDGameServer : CDServer
{

    protected CDGameServer(ServerConfig config) : base(config)
    {
    }
}