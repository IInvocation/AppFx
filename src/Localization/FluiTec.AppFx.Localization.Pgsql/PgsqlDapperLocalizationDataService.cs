using System;
using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Localization.Dapper;
using FluiTec.AppFx.Localization.Dapper.Migration;
using FluiTec.AppFx.Localization.Pgsql.Repositories;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Pgsql
{
    public class PgsqlDapperLocalizationDataService : PgsqlDapperDataService, ILocalizationDataService
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public PgsqlDapperLocalizationDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "PgsqlDapperLocalizationDataService";

        /// <summary>Gets or sets information describing the meta.</summary>
        /// <value>Information describing the meta.</value>
        public override IVersionTableMetaData MetaData => new VersionTable();

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
                new Func<IUnitOfWork, IResourceRepository>(work => new PgsqlDapperResourceRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, ITranslationRepository>(work => new PgsqlDapperTranslationRepository(work)));
        }

        #endregion
    }
}