using System;
using FluiTec.AppFx.Data.Sql.Mappers;

namespace FluiTec.AppFx.Data.Sql.Adapters
{
	/// <summary>	A SQL adapter. </summary>
	public abstract class SqlAdapter : ISqlAdapter
	{
		/// <summary>	The entity name mapper. </summary>
		protected readonly IEntityNameMapper EntityNameMapper;

		/// <summary>	Specialised default constructor for use only by derived class. </summary>
		protected SqlAdapter() : this(new AttributeTypeEntityNameMapper())
		{
		}

		/// <summary>	Specialised constructor for use only by derived class. </summary>
		/// <param name="entityNameMapper">	The entity name mapper. </param>
		protected SqlAdapter(IEntityNameMapper entityNameMapper)
		{
			EntityNameMapper = entityNameMapper ?? throw new ArgumentNullException(nameof(entityNameMapper));
		}

		#region Statements

		/// <summary>	The select all statement. </summary>
		public virtual string SelectAllStatement(Type type)
		{
			return $"SELECT * FROM {RenderTableName(type)}";
		}

		#endregion

		#region Rendering

		/// <summary>	Renders the table name described by tableName. </summary>
		/// <param name="tableName">	Name of the table. </param>
		/// <returns>	A string. </returns>
		public virtual string RenderTableName(string tableName) => tableName;

		/// <summary>	Renders the table name described by type. </summary>
		/// <param name="type">	The type. </param>
		/// <returns>	A string. </returns>
		public virtual string RenderTableName(Type type)
		{
			return RenderTableName(EntityNameMapper.GetName(type));
		}

		#endregion
	}
}