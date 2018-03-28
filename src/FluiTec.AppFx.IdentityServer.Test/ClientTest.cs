using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ClientTest : IdentityServerTest
    {
        public ClientTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetClient()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);
                Assert.AreEqual(client.Name, uow.ClientRepository.Get(client.Id).Name);
            }
        }

        public virtual void CanAddAndGetClients()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var clients = new[]
                {
                    new ClientEntity
                    {
                        ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd1",
                        Name = "TestClient",
                        Secret = "MySecret1",
                        AllowOfflineAccess = false,
                        GrantTypes = "client_credentials"
                    },
                    new ClientEntity
                    {
                        ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd2",
                        Name = "TestClient",
                        Secret = "MySecret2",
                        AllowOfflineAccess = false,
                        GrantTypes = "client_credentials"
                    }
                };
                uow.ClientRepository.AddRange(clients);
                Assert.AreEqual(clients.Length, uow.ClientRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateClient()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);

                client.Name = "changed";

                uow.ClientRepository.Update(client);
                Assert.AreEqual(client.Name, uow.ClientRepository.Get(client.Id).Name);
            }
        }

        public virtual void CanDeleteClient()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);
                uow.ClientRepository.Delete(client);

                Assert.AreEqual(null, uow.ClientRepository.Get(client.Id));
            }
        }

        public virtual void CanGetByClientId()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);
                Assert.AreEqual(client.Name, uow.ClientRepository.GetByClientId(client.ClientId).Name);
            }
        }

        public virtual void CanGetCompoundByClientId()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var client = new ClientEntity
                {
                    ClientId = "fluitec.appfx.lkjsadlkjsalkjaslkjdasd",
                    Name = "TestClient",
                    Secret = "MySecret",
                    AllowOfflineAccess = false,
                    GrantTypes = "client_credentials"
                };
                uow.ClientRepository.Add(client);
                Assert.AreEqual(client.Name, uow.ClientRepository.GetCompoundByClientId(client.ClientId).Client.Name);
            }
        }
    }
}