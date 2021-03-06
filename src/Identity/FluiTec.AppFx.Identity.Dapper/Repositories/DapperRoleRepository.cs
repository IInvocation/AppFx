﻿using System;
using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Repositories
{
    /// <summary>	A dapper role repository. </summary>
    public abstract class DapperRoleRepository : DapperRepository<IdentityRoleEntity, int>, IRoleRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        protected DapperRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets an identity role entity using the given identifier. </summary>
        /// <param name="identifier">	The identifier to get. </param>
        /// <returns>	An IdentityRoleEntity. </returns>
        public virtual IdentityRoleEntity Get(string identifier)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(IdentityRoleEntity.Identifier));
            return UnitOfWork.Connection.QuerySingleOrDefault<IdentityRoleEntity>(command,
                new {Identifier = Guid.Parse(identifier)},
                UnitOfWork.Transaction);
        }

        /// <summary>	Searches for the first lowered name. </summary>
        /// <param name="normalizedName">	Name of the lowered. </param>
        /// <returns>	The found lowered name. </returns>
        public virtual IdentityRoleEntity FindByLoweredName(string normalizedName)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(IdentityRoleEntity.NormalizedName));
            return UnitOfWork.Connection.QuerySingleOrDefault<IdentityRoleEntity>(command,
                new {NormalizedName = normalizedName},
                UnitOfWork.Transaction);
        }

        /// <summary>	Finds the identifiers in this collection. </summary>
        /// <param name="roleIds">	List of identifiers for the roles. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public abstract IEnumerable<IdentityRoleEntity> FindByIds(IEnumerable<int> roleIds);

        /// <summary>Finds the names in this collection.</summary>
        /// <param name="names">    The names. </param>
        /// <returns>An enumerator that allows foreach to be used to process the names in this collection.</returns>
        public abstract IEnumerable<IdentityRoleEntity> FindByNames(IEnumerable<string> names);
    }
}