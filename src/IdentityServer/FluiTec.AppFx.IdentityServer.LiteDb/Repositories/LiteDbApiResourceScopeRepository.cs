using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database API resource scope repository.
    /// </summary>
    public class LiteDbApiResourceScopeRepository : LiteDbIntegerRepository<ApiResourceScopeEntity>,
        IApiResourceScopeRepository
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbApiResourceScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        ///     Gets the identifiers in this collection.
        /// </summary>
        /// <param name="ids">  The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public IEnumerable<ApiResourceScopeEntity> GetByScopeIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.ScopeId));
        }

        /// <summary>
        ///     Gets the API identifiers in this collection.
        /// </summary>
        /// <param name="ids">  The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the API identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<ApiResourceScopeEntity> GetByApiIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.ApiResourceId));
        }
    }
}