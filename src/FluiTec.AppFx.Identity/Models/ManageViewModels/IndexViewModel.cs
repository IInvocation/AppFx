using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace FluiTec.AppFx.Identity.Models.ManageViewModels
{
    /// <summary>A ViewModel for the manage.</summary>
    public class IndexViewModel
    {
        /// <summary>Gets or sets a message describing the status.</summary>
        /// <value>A message describing the status.</value>
        public string StatusMessage { get; set; }

        /// <summary>   Gets or sets a value indicating whether this object has password. </summary>
        /// <value> True if this object has password, false if not. </value>
        public bool HasPassword { get; set; }

        /// <summary>   Gets or sets the logins. </summary>
        /// <value> The logins. </value>
        public IList<UserLoginInfo> Logins { get; set; }

        /// <summary>   Gets or sets the phone number. </summary>
        /// <value> The phone number. </value>
        public string PhoneNumber { get; set; }

        /// <summary>   Gets or sets a value indicating whether the two factor. </summary>
        /// <value> True if two factor, false if not. </value>
        public bool TwoFactor { get; set; }

        /// <summary>   Gets or sets a value indicating whether the browser remembered. </summary>
        /// <value> True if browser remembered, false if not. </value>
        public bool BrowserRemembered { get; set; }
    }
}