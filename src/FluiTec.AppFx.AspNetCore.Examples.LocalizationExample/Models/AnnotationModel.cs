using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.LocalizationExample.Models
{
    [LocalizedResource]
    public class AnnotationModel
    {
        /// <summary>   Name of the full model. </summary>
        private const string FullModelName = "FluiTec.AppFx.AspNetCore.Examples.LocalizationExample.Models.AnnotationModel.UserName";

        /// <summary>   Gets or sets the name of the user. </summary>
        /// <value> The name of the user. </value>
        [Display(Name = FullModelName, Description = "Username:")] // translation for cultures: invariant, en
        [DisplayTranslationForCulture("UserName", "Benutzername:", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username must not be empty.")] // translation for cultures: invariant, en
        [ValidationTranslationForCulture("Required", "Benutzername darf nicht leer sein.", "de")] // translation of Required for culture: de-DE
        public string UserName { get; set; }

        /// <summary>   Gets or sets the email. </summary>
        /// <value> The email. </value>
        public string Email { get; set; }
    }
}
