using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.DataProtection.LiteDb.Repositories;
using FluiTec.AppFx.DataProtection.Repositories;
using System;

namespace FluiTec.AppFx.DataProtection.LiteDb
{
    public class LiteDbDataProtectionDataService : LiteDbDataService, IDataProtectionDataService
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="useSingletonConnection">   The use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbDataProtectionDataService(bool? useSingletonConnection, string dbFilePath,
            string applicationFolder = null) : base(useSingletonConnection, dbFilePath, applicationFolder)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public LiteDbDataProtectionDataService(ILiteDbServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "LiteDbDataProtectionDataService";

        #endregion

        #region Methods

        /// <summary>Starts unit of work.</summary>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IDataProtectionUnitOfWork StartUnitOfWork()
        {
            return new LiteDbDataProtectionUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IDataProtectionUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork)) throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}.");
            return new LiteDbDataProtectionUnitOfWork(this, (LiteDbUnitOfWork)other);
        }

        /// <summary>Determine if we can migrate.</summary>
        /// <returns>True if we can migrate, false if not.</returns>
        public bool CanMigrate() => false;

        /// <summary>Migrates this object.</summary>
        public void Migrate() => throw new NotImplementedException();

        /// <summary>Registers the identity repositories.</summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IDataProtectionKeyRepository>(work => new LiteDbDataProtectionRepository(work)));
        }


        #endregion
    }
}
