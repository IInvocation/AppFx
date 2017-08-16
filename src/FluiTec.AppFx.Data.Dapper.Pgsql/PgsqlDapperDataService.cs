using Dapper.Contrib.Extensions;

namespace FluiTec.AppFx.Data.Dapper.Pgsql
{
	/// <summary>	A ngsql dapper data service. </summary>
	public abstract class PgsqlDapperDataService : DapperDataService
	{
		#region Constructors

		/// <summary>	Specialised constructor for use only by derived class. </summary>
		/// <param name="connectionString"> 	The connection string. </param>
		/// <param name="connectionFactory">	The connection factory. </param>
		protected PgsqlDapperDataService(string connectionString, IConnectionFactory connectionFactory) : base(
			connectionString, connectionFactory, new QuotedEntityNameAttributeNameService())
		{
			SqlMapperExtensions.GetDatabaseType = connection => "npgsqlconnection";
		}

		/// <summary>	Specialised constructor for use only by derived class. </summary>
		/// <param name="options">	Options for controlling the operation. </param>
		protected PgsqlDapperDataService(IDapperServiceOptions options) : base(options, new QuotedEntityNameAttributeNameService())
		{
			SqlMapperExtensions.GetDatabaseType = connection => "npgsqlconnection";
		}

		#endregion
	}
}