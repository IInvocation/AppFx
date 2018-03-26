using System;
using System.Linq;
using System.Threading.Tasks;
using FluiTec.AppFx.AspNetCore.Configuration;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Resources.Controllers;
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
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public AccountController(
            UserManager<IdentityUserEntity> userManager,
            SignInManager<IdentityUserEntity> signInManager,
            ITemplatingMailService emailSender,
            ILoggerFactory loggerFactory,
            IIdentityDataService dataService,
            AdminOptions adminOptions,
            IStringLocalizer<AccountResource> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _adminOptions = adminOptions;
            _localizer = localizer;
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