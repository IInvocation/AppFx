using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Localization.Compound;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.LiteDb.Repositories
{
    /// <summary>A lite database translation repository.</summary>
    public class LiteDbTranslationRepository : LiteDbIntegerRepository<TranslationEntity>, ITranslationRepository
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbTranslationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region ITranslationRepository

        /// <summary>   Enumerates by resource in this collection. </summary>
        /// <param name="resource"> The resource. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process by resource in this collection.
        /// </returns>
        public IEnumerable<TranslationEntity> ByResource(ResourceEntity resource)
        {
            return Collection.Find(entity => entity.ResourceId == resource.Id);
        }

        /// <summary>   Gets all compounds in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all compounds in this collection.
        /// </returns>
        public IEnumerable<CompoundTranslationEntity> GetAllCompound()
        {
            var resources = UnitOfWork.GetRepository<IResourceRepository>().GetAll().ToList();
            var translations = UnitOfWork.GetRepository<ITranslationRepository>().GetAll().GroupBy(t => t.ResourceId);

            foreach (var group in translations)
            {
                var resource = resources.Single(r => r.Id == group.Key);
                yield return new CompoundTranslationEntity
                {
                    Resource = resource,
                    Translations = group.ToList()
                };
            }
        }

        #endregion
    }
}