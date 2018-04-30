using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Repositories
{
    /// <summary>	A mssql identity resource claim repository. </summary>
    public class MssqlIdentityResourceClaimRepository : IdentityResourceClaimRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public MssqlIdentityResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion
    }
}