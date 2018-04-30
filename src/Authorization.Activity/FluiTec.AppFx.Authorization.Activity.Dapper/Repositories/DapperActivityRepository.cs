using System.Linq;
using Dapper;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Repositories
{
    /// <summary>A dapper activity repository.</summary>
    public class DapperActivityRepository : DapperRepository<ActivityEntity, int>, IActivityRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperActivityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>Gets by resource and activity.</summary>
        /// <param name="resourceName"> Name of the resource. </param>
        /// <param name="activityName"> Name of the activity. </param>
        /// <returns>The by resource and activity.</returns>
        public ActivityEntity GetByResourceAndActivity(string resourceName, string activityName)
        {
            var command =
                $"SELECT * FROM {TableName} WHERE {nameof(ActivityEntity.ResourceName)} = @ResourceName AND {nameof(ActivityEntity.Name)} = @Name";
            return UnitOfWork.Connection.Query<ActivityEntity>(command,
                new {ResourceName = resourceName, Name = activityName},
                UnitOfWork.Transaction).SingleOrDefault();
        }
    }
}