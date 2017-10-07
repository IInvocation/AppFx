using System;
using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database user login repository.
    /// </summary>
    public class LiteDbUserLoginRepository : LiteDbIntegerRepository<IdentityUserLoginEntity>, IUserLoginRepository
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbUserLoginRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IUserLoginRepository

        /// <summary>
        ///     Removes the by name and key.
        /// </summary>
        /// <param name="providerName"> Name of the provider. </param>
        /// <param name="providerKey">  The provider key. </param>
        public void RemoveByNameAndKey(string providerName, string providerKey)
        {
            Collection.Delete(e => e.ProviderName == providerName && e.ProviderKey == providerKey);
        }

        /// <summary>
        ///     Finds the user identifiers in this collection.
        /// </summary>
        /// <param name="userId">   Identifier for the user. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the user identifiers in this
        ///     collection.
        /// </returns>
        public IEnumerable<IdentityUserLoginEntity> FindByUserId(Guid userId)
        {
            return Collection.Find(e => e.UserId == userId);
        }

        /// <summary>
        ///     Searches for the first name and key.
        /// </summary>
        /// <param name="providerName"> Name of the provider. </param>
        /// <param name="providerKey">  The provider key. </param>
        /// <returns>
        ///     The found name and key.
        /// </returns>
        public IdentityUserLoginEntity FindByNameAndKey(string providerName, string providerKey)
        {
            return Collection.Find(e => e.ProviderName == providerName && e.ProviderKey == providerKey)
                .SingleOrDefault();
        }

        #endregion
    }
}