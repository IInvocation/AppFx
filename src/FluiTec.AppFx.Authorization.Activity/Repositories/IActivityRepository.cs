using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity.Repositories
{
    /// <summary>Interface for activity repository.</summary>
    public interface IActivityRepository : IDataRepository<ActivityEntity, int>
    {
        /// <summary>Gets by resource and activity.</summary>
        /// <param name="resourceName"> Name of the resource. </param>
        /// <param name="activityName"> Name of the activity. </param>
        /// <returns>The by resource and activity.</returns>
        ActivityEntity GetByResourceAndActivity(string resourceName, string activityName);
    }
}