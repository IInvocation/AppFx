using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql.Repositories
{
    /// <summary>	A Mysql client scope repository. </summary>
    public class MysqlClientScopeRepository : ClientScopeRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public MysqlClientScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion
    }
}