using System;
using System.Collections.Concurrent;
using System.Data;
using FluiTec.AppFx.Data.Sql.Adapters;

namespace FluiTec.AppFx.Data.Sql
{
	/// <summary>	A default SQL builder. </summary>
	public static class DefaultSqlBuilder
	{
		/// <summary>	The padlock. </summary>
		private static readonly object Padlock = new object();

		/// <summary>	Dictionary of builders. </summary>
		private static readonly ConcurrentDictionary<string, SqlBuilder> BuilderDictionary;

		/// <summary>	Gets SQL builder delegate. </summary>
		/// <param name="connection">	The connection. </param>
		/// <returns>	A SqlBuilder. </returns>
		public delegate SqlBuilder GetSqlBuilderDelegate(IDbConnection connection);

		/// <summary>	The get SQL builder. </summary>
		public static GetSqlBuilderDelegate GetSqlBuilder;

		/// <summary>	Static constructor. </summary>
		static DefaultSqlBuilder()
		{
			BuilderDictionary = new ConcurrentDictionary<string, SqlBuilder>();
			BuilderDictionary.TryAdd(key: "System.Data.SqlClient.SqlConnection", value: new SqlBuilder(new MicrosoftSqlAdapter()));
			BuilderDictionary.TryAdd(key: "Npgsql.NpgsqlConnection", value: new SqlBuilder(new PostgreSqlAdapter()));
		}

		/// <summary>	An IDbConnection extension method that gets a builder. </summary>
		/// <param name="connection">	The connection to act on. </param>
		/// <returns>	The builder. </returns>
		public static SqlBuilder GetBuilder(this IDbConnection connection)
		{
			lock (Padlock)
			{
				if (GetSqlBuilder != null)
				{
					return GetSqlBuilder(connection);
				}
				var connectionTypeName = connection.GetType().FullName;
				if (BuilderDictionary.TryGetValue(connectionTypeName, out SqlBuilder builder))
					return builder;
				throw new NotImplementedException($"No default builder for connection for {connectionTypeName} registered!");
			}
		}
	}
}