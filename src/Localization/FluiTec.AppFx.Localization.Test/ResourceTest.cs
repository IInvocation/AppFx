using System;
using System.Linq;
using FluiTec.AppFx.Localization.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.Test
{
    /// <summary>A resource test.</summary>
    public class ResourceTest : DataServiceTest
    {
        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public ResourceTest(ILocalizationDataService dataService) : base(dataService)
        {
        }

        /// <summary>Can add and get resource.</summary>
        public virtual void CanAddAndGetResource()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resourceType = typeof(TestResource);

                var resource = new ResourceEntity
                {
                    ResourceKey = resourceType.FullName + nameof(TestResource.Name),
                    Author = "Code",
                    ModificationDate = DateTime.Now,
                    IsHidden = false
                };

                uow.ResourceRepository.Add(resource);
                Assert.AreEqual(resource.ResourceKey, uow.ResourceRepository.Get(resource.Id).ResourceKey);
            }
        }

        /// <summary>Can add and get resources.</summary>
        public virtual void CanAddAndGetResources()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resourceType = typeof(TestResource);

                var resources = new[]
                {
                    new ResourceEntity
                    {
                        ResourceKey = resourceType.FullName + nameof(TestResource.Name),
                        Author = "Code",
                        ModificationDate = DateTime.Now,
                        IsHidden = false
                    },
                    new ResourceEntity
                    {
                        ResourceKey = resourceType.FullName + nameof(TestResource.Value),
                        Author = "Code",
                        ModificationDate = DateTime.Now,
                        IsHidden = false
                    }
                };
                uow.ResourceRepository.AddRange(resources);

                Assert.AreEqual(resources.Length, uow.ResourceRepository.GetAll().Count());
            }
        }

        /// <summary>Can update resource.</summary>
        public virtual void CanUpdateResource()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resourceType = typeof(TestResource);

                var resource = new ResourceEntity
                {
                    ResourceKey = resourceType.FullName + nameof(TestResource.Name),
                    Author = "Code",
                    ModificationDate = DateTime.Now,
                    IsHidden = false
                };
                uow.ResourceRepository.Add(resource);


                resource.ResourceKey = "meykey";
                uow.ResourceRepository.Update(resource);

                Assert.AreEqual(resource.ResourceKey, uow.ResourceRepository.Get(resource.Id).ResourceKey);
            }
        }

        /// <summary>Can delete claim.</summary>
        public virtual void CanDeleteClaim()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resourceType = typeof(TestResource);

                var resource = new ResourceEntity
                {
                    ResourceKey = resourceType.FullName + nameof(TestResource.Name),
                    Author = "Code",
                    ModificationDate = DateTime.Now,
                    IsHidden = false
                };
                uow.ResourceRepository.Add(resource);

                uow.ResourceRepository.Delete(resource);

                Assert.AreEqual(null, uow.ResourceRepository.Get(resource.Id));
            }
        }
    }
}