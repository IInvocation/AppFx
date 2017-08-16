using FluiTec.AppFx.Data.Sql.Mappers;

namespace FluiTec.AppFx.Data.Sql.Adapters
{
	/// <summary>	A postgre SQL adapter. </summary>
	public class PostgreSqlAdapter : SqlAdapter
	{
		/// <summary>	Default constructor. </summary>
		public PostgreSqlAdapter()
		{
		}

		/// <summary>	Constructor. </summary>
		/// <param name="entityNameMapper">	The entity name mapper. </param>
		public PostgreSqlAdapter(IEntityNameMapper entityNameMapper) : base(entityNameMapper)
		{
		}

		public override string RenderTableName(string tableName) => $"\"{tableName}\"";
	}
}