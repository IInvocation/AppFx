using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity.Repositories
{
    /// <summary>Interface for activity repository.</summary>
    public interface IActivityRepository : IDataRepository<ActivityEntity, int>
    {
    }
}