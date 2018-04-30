using System.Collections.Generic;
using System.Linq;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Sql;
using FluiTec.AppFx.IdentityServer.Compound;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Repositories
{
    /// <summary>	A mssql API resource repository. </summary>
    public class PgsqlApiResourceRepository : ApiResourceRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public PgsqlApiResourceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region ApiResourceRepository

        /// <summary>	Gets the identifiers in this collection. </summary>
        /// <param name="ids">	The identifiers. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the identifiers in this collection.
        /// </returns>
        public override IEnumerable<ApiResourceEntity> GetByIds(int[] ids)
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(ApiResourceEntity)).ToArray())} FROM {TableName} WHERE \"{nameof(ApiResourceEntity.Id)}\" = ANY(@Ids)";
            return UnitOfWork.Connection.Query<ApiResourceEntity>(command, new {Ids = ids},
                UnitOfWork.Transaction);
        }

        /// <summary>	Gets all compounds in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all compounds in this collection.
        /// </returns>
        public override IEnumerable<CompoundApiResource> GetAllCompound()
        {
            var command = $"SELECT * FROM {TableName} AS \"aRes\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IApiResourceScopeRepository>().TableName} AS \"aScope\"" +
                          $" ON \"aRes\".\"{nameof(ApiResourceEntity.Id)}\" = \"aScope\".\"{nameof(ApiResourceScopeEntity.ApiResourceId)}\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IApiResourceClaimRepository>().TableName} AS \"aClaim\"" +
                          $" ON \"aRes\".\"{nameof(ApiResourceEntity.Id)}\" = \"aClaim\".\"{nameof(ApiResourceClaimEntity.ApiResourceId)}\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IScopeRepository>().TableName} AS \"scope\"" +
                          $" ON \"aScope\".\"{nameof(ApiResourceScopeEntity.ScopeId)}\" = \"scope\".\"{nameof(ScopeEntity.Id)}\"";
            var lookup = new Dictionary<int, CompoundApiResource>();
            UnitOfWork.Connection
                .Query<ApiResourceEntity, ApiResourceScopeEntity, ApiResourceClaimEntity, ScopeEntity,
                    CompoundApiResource>(command,
                    (entity, apiScope, apiClaim, scope) =>
                    {
                        // make sure the pk exists
                        if (entity == null || entity.Id == default(int))
                            return null;

                        // make sure our list contains the pk
                        if (!lookup.ContainsKey(entity.Id))
                            lookup.Add(entity.Id, new CompoundApiResource {ApiResource = entity});

                        // fetch the real element
                        var tempElem = lookup[entity.Id];

                        // add api-scope
                        if (apiScope != null)
                            tempElem.ApiResourceScopes.Add(apiScope);

                        // add claim
                        if (apiClaim != null)
                            tempElem.ApiResourceClaims.Add(apiClaim);

                        // add scope
                        if (scope != null)
                            tempElem.Scopes.Add(scope);

                        return tempElem;
                    }, null, UnitOfWork.Transaction);
            return lookup.Values;
        }

        /// <summary>	Gets the scope names in this collection. </summary>
        /// <param name="scopeNames">	List of names of the scopes. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the scope names in this collection.
        /// </returns>
        public override IEnumerable<CompoundApiResource> GetByScopeNamesCompound(IEnumerable<string> scopeNames)
        {
            var command = $"SELECT * FROM {TableName} AS \"aRes\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IApiResourceScopeRepository>().TableName} AS \"aScope\"" +
                          $" ON \"aRes\".\"{nameof(ApiResourceEntity.Id)}\" = \"aScope\".\"{nameof(ApiResourceScopeEntity.ApiResourceId)}\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IApiResourceClaimRepository>().TableName} AS \"aClaim\"" +
                          $" ON \"aRes\".\"{nameof(ApiResourceEntity.Id)}\" = \"aClaim\".\"{nameof(ApiResourceClaimEntity.ApiResourceId)}\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IScopeRepository>().TableName} AS \"scope\"" +
                          $" ON \"aScope\".\"{nameof(ApiResourceScopeEntity.ScopeId)}\" = \"scope\".\"{nameof(ScopeEntity.Id)}\"" +
                          $" WHERE \"scope\".\"{nameof(ScopeEntity.Name)}\" = ANY(@ScopeNames)";
            var lookup = new Dictionary<int, CompoundApiResource>();
            UnitOfWork.Connection
                .Query<ApiResourceEntity, ApiResourceScopeEntity, ApiResourceClaimEntity, ScopeEntity,
                    CompoundApiResource>(command,
                    (entity, apiScope, apiClaim, scope) =>
                    {
                        // make sure the pk exists
                        if (entity == null || entity.Id == default(int))
                            return null;

                        // make sure our list contains the pk
                        if (!lookup.ContainsKey(entity.Id))
                            lookup.Add(entity.Id, new CompoundApiResource
                            {
                                ApiResource = entity
                            });

                        // fetch the real element
                        var tempElem = lookup[entity.Id];

                        // add api-scope
                        if (apiScope != null)
                            tempElem.ApiResourceScopes.Add(apiScope);

                        // add claim
                        if (apiClaim != null)
                            tempElem.ApiResourceClaims.Add(apiClaim);

                        // add scope
                        if (scope != null)
                            tempElem.Scopes.Add(scope);

                        return tempElem;
                    }, new {ScopeNames = scopeNames}, UnitOfWork.Transaction);
            return lookup.Values;
        }

        /// <summary>	Gets the name compounts in this collection. </summary>
        /// <param name="name">	The name. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the name compounts in this collection.
        /// </returns>
        public override CompoundApiResource GetByNameCompount(string name)
        {
            var command =
                $"SELECT {SqlBuilder.Adapter.RenderPropertyList(SqlCache.TypePropertiesChache(typeof(ApiResourceEntity)).ToArray())} FROM {TableName} AS \"aRes\"" +
                $" LEFT JOIN {UnitOfWork.GetRepository<IApiResourceScopeRepository>().TableName} AS \"aScope\"" +
                $" ON \"aRes\".\"{nameof(ApiResourceEntity.Id)}\" = \"aScope\".\"{nameof(ApiResourceScopeEntity.ApiResourceId)}\"" +
                $" LEFT JOIN {UnitOfWork.GetRepository<IApiResourceClaimRepository>().TableName} AS \"aClaim\"" +
                $" ON \"aRes\".\"{nameof(ApiResourceEntity.Id)}\" = \"aClaim\".\"{nameof(ApiResourceClaimEntity.ApiResourceId)}\"" +
                $" LEFT JOIN {UnitOfWork.GetRepository<IScopeRepository>().TableName} AS \"scope\"" +
                $" ON \"aScope\".\"{nameof(ApiResourceScopeEntity.ScopeId)}\" = \"scope\".\"{nameof(ScopeEntity.Id)}\"" +
                $" WHERE \"aRes\".\"{nameof(ApiResourceEntity.Name)}\" = @ResName";
            var lookup = new Dictionary<int, CompoundApiResource>();
            UnitOfWork.Connection
                .Query<ApiResourceEntity, ApiResourceScopeEntity, ApiResourceClaimEntity, ScopeEntity,
                    CompoundApiResource>(command,
                    (entity, apiScope, apiClaim, scope) =>
                    {
                        // make sure the pk exists
                        if (entity == null || entity.Id == default(int))
                            return null;

                        // make sure our list contains the pk
                        if (!lookup.ContainsKey(entity.Id))
                            lookup.Add(entity.Id, new CompoundApiResource
                            {
                                ApiResource = entity
                            });

                        // fetch the real element
                        var tempElem = lookup[entity.Id];

                        // add api-scope
                        if (apiScope != null)
                            tempElem.ApiResourceScopes.Add(apiScope);

                        // add claim
                        if (apiClaim != null)
                            tempElem.ApiResourceClaims.Add(apiClaim);

                        // add scope
                        if (scope != null)
                            tempElem.Scopes.Add(scope);

                        return tempElem;
                    }, new {ResName = name}, UnitOfWork.Transaction);
            return lookup.Values.SingleOrDefault();
        }

        #endregion
    }
}