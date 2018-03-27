using System;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews;
using FluiTec.AppFx.Mail;
using FluiTec.AppFx.Localization;
using Microsoft.Extensions.Localization;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.MailModels
{
    /// <summary>   A data Model for the error. This class cannot be inherited. </summary>
    public sealed class ErrorModel : MailModel
    {
        /// <summary>   Constructor. </summary>
        /// <param name="localizerFactory"> The localizer factory. </param>
        /// <param name="exception">        The exception. </param>
        public ErrorModel(IStringLocalizerFactory localizerFactory, Exception exception)
        {
            var localizer = localizerFactory.Create(typeof(ErrorModelResource));

            ApplicationName = MailGlobals.ApplicationName;
            ApplicationUrl = MailGlobals.ApplicationUrl;
            ApplicationUrlDisplay = MailGlobals.ApplicationUrlDisplay;

            Subject = localizer.GetString(() => ErrorModelResource.Subject);
            Header = localizer.GetString(() => ErrorModelResource.Header);
            ExceptionPreText = localizer.GetString(() => ErrorModelResource.ExceptionPreText);

            ExceptionText = exception?.ToString();
        }

        /// <summary>	Gets or sets the exception pre text. </summary>
        /// <value>	The exception pre text. </value>
        public string ExceptionPreText { get; set; }

        /// <summary>	Gets or sets the exception text. </summary>
        /// <value>	The exception text. </value>
        public string ExceptionText { get; set; }

        /// <summary>	Gets or sets the error route. </summary>
        /// <value>	The error route. </value>
        public string ErrorRoute { get; set; }
    }
}
