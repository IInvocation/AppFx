using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Authorization.Activity.Repositories
{
    /// <summary>Interface for activity role repository.</summary>
    public interface IActivityRoleRepository : IDataRepository<ActivityRoleEntity, int>
    {
        /// <summary>Enumerates by activity in this collection.</summary>
        /// <param name="entity">   The entity. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by activity in this
        ///     collection.
        /// </returns>
        IEnumerable<ActivityRoleEntity> ByActivity(ActivityEntity entity);

        /// <summary>   Enumerates by role in this collection. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by role in this collection.
        /// </returns>
        IEnumerable<ActivityRoleEntity> ByRole(int roleId);
    }
}