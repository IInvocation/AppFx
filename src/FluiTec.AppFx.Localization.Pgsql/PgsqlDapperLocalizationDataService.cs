using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Localization.Dapper;
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

        #endregion

        #region ILocalizationDataService

        /// <summary>Starts unit of work.</summary>
        /// <returns>An ILocalizationUnitOfWork.</returns>
        public ILocalizationUnitOfWork StartUnitOfWork()
        {
            return new DapperLocalizationUnitOfWork(this);
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