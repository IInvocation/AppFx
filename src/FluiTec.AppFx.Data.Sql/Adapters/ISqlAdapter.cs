using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace FluiTec.AppFx.Data.Sql.Adapters
{
	public interface ISqlAdapter
	{
		/// <summary>	Select all statement. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	A string. </returns>
		string SelectAllStatement(Type type);
	}

	/// <summary>	Interface for entity name mapper. </summary>
	public interface IEntityNameMapper
	{
		/// <summary>	Gets a name. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	The name. </returns>
		string GetName(Type type);
	}

	/// <summary>	A type entity name mapper. </summary>
	public class TypeEntityNameMapper : IEntityNameMapper
	{
		/// <summary>	Gets a name. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	The name. </returns>
		public virtual string GetName(Type type)
		{
			if(SqlCache.EntityNameCache.TryGetValue(type.TypeHandle, out string name))
			{
				return name;
			}
			var entityName = type.Name;
			SqlCache.EntityNameCache[type.TypeHandle] = entityName;
			return entityName;
		}
	}

	/// <summary>	An attribute type entity name mapper. </summary>
	public class AttributeTypeEntityNameMapper : TypeEntityNameMapper
	{
		/// <summary>	Gets a name. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	The name. </returns>
		public override string GetName(Type type)
		{
			var attribute =
				type.GetTypeInfo().GetCustomAttributes(typeof(EntityNameAttribute)).SingleOrDefault() as EntityNameAttribute;
			return attribute != null ? attribute.Name : base.GetName(type);
		}
	}

	/// <summary>	A SQL adapter. </summary>
	public abstract class SqlAdapter : ISqlAdapter
	{
		/// <summary>	The entity name mapper. </summary>
		protected readonly IEntityNameMapper EntityNameMapper;

		/// <summary>	Specialised constructor for use only by derived class. </summary>
		/// <param name="entityNameMapper">	The entity name mapper. </param>
		protected SqlAdapter(IEntityNameMapper entityNameMapper)
		{
			EntityNameMapper = entityNameMapper;
		}

		/// <summary>	The select all statement. </summary>
		public virtual string SelectAllStatement(Type type)
		{
			return $"SELECT * FROM {EntityNameMapper.GetName(type)}";
		}
	}
}