﻿using System;
using System.Collections.Generic;
using System.Text;
using FluiTec.AppFx.Mail;

namespace FluiTec.AppFx.Identity.Mvc.Models
{
	public class RecoverPasswordModel : MailModel
	{
		/// <summary>	Default constructor. </summary>
		/// <param name="validationUrl">	URL of the validation. </param>
		public RecoverPasswordModel(string validationUrl)
		{
			//Subject = Resources.MailModels.RecoverPasswordModel.Subject;
			//Header = Resources.MailModels.RecoverPasswordModel.Header;

			//ApplicationName = Global.ApplicationName;
			//ApplicationUrl = Global.ApplicationUrl;
			//ApplicationUrlDisplay = Global.ApplicationUrlDisplay;

			//PleaseConfirmText = Resources.MailModels.RecoverPasswordModel.PleaseConfirmText;
			//ConfirmLinkText = Resources.MailModels.RecoverPasswordModel.ConfirmLinkText;
			//ConfirmEmailReasonText = Resources.MailModels.RecoverPasswordModel.ConfirmEmailReasonText;
			//ThankYouText = Resources.MailModels.RecoverPasswordModel.ThankYouText;

			ValidationUrl = validationUrl;
            throw new NotImplementedException();
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
