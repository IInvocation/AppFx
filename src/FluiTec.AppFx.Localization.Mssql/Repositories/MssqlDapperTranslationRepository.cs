using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Localization.Compound;
using FluiTec.AppFx.Localization.Dapper.Repositories;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.Repositories;

namespace FluiTec.AppFx.Localization.Mssql.Repositories
{
    /// <summary>A mssql dapper translation repository.</summary>
    public class MssqlDapperTranslationRepository : TranslationRepository, ITranslationRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="work"> The work. </param>
        public MssqlDapperTranslationRepository(IUnitOfWork work) : base(work)
        {
        }

        /// <summary>Gets all compounds in this collection.</summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all compounds in this
        ///     collection.
        /// </returns>
        public override IEnumerable<CompoundTranslationEntity> GetAllCompound()
        {
            var command = $"SELECT * FROM {UnitOfWork.GetRepository<IResourceRepository>().TableName} AS resource" +
                          $" LEFT JOIN {TableName} AS translation" +
                          $" ON resource.{nameof(ResourceEntity.Id)} = translation.{nameof(TranslationEntity.ResourceId)}";
            var lookup = new Dictionary<int, CompoundTranslationEntity>();
            UnitOfWork.Connection
                .Query<ResourceEntity, TranslationEntity, CompoundTranslationEntity>(command,
                    (resource, translation) =>
                    {
                        // make sure the pk exists
                        if (resource == null || resource.Id == default(int))
                            return null;

                        // make sure our list contains the pk
                        if (!lookup.ContainsKey(resource.Id))
                            lookup.Add(resource.Id, new CompoundTranslationEntity
                            {
                                Resource = resource
                            });

                        // fetch the real element
                        var tempElem = lookup[resource.Id];

                        // add translations
                        if (translation != null)
                            tempElem.Translations.Add(translation);

                        return tempElem;
                    }, null, UnitOfWork.Transaction);
            return lookup.Values;
        }
    }
}