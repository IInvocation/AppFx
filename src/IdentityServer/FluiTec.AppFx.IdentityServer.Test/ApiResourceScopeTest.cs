using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ApiResourceScopeTest : IdentityServerTest
    {
        public ApiResourceScopeTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetApiResourceScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new ApiResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Enabled = true
                };
                uow.ApiResourceRepository.Add(resource);

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

                var resourceScope = new ApiResourceScopeEntity
                {
                    ApiResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.ApiResourceScopeRepository.Add(resourceScope);

                Assert.AreEqual(resourceScope.ApiResourceId,
                    uow.ApiResourceScopeRepository.Get(resourceScope.Id).ApiResourceId);
            }
        }

        public virtual void CanAddAndGetApiResourceScopes()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new ApiResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Enabled = true
                };
                uow.ApiResourceRepository.Add(resource);

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
                    new ApiResourceScopeEntity
                    {
                        ApiResourceId = resource.Id,
                        ScopeId = scope.Id
                    },
                    new ApiResourceScopeEntity
                    {
                        ApiResourceId = resource.Id,
                        ScopeId = scope2.Id
                    }
                };
                uow.ApiResourceScopeRepository.AddRange(resourceScopes);
                Assert.AreEqual(resourceScopes.Length, uow.ApiResourceScopeRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateApiResourceScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new ApiResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Enabled = true
                };
                uow.ApiResourceRepository.Add(resource);

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

                var resourceScope = new ApiResourceScopeEntity
                {
                    ApiResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.ApiResourceScopeRepository.Add(resourceScope);

                resourceScope.ScopeId = scope2.Id;
                uow.ApiResourceScopeRepository.Update(resourceScope);

                Assert.AreEqual(resourceScope.ScopeId, uow.ApiResourceScopeRepository.Get(resourceScope.Id).ScopeId);
            }
        }

        public virtual void CanDeleteApiResourceScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new ApiResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Enabled = true
                };
                uow.ApiResourceRepository.Add(resource);

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

                var resourceScope = new ApiResourceScopeEntity
                {
                    ApiResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.ApiResourceScopeRepository.Add(resourceScope);

                uow.ApiResourceScopeRepository.Delete(resourceScope);

                Assert.AreEqual(null, uow.ApiResourceScopeRepository.Get(resourceScope.Id));
            }
        }

        public virtual void CanGetByScopeIds()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new ApiResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Enabled = true
                };
                uow.ApiResourceRepository.Add(resource);

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

                var resourceScope = new ApiResourceScopeEntity
                {
                    ApiResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.ApiResourceScopeRepository.Add(resourceScope);

                Assert.IsNotNull(uow.ApiResourceScopeRepository.GetByScopeIds(new[] {scope.Id}).Single());
            }
        }

        public virtual void CanGetByApiIds()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resource = new ApiResourceEntity
                {
                    Name = "openid",
                    Description = "OpenId-Scope",
                    DisplayName = "OpenId",
                    Enabled = true
                };
                uow.ApiResourceRepository.Add(resource);

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

                var resourceScope = new ApiResourceScopeEntity
                {
                    ApiResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.ApiResourceScopeRepository.Add(resourceScope);

                Assert.IsNotNull(uow.ApiResourceScopeRepository.GetByApiIds(new[] {resource.Id}).Single());
            }
        }
    }
}