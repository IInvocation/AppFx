using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FluiTec.AppFx.Identity.Models.ManageViewModels
{
    /// <summary>A ViewModel for the manage logins.</summary>
    public class ManageLoginsViewModel
    {
        /// <summary>   Gets or sets the current logins. </summary>
        /// <value> The current logins. </value>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>   Gets or sets the other logins. </summary>
        /// <value> The other logins. </value>
        public IList<AuthenticationScheme> OtherLogins { get; set; }
    }
}