using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Entities;

namespace FluiTec.AppFx.IdentityServer.Repositories
{
    /// <summary>	Interface for identity resource scope repository. </summary>
    public interface IIdentityResourceScopeRepository : IDataRepository<IdentityResourceScopeEntity, int>
    {
        /// <summary>	Gets the identity identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        IEnumerable<IdentityResourceScopeEntity> GetByIdentityIds(int[] ids);

        /// <summary>	Gets the scope identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope identifiers in this
        ///     collection.
        /// </returns>
        IEnumerable<IdentityResourceScopeEntity> GetByScopeIds(int[] ids);
    }
}