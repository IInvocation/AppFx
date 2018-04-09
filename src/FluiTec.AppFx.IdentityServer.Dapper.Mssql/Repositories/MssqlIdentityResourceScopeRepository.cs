using System.Collections.Generic;
using System.Linq;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Sql;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;
using FluiTec.AppFx.IdentityServer.Entities;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mssql.Repositories
{
    /// <summary>	A mssql identity resource scope repository. </summary>
    public class MssqlIdentityResourceScopeRepository : IdentityResourceScopeRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public MssqlIdentityResourceScopeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the identity identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        public override IEnumerable<IdentityResourceScopeEntity> GetByIdentityIds(int[] ids)
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(IdentityResourceScopeEntity)).ToArray())} FROM {TableName} WHERE {nameof(IdentityResourceScopeEntity.IdentityResourceId)} IN @Ids";
            return UnitOfWork.Connection.Query<IdentityResourceScopeEntity>(command, new {Ids = ids},
                UnitOfWork.Transaction);
        }

        /// <summary>	Gets the scope identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope identifiers in this
        ///     collection.
        /// </returns>
        public override IEnumerable<IdentityResourceScopeEntity> GetByScopeIds(int[] ids)
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(IdentityResourceScopeEntity)).ToArray())} FROM {TableName} WHERE {nameof(IdentityResourceScopeEntity.ScopeId)} IN @Ids";
            return UnitOfWork.Connection.Query<IdentityResourceScopeEntity>(command, new {Ids = ids},
                UnitOfWork.Transaction);
        }
    }
}