using System;
using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.Authorization.Activity.Dapper.Migration;
using FluiTec.AppFx.Authorization.Activity.Dapper.Repositories;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Mysql
{
    /// <summary>A mysql dapper authorization data service.</summary>
    public class MysqlDapperAuthorizationDataService : MysqlDapperDataService, IAuthorizationDataService
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public MysqlDapperAuthorizationDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "MysqlDapperAuthorizationDataService";

        /// <summary>Gets or sets information describing the meta.</summary>
        /// <value>Information describing the meta.</value>
        public override IVersionTableMetaData MetaData => new VersionTable();

        #endregion

        #region Methods

        /// <summary>Starts unit of work.</summary>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IAuthorizationUnitOfWork StartUnitOfWork()
        {
            return new DapperAuthorizationUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IAuthorizationUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}");
            return new DapperAuthorizationUnitOfWork(this, (DapperUnitOfWork)other);
        }

        /// <summary>Registers the identity repositories.</summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActivityRepository>(work => new DapperActivityRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActivityRoleRepository>(work => new DapperActivityRoleRepository(work)));
        }

        #endregion
    }
}