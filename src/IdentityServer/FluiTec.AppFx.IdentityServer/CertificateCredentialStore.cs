using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FluiTec.AppFx.IdentityServer.Configuration;
using IdentityServer4.Stores;
using Microsoft.IdentityModel.Tokens;

namespace FluiTec.AppFx.IdentityServer
{
    /// <summary>A certificate credential store.</summary>
    public class CertificateCredentialStore : ISigningCredentialStore, IValidationKeysStore
    {
        /// <summary>Options for controlling the operation.</summary>
        private readonly CertificateOptions _options;

        /// <summary>Constructor.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="options">  Options for controlling the operation. </param>
        public CertificateCredentialStore(CertificateOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>Gets the signing credentials.</summary>
        /// <returns>The asynchronous result that yields the signing credentials asynchronous.</returns>
        public Task<SigningCredentials> GetSigningCredentialsAsync()
        {
            var cert = GetCertificate(_options.CurrentThumbprint, StoreLocation.LocalMachine, StoreName.My);
            var credentials = new SigningCredentials(FromCertificate(cert), "RS256");
            return Task.FromResult(credentials);
        }

        /// <summary>Gets all validation keys.</summary>
        /// <returns>The asynchronous result that yields an enumerator that allows foreach to be used to
        /// process the validation keys asynchronous in this collection.</returns>
        public Task<IEnumerable<SecurityKey>> GetValidationKeysAsync()
        {
            var keys = new List<SecurityKey>
            {
                FromCertificate(GetCertificate(_options.CurrentThumbprint, StoreLocation.LocalMachine, StoreName.My))
            };
            if (_options.ValidationThumbprints != null && _options.ValidationThumbprints.Any())
                keys.AddRange(_options.ValidationThumbprints.Select(thumb => FromCertificate(GetCertificate(thumb, StoreLocation.LocalMachine, StoreName.My))));

            return Task.FromResult<IEnumerable<SecurityKey>>(keys);
        }

        /// <summary>Gets a certificate.</summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        /// <param name="thumbprint">   The thumbprint. </param>
        /// <param name="location">     The location. </param>
        /// <param name="storeName">         The storeName. </param>
        /// <returns>The certificate.</returns>
        private X509Certificate2 GetCertificate(string thumbprint, StoreLocation location, StoreName storeName)
        {
            using (var store = new X509Store(storeName, location))
            {
                store.Open(OpenFlags.ReadOnly);
                var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                if (certCollection.Count == 0)
                    throw new Exception("No certificate found containing the specified thumbprint.");

                return certCollection[0];
            }
        }

        /// <summary>Initializes this object from the given from certificate.</summary>
        /// <param name="certificate">  The certificate. </param>
        /// <returns>A SecurityKey.</returns>
        private SecurityKey FromCertificate(X509Certificate2 certificate)
        {
            return new X509SecurityKey(certificate);
        }
    }
}