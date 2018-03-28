using System;
using System.Linq;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Test
{
    /// <summary>	(Unit Test Class) an identity role test. </summary>
    [TestClass]
    public class IdentityRoleTest : IdentityTest
    {
        /// <summary>	Default constructor. </summary>
        public IdentityRoleTest(IIdentityDataService dataService) : base(dataService)
        {
        }

        /// <summary>	Can add and get role. </summary>
        public virtual void CanAddAndGetRole()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = new IdentityRoleEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "DummyRole",
                    ApplicationId = 0,
                    Description = "DummyRole",
                    LoweredName = "dummyrole"
                };

                uow.RoleRepository.Add(role);
                Assert.AreEqual(role.Name, uow.RoleRepository.Get(role.Id).Name);
            }
        }

        /// <summary>	Can add and get role. </summary>
        public virtual void CanAddAndGetRoleByIdentifier()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = new IdentityRoleEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "DummyRole",
                    ApplicationId = 0,
                    Description = "DummyRole",
                    LoweredName = "dummyrole"
                };

                uow.RoleRepository.Add(role);
                Assert.AreEqual(role.Name, uow.RoleRepository.Get(role.Identifier.ToString()).Name);
            }
        }

        public virtual void CanAddAndFindByLoweredName()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = new IdentityRoleEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "DummyRole",
                    ApplicationId = 0,
                    Description = "DummyRole",
                    LoweredName = "dummyrole"
                };

                uow.RoleRepository.Add(role);
                Assert.AreEqual(role.Name, uow.RoleRepository.FindByLoweredName(role.LoweredName).Name);
            }
        }

        public virtual void CanAddAndFindByIds()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = new IdentityRoleEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "DummyRole",
                    ApplicationId = 0,
                    Description = "DummyRole",
                    LoweredName = "dummyrole"
                };

                uow.RoleRepository.Add(role);
                Assert.AreEqual(1, uow.RoleRepository.FindByIds(new[] {role.Id}).Count());
            }
        }

        /// <summary>	Can add and get roles. </summary>
        public virtual void CanAddAndGetRoles()
        {
            var roles = new[]
            {
                new IdentityRoleEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "DummyRole",
                    ApplicationId = 0,
                    Description = "DummyRole",
                    LoweredName = "dummyrole"
                },
                new IdentityRoleEntity
                {
                    Identifier = Guid.NewGuid(),
                    Name = "DummyRole2",
                    ApplicationId = 0,
                    Description = "DummyRole2",
                    LoweredName = "dummyrole2"
                }
            };
            using (var uow = DataService.StartUnitOfWork())
            {
                uow.RoleRepository.AddRange(roles);
                Assert.AreEqual(roles.Length, uow.RoleRepository.GetAll().Count());
            }
        }

        /// <summary>	Can update role. </summary>
        public virtual void CanUpdateRole()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = uow.RoleRepository.Add(new IdentityRoleEntity
                    {
                        Identifier = Guid.NewGuid(),
                        Name = "DummyRole2",
                        ApplicationId = 0,
                        Description = "DummyRole2",
                        LoweredName = "dummyrole2"
                    }
                );

                role.Name = "Changed";
                uow.RoleRepository.Update(role);
                Assert.AreEqual(role.Name, uow.RoleRepository.Get(role.Id).Name);
            }
        }

        /// <summary>	Can delete role. </summary>
        public virtual void CanDeleteRole()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = uow.RoleRepository.Add(new IdentityRoleEntity
                    {
                        Identifier = Guid.NewGuid(),
                        Name = "DummyRole2",
                        ApplicationId = 0,
                        Description = "DummyRole2",
                        LoweredName = "dummyrole2"
                    }
                );

                uow.RoleRepository.Delete(role.Id);
                Assert.AreEqual(null, uow.RoleRepository.Get(role.Id));
            }
        }
    }
}