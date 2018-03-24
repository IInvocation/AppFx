using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Activity.LiteDb
{
    /// <summary>A lite database authorization unit of work.</summary>
    public class LiteDbAuthorizationUnitOfWork : LiteDbUnitOfWork, IAuthorizationUnitOfWork
    {
        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public LiteDbAuthorizationUnitOfWork(LiteDbDataService dataService) : base(dataService)
        {
        }

        #region Fields

        /// <summary>The activity repository.</summary>
        private IActivityRepository _activityRepository;

        #endregion

        #region IAuthorizationUnitOfWork

        /// <summary>Gets or sets the client repository.</summary>
        /// <value>The client repository.</value>
        public IActivityRepository ActivityRepository => _activityRepository ??
                                                     (_activityRepository = GetRepository<IActivityRepository>());

        #endregion
    }
}