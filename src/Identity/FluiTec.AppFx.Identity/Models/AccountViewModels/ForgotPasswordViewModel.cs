using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.AccountViewModels
{
    /// <summary>A ViewModel for the forgot password.</summary>
    [LocalizedModel]
    public class ForgotPasswordViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.AccountViewModels.ForgotPasswordViewModel";

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Display(Name = FullModelName + "Email", Description = "Email")]
        [DisplayTranslationForCulture("Email", "Email", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [EmailAddress(ErrorMessage = "EmailMessage")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}