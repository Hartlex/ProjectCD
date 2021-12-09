using System.Net;

namespace CD.Network.Server.Config
{
    public class GameServerConfig : ServerConfig
    {
        private readonly byte _id;
        private readonly string _name;
        private readonly int _channelCount;

        public GameServerConfig(byte id, string name, IPEndPoint ipEndPoint, int acceptedSessions, int channelCount) : base(ipEndPoint, acceptedSessions)
        {
            _id = id;
            _name = name;
            _channelCount = channelCount;
        }

        public string GetName()
        {
            return _name;
        }

        public byte GetId()
        {
            return _id;
        }

        public int GetChannelCount()
        {
            return _channelCount;
        }
        
    }
}
