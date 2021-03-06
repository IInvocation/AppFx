﻿using System.Collections.Generic;
using System.Linq;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Sql;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql.Repositories
{
    /// <summary>	A pgsql dapper role repository. </summary>
    public class PgsqlDapperRoleRepository : DapperRoleRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public PgsqlDapperRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Finds the identifiers in this collection. </summary>
        /// <param name="roleIds">	List of identifiers for the roles. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public override IEnumerable<IdentityRoleEntity> FindByIds(IEnumerable<int> roleIds)
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(IdentityRoleEntity)).ToArray())} FROM {TableName} WHERE \"{nameof(IdentityUserEntity.Id)}\" = ANY(@Ids)";
            return UnitOfWork.Connection.Query<IdentityRoleEntity>(command, new {Ids = roleIds.ToArray()},
                UnitOfWork.Transaction);
        }

        /// <summary>Finds the names in this collection.</summary>
        /// <param name="names">    The names. </param>
        /// <returns>An enumerator that allows foreach to be used to process the names in this collection.</returns>
        public override IEnumerable<IdentityRoleEntity> FindByNames(IEnumerable<string> names)
        {
            var command =
                $"{SqlBuilder.SelectAll(typeof(IdentityRoleEntity))} WHERE {nameof(IdentityUserEntity.Name)} IN @Names";
            return UnitOfWork.Connection.Query<IdentityRoleEntity>(command, new { Names = names },
                UnitOfWork.Transaction);
        }
    }
}