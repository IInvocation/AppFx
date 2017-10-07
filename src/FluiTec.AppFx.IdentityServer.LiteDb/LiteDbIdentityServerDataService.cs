using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.IdentityServer.LiteDb
{
    /// <summary>
    /// A lite database identity server data service.
    /// </summary>
    public class LiteDbIdentityServerDataService : LiteDbDataService, IIdentityServerDataService
    {
        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="useSingletonConnection">   True to use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbIdentityServerDataService(bool useSingletonConnection, string dbFilePath, string applicationFolder = null) 
            : this(new LiteDbServiceOptions { UseSingletonConnection = useSingletonConnection, ApplicationFolder = applicationFolder, DbFileName = dbFilePath})
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        ///
        /// <param name="options">  Options for controlling the operation. </param>
        public LiteDbIdentityServerDataService(ILiteDbServiceOptions options) : base(options)
        {
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        ///
        /// <value>
        /// The name.
        /// </value>
        public override string Name => "LiteDbIdentityServerDataService";

        #endregion

        #region Methods

        /// <summary>
        /// Starts unit of work.
        /// </summary>
        ///
        /// <returns>
        /// An IIdentityServerUnitOfWork.
        /// </returns>
        public IIdentityServerUnitOfWork StartUnitOfWork()
        {
            return new LiteDbIdentityServerUnitOfWork(this);
        }

        /// <summary>
        /// Begins unit of work.
        /// </summary>
        ///
        /// <returns>
        /// An IUnitOfWork.
        /// </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbIdentityServerUnitOfWork(this);
        }

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
