using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Identity.Dapper.Mysql.Repositories
{
	/// <summary>	A mssql dapper role repository. </summary>
	public class MysqlDapperRoleRepository : DapperRoleRepository
	{
		/// <summary>	Constructor. </summary>
		/// <param name="unitOfWork">	The unit of work. </param>
		public MysqlDapperRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>	Finds the identifiers in this collection. </summary>
		/// <param name="roleIds">	List of identifiers for the roles. </param>
		/// <returns>
		///     An enumerator that allows foreach to be used to process the identifiers in this collection.
		/// </returns>
		public override IEnumerable<IdentityRoleEntity> FindByIds(IEnumerable<int> roleIds)
		{
			var command = $"SELECT * FROM {TableName} WHERE {nameof(IdentityUserEntity.Id)} IN @Ids";
			return UnitOfWork.Connection.Query<IdentityRoleEntity>(command, new {Ids = roleIds},
				UnitOfWork.Transaction);
		}
	}
}