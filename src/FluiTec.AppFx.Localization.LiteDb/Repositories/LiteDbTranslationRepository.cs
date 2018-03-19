using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;
using LiteDB;

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

        /// <summary>Enumerates by resources in this collection.</summary>
        /// <param name="resources">    The resources. </param>
        /// <returns>An enumerator that allows foreach to be used to process by resources in this
        /// collection.</returns>
        public IEnumerable<TranslationEntity> ByResources(IEnumerable<ResourceEntity> resources)
        {
            var resourceIds = resources.Select(r => r.Id);
            return Collection.Find(
                Query.In(nameof(TranslationEntity.ResourceId), resourceIds.Select(r => new BsonValue(r))));
        }

        /// <summary>Enumerates by resources in this collection.</summary>
        /// <param name="resources">    The resources. </param>
        /// <param name="language">     The language. </param>
        /// <returns>An enumerator that allows foreach to be used to process by resources in this
        /// collection.</returns>
        public IEnumerable<TranslationEntity> ByResources(IEnumerable<ResourceEntity> resources, string language)
        {
            var resourceIds = resources.Select(r => r.Id);
            return Collection.Find(Query.And(
                    Query.In(nameof(TranslationEntity.ResourceId), resourceIds.Select(r => new BsonValue(r))), 
                    Query.EQ(nameof(TranslationEntity.Language), language)));
        }

        #endregion
    }
}