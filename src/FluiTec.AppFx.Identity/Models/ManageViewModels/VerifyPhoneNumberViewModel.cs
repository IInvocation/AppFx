using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.ManageViewModels
{
    /// <summary>A ViewModel for the verify phone number.</summary>
    [LocalizedModel]
    public class VerifyPhoneNumberViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.ManageViewModels.VerifyPhoneNumberViewModel";

        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        [Display(Name = FullModelName + "Code", Description = "Code")]
        [DisplayTranslationForCulture("Code", "Code", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        public string Code { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        [Display(Name = FullModelName + "Phone", Description = "Phone")]
        [DisplayTranslationForCulture("Phone", "Telefon", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [Phone(ErrorMessage = "PhoneMessage")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}