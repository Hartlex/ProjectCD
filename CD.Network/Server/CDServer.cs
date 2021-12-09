using CD.Network.Server.Config;

namespace CD.Network.Server
{
    public abstract class CDServer
    {
        private readonly ServerConfig _config;
        
        protected CDServer(ServerConfig config)
        {
            _config = config;
        }
    }
}