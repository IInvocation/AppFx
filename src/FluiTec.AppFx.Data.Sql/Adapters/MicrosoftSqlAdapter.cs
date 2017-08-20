using System.Reflection;
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

		/// <summary>	Gets automatic key statement. </summary>
		/// <param name="propertyInfo">	Information describing the property. </param>
		/// <returns>	The automatic key statement. </returns>
		public override string GetAutoKeyStatement(PropertyInfo propertyInfo)
		{
			return $";SELECT SCOPE_IDENTITY() {RenderPropertyName(propertyInfo)}";
		}
	}
}