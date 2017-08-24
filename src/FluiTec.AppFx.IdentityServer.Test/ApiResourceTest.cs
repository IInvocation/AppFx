using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ApiResourceTest : IdentityServerTest
    {
		public ApiResourceTest(IIdentityServerDataService dataService) : base(dataService) { }

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

			    Assert.AreEqual(expected: null, actual: uow.ApiResourceRepository.Get(resource.Id));
		    }
	    }
	}
}
