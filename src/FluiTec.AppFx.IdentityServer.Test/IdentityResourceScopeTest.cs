using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class IdentityResourceScopeTest : IdentityServerTest
    {
        public IdentityResourceScopeTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetIdentityResourceScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new IdentityResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.IdentityResourceRepository.Add(resource);

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

                var resourceScope = new IdentityResourceScopeEntity
                {
                    IdentityResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.IdentityResourceScopeRepository.Add(resourceScope);

                Assert.AreEqual(resourceScope.IdentityResourceId,
                    uow.IdentityResourceScopeRepository.Get(resourceScope.Id).IdentityResourceId);
            }
        }

        public virtual void CanAddAndGetIdentityResourceScopes()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new IdentityResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.IdentityResourceRepository.Add(resource);

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

                var scope2 = new ScopeEntity
                {
                    Name = "openid2",
                    Description = "OpenId-Scope2",
                    DisplayName = "OpenId2",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope2);

                var resourceScopes = new[]
                {
                    new IdentityResourceScopeEntity
                    {
                        IdentityResourceId = resource.Id,
                        ScopeId = scope.Id
                    },
                    new IdentityResourceScopeEntity
                    {
                        IdentityResourceId = resource.Id,
                        ScopeId = scope2.Id
                    }
                };
                uow.IdentityResourceScopeRepository.AddRange(resourceScopes);
                Assert.AreEqual(resourceScopes.Length, uow.IdentityResourceScopeRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateIdentityResourceScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new IdentityResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.IdentityResourceRepository.Add(resource);

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
                var scope2 = new ScopeEntity
                {
                    Name = "openid2",
                    Description = "OpenId-Scope2",
                    DisplayName = "OpenId2",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.ScopeRepository.Add(scope2);

                var resourceScope = new IdentityResourceScopeEntity
                {
                    IdentityResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.IdentityResourceScopeRepository.Add(resourceScope);

                resourceScope.ScopeId = scope2.Id;
                uow.IdentityResourceScopeRepository.Update(resourceScope);

                Assert.AreEqual(resourceScope.ScopeId,
                    uow.IdentityResourceScopeRepository.Get(resourceScope.Id).ScopeId);
            }
        }

        public virtual void CanDeleteIdentityResourceScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new IdentityResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Emphasize = true,
                    Required = true,
                    ShowInDiscoveryDocument = true
                };
                uow.IdentityResourceRepository.Add(resource);

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

                var resourceScope = new IdentityResourceScopeEntity
                {
                    IdentityResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.IdentityResourceScopeRepository.Add(resourceScope);

                uow.IdentityResourceScopeRepository.Delete(resourceScope);

                Assert.AreEqual(null, uow.IdentityResourceScopeRepository.Get(resourceScope.Id));
            }
        }
    }
}