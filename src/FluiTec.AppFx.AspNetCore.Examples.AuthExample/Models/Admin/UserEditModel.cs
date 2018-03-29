﻿using System.ComponentModel.DataAnnotations;
using DbLocalizationProvider.Abstractions;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin
{
    /// <summary>   A data Model for the user edit. </summary>
    [LocalizedModel]
    public class UserEditModel : UpdateModel
    {
        /// <summary>   Name of the full model. </summary>
        private const string FullModelName = "FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Admin.UserEditModel";

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

        /// <summary>   Gets or sets the email. </summary>
        /// <value> The email. </value>
        [Display(Name = FullModelName + "Email", Description = "Email")]
        [DisplayTranslationForCulture("Email", "Email", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [EmailAddress(ErrorMessage = "EmailMessage")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>   Gets or sets the phone. </summary>
        /// <value> The phone. </value>
        [Display(Name = FullModelName + "Phone", Description = "Phone")]
        [DisplayTranslationForCulture("Phone", "Telefon", "de")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredMessage")]
        [Phone(ErrorMessage = "PhoneMessage")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}