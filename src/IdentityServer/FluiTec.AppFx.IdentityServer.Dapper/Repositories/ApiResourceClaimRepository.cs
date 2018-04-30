using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Repositories
{
    /// <summary>	An API resource claim repository. </summary>
    public class ApiResourceClaimRepository : DapperRepository<ApiResourceClaimEntity, int>,
        IApiResourceClaimRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public ApiResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the API identifiers in this collection. </summary>
        /// <param name="id">	The identifier. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the API identifiers in this
        ///     collection.
        /// </returns>
        public virtual IEnumerable<ApiResourceClaimEntity> GetByApiId(int id)
        {
            var command = SqlBuilder.SelectByFilter(EntityType,
                nameof(ApiResourceClaimEntity.ApiResourceId));
            return UnitOfWork.Connection.Query<ApiResourceClaimEntity>(command, new {ApiResourceId = id},
                UnitOfWork.Transaction);
        }
    }
}