using System;
using System.Threading.Tasks;
using FluiTec.AppFx.AspNetCore.Configuration;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.MailModels;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Controllers;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.MailViews;
using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Models.AccountViewModels;
using FluiTec.AppFx.Mail;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using FluiTec.AppFx.Localization;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>A controller for handling accounts.</summary>
    [Authorize]
    public class AccountController : Controller
    {
        #region Fields

        /// <summary>   Manager for user. </summary>
        private readonly UserManager<IdentityUserEntity> _userManager;

        /// <summary>   Manager for sign in. </summary>
        private readonly SignInManager<IdentityUserEntity> _signInManager;

        /// <summary>   The email sender. </summary>
        private readonly ITemplatingMailService _emailSender;

        /// <summary>   The logger. </summary>
        private readonly ILogger _logger;

        /// <summary>   Options for controlling the admin. </summary>
        private readonly AdminOptions _adminOptions;

        /// <summary>   The localizer. </summary>
        private readonly IStringLocalizer<AccountResource> _localizer;

        /// <summary>   The localizer factory. </summary>
        private readonly IStringLocalizerFactory _localizerFactory;

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="userManager">      Manager for user. </param>
        /// <param name="signInManager">    Manager for sign in. </param>
        /// <param name="emailSender">      The email sender. </param>
        /// <param name="loggerFactory">    The logger factory. </param>
        /// <param name="dataService">      The data service. </param>
        /// <param name="adminOptions">     Options for controlling the admin. </param>
        /// <param name="localizer">        The localizer. </param>
        /// <param name="localizerFactory"> The localizer factory. </param>
        public AccountController(
            UserManager<IdentityUserEntity> userManager,
            SignInManager<IdentityUserEntity> signInManager,
            ITemplatingMailService emailSender,
            ILoggerFactory loggerFactory,
            IIdentityDataService dataService,
            AdminOptions adminOptions,
            IStringLocalizer<AccountResource> localizer,
            IStringLocalizerFactory localizerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _adminOptions = adminOptions;
            _localizer = localizer;
            _localizerFactory = localizerFactory;
        }

        #endregion

        #region Login

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var tUser = await _userManager.FindByEmailAsync(model.Email);
                if (tUser != null)
                {
                    var result =
                        await _signInManager.PasswordSignInAsync(tUser, model.Password, model.RememberMe, true);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation(1, "User logged in.");
                        return RedirectToLocal(returnUrl);
                    }

                    if (result.RequiresTwoFactor)
                    {
                        throw new NotImplementedException("TwoFactor-Authentication is not implemented!");
                    }

                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning(2, "User account locked out.");
                        return View("Lockout", tUser.LockedOutTill);
                    }
                }

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError(string.Empty, _localizer.GetString(r => r.EmailNotConfirmed));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, _localizer.GetString(r => r.InvalidLoginAttempt));
                }

                return View(model);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #region Register

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUserEntity { Name = model.Name, Email = model.Email, Phone = model.Phone };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Send an email with this link
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Identifier, code }, HttpContext.Request.Scheme);

                    if (_adminOptions.ConfirmationRecipient == MailAddressConfirmationRecipient.User)
                        await _emailSender.SendEmailAsync(_adminOptions.ConfirmationRecipient == MailAddressConfirmationRecipient.Admin 
                            ? _adminOptions.AdminConfirmationRecipient : model.Email, 
                            new UserConfirmMailModel(_localizerFactory, callbackUrl) { Email = model.Email });
                    else
                        await _emailSender.SendEmailAsync(_adminOptions.ConfirmationRecipient == MailAddressConfirmationRecipient.Admin 
                            ? _adminOptions.AdminConfirmationRecipient : model.Email, 
                            new AdminConfirmMailModel(_localizerFactory, callbackUrl) { Email = _adminOptions.AdminConfirmationRecipient });
                    
                    // sign the user in
                    // disabled to force the the user to confirm his mail address
                    //await _signInManager.SignInAsync(user, isPersistent: false);

                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction(nameof(ConfirmEmailNotification));
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #region ConfirmEmail

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmEmailNotification()
        {
            return View(_adminOptions);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        #endregion

        #region Helpers

        /// <summary>   Adds the errors. </summary>
        /// <param name="result">   The result. </param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        /// <summary>   Redirect to local. </summary>
        /// <param name="returnUrl">    URL of the return. </param>
        /// <returns>   An IActionResult. </returns>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #endregion
    }
}