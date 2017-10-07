using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database user role repository.
    /// </summary>
    public class LiteDbUserRoleRepository : LiteDbIntegerRepository<IdentityUserRoleEntity>, IUserRoleRepository
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbUserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IUserRoleRepository

        /// <summary>
        ///     Searches for the first user identifier and role identifier.
        /// </summary>
        /// <param name="userId">   Identifier for the user. </param>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>
        ///     The found user identifier and role identifier.
        /// </returns>
        public IdentityUserRoleEntity FindByUserIdAndRoleId(int userId, int roleId)
        {
            return Collection.Find(e => e.UserId == userId && e.RoleId == roleId).SingleOrDefault();
        }

        /// <summary>
        ///     Searches for the first user.
        /// </summary>
        /// <param name="user"> The user. </param>
        /// <returns>
        ///     The found user.
        /// </returns>
        public IEnumerable<int> FindByUser(IdentityUserEntity user)
        {
            return Collection.Find(e => e.UserId == user.Id).Select(e => e.RoleId);
        }

        /// <summary>
        ///     Finds the roles in this collection.
        /// </summary>
        /// <param name="role"> The role. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the roles in this collection.
        /// </returns>
        public IEnumerable<int> FindByRole(IdentityRoleEntity role)
        {
            return Collection.Find(e => e.RoleId == role.Id).Select(e => e.UserId);
        }

        #endregion
    }
}