using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FluiTec.AppFx.Identity
{
    /// <summary>   Manager for name ignoring users. </summary>
    public class NameIgnoringUserManager : UserManager<IdentityUserEntity>
    {
        /// <summary>   Constructor. </summary>
        /// <param name="store">                The store. </param>
        /// <param name="optionsAccessor">      The options accessor. </param>
        /// <param name="passwordHasher">       The password hasher. </param>
        /// <param name="userValidators">       The user validators. </param>
        /// <param name="passwordValidators">   The password validators. </param>
        /// <param name="keyNormalizer">        The key normalizer. </param>
        /// <param name="errors">               The errors. </param>
        /// <param name="services">             The services. </param>
        /// <param name="logger">               The logger. </param>
        public NameIgnoringUserManager(IUserStore<IdentityUserEntity> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<IdentityUserEntity> passwordHasher, IEnumerable<IUserValidator<IdentityUserEntity>> userValidators, IEnumerable<IPasswordValidator<IdentityUserEntity>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<IdentityUserEntity>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {

        }

        /// <summary>
        ///     Creates the specified <paramref name="user" /> in the backing store with no password, as
        ///     an asynchronous operation.
        /// </summary>
        /// <param name="user"> The user to create. </param>
        /// <returns>
        ///     The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous
        ///     operation, containing the <see cref="T:Microsoft.AspNetCore.Identity.IdentityResult" />
        ///     of the operation.
        /// </returns>
        public override async Task<IdentityResult> CreateAsync(IdentityUserEntity user)
        {
            ThrowIfDisposed();
            if (SupportsUserSecurityStamp)
            {
                if (Store is IUserSecurityStampStore<IdentityUserEntity> store)
                    await store.SetSecurityStampAsync(user, Guid.NewGuid().ToString(), CancellationToken);
                else
                    throw new NotImplementedException();
            }

            user.NormalizedName = user.Name.ToUpper();
            user.NormalizedEmail = user.Email.ToUpper();
            user.LockoutEnabled = SupportsUserLockout;

            var validator = UserValidators.SingleOrDefault(v => v.GetType() == typeof(UserValidator<IdentityUserEntity>));
            IdentityResult result;
            if (validator != null)
            {
                result = await validator.ValidateAsync(this, user);
            }
            else
            {
                result = await UserValidators.Last().ValidateAsync(this, user);
            }

            if (!result.Succeeded)
            {
                return result;
            }

            var res = await Store.CreateAsync(user, CancellationToken);

            return IdentityResult.Success;
        }
    }
}
