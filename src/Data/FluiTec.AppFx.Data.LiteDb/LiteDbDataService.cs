using System;
using System.IO;
using System.Runtime.InteropServices;
using LiteDB;

namespace FluiTec.AppFx.Data.LiteDb
{
    /// <summary>	A litedb data service. </summary>
    public abstract class LiteDbDataService : DataService
    {
        #region Fields

        /// <summary>	Gets a value indicating whether this object use singleton connection. </summary>
        /// <value>	True if use singleton connection, false if not. </value>
        private readonly bool _useSingletonConnection;

        #endregion

        #region IDataService

        /// <summary>	Begins unit of work. </summary>
        /// <returns>	An IUnitOfWork. </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbUnitOfWork(this);
        }

        /// <summary>Begins unit of work.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="other">    The other. </param>
        /// <returns>An IUnitOfWork.</returns>
        public override IUnitOfWork BeginUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork))
                throw new ArgumentException(
                    $"Incompatible implementation of UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}!");
            return new LiteDbUnitOfWork(this, (LiteDbUnitOfWork)other);
        }

        #endregion

        #region Methods

        /// <summary>	Gets the filename of the construct application data database file. </summary>
        /// <exception cref="NotSupportedException">
        ///     Thrown when the requested operation is not
        ///     supported.
        /// </exception>
        /// <param name="applicationFolder">	Pathname of the application folder. </param>
        /// <param name="fileName">				Filename of the file. </param>
        /// <returns>	The filename of the construct application data database file. </returns>
        protected virtual string ConstructAppDataDbFileName(string applicationFolder, string fileName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var appData = Environment.GetEnvironmentVariable("LocalAppData");
                return Path.Combine(appData, applicationFolder, fileName);
            }

            // reason: leave open for os x
            // ReSharper disable once InvertIf
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var appData = Environment.GetEnvironmentVariable("user.home");
                return Path.Combine(appData, applicationFolder, fileName);
            }

            // TODO: Implement method for os x

            throw new NotSupportedException("Operating-System is not supported.");
        }

        #endregion

        #region Properties

        /// <summary>	Gets or sets the database. </summary>
        /// <value>	The database. </value>
        public LiteDatabase Database { get; private set; }

        /// <summary>	Gets the name service. </summary>
        /// <value>	The name service. </value>
        public virtual IEntityNameService NameService { get; }

        #endregion

        #region Constructors

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <remarks>
        ///     If dbFilePath isnt rooted or doesnt start with a dot - an applicationFolder is required,
        ///     because the service will save in local-appdata.
        /// </remarks>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when one or more arguments have unsupported or
        ///     illegal values.
        /// </exception>
        /// <param name="useSingletonConnection">	True to use singleton connection. </param>
        /// <param name="dbFilePath">			 	Full pathname of the database file. </param>
        /// <param name="applicationFolder">	 	(Optional) Pathname of the application folder. </param>
        protected LiteDbDataService(bool? useSingletonConnection, string dbFilePath, string applicationFolder = null)
        {
            if (string.IsNullOrWhiteSpace(dbFilePath)) throw new ArgumentNullException(nameof(dbFilePath));

            if (!Path.IsPathRooted(dbFilePath) && !dbFilePath.StartsWith("."))
                if (string.IsNullOrWhiteSpace(applicationFolder))
                    throw new ArgumentException(
                        $"Giving non-rooted {nameof(dbFilePath)} requires giving an {nameof(applicationFolder)}.");
            _useSingletonConnection = useSingletonConnection ?? false;

            Database = _useSingletonConnection
                ? LiteDbDatabaseSingleton.GetDatabase(dbFilePath)
                : new LiteDatabase(dbFilePath);
            NameService = new EntityNameAttributeNameService();
        }

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        protected LiteDbDataService(ILiteDbServiceOptions options) : this(options?.UseSingletonConnection,
            options?.DbFileName, options?.ApplicationFolder)
        {
        }

        #endregion

        #region IDisposable

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        public override void Dispose()
        {
            if (!_useSingletonConnection)
                Dispose(true);
        }

        /// <summary>
        ///     Releases the unmanaged resources used by the FluiTec.AppFx.Data.Dapper.DapperDataService and
        ///     optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     True to release both managed and unmanaged resources; false to
        ///     release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (_useSingletonConnection) return;
            Database?.Dispose();
            Database = null;
        }

        #endregion

        #region Migration

        /// <summary>Determine if we can migrate.</summary>
        /// <returns>True if we can migrate, false if not.</returns>
        public override bool CanMigrate() => false;

        /// <summary>Migrates the database.</summary>
        public override void Migrate() => throw new NotImplementedException();

        #endregion
    }
}