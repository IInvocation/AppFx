using System;
using FluiTec.AppFx.Authorization.Activity.Dapper.Repositories;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Pgsql
{
    /// <summary>A pgsql dapper authorization data service.</summary>
    public class PgsqlDapperAuthorizationDataService : PgsqlDapperDataService, IAuthorizationDataService
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public PgsqlDapperAuthorizationDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "PgsqlDapperAuthorizationDataService";

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
            RegisterRepositoryProvider(new Func<IUnitOfWork, IActivityRoleRepository>(work => new DapperActivityRoleRepository(work)));
        }

        #endregion
    }
}
