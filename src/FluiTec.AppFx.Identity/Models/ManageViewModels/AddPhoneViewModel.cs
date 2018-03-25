using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.Identity.Models.ManageViewModels
{
    /// <summary>A ViewModel for the add phone.</summary>
    [LocalizedModel]
    public class AddPhoneViewModel
    {
        /// <summary>Name of the full model.</summary>
        private const string FullModelName = "FluiTec.AppFx.Identity.Models.ManageViewModels.AddPhoneViewModel";

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