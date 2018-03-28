using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Localization.Dapper.Repositories;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Pgsql.Repositories
{
    /// <summary>A mysql dapper resource repository.</summary>
    public class PgsqlDapperResourceRepository : ResourceRepository, IResourceRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="work"> The work. </param>
        public PgsqlDapperResourceRepository(IUnitOfWork work) : base(work)
        {
        }

        /// <summary>Resets the synchronise status.</summary>
        public override void ResetSyncStatus()
        {
            var command = $"UPDATE {TableName} SET {nameof(ResourceEntity.FromCode)} = @FromCode";
            UnitOfWork.Connection.Execute(command, new {FromCode = false}, UnitOfWork.Transaction);
        }

        /// <summary>Refactor key.</summary>
        /// <param name="oldKey">   The old key. </param>
        /// <param name="newKey">   The new key. </param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public override bool RefactorKey(string oldKey, string newKey)
        {
            var command =
                $"UPDATE {TableName} SET {nameof(ResourceEntity.ResourceKey)} @NewKey WHERE {nameof(ResourceEntity.ResourceKey)} = @OldKey";
            return UnitOfWork.Connection.Execute(command, new {NewKey = newKey, OldKey = oldKey},
                       UnitOfWork.Transaction) > 0;
        }
    }
}