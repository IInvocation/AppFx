using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database identity resource scope repository. </summary>
    public class LiteDbIdentityResourceScopeRepository : LiteDbIntegerRepository<IdentityResourceScopeEntity>,
        IIdentityResourceScopeRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbIdentityResourceScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the identity identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<IdentityResourceScopeEntity> GetByIdentityIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.IdentityResourceId));
        }

        /// <summary>	Gets the scope identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<IdentityResourceScopeEntity> GetByScopeIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.ScopeId));
        }
    }
}