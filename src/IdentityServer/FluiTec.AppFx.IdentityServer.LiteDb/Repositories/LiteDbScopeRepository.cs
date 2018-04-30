using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database scope repository. </summary>
    public class LiteDbScopeRepository : LiteDbIntegerRepository<ScopeEntity>, IScopeRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public IEnumerable<ScopeEntity> GetByIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.Id));
        }

        /// <summary>	Gets the names in this collection. </summary>
        /// <param name="names">	The names. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the names in this collection.
        /// </returns>
        public IEnumerable<ScopeEntity> GetByNames(string[] names)
        {
            return GetAll().Where(e => names.Contains(e.Name));
        }
    }
}