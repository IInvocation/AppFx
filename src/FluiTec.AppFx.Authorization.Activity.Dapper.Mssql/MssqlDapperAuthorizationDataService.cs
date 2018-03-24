using System;
using FluiTec.AppFx.Authorization.Activity.Dapper.Repositories;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Mssql
{
    /// <summary>A mssql dapper authorization data service.</summary>
    public class MssqlDapperAuthorizationDataService : MssqlDapperDataService, IAuthorizationDataService
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public MssqlDapperAuthorizationDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "MssqlDapperAuthorizationDataService";

        #endregion

        #region Methods

        /// <summary>Starts unit of work.</summary>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IAuthorizationUnitOfWork StartUnitOfWork()
        {
            return new DapperAuthorizationUnitOfWork(this);
        }

        /// <summary>Registers the identity repositories.</summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(new Func<IUnitOfWork, IActivityRepository>(work => new DapperActivityRepository(work)));
        }

        #endregion
    }
}
