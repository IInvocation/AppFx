using System.Collections.Generic;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Localization.Entities;

namespace FluiTec.AppFx.Localization.Repositories
{
    /// <summary>Interface for resource repository.</summary>
    public interface IResourceRepository : IDataRepository<ResourceEntity, int>
    {
        /// <summary>Gets the names in this collection.</summary>
        /// <param name="name"> The name. </param>
        /// <returns>An enumerator that allows foreach to be used to process the names in this collection.</returns>
        IEnumerable<ResourceEntity> GetByName(string name);
    }
}