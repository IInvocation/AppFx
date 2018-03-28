using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class IdentityResourceClaimTest : IdentityServerTest
    {
        public IdentityResourceClaimTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetIdentityResourceClaim()
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

                var claim = new IdentityResourceClaimEntity
                {
                    IdentityResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.IdentityResourceClaimRepository.Add(claim);

                Assert.AreEqual(claim.ClaimType, uow.IdentityResourceClaimRepository.Get(claim.Id).ClaimType);
            }
        }

        public virtual void CanAddAndGetIdentityResourceClaims()
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

                var claims = new[]
                {
                    new IdentityResourceClaimEntity
                    {
                        IdentityResourceId = resource.Id,
                        ClaimType = "ClaimType"
                    },
                    new IdentityResourceClaimEntity
                    {
                        IdentityResourceId = resource.Id,
                        ClaimType = "ClaimType2"
                    }
                };
                uow.IdentityResourceClaimRepository.AddRange(claims);
                Assert.AreEqual(claims.Length, uow.IdentityResourceClaimRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateIdentityResource()
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

                var claim = new IdentityResourceClaimEntity
                {
                    IdentityResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.IdentityResourceClaimRepository.Add(claim);

                claim.ClaimType = "changed";
                uow.IdentityResourceClaimRepository.Update(claim);

                Assert.AreEqual(claim.ClaimType, uow.IdentityResourceClaimRepository.Get(claim.Id).ClaimType);
            }
        }

        public virtual void CanDeleteIdentityResource()
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

                var claim = new IdentityResourceClaimEntity
                {
                    IdentityResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.IdentityResourceClaimRepository.Add(claim);

                uow.IdentityResourceClaimRepository.Delete(claim);

                Assert.AreEqual(null, uow.IdentityResourceClaimRepository.Get(claim.Id));
            }
        }

        public virtual void CanGetByIdentityId()
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

                var claim = new IdentityResourceClaimEntity
                {
                    IdentityResourceId = resource.Id,
                    ClaimType = "ClaimType"
                };
                uow.IdentityResourceClaimRepository.Add(claim);

                Assert.AreEqual(claim.ClaimType,
                    uow.IdentityResourceClaimRepository.GetByIdentityId(resource.Id).First().ClaimType);
            }
        }
    }
}