using System;
using System.Linq;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Test
{
    public class IdentityClaimTest : IdentityTest
    {
        public IdentityClaimTest(IIdentityDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetClaim()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claim = new IdentityClaimEntity
                {
                    UserId = user.Id,
                    Type = "Age",
                    Value = "18"
                };
                uow.ClaimRepository.Add(claim);
                Assert.AreEqual(claim.Value, uow.ClaimRepository.Get(claim.Id).Value);
            }
        }

        public virtual void CanAddAndGetClaims()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claims = new[]
                {
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Age",
                        Value = "18"
                    },
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Sex",
                        Value = "male"
                    }
                };
                uow.ClaimRepository.AddRange(claims);

                Assert.AreEqual(claims.Length, uow.ClaimRepository.GetAll().Count());
            }
        }

        public virtual void CanGetClaimsByType()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claims = new[]
                {
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Age",
                        Value = "18"
                    },
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Sex",
                        Value = "male"
                    }
                };
                uow.ClaimRepository.AddRange(claims);

                Assert.AreEqual(claims.Single(c => c.Type == "Sex").UserId,
                    uow.ClaimRepository.GetUserIdsForClaimType("Sex").Single());
            }
        }

        public virtual void CanGetByUserAndType()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claims = new[]
                {
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Age",
                        Value = "18"
                    },
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Sex",
                        Value = "male"
                    }
                };
                uow.ClaimRepository.AddRange(claims);

                Assert.AreEqual(claims.Single(c => c.Type == "Sex").UserId,
                    uow.ClaimRepository.GetByUserAndType(user, "Sex").UserId);
            }
        }

        public virtual void CanGetByUser()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claims = new[]
                {
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Age",
                        Value = "18"
                    },
                    new IdentityClaimEntity
                    {
                        UserId = user.Id,
                        Type = "Sex",
                        Value = "male"
                    }
                };
                uow.ClaimRepository.AddRange(claims);

                Assert.AreEqual(claims.Length, uow.ClaimRepository.GetByUser(user).Count());
            }
        }

        public virtual void CanUpdateClaim()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claim = new IdentityClaimEntity
                {
                    UserId = user.Id,
                    Type = "Age",
                    Value = "18"
                };
                uow.ClaimRepository.Add(claim);


                claim.Value = "20";
                uow.ClaimRepository.Update(claim);

                Assert.AreEqual(claim.Value, uow.ClaimRepository.Get(claim.Id).Value);
            }
        }

        public virtual void CanDeleteClaim()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    LoweredUserName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);

                var claim = new IdentityClaimEntity
                {
                    UserId = user.Id,
                    Type = "Age",
                    Value = "18"
                };
                uow.ClaimRepository.Add(claim);

                uow.ClaimRepository.Delete(claim);

                Assert.AreEqual(null, uow.ClaimRepository.Get(claim.Id));
            }
        }
    }
}