using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.AccountViewModels
{
    /// <summary>A ViewModel for the confirm email again.</summary>
    [LocalizedModel]
    public class ConfirmEmailAgainViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.AccountViewModels.ConfirmEmailAgainViewModel";

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
    }
}