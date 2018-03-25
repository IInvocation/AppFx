using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Localization.Compound;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Dapper.Repositories
{
    /// <summary>A translation repository.</summary>
    public abstract class TranslationRepository : DapperRepository<TranslationEntity, int>, ITranslationRepository
    {
        /// <summary>Specialised constructor for use only by derived class.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        protected TranslationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>Enumerates by resource in this collection.</summary>
        /// <param name="resource"> The resource. </param>
        /// <returns>An enumerator that allows foreach to be used to process by resource in this
        /// collection.</returns>
        public virtual IEnumerable<TranslationEntity> ByResource(ResourceEntity resource)
        {
            var command = SqlBuilder.SelectByFilter(EntityType, nameof(TranslationEntity.ResourceId));
            return UnitOfWork.Connection.Query<TranslationEntity>(command, new { ResourceId = resource.Id }, UnitOfWork.Transaction);
        }

        /// <summary>Gets all compounds in this collection.</summary>
        /// <returns>An enumerator that allows foreach to be used to process all compounds in this
        /// collection.</returns>
        public abstract IEnumerable<CompoundTranslationEntity> GetAllCompound();
    }
}