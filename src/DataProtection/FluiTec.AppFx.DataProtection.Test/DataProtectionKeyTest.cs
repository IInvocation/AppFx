using FluiTec.AppFx.DataProtection.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;

namespace FluiTec.AppFx.DataProtection.Test
{
    public class DataProtectionKeyTest : DataProtectionTest
    {
        public DataProtectionKeyTest(IDataProtectionDataService dataService) : base(dataService)
        {
            if (dataService.CanMigrate())
                dataService.Migrate();
        }

        public virtual void CanAddAndGetKey()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var key = new DataProtectionKeyEntity
                {
                    FriendlyName = "MyName",
                    XmlData = new XElement("test").ToString()
                };

                uow.DataProtectionKeyRepository.Add(key);

                Assert.AreEqual(key.FriendlyName, uow.DataProtectionKeyRepository.Get(key.Id).FriendlyName);
            }
        }

        public virtual void CanAddAndGetKeys()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var keys = new[]
                {
                    new DataProtectionKeyEntity
                    {
                        FriendlyName = "MyName1",
                        XmlData = new XElement("test1").ToString()
                    },
                    new DataProtectionKeyEntity
                    {
                        FriendlyName = "MyName2",
                        XmlData = new XElement("test2").ToString()
                    }
                };
                uow.DataProtectionKeyRepository.AddRange(keys);

                Assert.AreEqual(keys.Length, uow.DataProtectionKeyRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateKey()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var key = new DataProtectionKeyEntity
                {
                    FriendlyName = "MyName",
                    XmlData = new XElement("test").ToString()
                };

                uow.DataProtectionKeyRepository.Add(key);

                key.FriendlyName = "Updated";

                uow.DataProtectionKeyRepository.Update(key);

                Assert.AreEqual(key.FriendlyName, uow.DataProtectionKeyRepository.Get(key.Id).FriendlyName);
            }
        }

        public virtual void CanDeleteKey()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var key = new DataProtectionKeyEntity
                {
                    FriendlyName = "MyName",
                    XmlData = new XElement("test").ToString()
                };

                uow.DataProtectionKeyRepository.Add(key);

                uow.DataProtectionKeyRepository.Delete(key);

                Assert.AreEqual(null, uow.DataProtectionKeyRepository.Get(key.Id));
            }
        }
    }
}
