using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Localization.Dapper.Repositories;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Mssql.Repositories
{
    /// <summary>A mssql dapper resource repository.</summary>
    public class MssqlDapperResourceRepository : ResourceRepository, IResourceRepository
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public MssqlDapperResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IResourceRepository

        /// <summary>Refactor key.</summary>
        /// <param name="oldKey">   The old key. </param>
        /// <param name="newKey">   The new key. </param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public override bool RefactorKey(string oldKey, string newKey)
        {
            var command = $"UPDATE {TableName} SET {nameof(ResourceEntity.ResourceKey)} @NewKey WHERE {nameof(ResourceEntity.ResourceKey)} = @OldKey";
            return UnitOfWork.Connection.Execute(command, new {NewKey = newKey, OldKey = oldKey}, UnitOfWork.Transaction) > 0;
        }

        /// <summary>Resets the synchronise status.</summary>
        public override void ResetSyncStatus()
        {
            var command = $"UPDATE {TableName} SET {nameof(ResourceEntity.FromCode)} = @FromCode";
            UnitOfWork.Connection.Execute(command, new { FromCode = false }, UnitOfWork.Transaction);
        }

        #endregion
    }
}