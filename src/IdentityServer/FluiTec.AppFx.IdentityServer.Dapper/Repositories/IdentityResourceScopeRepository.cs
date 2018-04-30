using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Repositories
{
    /// <summary>	An identity resource scope repository. </summary>
    public abstract class IdentityResourceScopeRepository : DapperRepository<IdentityResourceScopeEntity, int>,
        IIdentityResourceScopeRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        protected IdentityResourceScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the identity identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        public abstract IEnumerable<IdentityResourceScopeEntity> GetByIdentityIds(int[] ids);

        /// <summary>	Gets the scope identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope identifiers in this
        ///     collection.
        /// </returns>
        public abstract IEnumerable<IdentityResourceScopeEntity> GetByScopeIds(int[] ids);
    }
}