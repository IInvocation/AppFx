using System.Data;
using Npgsql;

namespace FluiTec.AppFx.Data.Dapper.Pgsql
{
	/// <summary>	A pgsql connection factory. </summary>
	public class PgsqlConnectionFactory : IConnectionFactory
	{
		/// <summary>	Creates a connection. </summary>
		/// <param name="connectionString">	The connection string. </param>
		/// <returns>	The new connection. </returns>
		public IDbConnection CreateConnection(string connectionString)
		{
#if DEBUG
			return new WrappedDbConnection(new NpgsqlConnection(connectionString));
#else
			return new NpgsqlConnection(connectionString);
#endif
		}
	}
}