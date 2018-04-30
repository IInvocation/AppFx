using System;
using System.Security.Cryptography;

namespace FluiTec.AppFx.IdentityServer
{
    /// <summary>A random string creator.</summary>
    public static class RandomStringCreator
    {
        /// <summary>Generates a random string.</summary>
        /// <param name="size">   The size. </param>
        /// <returns>The random string.</returns>
        public static string GenerateRandomString(int size)
        {
            if (size < 16) throw new ArgumentException("Mininum size is 16");
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                var tokenData = new byte[size];
                rng.GetBytes(tokenData);

                return Convert.ToBase64String(tokenData);
            }
        }
    }
}