using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Mvc.Models.AccountViewModels
{
    /// <summary>A ViewModel for the confirm email again.</summary>
    [LocalizedModel]
    public class ConfirmEmailAgainViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Mvc.Models.AccountViewModels.ConfirmEmailAgainViewModel.Email";

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Display(Name = FullModelName, Description = "Email:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email must not be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email-Address")]
        public string Email { get; set; }
    }
}