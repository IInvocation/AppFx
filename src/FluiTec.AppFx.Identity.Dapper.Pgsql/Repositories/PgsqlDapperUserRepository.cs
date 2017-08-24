using System;
using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql.Repositories
{
	/// <summary>	A pgsql dapper user repository. </summary>
	public class PgsqlDapperUserRepository : DapperUserRepository
	{
		/// <summary>	Constructor. </summary>
		/// <param name="unitOfWork">	The unit of work. </param>
		public PgsqlDapperUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>	Gets an identity user entity using the given identifier. </summary>
		/// <param name="identifier">	The identifier to get. </param>
		/// <returns>	An IdentityUserEntity. </returns>
		public override IdentityUserEntity Get(string identifier)
		{
			var command = $"SELECT * FROM {TableName} WHERE \"{nameof(IdentityUserEntity.Identifier)}\" = @Identifier";
			return UnitOfWork.Connection.QuerySingleOrDefault<IdentityUserEntity>(command, new { Identifier = Guid.Parse(identifier) },
				UnitOfWork.Transaction);
		}

		/// <summary>	Finds the identifiers in this collection. </summary>
		/// <param name="userIds">	List of identifiers for the users. </param>
		/// <returns>
		///     An enumerator that allows foreach to be used to process the identifiers in this collection.
		/// </returns>
		public override IEnumerable<IdentityUserEntity> FindByIds(IEnumerable<int> userIds)
		{
			var command = $"SELECT * FROM {TableName} WHERE \"{nameof(IdentityUserEntity.Id)}\" = ANY(@Ids)";
			return UnitOfWork.Connection.Query<IdentityUserEntity>(command, new { Ids = userIds },
				UnitOfWork.Transaction);
		}

		/// <summary>	Searches for the first login. </summary>
		/// <param name="providerName">	Name of the provider. </param>
		/// <param name="providerKey"> 	The provider key. </param>
		/// <returns>	The found login. </returns>
		public override IdentityUserEntity FindByLogin(string providerName, string providerKey)
		{
			var otherTableName = GetTableName(typeof(IdentityUserLoginEntity));
			var command = $"SELECT {TableName}.* FROM {TableName} " +
			              $"INNER JOIN {otherTableName} ON " +
			              $"{TableName}.\"{nameof(IdentityUserEntity.Identifier)}\" = {otherTableName}.\"{nameof(IdentityUserLoginEntity.UserId)}\" " +
			              $"WHERE {otherTableName}.\"{nameof(IdentityUserLoginEntity.ProviderName)}\" = @ProviderName " +
			              $"AND {otherTableName}.\"{nameof(IdentityUserLoginEntity.ProviderKey)}\" = @ProviderKey";
			return UnitOfWork.Connection.QuerySingleOrDefault<IdentityUserEntity>(command,
				new { ProviderName = providerName, ProviderKey = providerKey },
				UnitOfWork.Transaction);
		}
	}
}