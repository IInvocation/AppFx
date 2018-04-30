using System.Data;
using Microsoft.Data.Sqlite;

namespace FluiTec.AppFx.Data.Dapper.SqLite
{
    /// <summary>   A sq lite connection factory. </summary>
    public class SqLiteConnectionFactory : IConnectionFactory
    {
        /// <summary>   Creates a connection. </summary>
        /// <param name="connectionString"> The connection string. </param>
        /// <returns>   The new connection. </returns>
        public IDbConnection CreateConnection(string connectionString)
        {
            return new SqliteConnection(connectionString);
        }
    }
}