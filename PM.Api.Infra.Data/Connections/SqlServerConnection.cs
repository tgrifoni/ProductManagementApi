using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace PM.Api.Infra.Data.Connections
{
    public class SqlServerConnection : IConnection
    {
        private readonly string _connectionString;

        public SqlServerConnection(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:PM"];
        }

        public SqlConnection CreateConnection() =>
            new SqlConnection(_connectionString);
    }
}
