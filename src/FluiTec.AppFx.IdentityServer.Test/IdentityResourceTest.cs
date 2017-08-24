using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
	public class IdentityResourceTest : IdentityServerTest
	{
		public IdentityResourceTest(IIdentityServerDataService dataService) : base(dataService) { }

		public virtual void CanAddAndGetIdentityResource()
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
				Assert.AreEqual(resource.Name, uow.IdentityResourceRepository.Get(resource.Id).Name);
			}
		}

		public virtual void CanAddAndGetIdentityResources()
		{
			using (var uow = DataService.StartUnitOfWork())
			{
				var resources = new[]
				{
					new IdentityResourceEntity
					{
						Name = "openid",
						Description = "OpenId-Scope",
						DisplayName = "OpenId",
						Emphasize = true,
						Required = true,
						ShowInDiscoveryDocument = true
					},
					new IdentityResourceEntity
					{
						Name = "profile",
						Description = "Profile-Scope",
						DisplayName = "Profile",
						Emphasize = true,
						Required = true,
						ShowInDiscoveryDocument = true
					}
				};
				uow.IdentityResourceRepository.AddRange(resources);
				Assert.AreEqual(resources.Length, uow.IdentityResourceRepository.GetAll().Count());
			}
		}

		public virtual void CanUpdateResource()
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

				resource.Name = "changed";
				uow.IdentityResourceRepository.Update(resource);

				Assert.AreEqual(resource.Name, uow.IdentityResourceRepository.Get(resource.Id).Name);
			}
		}

		public virtual void CanDeleteResource()
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

				uow.IdentityResourceRepository.Delete(resource);

				Assert.AreEqual(expected: null, actual: uow.IdentityResourceRepository.Get(resource.Id));
			}
		}
	}
}