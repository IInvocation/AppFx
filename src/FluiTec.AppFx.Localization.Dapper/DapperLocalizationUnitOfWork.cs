using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Dapper
{
    /// <summary>A dapper localization unit of work.</summary>
    public class DapperLocalizationUnitOfWork : DapperUnitOfWork, ILocalizationUnitOfWork
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="dataService">	The data service. </param>
        public DapperLocalizationUnitOfWork(DapperDataService dataService) : base(dataService)
        {
        }

        #endregion

        #region Fields

        /// <summary>The resource repository.</summary>
        private IResourceRepository _resourceRepository;

        /// <summary>The translation repository.</summary>
        private ITranslationRepository _translationRepository;

        #endregion

        #region ILocalizationUnitOfWork

        /// <summary>Gets the resource repository.</summary>
        /// <value>The resource repository.</value>
        public IResourceRepository ResourceRepository => _resourceRepository ??
                                                         (_resourceRepository = GetRepository<IResourceRepository>());

        /// <summary>Gets the translation repository.</summary>
        /// <value>The translation repository.</value>
        public ITranslationRepository TranslationRepository => _translationRepository ??
                                                               (_translationRepository =
                                                                   GetRepository<ITranslationRepository>());

        #endregion
    }
}