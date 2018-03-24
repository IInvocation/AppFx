using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity.Repositories
{
    /// <summary>Interface for activity role repository.</summary>
    public interface IActivityRoleRepository : IDataRepository<ActivityRoleEntity, int>
    {
        /// <summary>Enumerates by activity in this collection.</summary>
        /// <param name="entity">   The entity. </param>
        /// <returns>An enumerator that allows foreach to be used to process by activity in this
        /// collection.</returns>
        IEnumerable<ActivityRoleEntity> ByActivity(ActivityEntity entity);
    }
}