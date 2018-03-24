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
        [Display(Name = FullModelName + "Email", Description = "Email:")]
        [DisplayTranslationForCulture("Email", "Email:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must not be empty")]
        [ValidationTranslationForCulture("Required", "Email darf nicht leer sein", "de")]
        [EmailAddress(ErrorMessage = "Invalid Email-Address")]
        [ValidationTranslationForCulture("EmailAddress", "Ungültige Email-Adresse", "de")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Display(Name = FullModelName + "Name", Description = "Name:")]
        [DisplayTranslationForCulture("Name", "Name:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must not be empty")]
        [ValidationTranslationForCulture("Required", "Name darf nicht leer sein", "de")]
        public string Name { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        [Display(Name = FullModelName + "Phone", Description = "Phone:")]
        [DisplayTranslationForCulture("Phone", "Telefon:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone must not be empty")]
        [ValidationTranslationForCulture("Required", "Telefon darf nicht leer sein", "de")]
        [Phone(ErrorMessage = "Invalid Phone-Number")]
        [ValidationTranslationForCulture("Phone", "Ungültige Telefonnummer", "de")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

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
    }
}