using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Repositories
{
    /// <summary>	A mssql client scope repository. </summary>
    public class PgsqlClientScopeRepository : ClientScopeRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public PgsqlClientScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion
    }
}