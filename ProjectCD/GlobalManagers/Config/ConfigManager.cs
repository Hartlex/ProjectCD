using System.Configuration;
using CD.Network.Server.Config;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.PacketInfos.Auth;

namespace ProjectCD.GlobalManagers.Config
{
    public class ConfigManager : Singleton<ConfigManager>
    {
        private static readonly string ConfigPath= ConfigurationManager.AppSettings["configPath"];
        private LoginServerConfig _loginServerConfig;
        private ClientVersion _compatibleClientVersion;
        private DatabaseConfig _databaseConfig;
        private GameServerConfig[] _gameServerConfigs;

        public void LoadConfigurations()
        {
            try
            {
                LoadLoginServerConfig();
                LoadCompatibleClientVersion();
                LoadDatabaseConfig();
                LoadGameServerConfig();
                
                Logger.Instance.Log("All Configurations loaded!",LogType.SUCCESS);
            }
            catch (Exception e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
            }
        }

        public LoginServerConfig GetLoginServerConfig()
        {
            return _loginServerConfig;
        }
        public bool IsClientVersionCompatible(ClientVersion version)
        {
            return version.Equals(_compatibleClientVersion);
        }
        public DatabaseConfig GetDbConfig()
        {
            return _databaseConfig;
        }
        public GameServerConfig[] GetGameServerConfigs()
        {
            return _gameServerConfigs;
        }
        #region ConfigLoaderMethods
        
        private void LoadLoginServerConfig()
        {
            var parser = new ConfigParser(ConfigPath + @"\LoginServerConfig.ini");
            if (!parser.TryParseLoginServerInfo(out _loginServerConfig))
            {
                throw new Exception("Failed to load LoginConfig");
            }
            Logger.Instance.Log("LoginServerConfig loaded!",LogType.SUCCESS);
        }
        private void LoadCompatibleClientVersion()
        {
            var versionString = ConfigurationManager.AppSettings["compatibleClientVersion"];
            _compatibleClientVersion = new ClientVersion(versionString);
            Logger.Instance.Log("CompatibleClientVersion loaded!",LogType.SUCCESS);
        }
        private void LoadDatabaseConfig()
        {
            var parser = new ConfigParser(ConfigPath + @"\DatabaseConfig.ini");
            if (!parser.TryParseDatabaseConfig(out _databaseConfig))
            {
                throw new Exception("Failed to load DatabaseConfig");
            }
            Logger.Instance.Log("DatabaseConfig loaded!",LogType.SUCCESS);
        }
        private void LoadGameServerConfig()
        {
            var parser = new ConfigParser(ConfigPath + @"\GameServerConfig.ini");
            if(!parser.TryParseGameServerInfo(out _gameServerConfigs))
            {
                throw new Exception("Failed to load GameServerConfig");
            }
            Logger.Instance.Log("GameServerConfig loaded!",LogType.SUCCESS);
        }

        #endregion

    }
}
