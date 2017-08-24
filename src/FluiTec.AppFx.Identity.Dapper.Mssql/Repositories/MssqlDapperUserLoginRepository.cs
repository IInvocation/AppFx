using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Identity.Dapper.Mssql.Repositories
{
	/// <summary>	A mssql dapper user login repository. </summary>
	public class MssqlDapperUserLoginRepository : DapperUserLoginRepository
	{
		/// <summary>	Constructor. </summary>
		/// <param name="unitOfWork">	The unit of work. </param>
		public MssqlDapperUserLoginRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		/// <summary>	Removes the by name and key. </summary>
		/// <param name="providerName">	Name of the provider. </param>
		/// <param name="providerKey"> 	The provider key. </param>
		public override void RemoveByNameAndKey(string providerName, string providerKey)
		{
			var command =
				$"DELETE FROM {TableName} WHERE {nameof(IdentityUserLoginEntity.ProviderName)} = @ProviderName AND {nameof(IdentityUserLoginEntity.ProviderKey)} = @ProviderKey";
			UnitOfWork.Connection.Execute(command, new {ProviderName = providerName, ProviderKey = providerKey},
				UnitOfWork.Transaction);
		}
	}
}