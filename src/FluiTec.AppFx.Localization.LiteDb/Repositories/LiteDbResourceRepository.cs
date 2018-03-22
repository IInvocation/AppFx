using System.Linq;
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

        /// <summary>   Gets by key. </summary>
        /// <param name="key">  The key. </param>
        /// <returns>   The by key. </returns>
        public ResourceEntity GetByKey(string key)
        {
            return Collection.Find(e => e.Key == key).SingleOrDefault();
        }

        /// <summary>   Resets the synchronise status. </summary>
        public void ResetSyncStatus()
        {
            foreach (var entity in Collection.FindAll())
                entity.FromCode = false;
        }

        /// <summary>Refactor key.</summary>
        /// <param name="oldKey">   The old key. </param>
        /// <param name="newKey">   The new key. </param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool RefactorKey(string oldKey, string newKey)
        {
            var entity = GetByKey(oldKey);
            if (entity == null) return false;

            entity.Key = newKey;
            entity.FromCode = true;
            Update(entity);
            return true;
        }

        #endregion
    }
}