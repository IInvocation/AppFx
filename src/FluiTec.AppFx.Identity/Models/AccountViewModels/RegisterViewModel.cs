using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.AccountViewModels
{
    /// <summary>A ViewModel for the register.</summary>
    [LocalizedModel]
    public class RegisterViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.AccountViewModels.RegisterViewModel";

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Display(Name = FullModelName + "Email", Description = "Email")]
        [DisplayTranslationForCulture("Email", "Email", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [EmailAddress(ErrorMessage = "EmailMessage")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Display(Name = FullModelName + "Name", Description = "Name")]
        [DisplayTranslationForCulture("Name", "Name", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        public string Name { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        [Display(Name = FullModelName + "Phone", Description = "Phone")]
        [DisplayTranslationForCulture("Phone", "Telefon", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [Phone(ErrorMessage = "PhoneMessage")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        [Display(Name = FullModelName + "Password", Description = "Password")]
        [DisplayTranslationForCulture("Password", "Passwort", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>Gets or sets the confirm password.</summary>
        /// <value>The confirm password.</value>
        [Display(Name = FullModelName + "ConfirmPassword", Description = "Password confirmation")]
        [DisplayTranslationForCulture("ConfirmPassword", "Passwort-Bestätigung", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [Compare("Password", ErrorMessage = "CompareMessage")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}