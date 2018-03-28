using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ApiResourceTest : IdentityServerTest
    {
        public ApiResourceTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetApiResource()
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
                Assert.AreEqual(resource.Name, uow.ApiResourceRepository.Get(resource.Id).Name);
            }
        }

        public virtual void CanAddAndGetByName()
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
                Assert.AreEqual(resource.Name, uow.ApiResourceRepository.GetByName(resource.Name).Name);
            }
        }

        public virtual void CanAddAndGetByIds()
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
                Assert.AreEqual(resource.Name, uow.ApiResourceRepository.GetByIds(new[] {resource.Id}).Single().Name);
            }
        }

        public virtual void CanAddAndGetApiResources()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resources = new[]
                {
                    new ApiResourceEntity
                    {
                        Name = "openid",
                        Description = "OpenId-Scope",
                        DisplayName = "OpenId",
                        Enabled = true
                    },
                    new ApiResourceEntity
                    {
                        Name = "openid2",
                        Description = "OpenId-Scope2",
                        DisplayName = "OpenId2",
                        Enabled = true
                    }
                };
                uow.ApiResourceRepository.AddRange(resources);
                Assert.AreEqual(resources.Length, uow.ApiResourceRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateResource()
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

                resource.Name = "changed";
                uow.ApiResourceRepository.Update(resource);

                Assert.AreEqual(resource.Name, uow.ApiResourceRepository.Get(resource.Id).Name);
            }
        }

        public virtual void CanDeleteResource()
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

                uow.ApiResourceRepository.Delete(resource);

                Assert.AreEqual(null, uow.ApiResourceRepository.Get(resource.Id));
            }
        }

        public virtual void CanGetAllCompound()
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
                Assert.IsNotNull(uow.ApiResourceRepository.GetAllCompound().First());
            }
        }

        public virtual void CanGetGetByScopeNamesCompound()
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

                var resScope = new ApiResourceScopeEntity
                {
                    ApiResourceId = resource.Id,
                    ScopeId = scope.Id
                };
                uow.ApiResourceScopeRepository.Add(resScope);


                Assert.IsNotNull(uow.ApiResourceRepository.GetByScopeNamesCompound(new[] {scope.Name}).First());
            }
        }

        public virtual void CanGetByNameCompountd()
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
                Assert.IsNotNull(uow.ApiResourceRepository.GetByName(resource.Name));
            }
        }
    }
}