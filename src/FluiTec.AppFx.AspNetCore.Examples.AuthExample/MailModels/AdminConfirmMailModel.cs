using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews;
using FluiTec.AppFx.Localization;
using FluiTec.AppFx.Mail;
using Microsoft.Extensions.Localization;

// ReSharper disable VirtualMemberCallInConstructor

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.MailModels
{
    /// <summary>   A data Model for the admin confirm mail. </summary>
    public class AdminConfirmMailModel : MailModel
    {
        /// <summary>   Constructor. </summary>
        /// <param name="localizerFactory"> The localizer factory. </param>
        /// <param name="validationUrl">    URL of the validation. </param>
        public AdminConfirmMailModel(IStringLocalizerFactory localizerFactory, string validationUrl)
        {
            var localizer = localizerFactory.Create(typeof(UserConfirmMailResource));
            ValidationUrl = validationUrl;

            ApplicationName = MailGlobals.ApplicationName;
            ApplicationUrl = MailGlobals.ApplicationUrl;
            ApplicationUrlDisplay = MailGlobals.ApplicationUrlDisplay;

            Subject = localizer.GetString(() => AdminConfirmMailResource.Subject);
            Header = localizer.GetString(() => AdminConfirmMailResource.Header);
            PleaseConfirmText = localizer.GetString(() => AdminConfirmMailResource.PleaeConfirmText);
            ConfirmLinkText = localizer.GetString(() => AdminConfirmMailResource.ConfirmLinkText);
            ConfirmEmailReasonText = localizer.GetString(() => AdminConfirmMailResource.ConfirmEmailReasonText, MailGlobals.ApplicationUrl, MailGlobals.ApplicationUrlDisplay);
            ThankYouText = localizer.GetString(() => AdminConfirmMailResource.ThankYouText, MailGlobals.ApplicationUrl, MailGlobals.ApplicationUrlDisplay);
        }

        /// <summary>	Gets or sets URL of the validation. </summary>
        /// <value>	The validation URL. </value>
        public string ValidationUrl { get; set; }

        /// <summary>	Gets or sets the email. </summary>
        /// <value>	The email. </value>
        public string Email { get; set; }

        /// <summary>   Gets or sets the thank you text. </summary>
        /// <value> The thank you text. </value>
        public string ThankYouText { get; set; }

        /// <summary>   Gets or sets the confirm email reason text. </summary>
        /// <value> The confirm email reason text. </value>
        public string ConfirmEmailReasonText { get; set; }

        /// <summary>   Gets or sets the confirm link text. </summary>
        /// <value> The confirm link text. </value>
        public string ConfirmLinkText { get; set; }

        /// <summary>   Gets or sets the please confirm text. </summary>
        /// <value> The please confirm text. </value>
        public string PleaseConfirmText { get; set; }
    }
}