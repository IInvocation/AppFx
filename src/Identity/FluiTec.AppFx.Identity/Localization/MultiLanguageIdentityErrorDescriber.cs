using FluiTec.AppFx.Identity.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.Identity.Localization
{
    /// <summary>A multi language identity error describer.</summary>
    public class MultiLanguageIdentityErrorDescriber : IdentityErrorDescriber
    {
        /// <summary>The localizer.</summary>
        private readonly IStringLocalizer<IdentityResource> _localizer;

        /// <summary>Name of the type.</summary>
        private readonly string _typeName;

        /// <summary>Constructor.</summary>
        /// <param name="localizer">    The localizer. </param>
        public MultiLanguageIdentityErrorDescriber(IStringLocalizer<IdentityResource> localizer)
        {
            _typeName = typeof(IdentityResource).FullName;
            _localizer = localizer;
        }

        /// <summary>From resource.</summary>
        /// <param name="errorName">    Name of the error. </param>
        /// <param name="args">         A variable-length parameters list containing arguments. </param>
        /// <returns>An IdentityError.</returns>
        private IdentityError FromStringLocalizer(string errorName, params object[] args)
        {
            var resString = _localizer.GetString($"{_typeName}.{errorName}", args);
            return new IdentityError
            {
                Code = errorName,
                Description = resString
            };
        }

        #region IdentityErrorDescriber

        /// <summary>	Duplicate email. </summary>
        /// <param name="email">	The email. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError DuplicateEmail(string email)
        {
            return FromStringLocalizer(nameof(DuplicateEmail), email);
        }

        /// <summary>	Duplicate user name. </summary>
        /// <param name="userName">	Name of the user. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError DuplicateUserName(string userName)
        {
            return FromStringLocalizer(nameof(DuplicateUserName), userName);
        }

        /// <summary>	Invalid email. </summary>
        /// <param name="email">	The email. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError InvalidEmail(string email)
        {
            return FromStringLocalizer(nameof(InvalidEmail), email);
        }

        /// <summary>	Default error. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError DefaultError()
        {
            return FromStringLocalizer(nameof(DefaultError));
        }

        /// <summary>	Duplicate role name. </summary>
        /// <param name="role">	The role. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError DuplicateRoleName(string role)
        {
            return FromStringLocalizer(nameof(DuplicateRoleName), role);
        }

        /// <summary>	Invalid role name. </summary>
        /// <param name="role">	The role. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError InvalidRoleName(string role)
        {
            return FromStringLocalizer(nameof(InvalidRoleName), role);
        }

        /// <summary>	Invalid token. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError InvalidToken()
        {
            return FromStringLocalizer(nameof(InvalidToken));
        }

        /// <summary>	Invalid user name. </summary>
        /// <param name="userName">	Name of the user. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError InvalidUserName(string userName)
        {
            return FromStringLocalizer(nameof(InvalidUserName), userName);
        }

        /// <summary>	Concurrency failure. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError ConcurrencyFailure()
        {
            return FromStringLocalizer(nameof(ConcurrencyFailure));
        }

        /// <summary>	Login already associated. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError LoginAlreadyAssociated()
        {
            return FromStringLocalizer(nameof(LoginAlreadyAssociated));
        }

        /// <summary>	Password mismatch. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError PasswordMismatch()
        {
            return FromStringLocalizer(nameof(PasswordMismatch));
        }

        /// <summary>	Password requires digit. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError PasswordRequiresDigit()
        {
            return FromStringLocalizer(nameof(PasswordRequiresDigit));
        }

        /// <summary>	Password requires lower. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError PasswordRequiresLower()
        {
            return FromStringLocalizer(nameof(PasswordRequiresLower));
        }

        /// <summary>	Password requires non alphanumeric. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return FromStringLocalizer(nameof(PasswordRequiresNonAlphanumeric));
        }

        /// <summary>	Password requires upper. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError PasswordRequiresUpper()
        {
            return FromStringLocalizer(nameof(PasswordRequiresUpper));
        }

        /// <summary>	Password too short. </summary>
        /// <param name="length">	The length. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError PasswordTooShort(int length)
        {
            return FromStringLocalizer(nameof(PasswordTooShort), length);
        }

        /// <summary>	User already has password. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError UserAlreadyHasPassword()
        {
            return FromStringLocalizer(nameof(UserAlreadyHasPassword));
        }

        /// <summary>	User already in role. </summary>
        /// <param name="role">	The role. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError UserAlreadyInRole(string role)
        {
            return FromStringLocalizer(nameof(UserAlreadyInRole), role);
        }

        /// <summary>	User lockout not enabled. </summary>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError UserLockoutNotEnabled()
        {
            return FromStringLocalizer(nameof(UserLockoutNotEnabled));
        }

        /// <summary>	User not in role. </summary>
        /// <param name="role">	The role. </param>
        /// <returns>	An IdentityError. </returns>
        public override IdentityError UserNotInRole(string role)
        {
            return FromStringLocalizer(nameof(UserNotInRole), role);
        }

        #endregion
    }
}