using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Dapper.Repositories
{
    /// <summary>A resource repository.</summary>
    public abstract class ResourceRepository : DapperRepository<ResourceEntity, int>, IResourceRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        protected ResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>Gets by key.</summary>
        /// <param name="key">  The key. </param>
        /// <returns>The by key.</returns>
        public virtual ResourceEntity GetByKey(string key)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(ResourceEntity.ResourceKey));
            return UnitOfWork.Connection.QuerySingleOrDefault<ResourceEntity>(command, new { Key = key },
                UnitOfWork.Transaction);
        }

        /// <summary>Resets the synchronise status.</summary>
        public abstract void ResetSyncStatus();

        /// <summary>Refactor key.</summary>
        /// <param name="oldKey">   The old key. </param>
        /// <param name="newKey">   The new key. </param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public abstract bool RefactorKey(string oldKey, string newKey);
    }
}