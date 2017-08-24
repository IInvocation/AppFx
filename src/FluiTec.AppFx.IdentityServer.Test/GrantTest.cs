using System;
using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class GrantTest : IdentityServerTest
    {
		public GrantTest(IIdentityServerDataService dataService) : base(dataService) { }

	    public virtual void CanAddAndGetGrant()
	    {
		    using (var uow = DataService.StartUnitOfWork())
		    {
			    var grant = new GrantEntity
			    {
				    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
					CreationTime = DateTime.Now,
					Data = "Data",
					GrantKey = "MyKey",
					SubjectId = Guid.NewGuid().ToString(),
					Type = "Type"
			    };
			    uow.GrantRepository.Add(grant);
			    Assert.AreEqual(grant.Data, uow.GrantRepository.Get(grant.Id).Data);
		    }
	    }

	    public virtual void CanAddAndGetGrants()
	    {
		    using (var uow = DataService.StartUnitOfWork())
		    {
			    var grants = new[]
			    {
					new GrantEntity
				    {
					    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
					    CreationTime = DateTime.Now,
					    Data = "Data",
					    GrantKey = "MyKey",
					    SubjectId = Guid.NewGuid().ToString(),
					    Type = "Type"
				    },
					new GrantEntity
					{
						ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
						CreationTime = DateTime.Now,
						Data = "Data2",
						GrantKey = "MyKey2",
						SubjectId = Guid.NewGuid().ToString(),
						Type = "Type2"
					}
				};
			    uow.GrantRepository.AddRange(grants);
			    Assert.AreEqual(grants.Length, uow.GrantRepository.GetAll().Count());
		    }
	    }

	    public virtual void CanUpdateGrant()
	    {
		    using (var uow = DataService.StartUnitOfWork())
		    {
				var grant = new GrantEntity
			    {
				    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
				    CreationTime = DateTime.Now,
				    Data = "Data",
				    GrantKey = "MyKey",
				    SubjectId = Guid.NewGuid().ToString(),
				    Type = "Type"
			    };
			    uow.GrantRepository.Add(grant);

				grant.Data = "changed";

			    uow.GrantRepository.Update(grant);
			    Assert.AreEqual(grant.Data, uow.GrantRepository.Get(grant.Id).Data);
		    }
	    }

	    public virtual void CanDeleteGrant()
	    {
		    using (var uow = DataService.StartUnitOfWork())
		    {
				var grant = new GrantEntity
			    {
				    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
				    CreationTime = DateTime.Now,
				    Data = "Data",
				    GrantKey = "MyKey",
				    SubjectId = Guid.NewGuid().ToString(),
				    Type = "Type"
			    };
			    uow.GrantRepository.Add(grant);

				uow.GrantRepository.Delete(grant);

			    Assert.AreEqual(expected: null, actual: uow.GrantRepository.Get(grant.Id));
		    }
	    }
	}
}
