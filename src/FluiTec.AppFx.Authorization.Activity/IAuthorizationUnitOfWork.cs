using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity
{
    /// <summary>Interface for authorization unit of work.</summary>
    public interface IAuthorizationUnitOfWork : IUnitOfWork
    {
        /// <summary>Gets the activity repository.</summary>
        /// <value>The activity repository.</value>
        IActivityRepository ActivityRepository { get; }

        /// <summary>Gets the activity role repository.</summary>
        /// <value>The activity role repository.</value>
        IActivityRoleRepository ActivityRoleRepository { get; }
    }
}