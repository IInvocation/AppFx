using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Compound;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database API resource repository.
    /// </summary>
    public class LiteDbApiResourceRepository : LiteDbIntegerRepository<ApiResourceEntity>, IApiResourceRepository
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbApiResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IApiResourceRepository

        /// <summary>
        ///     Gets by name.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <returns>
        ///     The by name.
        /// </returns>
        public ApiResourceEntity GetByName(string name)
        {
            return Collection.Find(e => e.Name == name).SingleOrDefault();
        }

        /// <summary>
        ///     Gets the identifiers in this collection.
        /// </summary>
        /// <param name="ids">  The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public IEnumerable<ApiResourceEntity> GetByIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.Id));
        }

        /// <summary>
        ///     Gets all compounds in this collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all compounds in this collection.
        /// </returns>
        public IEnumerable<CompoundApiResource> GetAllCompound()
        {
            var claimsRepo = UnitOfWork.GetRepository<IApiResourceClaimRepository>();
            var rScopesRepo = UnitOfWork.GetRepository<IApiResourceScopeRepository>();
            var scopesRepo = UnitOfWork.GetRepository<IScopeRepository>();

            var apiResources = GetAll().ToList();
            var rScopes = rScopesRepo.GetByApiIds(apiResources.Select(e => e.Id).ToArray()).ToList();

            return apiResources.Select(e =>
                new CompoundApiResource
                {
                    ApiResource = e,
                    ApiResourceClaims = claimsRepo.GetByApiId(e.Id).ToList(),
                    ApiResourceScopes = rScopes.Where(rs => rs.ApiResourceId == e.Id).ToList(),
                    Scopes = scopesRepo
                        .GetByIds(rScopes.Where(rs => rs.ApiResourceId == e.Id).Select(rs => rs.ScopeId).ToArray())
                        .ToList()
                });
        }

        /// <summary>
        ///     Gets the scope names in this collection.
        /// </summary>
        /// <param name="scopeNames">   List of names of the scopes. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope names in this collection.
        /// </returns>
        public IEnumerable<CompoundApiResource> GetByScopeNamesCompound(IEnumerable<string> scopeNames)
        {
            var claimsRepo = UnitOfWork.GetRepository<IApiResourceClaimRepository>();

            var scopes = UnitOfWork.GetRepository<IScopeRepository>().GetByNames(scopeNames.ToArray()).ToList();
            var rScopes = UnitOfWork.GetRepository<IApiResourceScopeRepository>()
                .GetByScopeIds(scopes.Select(s => s.Id).ToArray()).ToList();
            var apis = GetByIds(rScopes.Distinct().Select(rs => rs.ApiResourceId).ToArray());

            return apis.Select(e =>
                new CompoundApiResource
                {
                    ApiResource = e,
                    ApiResourceClaims = claimsRepo.GetByApiId(e.Id).ToList(),
                    ApiResourceScopes = rScopes.Where(rs => rs.ApiResourceId == e.Id).ToList(),
                    Scopes = scopes.Where(s =>
                            rScopes.Where(rs => rs.ApiResourceId == e.Id).Select(rs => rs.ScopeId).ToList()
                                .Contains(s.Id))
                        .ToList()
                });
        }

        /// <summary>
        ///     Gets by name compount.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <returns>
        ///     The by name compount.
        /// </returns>
        public CompoundApiResource GetByNameCompount(string name)
        {
            var api = Collection.Find(e => e.Name == name).Single();
            return new CompoundApiResource
            {
                ApiResource = api,
                ApiResourceClaims = UnitOfWork.GetRepository<IApiResourceClaimRepository>().GetByApiId(api.Id).ToList(),
                ApiResourceScopes = UnitOfWork.GetRepository<IApiResourceScopeRepository>().GetByApiIds(new[] {api.Id})
                    .ToList(),
                Scopes = UnitOfWork.GetRepository<IScopeRepository>().GetByIds(UnitOfWork
                    .GetRepository<IApiResourceScopeRepository>().GetByApiIds(new[] {api.Id}).Select(rs => rs.ScopeId)
                    .ToArray()).ToList()
            };
        }

        #endregion
    }
}