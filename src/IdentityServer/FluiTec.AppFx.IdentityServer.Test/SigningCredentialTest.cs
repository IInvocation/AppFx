using System;
using System.Linq;
using FluiTec.AppFx.IdentityServer.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.IdentityServer.Test
{
    public class SigningCredentialTest : IdentityServerTest
    {
        public SigningCredentialTest(IIdentityServerDataService dataService) : base(dataService)
        {
        }

        public virtual void CanAddAndGetSigningCredential()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var credential = new SigningCredentialEntity
                {
                    Issued = DateTime.Now,
                    Contents = "MyKey"
                };
                uow.SigningCredentialRepository.Add(credential);
                Assert.AreEqual(credential.Contents, uow.SigningCredentialRepository.Get(credential.Id).Contents);
            }
        }

        public virtual void CanAddAndGetSigningCredentials()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var credentials = new[]
                {
                    new SigningCredentialEntity
                    {
                        Issued = DateTime.Now,
                        Contents = "MyKey"
                    },
                    new SigningCredentialEntity
                    {
                        Issued = DateTime.Now,
                        Contents = "MyKey2"
                    }
                };
                uow.SigningCredentialRepository.AddRange(credentials);
                Assert.AreEqual(credentials.Length, uow.SigningCredentialRepository.GetAll().Count());
            }
        }

        public virtual void CanUpdateSigningCredential()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var credential = new SigningCredentialEntity
                {
                    Issued = DateTime.Now,
                    Contents = "MyKey"
                };
                uow.SigningCredentialRepository.Add(credential);

                credential.Contents = "changed";
                uow.SigningCredentialRepository.Update(credential);

                Assert.AreEqual(credential.Contents, uow.SigningCredentialRepository.Get(credential.Id).Contents);
            }
        }

        public virtual void CanDeleteSigningCredential()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var credential = new SigningCredentialEntity
                {
                    Issued = DateTime.Now,
                    Contents = "MyKey"
                };
                uow.SigningCredentialRepository.Add(credential);

                uow.SigningCredentialRepository.Delete(credential);

                Assert.AreEqual(null, uow.SigningCredentialRepository.Get(credential.Id));
            }
        }

        public virtual void CanGetLatest()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var credentials = new[]
                {
                    new SigningCredentialEntity
                    {
                        Issued = DateTime.Now.AddDays(1),
                        Contents = "MyKey"
                    },
                    new SigningCredentialEntity
                    {
                        Issued = DateTime.Now,
                        Contents = "MyKey2"
                    }
                };
                uow.SigningCredentialRepository.AddRange(credentials);
                Assert.AreEqual(credentials[0].Contents, uow.SigningCredentialRepository.GetLatest().Contents);
            }
        }

        public virtual void CanGetValidationValid()
        {
            using (var uow = DataService.StartUnitOfWork())
            {
                var credentials = new[]
                {
                    new SigningCredentialEntity
                    {
                        Issued = DateTime.Now.AddDays(1),
                        Contents = "MyKey"
                    },
                    new SigningCredentialEntity
                    {
                        Issued = DateTime.Now,
                        Contents = "MyKey2"
                    }
                };
                uow.SigningCredentialRepository.AddRange(credentials);
                Assert.AreEqual(credentials[0].Contents,
                    uow.SigningCredentialRepository.GetValidationValid(DateTime.Now.AddHours(1)).Single().Contents);
            }
        }
    }
}