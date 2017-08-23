using System.Reflection;
using FluiTec.AppFx.Data.Sql.Mappers;

namespace FluiTec.AppFx.Data.Sql.Adapters
{
	/// <summary>	a MySql adapter. </summary>
	public class MySqlAdapter : SqlAdapter
	{
		/// <summary>	Default constructor. </summary>
		public MySqlAdapter()
		{
		}

		/// <summary>	Constructor. </summary>
		/// <param name="entityNameMapper">	The entity name mapper. </param>
		public MySqlAdapter(IEntityNameMapper entityNameMapper) : base(entityNameMapper)
		{
		}

		/// <summary>	Gets automatic key statement. </summary>
		/// <param name="propertyInfo">	Information describing the property. </param>
		/// <returns>	The automatic key statement. </returns>
		public override string GetAutoKeyStatement(PropertyInfo propertyInfo)
		{
			return $";SELECT LAST_INSERT_ID() {RenderPropertyName(propertyInfo)}";
		}
	}
}