using System;
using System.Linq;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Test
{
    /// <summary>	An identity userlogin test. </summary>
    public class IdentityUserLoginTest : IdentityTest
    {
        /// <summary>	Constructor. </summary>
        /// <param name="dataService">	The data service. </param>
        public IdentityUserLoginTest(IIdentityDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetLogin()
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

                var login = new IdentityUserLoginEntity
                {
                    UserId = user.Identifier,
                    ProviderName = "Google",
                    ProviderKey = "MyKey",
                    ProviderDisplayName = null
                };
                uow.LoginRepository.Add(login);
                Assert.AreEqual(login.ProviderKey, uow.LoginRepository.Get(login.Id).ProviderKey);
            }
        }

        public virtual void CanAddAndFindByUserId()
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

                var login = new IdentityUserLoginEntity
                {
                    UserId = user.Identifier,
                    ProviderName = "Google",
                    ProviderKey = "MyKey",
                    ProviderDisplayName = null
                };
                uow.LoginRepository.Add(login);
                Assert.AreEqual(login.ProviderKey,
                    uow.LoginRepository.FindByUserId(user.Identifier).Single().ProviderKey);
            }
        }

        public virtual void CanAddAndGetLogins()
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

                var logins = new[]
                {
                    new IdentityUserLoginEntity
                    {
                        UserId = user.Identifier,
                        ProviderName = "Google",
                        ProviderKey = "askljökadöäsadFKÖÄ'sadasasd",
                        ProviderDisplayName = null
                    },
                    new IdentityUserLoginEntity
                    {
                        UserId = user.Identifier,
                        ProviderName = "Google",
                        ProviderKey = "MyKey",
                        ProviderDisplayName = null
                    }
                };
                uow.LoginRepository.AddRange(logins);
                Assert.AreEqual(logins.Length, uow.LoginRepository.GetAll().Count());
            }
        }

        public virtual void CanFindByNameAndKey()
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

                var logins = new[]
                {
                    new IdentityUserLoginEntity
                    {
                        UserId = user.Identifier,
                        ProviderName = "Google",
                        ProviderKey = "askljökadöäsadFKÖÄ'sadasasd",
                        ProviderDisplayName = null
                    },
                    new IdentityUserLoginEntity
                    {
                        UserId = user.Identifier,
                        ProviderName = "Google",
                        ProviderKey = "MyKey",
                        ProviderDisplayName = null
                    }
                };
                uow.LoginRepository.AddRange(logins);

                var entity = uow.LoginRepository.FindByNameAndKey("Google", "MyKey");
                Assert.IsNotNull(entity);
            }
        }

        public virtual void CanUpdateLogin()
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

                var login = new IdentityUserLoginEntity
                {
                    UserId = user.Identifier,
                    ProviderName = "Google",
                    ProviderKey = "MyKey",
                    ProviderDisplayName = null
                };
                uow.LoginRepository.Add(login);

                login.ProviderKey = "changed";
                uow.LoginRepository.Update(login);
                Assert.AreEqual(login.ProviderKey, uow.LoginRepository.Get(login.Id).ProviderKey);
            }
        }

        public virtual void CanDeleteUser()
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

                var login = new IdentityUserLoginEntity
                {
                    UserId = user.Identifier,
                    ProviderName = "Google",
                    ProviderKey = "MyKey",
                    ProviderDisplayName = null
                };
                uow.LoginRepository.Add(login);

                uow.LoginRepository.Delete(login.Id);
                Assert.AreEqual(null, uow.LoginRepository.Get(login.Id));
            }
        }

        public virtual void CanRemoveByNameAndKey()
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

                var login = new IdentityUserLoginEntity
                {
                    UserId = user.Identifier,
                    ProviderName = "Google",
                    ProviderKey = "MyKey",
                    ProviderDisplayName = null
                };
                uow.LoginRepository.Add(login);

                uow.LoginRepository.RemoveByNameAndKey(login.ProviderName, login.ProviderKey);
                Assert.AreEqual(null, uow.LoginRepository.Get(login.Id));
            }
        }
    }
}