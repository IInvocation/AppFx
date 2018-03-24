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