using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.AccountViewModels
{
    /// <summary>A ViewModel for the login.</summary>
    [LocalizedModel]
    public class LoginViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.AccountViewModels.LoginViewModel";

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Display(Name = FullModelName + "Email", Description = "Email")]
        [DisplayTranslationForCulture("Email", "Email", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [EmailAddress(ErrorMessage = "EmailMessage")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = FullModelName + "Password", Description = "Password")]
        [DisplayTranslationForCulture("Password", "Passwort", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = FullModelName + "RememberMe", Description = "Remember me?")]
        [DisplayTranslationForCulture("RememberMe", "An mich erinnern?", "de")]
        public bool RememberMe { get; set; }
    }
}