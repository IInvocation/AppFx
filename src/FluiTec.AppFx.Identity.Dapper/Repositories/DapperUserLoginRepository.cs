using System;
using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Repositories
{
	/// <summary>	A dapper user login repository. </summary>
	public abstract class DapperUserLoginRepository : DapperRepository<IdentityUserLoginEntity, int>, IUserLoginRepository
	{
		/// <summary>	Constructor. </summary>
		/// <param name="unitOfWork">	The unit of work. </param>
		protected DapperUserLoginRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>	Removes the by name and key. </summary>
		/// <param name="providerName">	Name of the provider. </param>
		/// <param name="providerKey"> 	The provider key. </param>
		public abstract void RemoveByNameAndKey(string providerName, string providerKey);

		/// <summary>	Finds the user identifiers in this collection. </summary>
		/// <param name="userId">	Identifier for the user. </param>
		/// <returns>
		///     An enumerator that allows foreach to be used to process the user identifiers in this
		///     collection.
		/// </returns>
		public virtual IEnumerable<IdentityUserLoginEntity> FindByUserId(Guid userId)
		{
			var command = SqlBuilder.SelectByFilter(EntityType, nameof(IdentityUserLoginEntity.UserId));
			return UnitOfWork.Connection.Query<IdentityUserLoginEntity>(command, new { UserId = userId },
				UnitOfWork.Transaction);
		}
	}
}