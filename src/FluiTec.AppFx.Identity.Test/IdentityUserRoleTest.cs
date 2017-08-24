using System;
using System.Linq;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Identity.Test
{
	[TestClass]
	public class IdentityUserRoleTest : IdentityTest
	{
		/// <summary>	Default constructor. </summary>
		public IdentityUserRoleTest(IIdentityDataService dataService) : base(dataService) { }

		/// <summary>	Can add and get user role. </summary>
		public virtual void CanAddAndGetUserRole()
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

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};
				uow.RoleRepository.Add(role);

				var userRole = new IdentityUserRoleEntity
				{
					UserId = user.Id,
					RoleId = role.Id
				};
				userRole = uow.UserRoleRepository.Add(userRole);

				Assert.AreEqual(userRole.RoleId, uow.UserRoleRepository.Get(userRole.Id).RoleId);
				Assert.AreEqual(userRole.UserId, uow.UserRoleRepository.Get(userRole.Id).UserId);
			}
		}

		public virtual void CanAddAndFindByUserIdAndRoleId()
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

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};
				uow.RoleRepository.Add(role);

				var userRole = new IdentityUserRoleEntity
				{
					UserId = user.Id,
					RoleId = role.Id
				};
				userRole = uow.UserRoleRepository.Add(userRole);

				Assert.AreEqual(userRole.RoleId, uow.UserRoleRepository.FindByUserIdAndRoleId(user.Id, role.Id).RoleId);
			}
		}

		public virtual void CanAddAndFindByUser()
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

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};
				uow.RoleRepository.Add(role);

				var userRole = new IdentityUserRoleEntity
				{
					UserId = user.Id,
					RoleId = role.Id
				};
				userRole = uow.UserRoleRepository.Add(userRole);

				Assert.AreEqual(userRole.RoleId, uow.UserRoleRepository.FindByUser(user).Single());
			}
		}

		public virtual void CanAddAndFindByRole()
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

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};
				uow.RoleRepository.Add(role);

				var userRole = new IdentityUserRoleEntity
				{
					UserId = user.Id,
					RoleId = role.Id
				};
				uow.UserRoleRepository.Add(userRole);

				Assert.AreEqual(user.Id, uow.UserRoleRepository.FindByRole(role).Single());
			}
		}

		public virtual void CanAddAndGetUserRoles()
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
				user = uow.UserRepository.Add(user);
				var user2 = new IdentityUserEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "Stefan Schnell",
					LoweredUserName = "STEFAN SCHNELL",
					Email = "s.schnell@wtschnell.de",
					NormalizedEmail = "S.SCHNELL@WTSCHNELL.DE",
					AccessFailedCount = 0,
					ApplicationId = 0,
					EmailConfirmed = true,
					IsAnonymous = false,
					LastActivityDate = DateTime.Now
				};
				user2 = uow.UserRepository.Add(user2);

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};

				role = uow.RoleRepository.Add(role);

				var userRoles = new[] {
					new IdentityUserRoleEntity
					{
						UserId = user.Id,
						RoleId = role.Id
					},
					new IdentityUserRoleEntity
					{
						UserId = user2.Id,
						RoleId = role.Id
					}
				};
				uow.UserRoleRepository.AddRange(userRoles);
				Assert.AreEqual(userRoles.Length, uow.UserRoleRepository.GetAll().Count());
			}
		}

		public virtual void CanUpdateUserRole()
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
				var user2 = new IdentityUserEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "Stefan Schnell",
					LoweredUserName = "STEFAN SCHNELL",
					Email = "s.schnell@wtschnell.de",
					NormalizedEmail = "S.SCHNELL@WTSCHNELL.DE",
					AccessFailedCount = 0,
					ApplicationId = 0,
					EmailConfirmed = true,
					IsAnonymous = false,
					LastActivityDate = DateTime.Now
				};
				uow.UserRepository.Add(user2);

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};
				uow.RoleRepository.Add(role);

				var userRole = new IdentityUserRoleEntity
				{
					UserId = user.Id,
					RoleId = role.Id
				};
				userRole = uow.UserRoleRepository.Add(userRole);
				userRole.UserId = user2.Id;
				uow.UserRoleRepository.Update(userRole);

				Assert.AreEqual(userRole.UserId, uow.UserRoleRepository.Get(userRole.Id).UserId);
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

				var role = new IdentityRoleEntity
				{
					Identifier = Guid.NewGuid(),
					Name = "DummyRole",
					ApplicationId = 0,
					Description = "DummyRole",
					LoweredName = "dummyrole"
				};
				uow.RoleRepository.Add(role);

				var userRole = new IdentityUserRoleEntity
				{
					UserId = user.Id,
					RoleId = role.Id
				};
				uow.UserRoleRepository.Add(userRole);

				uow.UserRoleRepository.Delete(userRole.Id);
				Assert.AreEqual(expected: null, actual: uow.UserRoleRepository.Get(userRole.Id));
			}
		}
	}
}