using System;
using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.IdentityServer.Dapper.Migration;
using FluiTec.AppFx.IdentityServer.Dapper.Mysql.Repositories;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Mysql
{
    /// <summary>	A Mysql dapper identity server data service. </summary>
    public class MysqlDapperIdentityServerDataService : MysqlDapperDataService, IIdentityServerDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        public MysqlDapperIdentityServerDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region IIdentityServerDataService

        /// <summary>	Starts unit of work. </summary>
        /// <returns>	An IIdentityServerUnitOfWork. </returns>
        public virtual IIdentityServerUnitOfWork StartUnitOfWork()
        {
            return new DapperIdentityServerUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IIdentityServerUnitOfWork.</returns>
        public virtual IIdentityServerUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}");
            return new DapperIdentityServerUnitOfWork(this, (DapperUnitOfWork)other);
        }

        #endregion

        #region Properties

        /// <summary>	Gets the name. </summary>
        /// <value>	The name. </value>
        public override string Name => "MysqlDapperIdentityServerDataService";

        /// <summary>Gets or sets information describing the meta.</summary>
        /// <value>Information describing the meta.</value>
        public override IVersionTableMetaData MetaData => new VersionTable();

        #endregion

        #region Methods

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IApiResourceClaimRepository>(work => new ApiResourceClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IApiResourceRepository>(work => new MysqlApiResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IApiResourceScopeRepository>(work => new MysqlApiResourceScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClientRepository>(work => new MysqlClientRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClientScopeRepository>(work => new MysqlClientScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IIdentityResourceClaimRepository>(work =>
                    new MysqlIdentityResourceClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IIdentityResourceRepository>(work => new MysqlIdentityResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IIdentityResourceScopeRepository>(work =>
                    new MysqlIdentityResourceScopeRepository(work)));
            RegisterRepositoryProvider(new Func<IUnitOfWork, IScopeRepository>(work => new MysqlScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClientClaimRepository>(work => new ClientClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, ISigningCredentialRepository>(work =>
                    new MysqlSigningCredentialRepository(work)));
            RegisterRepositoryProvider(new Func<IUnitOfWork, IGrantRepository>(work => new MysqlGrantRepository(work)));
        }

        #endregion
    }
}