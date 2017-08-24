using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Repositories
{
	/// <summary>	A dapper user role repository. </summary>
	public class DapperUserRoleRepository : DapperRepository<IdentityUserRoleEntity, int>, IUserRoleRepository
	{
		/// <summary>	Constructor. </summary>
		/// <param name="unitOfWork">	The unit of work. </param>
		public DapperUserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>	Searches for the first user identifier and role identifier. </summary>
		/// <param name="userId">	Identifier for the user. </param>
		/// <param name="roleId">	Identifier for the role. </param>
		/// <returns>	The found user identifier and role identifier. </returns>
		public virtual IdentityUserRoleEntity FindByUserIdAndRoleId(int userId, int roleId)
		{
			var command = SqlBuilder.SelectByFilter(typeof(IdentityUserRoleEntity),
				new[] {nameof(IdentityUserRoleEntity.UserId), nameof(IdentityUserRoleEntity.RoleId)});
			return UnitOfWork.Connection.QuerySingleOrDefault<IdentityUserRoleEntity>(command,
				new { UserId = userId, RoleId = roleId },
				UnitOfWork.Transaction);
		}

		/// <summary>	Finds the users in this collection. </summary>
		/// <param name="user">	The user. </param>
		/// <returns>
		///     An enumerator that allows foreach to be used to process the users in this collection.
		/// </returns>
		public virtual IEnumerable<int> FindByUser(IdentityUserEntity user)
		{
			var command = SqlBuilder.SelectByFilter(typeof(IdentityUserRoleEntity), nameof(IdentityUserRoleEntity.UserId),
				new[] {nameof(IdentityUserRoleEntity.RoleId)});
			return UnitOfWork.Connection.Query<int>(command, new { UserId = user.Id },
				UnitOfWork.Transaction);
		}

		/// <summary>	Finds the roles in this collection. </summary>
		/// <param name="role">	The role. </param>
		/// <returns>
		///     An enumerator that allows foreach to be used to process the roles in this collection.
		/// </returns>
		public virtual IEnumerable<int> FindByRole(IdentityRoleEntity role)
		{
			var command = SqlBuilder.SelectByFilter(typeof(IdentityUserRoleEntity), nameof(IdentityUserRoleEntity.RoleId), new [] {nameof(IdentityUserRoleEntity.UserId)});
			return UnitOfWork.Connection.Query<int>(command, new { RoleId = role.Id },
				UnitOfWork.Transaction);
		}
	}
}