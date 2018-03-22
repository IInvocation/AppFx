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
                    Key = resourceType.FullName + nameof(TestResource.Name)
                };

                uow.ResourceRepository.Add(resource);
                Assert.AreEqual(resource.Key, uow.ResourceRepository.Get(resource.Id).Key);
            }
        }

        /// <summary>Can add and get resources.</summary>
        public virtual void CanAddAndGetResources()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var resourceType = typeof(TestResource);

                var resources = new[] {
                    new ResourceEntity
                    {
                        Key = resourceType.FullName + nameof(TestResource.Name)
                    },
                    new ResourceEntity
                    {
                        Key = resourceType.FullName + nameof(TestResource.Value)
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
                    Key = resourceType.FullName + nameof(TestResource.Name)
                };
                uow.ResourceRepository.Add(resource);


                resource.Key = "meykey";
                uow.ResourceRepository.Update(resource);

                Assert.AreEqual(resource.Key, uow.ResourceRepository.Get(resource.Id).Key);
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
                    Key = resourceType.FullName + nameof(TestResource.Name)
                };
                uow.ResourceRepository.Add(resource);

                uow.ResourceRepository.Delete(resource);

                Assert.AreEqual(expected: null, actual: uow.ResourceRepository.Get(resource.Id));
            }
        }
    }
}
