using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.LiteDb
{
    /// <summary>A lite database localization unit of work.</summary>
    public class LiteDbLocalizationUnitOfWork : LiteDbUnitOfWork, ILocalizationUnitOfWork
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="dataService">  The data service. </param>
        public LiteDbLocalizationUnitOfWork(LiteDbDataService dataService) : base(dataService)
        {
        }

        /// <summary>Constructor.</summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public LiteDbLocalizationUnitOfWork(LiteDbDataService dataService, LiteDbUnitOfWork parentUnitOfWork) : base(
            dataService, parentUnitOfWork)
        {
        }

        #endregion

        #region Fields

        private IResourceRepository _resourceRepository;
        private ITranslationRepository _translationRepository;

        #endregion

        #region IIdentityUnitOfWork

        /// <summary>Gets or sets the resource repository.</summary>
        /// <value>The resource repository.</value>
        public IResourceRepository ResourceRepository =>
            _resourceRepository ?? (_resourceRepository = GetRepository<IResourceRepository>());

        /// <summary>Gets or sets the translation repository.</summary>
        /// <value>The translation repository.</value>
        public ITranslationRepository TranslationRepository =>
            _translationRepository ?? (_translationRepository = GetRepository<ITranslationRepository>());

        #endregion
    }
}