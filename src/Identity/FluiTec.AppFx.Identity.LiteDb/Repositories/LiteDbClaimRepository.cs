using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database claim repository.
    /// </summary>
    public class LiteDbClaimRepository : LiteDbIntegerRepository<IdentityClaimEntity>, IClaimRepository
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbClaimRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IClaimRepository

        /// <summary>
        ///     Gets by user.
        /// </summary>
        /// <param name="user"> The user. </param>
        /// <returns>
        ///     The by user.
        /// </returns>
        public IEnumerable<IdentityClaimEntity> GetByUser(IdentityUserEntity user)
        {
            return Collection.Find(e => e.UserId == user.Id);
        }

        /// <summary>
        ///     Gets the user identifiers for claim types in this collection.
        /// </summary>
        /// <param name="claimType">    Type of the claim. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the user identifiers for claim types
        ///     in this collection.
        /// </returns>
        public IEnumerable<int> GetUserIdsForClaimType(string claimType)
        {
            return Collection.Find(e => e.Type == claimType).Select(e => e.UserId);
        }

        /// <summary>
        ///     Gets by user and type.
        /// </summary>
        /// <param name="user">         The user. </param>
        /// <param name="claimType">    Type of the claim. </param>
        /// <returns>
        ///     The by user and type.
        /// </returns>
        public IdentityClaimEntity GetByUserAndType(IdentityUserEntity user, string claimType)
        {
            return Collection.Find(e => e.UserId == user.Id && e.Type == claimType).SingleOrDefault();
        }

        #endregion
    }
}