using System.Linq;
using System.Text;
using Dapper;

namespace FluiTec.AppFx.Data.Dapper
{
	/// <summary>	A dapper predefined key repository. </summary>
	/// <typeparam name="TEntity">	Type of the entity. </typeparam>
	/// <typeparam name="TKey">   	Type of the key. </typeparam>
	public abstract class DapperPredefinedKeyRepository<TEntity, TKey> : DapperRepository<TEntity, TKey>
		where TEntity : class, IEntity<TKey>, new()
	{
		#region Constructors

		/// <summary>	Specialised constructor for use only by derived class. </summary>
		///
		/// <param name="unitOfWork">	The unit of work. </param>
		protected DapperPredefinedKeyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		#endregion

		#region Metods

		/// <summary>	Sets insert key. </summary>
		/// <param name="entity">	The entity to add. </param>
		protected abstract void SetInsertKey(TEntity entity);

		#endregion

		#region DapperRepository

		/// <summary>	Adds entity. </summary>
		/// <param name="entity">	The entity to add. </param>
		/// <returns>	A TEntity. </returns>
		public override TEntity Add(TEntity entity)
		{
			var type = typeof(TEntity);
			
			// compute type infos
			var allProperties = SqlMapperExtensionsOwn.TypePropertiesCache(type);
			var keyProperties = SqlMapperExtensionsOwn.KeyPropertiesCache(type);
			var computedProperties = SqlMapperExtensionsOwn.ComputedPropertiesCache(type);
			var allPropertiesExceptComputed = allProperties.Except(computedProperties).ToList();

			// get sql-adapter
			var adapter = SqlMapperExtensionsOwn.GetFormatter(UnitOfWork.Connection);

			// generate sql for columns
			var sbColumnList = new StringBuilder(value: null);
			for (var i = 0; i < allPropertiesExceptComputed.Count; i++)
			{
				var property = allPropertiesExceptComputed[i];
				adapter.AppendColumnName(sbColumnList, property.Name);
				if (i < allPropertiesExceptComputed.Count - 1)
					sbColumnList.Append(value: ", ");
			}

			// generate sql for parameters
			var sbParameterList = new StringBuilder(value: null);
			for (var i = 0; i < allPropertiesExceptComputed.Count; i++)
			{
				var property = allPropertiesExceptComputed[i];
				sbParameterList.AppendFormat(format: "@{0}", arg0: property.Name);
				if (i < allPropertiesExceptComputed.Count - 1)
					sbParameterList.Append(value: ", ");
			}

			var cmd = $"insert into {TableName} ({sbColumnList}) values ({sbParameterList})";
			var multi = UnitOfWork.Connection.Execute(cmd, entity, UnitOfWork.Transaction);

			return entity;
		}

		#endregion
	}
}