using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql.Repositories
{
    /// <summary>	A Mysql identity resource claim repository. </summary>
    public class MysqlIdentityResourceClaimRepository : IdentityResourceClaimRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public MysqlIdentityResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion
    }
}