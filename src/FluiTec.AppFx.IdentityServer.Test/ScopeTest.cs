using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ScopeTest : IdentityServerTest
    {
        public ScopeTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
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
                Assert.AreEqual(scope.Name, uow.ScopeRepository.Get(scope.Id).Name);
            }
        }

        public virtual void CanAddAndGetScopes()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var scopes = new[]
                {
                    new ScopeEntity
                    {
                        Name = "openid",
                        Description = "OpenId-Scope",
                        DisplayName = "OpenId",
                        Emphasize = true,
                        Required = true,
                        ShowInDiscoveryDocument = true
                    },
                    new ScopeEntity
                    {
                        Name = "profile",
                        Description = "Profile-Scope",
                        DisplayName = "Profile",
                        Emphasize = true,
                        Required = true,
                        ShowInDiscoveryDocument = true
                    }
                };
                uow.ScopeRepository.AddRange(scopes);
                Assert.AreEqual(scopes.Length, uow.ScopeRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
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

                scope.Name = "changed";
                uow.ScopeRepository.Update(scope);

                Assert.AreEqual(scope.Name, uow.ScopeRepository.Get(scope.Id).Name);
            }
        }

        public virtual void CanDeleteScope()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
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

                uow.ScopeRepository.Delete(scope);

                Assert.AreEqual(null, uow.ScopeRepository.Get(scope.Id));
            }
        }

        public virtual void CanGetByIds()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
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
                Assert.AreEqual(scope.Name, uow.ScopeRepository.GetByIds(new[] {scope.Id}).First().Name);
            }
        }

        public virtual void CanGetByNames()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
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
                Assert.AreEqual(scope.Name, uow.ScopeRepository.GetByNames(new[] {scope.Name}).First().Name);
            }
        }
    }
}