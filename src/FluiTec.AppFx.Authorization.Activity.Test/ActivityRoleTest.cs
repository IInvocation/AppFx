using System;
using System.Linq;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Authorization.Activity.Test
{
    /// <summary>An activity role test.</summary>
    public class ActivityRoleTest : AuthorizationTest
    {
        private readonly IIdentityDataService _identityDataService;

        /// <summary>Specialised constructor for use only by derived class.</summary>
        /// <param name="dataService">          The data service. </param>
        /// <param name="identityDataService">  The identity data service. </param>
        protected ActivityRoleTest(IAuthorizationDataService dataService, IIdentityDataService identityDataService) :
            base(dataService)
        {
            _identityDataService = identityDataService;
        }

        /// <summary>Can add and get activity.</summary>
        public virtual void CanAddAndGetActivityRole()
        {
            var role = new IdentityRoleEntity
            {
                ApplicationId = 0,
                Description = "MyRole",
                Identifier = Guid.NewGuid(),
                LoweredName = "myrole",
                Name = "MyRole"
            };
            using (var iUow = _identityDataService.StartUnitOfWork())
            {
                role = iUow.RoleRepository.Add(role);
                iUow.Commit();
            }

            try
            {
                using (var uow = DataService.StartUnitOfWork())
                {
                    var activity = new ActivityEntity
                    {
                        Name = "MyActivity",
                        ResourceName = "MyResource"
                    };
                    activity = uow.ActivityRepository.Add(activity);

                    var aRole = new ActivityRoleEntity
                    {
                        ActivityId = activity.Id,
                        RoleId = role.Id,
                        Allow = true
                    };


                    uow.ActivityRoleRepository.Add(aRole);

                    Assert.AreEqual(aRole.Id, uow.ActivityRoleRepository.Get(aRole.Id).Id);
                }
            }
            finally
            {
                using (var iUow = _identityDataService.StartUnitOfWork())
                {
                    iUow.RoleRepository.Delete(role);
                    iUow.Commit();
                }
            }
        }

        /// <summary>Can add and get activities.</summary>
        public virtual void CanAddAndGetActivityRoles()
        {
            var activity1 = new ActivityEntity
            {
                Name = "MyActivity",
                ResourceName = "MyResource"
            };
            var activity2 = new ActivityEntity
            {
                Name = "MyActivity",
                ResourceName = "MyResource"
            };

            var role = new IdentityRoleEntity
            {
                ApplicationId = 0,
                Description = "MyRole",
                Identifier = Guid.NewGuid(),
                LoweredName = "myrole",
                Name = "MyRole"
            };

            using (var iUow = _identityDataService.StartUnitOfWork())
            {
                role = iUow.RoleRepository.Add(role);
                iUow.Commit();
            }

            try
            {
                using (var uow = DataService.StartUnitOfWork())
                {
                    activity1 = uow.ActivityRepository.Add(activity1);
                    activity2 = uow.ActivityRepository.Add(activity2);

                    var aRoles = new[]
                    {
                        new ActivityRoleEntity
                        {
                            ActivityId = activity1.Id,
                            RoleId = role.Id,
                            Allow = true
                        },
                        new ActivityRoleEntity
                        {
                            ActivityId = activity2.Id,
                            RoleId = role.Id,
                            Allow = true
                        }
                    };

                    uow.ActivityRoleRepository.AddRange(aRoles);
                    Assert.AreEqual(aRoles.Length, uow.ActivityRoleRepository.GetAll().Count());
                }
            }
            finally
            {
                using (var iUow = _identityDataService.StartUnitOfWork())
                {
                    iUow.RoleRepository.Delete(role);
                    iUow.Commit();
                }
            }
        }

        /// <summary>Can update activity.</summary>
        public virtual void CanUpdateActivityRole()
        {
            var role = new IdentityRoleEntity
            {
                ApplicationId = 0,
                Description = "MyRole",
                Identifier = Guid.NewGuid(),
                LoweredName = "myrole",
                Name = "MyRole"
            };
            using (var iUow = _identityDataService.StartUnitOfWork())
            {
                role = iUow.RoleRepository.Add(role);
                iUow.Commit();
            }

            try
            {
                using (var uow = DataService.StartUnitOfWork())
                {
                    var activity = new ActivityEntity
                    {
                        Name = "MyActivity",
                        ResourceName = "MyResource"
                    };
                    activity = uow.ActivityRepository.Add(activity);

                    var aRole = new ActivityRoleEntity
                    {
                        ActivityId = activity.Id,
                        RoleId = role.Id,
                        Allow = true
                    };

                    uow.ActivityRoleRepository.Add(aRole);

                    aRole.Allow = false;
                    uow.ActivityRoleRepository.Update(aRole);

                    Assert.AreEqual(aRole.Allow, uow.ActivityRoleRepository.Get(aRole.Id).Allow);
                }
            }
            finally
            {
                using (var iUow = _identityDataService.StartUnitOfWork())
                {
                    iUow.RoleRepository.Delete(role);
                    iUow.Commit();
                }
            }
        }

        /// <summary>Can delete activity.</summary>
        public virtual void CanDeleteActivityRole()
        {
            var role = new IdentityRoleEntity
            {
                ApplicationId = 0,
                Description = "MyRole",
                Identifier = Guid.NewGuid(),
                LoweredName = "myrole",
                Name = "MyRole"
            };
            using (var iUow = _identityDataService.StartUnitOfWork())
            {
                role = iUow.RoleRepository.Add(role);
                iUow.Commit();
            }

            try
            {
                using (var uow = DataService.StartUnitOfWork())
                {
                    var activity = new ActivityEntity
                    {
                        Name = "MyActivity",
                        ResourceName = "MyResource"
                    };
                    activity = uow.ActivityRepository.Add(activity);

                    var aRole = new ActivityRoleEntity
                    {
                        ActivityId = activity.Id,
                        RoleId = role.Id,
                        Allow = true
                    };

                    uow.ActivityRoleRepository.Add(aRole);

                    aRole.Allow = false;
                    uow.ActivityRoleRepository.Delete(aRole);

                    Assert.AreEqual(null, uow.ActivityRoleRepository.Get(aRole.Id));
                }
            }
            finally
            {
                using (var iUow = _identityDataService.StartUnitOfWork())
                {
                    iUow.RoleRepository.Delete(role);
                    iUow.Commit();
                }
            }
        }
    }
}