using System;
using System.IO;
using System.Runtime.InteropServices;
using DBreeze;

namespace FluiTec.AppFx.Data.Dbreeze
{
    /// <summary>   A dbreeze data service. </summary>
    public abstract class DbreezeDataService : DataService
    {
        #region IDataService

        /// <summary>   Begins unit of work. </summary>
        /// <returns>   An IUnitOfWork. </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new DbreezeUnitOfWork(this);
        }

        /// <summary>   Begins unit of work. </summary>
        /// <param name="other">    The other. </param>
        /// <returns>   An IUnitOfWork. </returns>
        public override IUnitOfWork BeginUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DbreezeUnitOfWork))
                throw new ArgumentException(
                    $"Incompatible implementation of UnitOfWork. Must be of type {nameof(DbreezeUnitOfWork)}!");
            return new DbreezeUnitOfWork(this, (DbreezeUnitOfWork)other);
        }

        #endregion

        #region Methods

        /// <summary>   Gets the filename of the construct application data database file. </summary>
        /// <exception cref="NotSupportedException">    Thrown when the requested operation is not
        ///                                             supported. </exception>
        /// <param name="applicationFolder">    Pathname of the application folder. </param>
        /// <param name="dbFolderName">         (Optional) Pathname of the database folder. </param>
        /// <returns>   The foldername of the construct application data database folder. </returns>
        protected virtual string ConstructAppDataDbFileName(string applicationFolder, string dbFolderName = "dbreeze")
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var appData = Environment.GetEnvironmentVariable("LocalAppData");
                return Path.Combine(appData, applicationFolder, dbFolderName);
            }

            // reason: leave open for os x
            // ReSharper disable once InvertIf
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var appData = Environment.GetEnvironmentVariable("user.home");
                return Path.Combine(appData, applicationFolder, dbFolderName);
            }

            // TODO: Implement method for os x

            throw new NotSupportedException("Operating-System is not supported.");
        }

        #endregion

        #region Properties

        /// <summary>   Gets or sets the database. </summary>
        /// <value> The database. </value>
        public DBreezeEngine Database { get; private set; }

        /// <summary>	Gets the name service. </summary>
        /// <value>	The name service. </value>
        public virtual IEntityNameService NameService { get; }

        #endregion

        #region Constructors

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="applicationFolder">    Pathname of the application folder. </param>
        /// <param name="dbFolderName">         (Optional) Pathname of the database folder. </param>
        protected DbreezeDataService(string applicationFolder, string dbFolderName = "dbreeze")
        {
            if (string.IsNullOrWhiteSpace(dbFolderName)) throw new ArgumentNullException(nameof(dbFolderName));
            if (string.IsNullOrWhiteSpace(applicationFolder)) throw new ArgumentNullException(nameof(applicationFolder));

            // ReSharper disable once VirtualMemberCallInConstructor
            Database = new DBreezeEngine(ConstructAppDataDbFileName(applicationFolder, dbFolderName));
            NameService = new EntityNameAttributeNameService();
        }

        #endregion

        #region IDisposable

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        public override void Dispose()
        {
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