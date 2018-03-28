using System.Linq;
using FluiTec.AppFx.Authorization.Activity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Authorization.Activity.Test
{
    [TestClass]
    public class ActivityTest : AuthorizationTest
    {
        /// <summary>Specialised constructor for use only by derived class.</summary>
        /// <param name="dataService">  The data service. </param>
        protected ActivityTest(IAuthorizationDataService dataService) : base(dataService)
        {
        }

        /// <summary>Can add and get activity.</summary>
        public virtual void CanAddAndGetActivity()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var activity = new ActivityEntity
                {
                    Name = "MyActivity",
                    ResourceName = "MyResource"
                };

                uow.ActivityRepository.Add(activity);
                Assert.AreEqual(activity.Name, uow.ActivityRepository.Get(activity.Id).Name);
            }
        }

        /// <summary>Can add and get activities.</summary>
        public virtual void CanAddAndGetActivities()
        {
            var roles = new[]
            {
                new ActivityEntity
                {
                    Name = "MyActivity1",
                    ResourceName = "MyResource"
                },
                new ActivityEntity
                {
                    Name = "MyActivity2",
                    ResourceName = "MyResource"
                }
            };
            using (var uow = DataService.StartUnitOfWork())
            {
                uow.ActivityRepository.AddRange(roles);
                Assert.AreEqual(roles.Length, uow.ActivityRepository.GetAll().Count());
            }
        }

        /// <summary>Can update activity.</summary>
        public virtual void CanUpdateActivity()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var activity = uow.ActivityRepository.Add(new ActivityEntity
                    {
                        Name = "Dummy",
                        ResourceName = "MyResource"
                    }
                );

                activity.Name = "Changed";
                uow.ActivityRepository.Update(activity);
                Assert.AreEqual(activity.Name, uow.ActivityRepository.Get(activity.Id).Name);
            }
        }

        /// <summary>Can delete activity.</summary>
        public virtual void CanDeleteActivity()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var role = uow.ActivityRepository.Add(new ActivityEntity
                    {
                        Name = "Dummy",
                        ResourceName = "MyResource"
                    }
                );

                uow.ActivityRepository.Delete(role.Id);
                Assert.AreEqual(null, uow.ActivityRepository.Get(role.Id));
            }
        }
    }
}