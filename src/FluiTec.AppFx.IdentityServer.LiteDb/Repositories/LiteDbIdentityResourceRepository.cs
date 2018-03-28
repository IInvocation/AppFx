using System.Collections.Generic;
using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Compound;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>	A lite database identity resource repository. </summary>
    public class LiteDbIdentityResourceRepository : LiteDbIntegerRepository<IdentityResourceEntity>,
        IIdentityResourceRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public LiteDbIdentityResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>	Gets all compounds in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all compounds in this collection.
        /// </returns>
        public IEnumerable<CompoundIdentityResource> GetAllCompound()
        {
            var claimsRepo = UnitOfWork.GetRepository<IIdentityResourceClaimRepository>();
            var rScopesRepo = UnitOfWork.GetRepository<IIdentityResourceScopeRepository>();
            var scopesRepo = UnitOfWork.GetRepository<IScopeRepository>();

            var identityResources = GetAll().ToList();
            var rScopes = rScopesRepo.GetByIdentityIds(identityResources.Select(e => e.Id).ToArray()).ToList();

            return identityResources.Select(e =>
                new CompoundIdentityResource
                {
                    IdentityResource = e,
                    IdentityResourceClaims = claimsRepo.GetByIdentityId(e.Id).ToList(),
                    IdentityResourceScopes = rScopes.Where(rs => rs.IdentityResourceId == e.Id).ToList(),
                    Scopes = scopesRepo
                        .GetByIds(rScopes.Where(rs => rs.IdentityResourceId == e.Id).Select(rs => rs.ScopeId).ToArray())
                        .ToList()
                });
        }

        /// <summary>	Gets the scope names compounds in this collection. </summary>
        /// <param name="scopeNames">	List of names of the scopes. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope names compounds in this
        ///     collection.
        /// </returns>
        public IEnumerable<CompoundIdentityResource> GetByScopeNamesCompound(IEnumerable<string> scopeNames)
        {
            var claimsRepo = UnitOfWork.GetRepository<IIdentityResourceClaimRepository>();

            var scopes = UnitOfWork.GetRepository<IScopeRepository>().GetByNames(scopeNames.ToArray()).ToList();
            var rScopes = UnitOfWork.GetRepository<IIdentityResourceScopeRepository>()
                .GetByScopeIds(scopes.Select(s => s.Id).ToArray()).ToList();
            var apis = GetByIds(rScopes.Distinct().Select(rs => rs.IdentityResourceId).ToArray());

            return apis.Select(e =>
                new CompoundIdentityResource
                {
                    IdentityResource = e,
                    IdentityResourceClaims = claimsRepo.GetByIdentityId(e.Id).ToList(),
                    IdentityResourceScopes = rScopes.Where(rs => rs.IdentityResourceId == e.Id).ToList(),
                    Scopes = scopes.Where(s =>
                            rScopes.Where(rs => rs.IdentityResourceId == e.Id).Select(rs => rs.ScopeId).ToList()
                                .Contains(s.Id))
                        .ToList()
                });
        }

        /// <summary>
        ///     Gets the identifiers in this collection.
        /// </summary>
        /// <param name="ids">  The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public IEnumerable<IdentityResourceEntity> GetByIds(int[] ids)
        {
            return GetAll().Where(e => ids.Contains(e.Id));
        }
    }
}