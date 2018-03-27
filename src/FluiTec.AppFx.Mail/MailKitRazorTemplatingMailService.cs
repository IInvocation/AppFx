using System;
using System.Threading.Tasks;
using FluiTec.AppFx.Mail.Configuration;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MimeKit;

namespace FluiTec.AppFx.Mail
{
    /// <summary>   A mail kit razor templating mail service. </summary>
    public class MailKitRazorTemplatingMailService : RazorTemplatingMailService
    {
        #region Properties

        /// <summary>	Options for controlling the operation. </summary>
        protected readonly MailServiceOptions Options;

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="options">          Options for controlling the operation. </param>
        /// <param name="razorViewEngine">  The razor view engine. </param>
        /// <param name="tempDataProvider"> The temporary data provider. </param>
        /// <param name="serviceProvider">  The service provider. </param>
        public MailKitRazorTemplatingMailService(MailServiceOptions options, IRazorViewEngine razorViewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider) : base(razorViewEngine, tempDataProvider, serviceProvider)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        #endregion

        #region Methods

        /// <summary>   Sends a mail. </summary>
        /// <typeparam name="TModel">   Type of the model. </typeparam>
        /// <param name="model">    The model. </param>
        /// <param name="email">    The email. </param>
        /// <param name="content">  The content. </param>
        protected void SendMail<TModel>(TModel model, string email, string content) where TModel : IMailModel
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Options.FromName, Options.FromMail));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = model.Subject;

            message.Body = new TextPart("html")
            {
                Text = content
            };

            using (var client = new SmtpClient())
            {
                // currently acceppt all certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(Options.SmtpServer, Options.SmtpPort, Options.EnableSsl);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                if (Options.Authenticate)
                {
                    client.Authenticate(Options.Username, Options.Password);
                }

                client.Send(message);
                client.Disconnect(true);
            }
        }

        #endregion

        /// <summary>	Gets view name. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <returns>	The view name. </returns>
        protected override string GetViewName<TModel>()
        {
            var modelType = typeof(TModel);
            var templateRoot = string.IsNullOrWhiteSpace(Options.TemplateRoot)
                ? string.Empty
                : $"{Options.TemplateRoot}/";
            return $"{templateRoot}{modelType.Name}.cshtml";
        }

        /// <summary>   Sends an email asynchronous. </summary>
        /// <typeparam name="TModel">   Type of the model. </typeparam>
        /// <param name="email">    The email. </param>
        /// <param name="model">    The model. </param>
        /// <returns>   A Task. </returns>
        public override Task SendEmailAsync<TModel>(string email, TModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                var text = Parse(model);
                SendMail(model, email, text);
            });
        }

        /// <summary>   Sends an email asynchronous. </summary>
        /// <typeparam name="TModel">   Type of the model. </typeparam>
        /// <param name="email">        The email. </param>
        /// <param name="templateName"> Name of the template. </param>
        /// <param name="model">        The model. </param>
        /// <returns>   A Task. </returns>
        public override Task SendEmailAsync<TModel>(string email, string templateName, TModel model)
        {
            return Task.Factory.StartNew(() =>
            {
                var text = Parse(templateName, model);
                SendMail(model, email, text);
            });
        }
    }
}