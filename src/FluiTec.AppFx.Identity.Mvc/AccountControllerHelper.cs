using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Mvc.Models;
using FluiTec.AppFx.Mail;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Identity.Mvc
{
	/// <summary>	A controller for handling base accounts. </summary>
	public abstract class BaseAccountController : Controller
	{
		#region Fields

		private readonly ITemplatingMailService _mailService;
		private readonly ILogger _logger;
		private readonly SignInManager<IdentityUserEntity> _signInManager;
		private readonly UserManager<IdentityUserEntity> _userManager;

		#endregion

		#region Constructors

		/// <summary>	Specialised constructor for use only by derived class. </summary>
		/// <param name="userManager">  	Manager for user. </param>
		/// <param name="signInManager">	Manager for sign in. </param>
		/// <param name="mailService">  	The mail service. </param>
		/// <param name="loggerFactory">	The logger factory. </param>
		protected BaseAccountController(UserManager<IdentityUserEntity> userManager,
			SignInManager<IdentityUserEntity> signInManager, ITemplatingMailService mailService, ILoggerFactory loggerFactory)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mailService = mailService;
			_logger = loggerFactory.CreateLogger<BaseAccountController>();
		}

		#endregion
		
		#region Routes

		// GET: /Account/Login
		[HttpGet]
		[AllowAnonymous]
		public virtual async Task<IActionResult> Login(string returnUrl = null)
		{
			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public virtual async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
		    if (!ModelState.IsValid) return View(model);
		    // This doesn't count login failures towards account lockout
		    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
		    var tUser = await _userManager.FindByEmailAsync(model.Email);
		    var result =
		        await _signInManager.PasswordSignInAsync(tUser, model.Password, model.RememberMe, true);
		    if (result.Succeeded)
		    {
		        _logger.LogInformation(1, "User logged in.");
		        return RedirectToLocal(returnUrl);
		    }
		    if (result.RequiresTwoFactor)
		        return RedirectToAction(nameof(SendCode), new {ReturnUrl = returnUrl, model.RememberMe});
		    if (result.IsLockedOut)
		    {
		        _logger.LogWarning(2, "User account locked out.");
		        return View("Lockout");
		    }

		    var user = await _userManager.FindByEmailAsync(model.Email);
		    if (user != null && !user.EmailConfirmed)
		        ModelState.AddModelError(string.Empty, Resources.AccountController.EmailNotConfirmed);
		    else
		        ModelState.AddModelError(string.Empty, Resources.AccountController.InvalidLoginAttempt);

		    return View(model);

		    // If we got this far, something failed, redisplay form
		}

		// GET: /Account/Register
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
		    if (!ModelState.IsValid) return View(model);
		    var user = new IdentityUserEntity {Name = model.Name, Email = model.Email};
		    var result = await _userManager.CreateAsync(user, model.Password);
		    if (result.Succeeded)
		    {
		        // Send an email with this link
		        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
		        var callbackUrl = Url.Action(nameof(ConfirmEmail), AccountController, new {userId = user.Identifier, code},
		            HttpContext.Request.Scheme);
		        var mailModel = new ConfirmMailModel(callbackUrl) {Email = model.Email};
		        await _mailService.SendEmailAsync(model.Email, mailModel);

		        // sign the user in
		        // disabled to force the the user to confirm his mail address
		        //await _signInManager.SignInAsync(user, isPersistent: false);
		        _logger.LogInformation(3, "User created a new account with password.");
		        return RedirectToLocal(returnUrl);
		    }
		    AddErrors(result);

		    // If we got this far, something failed, redisplay form
			return View(model);
		}

		// GET: /Account/Logout
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			_logger.LogInformation(4, "User logged out.");
			return RedirectToAction(DefaultAction, DefaultController);
		}

		// POST: /Account/ExternalLogin
		[HttpPost]
		[AllowAnonymous]
		public IActionResult ExternalLogin(string provider, string returnUrl = null)
		{
			// Request a redirect to the external login provider.
			var redirectUrl = Url.Action(nameof(ExternalLoginCallback), AccountController, new {ReturnUrl = returnUrl});
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return Challenge(properties, provider);
		}

		// GET: /Account/ExternalLoginCallback
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
		{
			if (remoteError != null)
			{
				ModelState.AddModelError(string.Empty, $"{Resources.AccountController.ExternalProviderError} {remoteError}");
				return View(nameof(Login));
			}
			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
				return RedirectToAction(nameof(this.Login));

			// Sign in the user with this external login provider if the user already has a login.
			var result =
				await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
			if (result.Succeeded)
			{
				_logger.LogInformation(5, "User logged in with {Name} provider.", info.LoginProvider);
				return RedirectToLocal(returnUrl);
			}
			if (result.RequiresTwoFactor)
				return RedirectToAction(nameof(SendCode), new {ReturnUrl = returnUrl});
			if (result.IsLockedOut)
				return View("Lockout");

			// If the user does not have an account, then ask the user to create an account.
			ViewData["ReturnUrl"] = returnUrl;
			ViewData["LoginProvider"] = info.LoginProvider;
			var email = info.Principal.FindFirstValue(ClaimTypes.Email);
			return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel {Email = email});
		}

		// POST: /Account/ExternalLoginConfirmation
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model,
			string returnUrl = null)
		{
			if (ModelState.IsValid)
			{
				// Get the information about the user from the external login provider
				var info = await _signInManager.GetExternalLoginInfoAsync();
				if (info == null)
					return View("ExternalLoginFailure");

				var user = new IdentityUserEntity {Name = model.Name, Email = model.Email};
				var result = await _userManager.CreateAsync(user);
				if (result.Succeeded)
				{
					result = await _userManager.AddLoginAsync(user, info);
					if (result.Succeeded)
					{
						var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						var callbackUrl = Url.Action(nameof(ConfirmEmail), AccountController, new {userId = user.Identifier, code},
							HttpContext.Request.Scheme);
						var mailModel = new ConfirmMailModel(callbackUrl) {Email = model.Email};
						await _mailService.SendEmailAsync(model.Email, mailModel);

						// disabled to force the the user to confirm his mail address
						// await _signInManager.SignInAsync(user, isPersistent: false);
						_logger.LogInformation(6, "User created an account using {Name} provider.", info.LoginProvider);
						return RedirectToLocal(returnUrl);
					}
				}
				AddErrors(result);
			}

			ViewData["ReturnUrl"] = returnUrl;
			return View(model);
		}

		// GET: /Account/ConfirmEmail
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
				return View("Error");
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
				return View("Error");
			var result = await _userManager.ConfirmEmailAsync(user, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}

		// GET: /Account/ConfirmEmailAgain
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ConfirmEmailAgain()
		{
			return View();
		}

		// POST: /Account/ConfirmEmailAgain
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmailAgain(ConfirmEmailAgainViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null || await _userManager.IsEmailConfirmedAsync(user))
				return View("ConfirmEmailAgainConfirmation");

			var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			var callbackUrl = Url.Action(nameof(ConfirmEmail), AccountController, new {userId = user.Identifier, code},
				HttpContext.Request.Scheme);
			var mailModel = new ConfirmMailModel(callbackUrl) {Email = model.Email};
			await _mailService.SendEmailAsync(model.Email, mailModel);
			return View("ConfirmEmailAgainConfirmation");
		}

		// GET: /Account/ForgotPassword
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		//
		// POST: /Account/ForgotPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
				return View("ForgotPasswordConfirmation");

			var code = await _userManager.GeneratePasswordResetTokenAsync(user);
			var callbackUrl = Url.Action(nameof(ResetPassword), AccountController, new {userId = user.Identifier, code},
				HttpContext.Request.Scheme);
			var mailModel = new RecoverPasswordModel(callbackUrl);
			await _mailService.SendEmailAsync(model.Email, mailModel);
			return View("ForgotPasswordConfirmation");

			// If we got this far, something failed, redisplay form
		}

		// GET: /Account/ForgotPasswordConfirmation
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		// GET: /Account/ResetPassword
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ResetPassword(string code = null)
		{
			return code == null ? View("Error") : View();
		}

		// POST: /Account/ResetPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user == null)
				return RedirectToAction(nameof(ResetPasswordConfirmation), AccountController);
			var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
			if (result.Succeeded)
				return RedirectToAction(nameof(ResetPasswordConfirmation), AccountController);
			AddErrors(result);
			return View();
		}

		// GET: /Account/ResetPasswordConfirmation
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		// GET: /Account/SendCode
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
		{
			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user == null)
				return View("Error");
			var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(user);
			var factorOptions = userFactors.Select(purpose => new SelectListItem {Text = purpose, Value = purpose}).ToList();
			return View(new SendCodeViewModel {Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe});
		}

		// POST: /Account/SendCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SendCode(SendCodeViewModel model)
		{
			if (!ModelState.IsValid)
				return View();

			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user == null)
				return View("Error");

			// Generate the token and send it
			var code = await _userManager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
			if (string.IsNullOrWhiteSpace(code))
				return View("Error");

			switch (model.SelectedProvider)
			{
				case "Email":
					//await _emailSender.SendEmailAsync(await _userManager.GetEmailAsync(user), "Security Code", message);
					break;
				case "Phone":
					//await _smsSender.SendSmsAsync(await _userManager.GetPhoneNumberAsync(user), message);
					break;
				default:
					throw new NotImplementedException();
			}

			return RedirectToAction(nameof(VerifyCode),
				new {Provider = model.SelectedProvider, model.ReturnUrl, model.RememberMe});
		}

		// GET: /Account/VerifyCode
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> VerifyCode(string provider, bool rememberMe, string returnUrl = null)
		{
			// Require that the user has already logged in via username/password or external login
			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
		    // ReSharper disable once ConvertIfStatementToReturnStatement
			if (user == null)
				return View("Error");
			return View(new VerifyCodeViewModel {Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe});
		}

		// POST: /Account/VerifyCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			// The following code protects for brute force attacks against the two factor codes.
			// If a user enters incorrect codes for a specified amount of time then the user account
			// will be locked out for a specified amount of time.
			var result =
				await _signInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);
			if (result.Succeeded)
				return RedirectToLocal(model.ReturnUrl);
			if (result.IsLockedOut)
			{
				_logger.LogWarning(7, "User account locked out.");
				return View("Lockout");
			}
			ModelState.AddModelError(string.Empty, Resources.AccountController.InvalidCode);
			return View(model);
		}

		// GET /Account/AccessDenied
		[HttpGet]
		public IActionResult AccessDenied()
		{
			return View();
		}

		#endregion

		#region Properties

		/// <summary>	Gets the default controller. </summary>
		/// <value>	The default controller. </value>
		public virtual string DefaultController => "Home";

		/// <summary>	The account controller. </summary>
		public virtual string AccountController => "Account";

		/// <summary>	Gets the default action. </summary>
		/// <value>	The default action. </value>
		public virtual string DefaultAction => "Index";

		#endregion

		#region Methods

		/// <summary>	Adds the errors. </summary>
		/// <param name="result">	The result. </param>
		protected void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
				ModelState.AddModelError(string.Empty, error.Description);
		}

		/// <summary>	Redirect to local. </summary>
		/// <param name="returnUrl">	URL of the return. </param>
		/// <returns>	An IActionResult. </returns>
		protected IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);
			return RedirectToAction(DefaultAction, DefaultController);
		}

		#endregion
	}
}