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
    ///     A lite database role repository.
    /// </summary>
    public class LiteDbRoleRepository : LiteDbIntegerRepository<IdentityRoleEntity>, IRoleRepository
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IRoleRepository

        /// <summary>
        ///     Gets an identity role entity using the given identifier.
        /// </summary>
        /// <param name="identifier">   The identifier to get. </param>
        /// <returns>
        ///     An IdentityRoleEntity.
        /// </returns>
        public IdentityRoleEntity Get(string identifier)
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
        public IdentityRoleEntity FindByLoweredName(string loweredName)
        {
            return Collection.Find(e => e.NormalizedName == loweredName).SingleOrDefault();
        }

        /// <summary>
        ///     Finds the identifiers in this collection.
        /// </summary>
        /// <param name="roleIds">  List of identifiers for the roles. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public IEnumerable<IdentityRoleEntity> FindByIds(IEnumerable<int> roleIds)
        {
            return GetAll().Where(e => roleIds.Contains(e.Id));
        }

        #endregion
    }
}