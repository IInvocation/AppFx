using FluiTec.AppFx.Data.Sql.Mappers;

namespace FluiTec.AppFx.Data.Sql.Adapters
{
	/// <summary>	A microsoft SQL adapter. </summary>
	public class MicrosoftSqlAdapter : SqlAdapter
	{
		/// <summary>	Default constructor. </summary>
		public MicrosoftSqlAdapter()
		{
		}

		/// <summary>	Constructor. </summary>
		/// <param name="entityNameMapper">	The entity name mapper. </param>
		public MicrosoftSqlAdapter(IEntityNameMapper entityNameMapper) : base(entityNameMapper)
		{
		}
	}
}