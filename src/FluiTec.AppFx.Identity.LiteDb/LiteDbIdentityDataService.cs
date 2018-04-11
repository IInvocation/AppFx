using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Identity.LiteDb.Repositories;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.LiteDb
{
    /// <summary>
    ///     A lite database identity data service.
    /// </summary>
    public class LiteDbIdentityDataService : LiteDbDataService, IIdentityDataService
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public override string Name => "LiteDbIdentityDataService";

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="useSingletonConnection">   True to use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbIdentityDataService(bool useSingletonConnection, string dbFilePath,
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
        public LiteDbIdentityDataService(ILiteDbServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterRepositoryProviders();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Starts unit of work.
        /// </summary>
        /// <returns>
        ///     An IIdentityUnitOfWork.
        /// </returns>
        public IIdentityUnitOfWork StartUnitOfWork()
        {
            return new LiteDbIdentityUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IIdentityUnitOfWork.</returns>
        public IIdentityUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}");
            return new LiteDbIdentityUnitOfWork(this, (LiteDbUnitOfWork)other);
        }

        /// <summary>
        ///     Begins unit of work.
        /// </summary>
        /// <returns>
        ///     An IUnitOfWork.
        /// </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbIdentityUnitOfWork(this);
        }

        /// <summary>
        ///     Registers the repository providers.
        /// </summary>
        protected virtual void RegisterRepositoryProviders()
        {
            RegisterRepositoryProvider(new Func<IUnitOfWork, IUserRepository>(work => new LiteDbUserRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClaimRepository>(work => new LiteDbClaimRepository(work)));
            RegisterRepositoryProvider(new Func<IUnitOfWork, IRoleRepository>(work => new LiteDbRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserRoleRepository>(work => new LiteDbUserRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserLoginRepository>(work => new LiteDbUserLoginRepository(work)));
        }

        #endregion
    }
}