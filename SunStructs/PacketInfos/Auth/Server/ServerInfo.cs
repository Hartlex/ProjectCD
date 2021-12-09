using CDShared.ByteLevel;
using static SunStructs.Definitions.Const;

namespace SunStructs.PacketInfos.Auth.Server
{
    public class ServerInfo : ServerPacketInfo
    {
        private readonly string _name;
        private readonly byte _serverNr;
        private readonly byte _limitAge;
        private readonly ServerState _state;

        public ServerInfo(string name, int serverNr)
        {
            this._name = name;
            this._serverNr = (byte)serverNr;
            _limitAge = 0;
            _state = ServerState.DISCONNECTED;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteString(_name,MAX_SERVER_NAME_LENGTH+1);
            buffer.WriteBlock(new []{_serverNr,_limitAge,(byte)_state});
            }
    }

    public enum ServerState
    {
        DISCONNECTED,
        CONNECTED,
    }
}