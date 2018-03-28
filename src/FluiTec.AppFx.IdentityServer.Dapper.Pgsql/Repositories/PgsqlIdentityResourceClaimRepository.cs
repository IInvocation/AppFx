using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Repositories
{
    /// <summary>	A mssql identity resource claim repository. </summary>
    public class PgsqlIdentityResourceClaimRepository : IdentityResourceClaimRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public PgsqlIdentityResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion
    }
}