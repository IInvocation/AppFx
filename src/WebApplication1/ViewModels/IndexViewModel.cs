using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider;
using DbLocalizationProvider.Abstractions;

namespace WebApplication1.ViewModels
{
    [LocalizedModel]
    public class IndexViewModel
    {
        [Display(Name = "User name:")] // This translates the Display for "invariant" and "en"
        [TranslationForCulture("Benutzername", "de-DE")] // this translates the Display for "de-DE"
        [Required(ErrorMessage = "Name of the user is required!")] // this translates the Required for "invariant" and "en"
        [ValidationTranslationForCulture("Required", "Der Benutzername ist erforderlich", "de-DE")] // this translations the Required for "de-DE"
        public string UserName { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Password is kinda required :)")]
        public string Password { get; set; }
    }
}