using System.Collections.Generic;
using System.Linq;
using Dapper;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.IdentityServer.Compound;
using FluiTec.AppFx.IdentityServer.Dapper.Repositories;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.Dapper.Pgsql.Repositories
{
    /// <summary>	A mssql client repository. </summary>
    public class PgsqlClientRepository : ClientRepository
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public PgsqlClientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region ClientRepository

        /// <summary>	Gets compound by client identifier. </summary>
        /// <param name="clientId">	Identifier for the client. </param>
        /// <returns>	The compound by client identifier. </returns>
        public override CompoundClientEntity GetCompoundByClientId(string clientId)
        {
            var command = $"SELECT * FROM {TableName} AS \"client\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IClientScopeRepository>().TableName} AS \"cScope\"" +
                          $" ON \"client\".\"{nameof(ClientEntity.Id)}\" = \"cScope\".\"{nameof(ClientScopeEntity.ClientId)}\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IScopeRepository>().TableName} AS \"scope\"" +
                          $" ON \"cScope\".\"{nameof(ClientScopeEntity.ScopeId)}\" = \"scope\".\"{nameof(ScopeEntity.Id)}\"" +
                          $" LEFT JOIN {UnitOfWork.GetRepository<IClientClaimRepository>().TableName} AS \"cClaim\"" +
                          $" ON \"client\".\"{nameof(ClientEntity.Id)}\" = \"cClaim\".\"{nameof(ClientClaimEntity.ClientId)}\"" +
                          $" WHERE \"client\".\"{nameof(ClientEntity.ClientId)}\" = @ClientId";
            var lookup = new Dictionary<int, CompoundClientEntity>();
            UnitOfWork.Connection
                .Query<ClientEntity, ClientScopeEntity, ScopeEntity, ClientClaimEntity, CompoundClientEntity>(
                    command,
                    (entity, clientScope, scope, clientClaim) =>
                    {
                        // make sure the pk exists
                        if (entity == null || entity.Id == default(int))
                            return null;

                        // make sure our list contains the pk
                        if (!lookup.ContainsKey(entity.Id))
                            lookup.Add(entity.Id, new CompoundClientEntity
                            {
                                Client = entity
                            });

                        // fetch the real element
                        var tempElem = lookup[entity.Id];

                        // add scope
                        if (scope != null && tempElem.Scopes.Count(s => s.Id == scope.Id) < 1)
                            tempElem.Scopes.Add(scope);

                        // add claim
                        if (clientClaim != null && tempElem.ClientClaims.Count(c => c.Id == clientClaim.Id) < 1)
                            tempElem.ClientClaims.Add(clientClaim);

                        return tempElem;
                    }, new {ClientId = clientId}, UnitOfWork.Transaction);
            return lookup.Values.SingleOrDefault();
        }

        #endregion
    }
}