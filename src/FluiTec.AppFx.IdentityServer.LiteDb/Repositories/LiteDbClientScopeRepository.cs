using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database client scope repository. </summary>
    public class LiteDbClientScopeRepository : LiteDbIntegerRepository<ClientScopeEntity>, IClientScopeRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbClientScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the client identifiers in this collection. </summary>
        /// <param name="id">	The identifier. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the client identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<ClientScopeEntity> GetByClientId(int id)
        {
            return Collection.Find(e => e.ClientId == id);
        }
    }
}