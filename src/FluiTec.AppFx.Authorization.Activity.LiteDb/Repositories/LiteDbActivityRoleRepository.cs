using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Activity.LiteDb.Repositories
{
    /// <summary>A lite database activity role repository.</summary>
    public class LiteDbActivityRoleRepository : LiteDbIntegerRepository<ActivityRoleEntity>, IActivityRoleRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbActivityRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>Enumerates by activity in this collection.</summary>
        /// <param name="entity">   The entity. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by activity in this
        ///     collection.
        /// </returns>
        public IEnumerable<ActivityRoleEntity> ByActivity(ActivityEntity entity)
        {
            return Collection.Find(e => e.ActivityId == entity.Id);
        }
    }
}