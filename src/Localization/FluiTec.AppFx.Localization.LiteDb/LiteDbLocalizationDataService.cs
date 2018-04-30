using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Localization.LiteDb.Repositories;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.LiteDb
{
    /// <summary>A lite database localization data service.</summary>
    public class LiteDbLocalizationDataService : LiteDbDataService, ILocalizationDataService
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public override string Name => "LiteDbLocalizationDataService";

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="useSingletonConnection">   True to use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbLocalizationDataService(bool useSingletonConnection, string dbFilePath,
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
        public LiteDbLocalizationDataService(ILiteDbServiceOptions options) : base(options)
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
        public ILocalizationUnitOfWork StartUnitOfWork()
        {
            return new LiteDbLocalizationUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An ILocalizationUnitOfWork.</returns>
        public ILocalizationUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}");
            return new LiteDbLocalizationUnitOfWork(this, (LiteDbUnitOfWork)other);
        }

        /// <summary>
        ///     Begins unit of work.
        /// </summary>
        /// <returns>
        ///     An IUnitOfWork.
        /// </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbLocalizationUnitOfWork(this);
        }

        /// <summary>
        ///     Registers the repository providers.
        /// </summary>
        protected virtual void RegisterRepositoryProviders()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IResourceRepository>(work => new LiteDbResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, ITranslationRepository>(work => new LiteDbTranslationRepository(work)));
        }

        #endregion
    }
}