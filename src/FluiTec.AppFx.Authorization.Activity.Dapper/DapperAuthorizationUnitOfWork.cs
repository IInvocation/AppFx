using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Activity.Dapper
{
    /// <summary>A dapper authorization unit of work.</summary>
    public class DapperAuthorizationUnitOfWork : DapperUnitOfWork, IAuthorizationUnitOfWork
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public DapperAuthorizationUnitOfWork(DapperDataService dataService) : base(dataService)
        {
        }

        #endregion

        #region Fields

        /// <summary>The activity repository.</summary>
        private IActivityRepository _activityRepository;

        /// <summary>The activity role repository.</summary>
        private IActivityRoleRepository _activityRoleRepository;

        #endregion

        #region IAuthorizationUnitOfWork

        /// <summary>Gets the activity repository.</summary>
        /// <value>The activity repository.</value>
        public IActivityRepository ActivityRepository =>
            _activityRepository ?? (_activityRepository = GetRepository<IActivityRepository>());

        /// <summary>Gets or sets the activity role repository.</summary>
        /// <value>The activity role repository.</value>
        public IActivityRoleRepository ActivityRoleRepository =>
            _activityRoleRepository ?? (_activityRoleRepository = GetRepository<IActivityRoleRepository>());

        #endregion
    }
}