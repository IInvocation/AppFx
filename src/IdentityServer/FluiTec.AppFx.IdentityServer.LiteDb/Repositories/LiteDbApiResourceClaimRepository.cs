using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database API resource claim repository.
    /// </summary>
    public class LiteDbApiResourceClaimRepository : LiteDbIntegerRepository<ApiResourceClaimEntity>,
        IApiResourceClaimRepository
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbApiResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        ///     Gets the api identifiers in this collection.
        /// </summary>
        /// <param name="id">   The identifier. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<ApiResourceClaimEntity> GetByApiId(int id)
        {
            return Collection.Find(e => e.ApiResourceId == id);
        }
    }
}