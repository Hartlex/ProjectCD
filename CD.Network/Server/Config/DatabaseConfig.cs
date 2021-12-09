using System.Data.SqlClient;

namespace CD.Network.Server.Config
{
    public class DatabaseConfig
    {
        private readonly string _connectionString;

        public DatabaseConfig(string dataSource, string initialCatalog, bool integratedSecurity)
        {
            var sb = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                IntegratedSecurity = integratedSecurity
            };
            _connectionString = sb.ConnectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        
    }
}

