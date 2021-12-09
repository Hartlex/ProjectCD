using System.Net;
using CD.Network.Server.Config;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;

namespace ProjectCD.GlobalManagers.Config
{ 
    class ConfigParser
    {
        private readonly string[] _configLines;

        public ConfigParser(string configPath)
        {
            _configLines = File.ReadAllLines(configPath);
        }

        public bool TryParseLoginServerInfo(out AuthServerConfig config)
        {
            var configDict = GetConfigDictionary();
            config = null;
            try
            {
                if (!configDict.TryGetValue("IpAddress", out var strIpAddress)) return false;
                if (!configDict.TryGetValue("Port", out var strPort)) return false;
                if (!configDict.TryGetValue("AcceptedSessions", out var strAcceptedSessions)) return false;
                IPAddress.TryParse(strIpAddress, out var ipAddress);
                int.TryParse(strPort, out var port);
                int.TryParse(strAcceptedSessions, out var acceptedSessions);
                var endPoint = new IPEndPoint(ipAddress, port);
                config = new AuthServerConfig(endPoint, acceptedSessions,AuthPacketParser.Instance.ParsePacket);
                return true;
            }
            catch (FormatException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return false;
            }
        }

        public bool TryParseDatabaseConfig(out DatabaseConfig config)
        {
            config = null;
            var configDict = GetConfigDictionary();
            try
            {
                if (!configDict.TryGetValue("DataSource", out var dataSource)) return false;
                if (!configDict.TryGetValue("InitCatalog", out var initCatalog)) return false;
                if (!configDict.TryGetValue("IntegratedSecurity", out var strIntegratedSecurity)) return false;
                bool.TryParse(strIntegratedSecurity, out bool integratedSecurity);
                config = new DatabaseConfig(dataSource, initCatalog, integratedSecurity);
                return true;
            }
            catch (FormatException e)
            {
                Logger.Instance.Log(e.ToString(), LogType.ERROR);
                return false;
            }

        }

        public bool TryParseGameServerInfo(out GameServerConfig[] configs)
        {
            configs = null;
            var configDict = GetConfigDictionary();
            try
            {
                configDict.TryGetValue("NumberOfServers", out var strNumberOfGameServers);
                if (!int.TryParse(strNumberOfGameServers, out var numberOfGameServers)) return false;
                configs = new GameServerConfig[numberOfGameServers];
                for (int i = 0; i < numberOfGameServers; i++)
                {
                    if (!configDict.TryGetValue("ServerId" + (i + 1), out var strServerId)) return false;
                    if (!configDict.TryGetValue("ServerName" + (i + 1), out var serverName)) return false;
                    if (!configDict.TryGetValue("ServerAddress" + (i + 1), out var strServerAddress)) return false;
                    if (!configDict.TryGetValue("ServerPort" + (i + 1), out var strServerPort)) return false;
                    if (!configDict.TryGetValue("AcceptedSessions" + (i + 1), out var strAcceptedSessions)) return false;
                    if (!configDict.TryGetValue("ChannelCount" + (i + 1), out var strChannelCount)) return false;

                    byte.TryParse(strServerId, out var serverId);
                    IPAddress.TryParse(strServerAddress, out var ipAddress);
                    int.TryParse(strServerPort, out var serverPort);
                    int.TryParse(strAcceptedSessions, out var acceptedSessions);
                    int.TryParse(strChannelCount, out var channelCount);

                    var ipEndPoint = new IPEndPoint(ipAddress, serverPort);
                    configs[i] = new GameServerConfig(serverId,serverName, ipEndPoint, acceptedSessions,channelCount,GamePacketParser.Instance.ParsePacket);
                }

                return true;
            }
            catch (FormatException e)
            {
                Logger.Instance.Log(e.ToString(), LogType.ERROR);
                return false;
            }

        }

        private Dictionary<string, string> GetConfigDictionary()
        {
            Dictionary<string, string> configDictionary = new Dictionary<string, string>(_configLines.Length);
            foreach (var configLine in _configLines)
            {
                var split = configLine.Split(':');
                configDictionary.Add(split[0], split[1]);
            }

            return configDictionary;
        }
    }
}
