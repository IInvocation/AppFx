using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin
{
    /// <summary>   A data Model for the role edit. </summary>
    [LocalizedModel]
    public class RoleEditModel : UpdateModel
    {
        /// <summary>   Name of the full model. </summary>
        private const string FullModelName = "FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin.RoleAddModel";

        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        public int Id { get; set; }

        /// <summary>   Gets or sets the name. </summary>
        /// <value> The name. </value>
        [Display(Name = FullModelName + "Name", Description = "Name")]
        [DisplayTranslationForCulture("Name", "Name", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        public string Name { get; set; }

        /// <summary>   Gets or sets the description. </summary>
        /// <value> The description. </value>
        [Display(Name = FullModelName + "Description", Description = "Name")]
        [DisplayTranslationForCulture("Description", "Beschreibung", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        public string Description { get; set; } 
    }
}