using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.LiteDb.Repositories
{
    /// <summary>A lite database resource repository.</summary>
    public class LiteDbResourceRepository : LiteDbIntegerRepository<ResourceEntity>, IResourceRepository
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IResourceRepository

        /// <summary>Gets the names in this collection.</summary>
        /// <param name="name"> The name. </param>
        /// <returns>An enumerator that allows foreach to be used to process the names in this collection.</returns>
        public IEnumerable<ResourceEntity> GetByName(string name)
        {
            return Collection.Find(e => e.Name == name);
        }

        #endregion
    }
}