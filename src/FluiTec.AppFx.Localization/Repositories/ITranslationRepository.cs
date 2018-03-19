using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Localization.Entities;

namespace FluiTec.AppFx.Localization.Repositories
{
    /// <summary>Interface for translation repository.</summary>
    public interface ITranslationRepository : IDataRepository<TranslationEntity, int>
    {
        /// <summary>Enumerates by resources in this collection.</summary>
        /// <param name="resources">    The resources. </param>
        /// <returns>An enumerator that allows foreach to be used to process by resources in this
        /// collection.</returns>
        IEnumerable<TranslationEntity> ByResources(IEnumerable<ResourceEntity> resources);

        /// <summary>Enumerates by resources in this collection.</summary>
        /// <param name="resources">    The resources. </param>
        /// <param name="language">     The language. </param>
        /// <returns>An enumerator that allows foreach to be used to process by resources in this
        /// collection.</returns>
        IEnumerable<TranslationEntity> ByResources(IEnumerable<ResourceEntity> resources, string language);
    }
}