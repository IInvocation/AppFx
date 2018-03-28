using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Repositories
{
    /// <summary>	An identity resource claim repository. </summary>
    public abstract class IdentityResourceClaimRepository : DapperRepository<IdentityResourceClaimEntity, int>,
        IIdentityResourceClaimRepository
    {
        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        protected IdentityResourceClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets the identity identifiers in this collection. </summary>
        /// <param name="id">	The identifier. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identity identifiers in this
        ///     collection.
        /// </returns>
        public virtual IEnumerable<IdentityResourceClaimEntity> GetByIdentityId(int id)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(IdentityResourceClaimEntity.IdentityResourceId));
            return UnitOfWork.Connection.Query<IdentityResourceClaimEntity>(command, new {IdentityResourceId = id},
                UnitOfWork.Transaction);
        }
    }
}