using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database client claim repository.
    /// </summary>
    public class LiteDbClientClaimRepository : LiteDbIntegerRepository<ClientClaimEntity>, IClientClaimRepository
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbClientClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}