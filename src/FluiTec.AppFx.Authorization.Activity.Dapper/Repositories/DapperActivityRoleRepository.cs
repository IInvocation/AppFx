using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Repositories
{
    /// <summary>A dapper activity role repository.</summary>
    public class DapperActivityRoleRepository : DapperRepository<ActivityRoleEntity, int>, IActivityRoleRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperActivityRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
            var command = $"SELECT * FROM {TableName} WHERE {nameof(ActivityRoleEntity.ActivityId)} = @ActivityId";
            return UnitOfWork.Connection.Query<ActivityRoleEntity>(command, new {ActivityId = entity.Id},
                UnitOfWork.Transaction);
        }

        /// <summary>   Enumerates by role in this collection. </summary>
        /// <param name="roleId">   Identifier for the role. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by role in this collection.
        /// </returns>
        public IEnumerable<ActivityRoleEntity> ByRole(int roleId)
        {
            var command = $"SELECT * FROM {TableName} WHERE {nameof(ActivityRoleEntity.RoleId)} = @RoleId";
            return UnitOfWork.Connection.Query<ActivityRoleEntity>(command, new { RoleId = roleId },
                UnitOfWork.Transaction);
        }
    }
}