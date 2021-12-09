using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Auth
{
    public class AnsServerListInfo : PacketInfo
    {
        private readonly ServerInfo[] _serverInfos;

        public AnsServerListInfo(ServerInfo[] serverInfos)
        {
            _serverInfos = serverInfos;
        }


        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte((byte)_serverInfos.Length);
            foreach (var serverInfo in _serverInfos)
            {
                buffer.WriteBlock(serverInfo.GetBytes());
            }
        }
    }
}
