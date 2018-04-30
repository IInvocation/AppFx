using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class ClientClaimTest : IdentityServerTest
    {
        public ClientClaimTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetClientClaim()
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

                var clientClaim = new ClientClaimEntity
                {
                    ClientId = client.Id,
                    ClaimType = "ClaimType",
                    ClaimValue = "MyValue"
                };
                uow.ClientClaimRepository.Add(clientClaim);

                Assert.AreEqual(clientClaim.ClaimValue, uow.ClientClaimRepository.Get(clientClaim.Id).ClaimValue);
            }
        }

        public virtual void CanAddAndGetClientClaims()
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

                var clientClaims = new[]
                {
                    new ClientClaimEntity
                    {
                        ClientId = client.Id,
                        ClaimType = "ClaimType",
                        ClaimValue = "MyValue"
                    },
                    new ClientClaimEntity
                    {
                        ClientId = client.Id,
                        ClaimType = "ClaimType2",
                        ClaimValue = "MyValue2"
                    }
                };
                uow.ClientClaimRepository.AddRange(clientClaims);
                Assert.AreEqual(clientClaims.Length, uow.ClientClaimRepository.GetAll().Count());
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

                var clientClaim = new ClientClaimEntity
                {
                    ClientId = client.Id,
                    ClaimType = "ClaimType",
                    ClaimValue = "MyValue"
                };
                uow.ClientClaimRepository.Add(clientClaim);

                clientClaim.ClaimValue = "changed";
                uow.ClientClaimRepository.Update(clientClaim);

                Assert.AreEqual(clientClaim.ClaimValue, uow.ClientClaimRepository.Get(clientClaim.Id).ClaimValue);
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

                var clientClaim = new ClientClaimEntity
                {
                    ClientId = client.Id,
                    ClaimType = "ClaimType",
                    ClaimValue = "MyValue"
                };
                uow.ClientClaimRepository.Add(clientClaim);

                uow.ClientClaimRepository.Delete(clientClaim);

                Assert.AreEqual(null, uow.ClientClaimRepository.Get(clientClaim.Id));
            }
        }
    }
}