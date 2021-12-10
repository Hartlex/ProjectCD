using System.Net;
using CDShared.ByteLevel;
using ProjectCD.NetworkBase.Connections;

namespace CD.Network.Server.Config
{
    public class GameServerConfig : ServerConfig
    {
        private readonly byte _groupID;
        private readonly string _name;
        private readonly int _channelCount;

        public GameServerConfig(byte groupID, string name, IPEndPoint ipEndPoint, int acceptedSessions, int channelCount, Action<ByteBuffer,Connection> handlePacket) : base(ipEndPoint, acceptedSessions,handlePacket)
        {
            _groupID = groupID;
            _name = name;
            _channelCount = channelCount;
        }

        public string GetName()
        {
            return _name;
        }

        public byte GetId()
        {
            return _groupID;
        }

        public int GetChannelCount()
        {
            return _channelCount;
        }
        
    }
}
