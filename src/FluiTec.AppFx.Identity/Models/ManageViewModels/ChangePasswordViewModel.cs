using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.ManageViewModels
{
    /// <summary>A ViewModel for the change password.</summary>
    [LocalizedModel]
    public class ChangePasswordViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.ManageViewModels.ChangePasswordViewModel";

        /// <summary>Gets or sets the old password.</summary>
        /// <value>The old password.</value>
        [Display(Name = FullModelName + "OldPassword", Description = "Old Password")]
        [DisplayTranslationForCulture("OldPassword", "Altes Passwort", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        /// <summary>Gets or sets the new password.</summary>
        /// <value>The new password.</value>
        [Display(Name = FullModelName + "NewPassword", Description = "New Password")]
        [DisplayTranslationForCulture("NewPassword", "Neues Passwort", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        /// <summary>Gets or sets the confirm password.</summary>
        /// <value>The confirm password.</value>
        [Display(Name = FullModelName + "ConfirmPassword", Description = "Password confirmation")]
        [DisplayTranslationForCulture("ConfirmPassword", "Passwort-Bestätigung", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [Compare("NewPassword", ErrorMessage = "CompareMessage")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}