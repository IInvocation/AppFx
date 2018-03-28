using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ApiResourceClaimTest : IdentityServerTest
    {
        public ApiResourceClaimTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetApiResourceClaim()
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

                var claim = new ApiResourceClaimEntity
                {
                    ApiResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.ApiResourceClaimRepository.Add(claim);

                Assert.AreEqual(claim.ClaimType, uow.ApiResourceClaimRepository.Get(claim.Id).ClaimType);
            }
        }

        public virtual void CanAddAndGetApiResourceClaimByApiResourceId()
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

                var claim = new ApiResourceClaimEntity
                {
                    ApiResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.ApiResourceClaimRepository.Add(claim);

                Assert.AreEqual(claim.ClaimType,
                    uow.ApiResourceClaimRepository.GetByApiId(resource.Id).Single().ClaimType);
            }
        }

        public virtual void CanAddAndGetApiResourceClaims()
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

                var claims = new[]
                {
                    new ApiResourceClaimEntity
                    {
                        ApiResourceId = resource.Id,
                        ClaimType = "ClaimType"
                    },
                    new ApiResourceClaimEntity
                    {
                        ApiResourceId = resource.Id,
                        ClaimType = "ClaimType2"
                    }
                };
                uow.ApiResourceClaimRepository.AddRange(claims);
                Assert.AreEqual(claims.Length, uow.ApiResourceClaimRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateApiResource()
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

                var claim = new ApiResourceClaimEntity
                {
                    ApiResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.ApiResourceClaimRepository.Add(claim);

                claim.ClaimType = "changed";
                uow.ApiResourceClaimRepository.Update(claim);

                Assert.AreEqual(claim.ClaimType, uow.ApiResourceClaimRepository.Get(claim.Id).ClaimType);
            }
        }

        public virtual void CanDeleteApiResource()
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

                var claim = new ApiResourceClaimEntity
                {
                    ApiResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.ApiResourceClaimRepository.Add(claim);

                uow.ApiResourceClaimRepository.Delete(claim);

                Assert.AreEqual(null, uow.ApiResourceClaimRepository.Get(claim.Id));
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

                var claim = new ApiResourceClaimEntity
                {
                    ApiResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.ApiResourceClaimRepository.Add(claim);

                Assert.IsNotNull(uow.ApiResourceClaimRepository.GetByApiId(resource.Id).Single());
            }
        }
    }
}