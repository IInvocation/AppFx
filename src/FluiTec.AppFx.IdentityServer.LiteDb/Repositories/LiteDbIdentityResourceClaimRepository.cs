using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database identity resource claim repository. </summary>
    public class LiteDbIdentityResourceClaimRepository : LiteDbIntegerRepository<IdentityResourceClaimEntity>,
        IIdentityResourceClaimRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbIdentityResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the identity identifiers in this collection. </summary>
        /// <param name="id">	The identifier. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<IdentityResourceClaimEntity> GetByIdentityId(int id)
        {
            return Collection.Find(e => e.IdentityResourceId == id);
        }
    }
}