using System;
using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class GrantTest : IdentityServerTest
    {
        public GrantTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

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

                Assert.AreEqual(null, uow.GrantRepository.Get(grant.Id));
            }
        }

        public virtual void CanGetByGrantKey()
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
                Assert.AreEqual(grant.Data, uow.GrantRepository.GetByGrantKey(grant.GrantKey).Data);
            }
        }

        public virtual void CanFindBySubjectId()
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
                Assert.AreEqual(grant.Data, uow.GrantRepository.FindBySubjectId(grant.SubjectId).First().Data);
            }
        }

        public virtual void CanRemoveByGrantKey()
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

                uow.GrantRepository.RemoveByGrantKey(grant.GrantKey);

                Assert.AreEqual(null, uow.GrantRepository.Get(grant.Id));
            }
        }

        public virtual void CanRemoveBySubjectAndClient()
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

                uow.GrantRepository.RemoveBySubjectAndClient(grant.SubjectId, grant.ClientId);

                Assert.AreEqual(null, uow.GrantRepository.Get(grant.Id));
            }
        }

        public virtual void CanRemoveBySubjectClientType()
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

                uow.GrantRepository.RemoveBySubjectClientType(grant.SubjectId, grant.ClientId, grant.Type);

                Assert.AreEqual(null, uow.GrantRepository.Get(grant.Id));
            }
        }
    }
}