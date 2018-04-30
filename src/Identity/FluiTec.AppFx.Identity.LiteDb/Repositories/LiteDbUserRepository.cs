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
    ///     A lite database user repository.
    /// </summary>
    public class LiteDbUserRepository : LiteDbIntegerRepository<IdentityUserEntity>, IUserRepository
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IUserRepository

        /// <summary>
        ///     Gets an identity user entity using the given identifier.
        /// </summary>
        /// <param name="identifier">   The identifier to get. </param>
        /// <returns>
        ///     An IdentityUserEntity.
        /// </returns>
        public IdentityUserEntity Get(string identifier)
        {
            var id = Guid.Parse(identifier);
            return Collection.Find(e => e.Identifier == id).SingleOrDefault();
        }

        /// <summary>
        ///     Searches for the first lowered name.
        /// </summary>
        /// <param name="loweredName">  Name of the lowered. </param>
        /// <returns>
        ///     The found lowered name.
        /// </returns>
        public IdentityUserEntity FindByLoweredName(string loweredName)
        {
            return Collection.Find(e => e.NormalizedName == loweredName).SingleOrDefault();
        }

        /// <summary>
        ///     Searches for the first normalized email.
        /// </summary>
        /// <param name="normalizedEmail">  The normalized email. </param>
        /// <returns>
        ///     The found normalized email.
        /// </returns>
        public IdentityUserEntity FindByNormalizedEmail(string normalizedEmail)
        {
            return Collection.Find(e => e.NormalizedEmail == normalizedEmail).SingleOrDefault();
        }

        /// <summary>
        ///     Finds the identifiers in this collection.
        /// </summary>
        /// <param name="userIds">  List of identifiers for the users. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public IEnumerable<IdentityUserEntity> FindByIds(IEnumerable<int> userIds)
        {
            return Collection.Find(e => userIds.Contains(e.Id));
        }

        /// <summary>
        ///     Searches for the first login.
        /// </summary>
        /// <param name="providerName"> Name of the provider. </param>
        /// <param name="providerKey">  The provider key. </param>
        /// <returns>
        ///     The found login.
        /// </returns>
        public IdentityUserEntity FindByLogin(string providerName, string providerKey)
        {
            var login = UnitOfWork.GetRepository<IUserLoginRepository>()
                .FindByNameAndKey(providerName, providerKey);
            return Get(login.UserId.ToString());
        }

        #endregion
    }
}