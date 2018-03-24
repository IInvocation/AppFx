using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.AccountViewModels
{
    /// <summary>A ViewModel for the external login confirmation.</summary>
    [LocalizedModel]
    public class ExternalLoginConfirmationViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.AccountViewModels.ExternalLoginConfirmationViewModel";

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Display(Name = FullModelName + "Name", Description = "Name:")]
        [DisplayTranslationForCulture("Name", "Name:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must not be empty")]
        [ValidationTranslationForCulture("Required", "Name darf nicht leer sein", "de")]
        public string Name { get; set; }

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

        [Display(Name = FullModelName + "Phone", Description = "Phone:")]
        [DisplayTranslationForCulture("Phone", "Telefon:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone must not be empty")]
        [ValidationTranslationForCulture("Required", "Telefon darf nicht leer sein", "de")]
        [Phone(ErrorMessage = "Invalid Phone-Number")]
        [ValidationTranslationForCulture("Phone", "Ungültige Telefonnummer", "de")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}