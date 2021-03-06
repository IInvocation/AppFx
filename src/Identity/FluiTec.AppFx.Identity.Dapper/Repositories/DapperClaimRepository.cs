﻿using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Repositories
{
    /// <summary>	A dapper claim repository. </summary>
    public class DapperClaimRepository : DapperRepository<IdentityClaimEntity, int>, IClaimRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public DapperClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region IClaimRepository

        /// <summary>	Gets by user. </summary>
        /// <param name="user">	The user. </param>
        /// <returns>	The by user. </returns>
        public virtual IEnumerable<IdentityClaimEntity> GetByUser(IdentityUserEntity user)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(IdentityClaimEntity.UserId));
            return UnitOfWork.Connection.Query<IdentityClaimEntity>(command, new {UserId = user.Id},
                UnitOfWork.Transaction);
        }

        /// <summary>	Gets the user identifiers for claim types in this collection. </summary>
        /// <param name="claimType">	Type of the claim. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the user identifiers for claim types
        ///     in this collection.
        /// </returns>
        public virtual IEnumerable<int> GetUserIdsForClaimType(string claimType)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(IdentityClaimEntity.Type),
                new[] {nameof(IdentityClaimEntity.UserId)});
            return UnitOfWork.Connection.Query<int>(command, new {Type = claimType},
                UnitOfWork.Transaction);
        }

        /// <summary>	Gets by user and type. </summary>
        /// <param name="user">			The user. </param>
        /// <param name="claimType">	Type of the claim. </param>
        /// <returns>	The by user and type. </returns>
        public virtual IdentityClaimEntity GetByUserAndType(IdentityUserEntity user, string claimType)
        {
            var command = SqlBuilder.SelectByFilter(EntityType,
                new[] {nameof(IdentityClaimEntity.Type), nameof(IdentityClaimEntity.UserId)});
            return UnitOfWork.Connection.QuerySingleOrDefault<IdentityClaimEntity>(command,
                new {Type = claimType, UserId = user.Id},
                UnitOfWork.Transaction);
        }

        #endregion
    }
}