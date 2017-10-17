﻿using System.ComponentModel.DataAnnotations;

namespace FluiTec.AppFx.Identity.Mvc.Models
{
	public class ConfirmEmailAgainViewModel
	{
		[Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.ViewModel))]
		[EmailAddress(ErrorMessageResourceName = "EmailMessage", ErrorMessageResourceType = typeof(Resources.ViewModel))]
		public string Email { get; set; }
	}
}