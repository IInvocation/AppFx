using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews;
using FluiTec.AppFx.Localization;
using FluiTec.AppFx.Mail;
using Microsoft.Extensions.Localization;

// ReSharper disable VirtualMemberCallInConstructor

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Mail
{
    /// <summary>   A data Model for the recover password mail. </summary>
    public class RecoverPasswordMailModel : MailModel
    {
        public RecoverPasswordMailModel(IStringLocalizerFactory localizerFactory, string validationUrl)
        {
            var localizer = localizerFactory.Create(typeof(RecoverPasswordResource));
            ValidationUrl = validationUrl;

            ApplicationName = MailGlobals.ApplicationName;
            ApplicationUrl = MailGlobals.ApplicationUrl;
            ApplicationUrlDisplay = MailGlobals.ApplicationUrlDisplay;

            Subject = localizer.GetString(() => RecoverPasswordResource.Subject);
            Header = localizer.GetString(() => RecoverPasswordResource.Header);
            PleaseConfirmText = localizer.GetString(() => RecoverPasswordResource.PleaeConfirmText);
            ConfirmLinkText = localizer.GetString(() => RecoverPasswordResource.ConfirmLinkText);
            ConfirmEmailReasonText = localizer.GetString(() => RecoverPasswordResource.ConfirmEmailReasonText);
            ThankYouText = localizer.GetString(() => RecoverPasswordResource.ThankYouText, MailGlobals.ApplicationUrl, MailGlobals.ApplicationUrlDisplay);
        }

        /// <summary>	Gets or sets URL of the validation. </summary>
        /// <value>	The validation URL. </value>
        public string ValidationUrl { get; set; }

        /// <summary>	Gets or sets the please confirm text. </summary>
        /// <value>	The please confirm text. </value>
        public string PleaseConfirmText { get; set; }

        /// <summary>	Gets or sets the confirm link text. </summary>
        /// <value>	The confirm link text. </value>
        public string ConfirmLinkText { get; set; }

        /// <summary>	Gets or sets the confirm email reason text. </summary>
        /// <value>	The confirm email reason text. </value>
        public string ConfirmEmailReasonText { get; set; }

        /// <summary>	Gets or sets the thank you text. </summary>
        /// <value>	The thank you text. </value>
        public string ThankYouText { get; set; }
    }
}