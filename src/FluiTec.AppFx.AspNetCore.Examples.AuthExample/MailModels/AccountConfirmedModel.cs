using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews;
using FluiTec.AppFx.Mail;
using Microsoft.Extensions.Localization;
using FluiTec.AppFx.Localization;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.MailModels
{
    /// <summary>   A data Model for the account confirmed. </summary>
    public class AccountConfirmedModel : MailModel
    {
        /// <summary>   Constructor. </summary>
        /// <param name="localizerFactory"> The localizer factory. </param>
        /// <param name="loginLink">        The login link. </param>
        public AccountConfirmedModel(IStringLocalizerFactory localizerFactory, string loginLink)
        {
            var localizer = localizerFactory.Create(typeof(AccountConfirmedResource));

            ApplicationName = MailGlobals.ApplicationName;
            ApplicationUrl = MailGlobals.ApplicationUrl;
            ApplicationUrlDisplay = MailGlobals.ApplicationUrlDisplay;

            ConfirmationText = localizer.GetString(() => AccountConfirmedResource.ConfirmedText);
            LoginText = localizer.GetString(() => AccountConfirmedResource.LoginText, loginLink, MailGlobals.ApplicationName);
        }

        /// <summary>   Gets or sets the confirmation text. </summary>
        /// <value> The confirmation text. </value>
        public string ConfirmationText { get; set; }

        /// <summary>   Gets or sets the login text. </summary>
        /// <value> The login text. </value>
        public string LoginText { get; set; }
    }
}