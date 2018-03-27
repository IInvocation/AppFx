using System;
using System.Threading.Tasks;
using FluiTec.AppFx.Mail.Configuration;
using MailKit.Net.Smtp;
using MimeKit;

namespace FluiTec.AppFx.Mail
{
    /// <summary>A mail kit templating mail service.</summary>
    public abstract class MailKitTemplatingMailService : ITemplatingMailService
    {
        #region Fields

        /// <summary>	Options for controlling the operation. </summary>
        protected readonly MailServiceOptions Options;

        /// <summary>The tempaling service.</summary>
        protected readonly ITemplatingService TempalingService;

        #endregion

        #region Methods

        /// <summary>Sends a mail.</summary>
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

        #region Constructors

        /// <summary>Constructor.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="templatingService">    The engine. </param>
        /// <param name="options">              Options for controlling the operation. </param>
        protected MailKitTemplatingMailService(ITemplatingService templatingService, MailServiceOptions options)
        {
            TempalingService = templatingService ?? throw new ArgumentNullException(nameof(templatingService));
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        #endregion

        #region ITemplatingMailService

        /// <summary>	Sends an email asynchronous. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <param name="email">	The email. </param>
        /// <param name="model">	The model. </param>
        /// <returns>	A Task. </returns>
        public Task SendEmailAsync<TModel>(string email, TModel model) where TModel : IMailModel
        {
            return Task.Factory.StartNew(() =>
            {
                var text = TempalingService.Parse(model);
                SendMail(model, email, text);
            });
        }

        /// <summary>	Sends an email asynchronous. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <param name="email">	   	The email. </param>
        /// <param name="templateName">	Name of the template. </param>
        /// <param name="model">	   	The model. </param>
        /// <returns>	A Task. </returns>
        public Task SendEmailAsync<TModel>(string email, string templateName, TModel model) where TModel : IMailModel
        {
            return Task.Factory.StartNew(() =>
            {
                var text = TempalingService.Parse(templateName, model);
                SendMail(model, email, text);
            });
        }

        #endregion
    }
}