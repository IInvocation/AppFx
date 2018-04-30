using System;
using System.Linq;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Test
{
    /// <summary>	(Unit Test Class) an identitiy user test. </summary>
    [TestClass]
    public class IdentityUserTest : IdentityTest
    {
        /// <summary>	Default constructor. </summary>
        public IdentityUserTest(IIdentityDataService dataService) : base(dataService)
        {
        }

        /// <summary>	(Unit Test Method) can add and get user. </summary>
        public virtual void CanAddAndGetUser()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    NormalizedName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);
                Assert.AreEqual(user.Name, uow.UserRepository.Get(user.Id).Name);
            }
        }

        /// <summary>	(Unit Test Method) can add and get user. </summary>
        public virtual void CanAddAndGetUserByIdentifier()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    NormalizedName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                var identifier = user.Identifier.ToString();
                uow.UserRepository.Add(user);
                Assert.AreEqual(user.Name, uow.UserRepository.Get(identifier).Name);
            }
        }

        public virtual void CanAddAndFindByLoweredName()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    NormalizedName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);
                Assert.AreEqual(user.Name, uow.UserRepository.FindByLoweredName(user.NormalizedName).Name);
            }
        }

        public virtual void CanAddAndFindByNormalizedEmail()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    NormalizedName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                };

                uow.UserRepository.Add(user);
                Assert.AreEqual(user.Name, uow.UserRepository.FindByNormalizedEmail(user.NormalizedEmail).Name);
            }
        }

        /// <summary>	(Unit Test Method) can add and get users. </summary>
        public virtual void CanAddAndGetUsers()
        {
            var users = new[]
            {
                new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Achim Schnell",
                    NormalizedName = "ACHIM SCHNELL",
                    Email = "a.schnell@wtschnell.de",
                    NormalizedEmail = "A.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                },
                new IdentityUserEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "Stefan Schnell",
                    NormalizedName = "STEFAN SCHNELL",
                    Email = "s.schnell@wtschnell.de",
                    NormalizedEmail = "S.SCHNELL@WTSCHNELL.DE",
                    AccessFailedCount = 0,
                    ApplicationId = 0,
                    EmailConfirmed = true,
                    IsAnonymous = false,
                    LastActivityDate = DateTime.Now
                }
            };
            using (var uow = DataService.StartUnitOfWork())
            {
                uow.UserRepository.AddRange(users);
                Assert.AreEqual(users.Length, uow.UserRepository.GetAll().Count());
            }
        }

        /// <summary>	(Unit Test Method) can update user. </summary>
        public virtual void CanUpdateUser()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Add(new IdentityUserEntity
                    {
                        Identifier = Guid.NewGuid(),
                        Name = "Stefan Schnell",
                        NormalizedName = "STEFAN SCHNELL",
                        Email = "s.schnell@wtschnell.de",
                        NormalizedEmail = "S.SCHNELL@WTSCHNELL.DE",
                        AccessFailedCount = 0,
                        ApplicationId = 0,
                        EmailConfirmed = true,
                        IsAnonymous = false,
                        LastActivityDate = DateTime.Now
                    }
                );

                user.Name = "Changed";
                uow.UserRepository.Update(user);
                Assert.AreEqual(user.Name, uow.UserRepository.Get(user.Id).Name);
            }
        }

        /// <summary>	(Unit Test Method) can delete user. </summary>
        public virtual void CanDeleteUser()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var user = uow.UserRepository.Add(new IdentityUserEntity
                    {
                        Identifier = Guid.NewGuid(),
                        Name = "Stefan Schnell",
                        NormalizedName = "STEFAN SCHNELL",
                        Email = "s.schnell@wtschnell.de",
                        NormalizedEmail = "S.SCHNELL@WTSCHNELL.DE",
                        AccessFailedCount = 0,
                        ApplicationId = 0,
                        EmailConfirmed = true,
                        IsAnonymous = false,
                        LastActivityDate = DateTime.Now
                    }
                );

                uow.UserRepository.Delete(user.Id);
                Assert.AreEqual(null, uow.UserRepository.Get(user.Id));
            }
        }
    }
}