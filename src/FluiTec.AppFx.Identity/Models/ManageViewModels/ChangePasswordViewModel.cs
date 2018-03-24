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
        [Display(Name = FullModelName + "OldPassword", Description = "Old Password:")]
        [DisplayTranslationForCulture("OldPassword", "Altes Passwort:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Old Password must not be empty")]
        [ValidationTranslationForCulture("Required", "Altes Passwort darf nicht leer sein", "de")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        /// <summary>Gets or sets the new password.</summary>
        /// <value>The new password.</value>
        [Display(Name = FullModelName + "NewPassword", Description = "New Password:")]
        [DisplayTranslationForCulture("NewPassword", "Neues Passwort:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "New Password must not be empty")]
        [ValidationTranslationForCulture("Required", "Neues Passwort darf nicht leer sein", "de")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

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