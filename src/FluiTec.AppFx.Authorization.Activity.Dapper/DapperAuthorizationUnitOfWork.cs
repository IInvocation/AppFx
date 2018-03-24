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

        #endregion

        #region IAuthorizationUnitOfWork

        /// <summary>Gets the activity repository.</summary>
        /// <value>The activity repository.</value>
        public IActivityRepository ActivityRepository => _activityRepository ?? (_activityRepository = GetRepository<IActivityRepository>());

        #endregion
    }
}
