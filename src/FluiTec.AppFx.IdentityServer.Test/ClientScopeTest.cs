using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ClientScopeTest : IdentityServerTest
    {
        public ClientScopeTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetClientScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);

                var scope = new ScopeEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope);

                var clientScope = new ClientScopeEntity
                {
                    ClientId = client.Id,
                    ScopeId = scope.Id
                };
                uow.ClientScopeRepository.Add(clientScope);

                Assert.AreEqual(clientScope.ScopeId, uow.ClientScopeRepository.Get(clientScope.Id).ScopeId);
            }
        }

        public virtual void CanAddAndGetClientScopes()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);

                var scope = new ScopeEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope);

                var clientScopes = new[]
                {
                    new ClientScopeEntity
                    {
                        ClientId = client.Id,
                        ScopeId = scope.Id
                    },
                    new ClientScopeEntity
                    {
                        ClientId = client.Id,
                        ScopeId = scope.Id
                    }
                };
                uow.ClientScopeRepository.AddRange(clientScopes);
                Assert.AreEqual(clientScopes.Length, uow.ClientScopeRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateClient()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);

                var scope = new ScopeEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                var scope2 = new ScopeEntity
                {
                    Name = "openidx",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope);
                uow.ScopeRepository.Add(scope2);

                var clientScope = new ClientScopeEntity
                {
                    ClientId = client.Id,
                    ScopeId = scope.Id
                };
                uow.ClientScopeRepository.Add(clientScope);

                clientScope.ScopeId = scope2.Id;
                uow.ClientScopeRepository.Update(clientScope);

                Assert.AreEqual(clientScope.ScopeId, uow.ClientScopeRepository.Get(clientScope.Id).ScopeId);
            }
        }

        public virtual void CanDeleteClient()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);

                var scope = new ScopeEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope);

                var clientScope = new ClientScopeEntity
                {
                    ClientId = client.Id,
                    ScopeId = scope.Id
                };
                uow.ClientScopeRepository.Add(clientScope);

                uow.ClientScopeRepository.Delete(clientScope);

                Assert.AreEqual(null, uow.ClientScopeRepository.Get(clientScope.Id));
            }
        }

        public virtual void CanGetByClientId()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);

                var scope = new ScopeEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope);

                var clientScope = new ClientScopeEntity
                {
                    ClientId = client.Id,
                    ScopeId = scope.Id
                };
                uow.ClientScopeRepository.Add(clientScope);

                Assert.AreEqual(clientScope.ScopeId,
                    uow.ClientScopeRepository.GetByClientId(clientScope.ClientId).First().ScopeId);
            }
        }
    }
}