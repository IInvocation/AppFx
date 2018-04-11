using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mssql;
using FluiTec.AppFx.Localization.Dapper;
using FluiTec.AppFx.Localization.Mssql.Repositories;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Mssql
{
    /// <summary>A mssql dapper localization data service.</summary>
    public class MssqlDapperLocalizationDataService : MssqlDapperDataService, ILocalizationDataService
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public MssqlDapperLocalizationDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "MssqlDapperLocalizationDataService";

        #endregion

        #region ILocalizationDataService

        /// <summary>Starts unit of work.</summary>
        /// <returns>An ILocalizationUnitOfWork.</returns>
        public ILocalizationUnitOfWork StartUnitOfWork()
        {
            return new DapperLocalizationUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An ILocalizationUnitOfWork.</returns>
        public ILocalizationUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}");
            return new DapperLocalizationUnitOfWork(this, (DapperUnitOfWork)other);
        }

        #endregion

        #region Methods

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IResourceRepository>(work => new MssqlDapperResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, ITranslationRepository>(work => new MssqlDapperTranslationRepository(work)));
        }

        #endregion
    }
}