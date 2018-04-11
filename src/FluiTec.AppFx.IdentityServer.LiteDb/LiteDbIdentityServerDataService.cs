using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.LiteDb.Repositories;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb
{
    /// <summary>
    ///     A lite database identity server data service.
    /// </summary>
    public class LiteDbIdentityServerDataService : LiteDbDataService, IIdentityServerDataService
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public override string Name => "LiteDbIdentityServerDataService";

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="useSingletonConnection">   True to use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbIdentityServerDataService(bool useSingletonConnection, string dbFilePath,
            string applicationFolder = null)
            : this(new LiteDbServiceOptions
            {
                UseSingletonConnection = useSingletonConnection,
                ApplicationFolder = applicationFolder,
                DbFileName = dbFilePath
            })
        {
        }

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public LiteDbIdentityServerDataService(ILiteDbServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Starts unit of work.
        /// </summary>
        /// <returns>
        ///     An IIdentityServerUnitOfWork.
        /// </returns>
        public IIdentityServerUnitOfWork StartUnitOfWork()
        {
            return new LiteDbIdentityServerUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IIdentityServerUnitOfWork.</returns>
        public IIdentityServerUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}");
            return new LiteDbIdentityServerUnitOfWork(this, (LiteDbUnitOfWork)other);
        }

        /// <summary>
        ///     Begins unit of work.
        /// </summary>
        /// <returns>
        ///     An IUnitOfWork.
        /// </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbIdentityServerUnitOfWork(this);
        }

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IApiResourceClaimRepository>(work => new LiteDbApiResourceClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IApiResourceRepository>(work => new LiteDbApiResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IApiResourceScopeRepository>(work => new LiteDbApiResourceScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClientRepository>(work => new LiteDbClientRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClientScopeRepository>(work => new LiteDbClientScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IIdentityResourceClaimRepository>(work =>
                    new LiteDbIdentityResourceClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IIdentityResourceRepository>(work => new LiteDbIdentityResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IIdentityResourceScopeRepository>(work =>
                    new LiteDbIdentityResourceScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IScopeRepository>(work => new LiteDbScopeRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClientClaimRepository>(work => new LiteDbClientClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, ISigningCredentialRepository>(work =>
                    new LiteDbSigningCredentialRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IGrantRepository>(work => new LiteDbGrantRepository(work)));
        }

        #endregion
    }
}