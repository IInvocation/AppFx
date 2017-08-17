using System;
using System.Linq;
using System.Reflection;

namespace FluiTec.AppFx.Data.Sql.Mappers
{
	/// <summary>	An attribute type entity name mapper. </summary>
	public class AttributeTypeEntityNameMapper : TypeEntityNameMapper
	{
		/// <summary>	Gets a name. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	The name. </returns>
		public override string GetName(Type type)
		{
			if (SqlCache.EntityNameCache.TryGetValue(type.TypeHandle, out string name))
				return name;

			var attribute = type
				.GetTypeInfo()
				.GetCustomAttributes(typeof(EntityNameAttribute))
				.SingleOrDefault() as EntityNameAttribute;
			var entityName = attribute != null ? attribute.Name : base.GetName(type);
			SqlCache.EntityNameCache.TryAdd(type.TypeHandle, entityName);
			return entityName;
		}
	}
}