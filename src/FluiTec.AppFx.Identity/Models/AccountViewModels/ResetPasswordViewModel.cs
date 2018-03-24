using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.AccountViewModels
{
    /// <summary>A ViewModel for the reset password.</summary>
    [LocalizedModel]
    public class ResetPasswordViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.AccountViewModels.ResetPasswordViewModel";

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Display(Name = FullModelName + "Email", Description = "Email:")]
        [DisplayTranslationForCulture("Email", "Email:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must not be empty")]
        [ValidationTranslationForCulture("Required", "Email darf nicht leer sein", "de")]
        [EmailAddress(ErrorMessage = "Invalid Email-Address")]
        [ValidationTranslationForCulture("EmailAddress", "Ungültige Email-Adresse", "de")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        [Display(Name = FullModelName + "Password", Description = "Password:")]
        [DisplayTranslationForCulture("Password", "Passwort:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must not be empty")]
        [ValidationTranslationForCulture("Required", "Passwort darf nicht leer sein", "de")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>Gets or sets the confirm password.</summary>
        /// <value>The confirm password.</value>
        [Display(Name = FullModelName + "ConfirmPassword", Description = "Password confirmation:")]
        [DisplayTranslationForCulture("ConfirmPassword", "Passwort-Bestätigung:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password-confirmation must not be empty")]
        [ValidationTranslationForCulture("Required", "Passwort-Bestätigung darf nicht leer sein", "de")]
        [Compare("Password", ErrorMessage = "Password must equal Password-confirmation")]
        [ValidationTranslationForCulture("Compare", "Passwort muss mit Passwort-Bestätigung übereinstimmen", "de")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        [Display(Name = FullModelName + "Code", Description = "Code:")]
        [DisplayTranslationForCulture("Code", "Code:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code is required")]
        [ValidationTranslationForCulture("Required", "Code ist erforderlich", "de")]
        public string Code { get; set; }
    }
}