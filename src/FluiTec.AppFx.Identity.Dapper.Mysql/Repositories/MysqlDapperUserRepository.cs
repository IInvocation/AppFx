using System.Collections.Generic;
using System.Linq;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Sql;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Repositories
{
	/// <summary>	A mssql dapper user repository. </summary>
	public class MysqlDapperUserRepository : DapperUserRepository
	{
		/// <summary>	Constructor. </summary>
		/// <param name="unitOfWork">	The unit of work. </param>
		public MysqlDapperUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		#region IUserRepository

		/// <summary>	Finds the identifiers in this collection. </summary>
		/// <param name="userIds">	List of identifiers for the users. </param>
		/// <returns>
		///     An enumerator that allows foreach to be used to process the identifiers in this collection.
		/// </returns>
		public override IEnumerable<IdentityUserEntity> FindByIds(IEnumerable<int> userIds)
		{
			var command = $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(IdentityUserEntity)).ToArray())} FROM {TableName} WHERE {nameof(IdentityUserEntity.Id)} IN @Ids";
			return UnitOfWork.Connection.Query<IdentityUserEntity>(command, new {Ids = userIds},
				UnitOfWork.Transaction);
		}

		/// <summary>	Searches for the first login. </summary>
		/// <param name="providerName">	Name of the provider. </param>
		/// <param name="providerKey"> 	The provider key. </param>
		/// <returns>	The found login. </returns>
		public override IdentityUserEntity FindByLogin(string providerName, string providerKey)
		{
			var otherTableName = GetTableName(typeof(IdentityUserLoginEntity));
			var command = $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(IdentityUserEntity)).ToArray())} FROM {TableName} " +
			              $"INNER JOIN {otherTableName} ON {TableName}.{nameof(IdentityUserEntity.Identifier)} = {otherTableName}.{nameof(IdentityUserLoginEntity.UserId)} " +
			              $"WHERE {otherTableName}.{nameof(IdentityUserLoginEntity.ProviderName)} = @ProviderName " +
			              $"AND {otherTableName}.{nameof(IdentityUserLoginEntity.ProviderKey)} = @ProviderKey";
			return UnitOfWork.Connection.QuerySingleOrDefault<IdentityUserEntity>(command,
				new {ProviderName = providerName, ProviderKey = providerKey},
				UnitOfWork.Transaction);
		}

		#endregion
	}
}