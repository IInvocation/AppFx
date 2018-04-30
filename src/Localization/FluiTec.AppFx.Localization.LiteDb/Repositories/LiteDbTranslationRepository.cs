using System;
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

        /// <summary>Adds entity.</summary>
        /// <param name="entity">   The entity to add. </param>
        /// <returns>A TEntity.</returns>
        /// <remarks>
        ///     Make sure only distinct languages exist
        /// </remarks>
        public override TranslationEntity Add(TranslationEntity entity)
        {
            return GetByResourceIdAndCulture(entity.ResourceId, entity.Language) ?? base.Add(entity);
        }

        /// <summary>Adds a range.</summary>
        /// <param name="entities"> An IEnumerable&lt;TEntity&gt; of items to append to this. </param>
        /// <remarks>
        ///     Make sure only distinct languages exist
        /// </remarks>
        public override void AddRange(IEnumerable<TranslationEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (GetByResourceIdAndCulture(entity.ResourceId, entity.Language) == null)
                    Collection.Insert(entity);
            }
        }

        /// <summary>Updates the given entity.</summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the requested operation is
        ///     invalid.
        /// </exception>
        /// <param name="entity">   The entity. </param>
        /// <returns>A TEntity.</returns>
        /// <remarks>
        ///     Make sure only distinct languages exist
        /// </remarks>
        public override TranslationEntity Update(TranslationEntity entity)
        {
            var original = Get(entity.Id);

            // if key wasnt changed - continue as usual
            if (original.ResourceId == entity.ResourceId && original.Language == entity.Language)
                return base.Update(entity);

            // if key was changed - make sure a corresponding one doesnt exist
            if (GetByResourceIdAndCulture(entity.ResourceId, entity.Language) == null)
                return base.Update(entity);

            throw new InvalidOperationException("Duplicate key cannot be created");
        }

        /// <summary>Gets by resource identifier and culture.</summary>
        /// <param name="resourceId">   Identifier for the resource. </param>
        /// <param name="culture">      The culture. </param>
        /// <returns>The by resource identifier and culture.</returns>
        private TranslationEntity GetByResourceIdAndCulture(int resourceId, string culture)
        {
            return Collection.Find(e => e.ResourceId == resourceId && e.Language == culture).SingleOrDefault();
        }

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