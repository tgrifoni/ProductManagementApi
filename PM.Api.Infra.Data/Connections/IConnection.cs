using System.Data.SqlClient;

namespace PM.Api.Infra.Data.Connections
{
    public interface IConnection
    {
        SqlConnection CreateConnection();
    }
}
