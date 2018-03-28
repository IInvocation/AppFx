using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews;
using FluiTec.AppFx.Localization;
using FluiTec.AppFx.Mail;
using Microsoft.Extensions.Localization;

// ReSharper disable VirtualMemberCallInConstructor

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Mail
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

            Subject = localizer.GetString(() => AccountConfirmedResource.Subject);
            Header = localizer.GetString(() => AccountConfirmedResource.Header);
        }

        /// <summary>   Gets or sets the confirmation text. </summary>
        /// <value> The confirmation text. </value>
        public string ConfirmationText { get; set; }

        /// <summary>   Gets or sets the login text. </summary>
        /// <value> The login text. </value>
        public string LoginText { get; set; }
    }
}