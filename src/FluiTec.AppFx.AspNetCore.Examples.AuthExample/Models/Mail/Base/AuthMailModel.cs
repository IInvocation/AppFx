using FluiTec.AppFx.AspNetCore.Configuration;
using FluiTec.AppFx.AspNetCore.Models;
using FluiTec.AppFx.Mail;
using Microsoft.Extensions.Localization;
using FluiTec.AppFx.Localization;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Mail
{
    /// <summary>   A data Model for the authentication mail. </summary>
    public class AuthMailModel : MailModel
    {
        private string _subject;

        /// <summary>   Constructor. </summary>
        /// <param name="localizerFactory"> The localizer factory. </param>
        /// <param name="appOptions">       Options for controlling the application. </param>
        public AuthMailModel(IStringLocalizerFactory localizerFactory, ApplicationOptions appOptions)
        {
            var localizer = localizerFactory.Create(typeof(ApplicationResource));

            ApplicationName = localizer.GetString(() => ApplicationResource.Name);
            ApplicationUrl = appOptions?.ApplicationRoot;
            ApplicationUrlDisplay = appOptions?.ApplicationRootDisplay;
        }

        /// <summary>   Gets or sets the subject. </summary>
        /// <value> The subject. </value>
        public override string Subject
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_subject))
                    return ApplicationName;
                return !_subject.StartsWith(ApplicationName) ? $"{ApplicationName}: {_subject}" : _subject;
            }
            set => _subject = value;
        }
    }
}