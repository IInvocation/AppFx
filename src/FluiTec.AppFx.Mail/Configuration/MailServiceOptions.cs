using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Mail.Configuration
{
	/// <summary>	A web mail options. </summary>
	[ConfigurationName("MailOptions")]
	public class MailServiceOptions
	{
		private string _templateRoot;

		/// <summary>	Default constructor. </summary>
		public MailServiceOptions()
		{
			Authenticate = true;
			TemplateRoot = "MailViews";
		}

		/// <summary>	Gets or sets a value indicating whether the authenticate. </summary>
		/// <value>	True if authenticate, false if not. </value>
		public bool Authenticate { get; set; }

		/// <summary>	Gets or sets the SMTP server. </summary>
		/// <value>	The SMTP server. </value>
		public string SmtpServer { get; set; }

		/// <summary>	Gets or sets the SMTP port. </summary>
		/// <value>	The SMTP port. </value>
		public int SmtpPort { get; set; }

		/// <summary>	Gets or sets a value indicating whether the ssl is enabled. </summary>
		/// <value>	True if enable ssl, false if not. </value>
		public bool EnableSsl { get; set; }

		/// <summary>	Gets or sets the username. </summary>
		/// <value>	The username. </value>
		public string Username { get; set; }

		/// <summary>	Gets or sets the password. </summary>
		/// <value>	The password. </value>
		public string Password { get; set; }

		/// <summary>	Gets or sets from mail. </summary>
		/// <value>	from mail. </value>
		public string FromMail { get; set; }

		/// <summary>	Gets or sets the name of from. </summary>
		/// <value>	The name of from. </value>
		public string FromName { get; set; }

		/// <summary>	Gets or sets the template root. </summary>
		/// <value>	The template root. </value>
		/// <remarks>
		/// Can not be null		 
		/// </remarks>
		public string TemplateRoot
		{
			get => _templateRoot;
			set
			{
				if (value != null && !string.IsNullOrWhiteSpace(value))
					_templateRoot = value;
			}
		}
	}
}