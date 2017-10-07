using System.Linq;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.IdentityServer.Compound;
using FluiTec.AppFx.IdentityServer.Entities;
using FluiTec.AppFx.IdentityServer.Repositories;

namespace FluiTec.AppFx.IdentityServer.LiteDb.Repositories
{
    /// <summary>
    ///     A lite database client repository.
    /// </summary>
    public class LiteDbClientRepository : LiteDbIntegerRepository<ClientEntity>, IClientRepository
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbClientRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        ///     Gets by client identifier.
        /// </summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>
        ///     The by client identifier.
        /// </returns>
        public ClientEntity GetByClientId(string clientId)
        {
            return Collection.Find(e => e.ClientId == clientId).SingleOrDefault();
        }

        /// <summary>
        ///     Gets compound by client identifier.
        /// </summary>
        /// <param name="clientId"> Identifier for the client. </param>
        /// <returns>
        ///     The compound by client identifier.
        /// </returns>
        public CompoundClientEntity GetCompoundByClientId(string clientId)
        {
            var client = GetByClientId(clientId);
            var cScopes = UnitOfWork.GetRepository<IClientScopeRepository>().GetByClientId(client.Id).ToList();
            return new CompoundClientEntity
            {
                Client = client,
                ClientClaims = UnitOfWork.GetRepository<IClientClaimRepository>().GetAll()
                    .Where(c => c.ClientId == client.Id).ToList(),
                Scopes = UnitOfWork.GetRepository<IScopeRepository>()
                    .GetByIds(cScopes.Select(cs => cs.ScopeId).Distinct().ToArray()).ToList()
            };
        }
    }
}