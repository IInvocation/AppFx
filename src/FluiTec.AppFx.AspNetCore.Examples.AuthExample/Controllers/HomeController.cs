using System;
using System.Threading.Tasks;
using FluiTec.AppFx.AspNetCore.Configuration;
using FluiTec.AppFx.AspNetCore.Examples.AuthExample.Models.Mail;
using FluiTec.AppFx.Mail;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.AspNetCore.Examples.AuthExample.Controllers
{
    /// <summary>A controller for handling homes.</summary>
    public class HomeController : Controller
    {
        /// <summary>   The current language. </summary>
        private string _currentLanguage;

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="logger">               The logger. </param>
        /// <param name="mailService">          The mail service. </param>
        /// <param name="errorOptions">         Options for controlling the error. </param>
        /// <param name="localizerFactory">     The localizer factory. </param>
        /// <param name="applicationOptions">   Options for controlling the application. </param>
        public HomeController(ILogger<HomeController> logger, ITemplatingMailService mailService,
            ErrorOptions errorOptions, IStringLocalizerFactory localizerFactory, ApplicationOptions applicationOptions)
        {
            _logger = logger;
            _mailService = mailService;
            _errorOptions = errorOptions;
            _localizerFactory = localizerFactory;
            _applicationOptions = applicationOptions;
        }

        #endregion

        #region Fields

        /// <summary>	The logger. </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>	The mail service. </summary>
        private readonly ITemplatingMailService _mailService;

        /// <summary>	Options for controlling the error. </summary>
        private readonly ErrorOptions _errorOptions;

        /// <summary>   The localizer factory. </summary>
        private readonly IStringLocalizerFactory _localizerFactory;

        /// <summary>   Options for controlling the application. </summary>
        private readonly ApplicationOptions _applicationOptions;

        #endregion

        #region Routes

        /// <summary>Gets the index.</summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>Gets the about.</summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult About()
        {
            return View();
        }

        public async Task<IActionResult> Error()
        {
            // get exception-data
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionFeature?.Error;
            var route = exceptionFeature?.Path;

            // only execute if there was a real exception
            if (exception != null)
            {
                _logger.LogError(0, exception, "Unhandled exception");

                // collect additional exception-info from log?

                try
                {
                    var mailModel = new ErrorMailModel(_localizerFactory, _applicationOptions, route, exception);
                    await _mailService.SendEmailAsync(_errorOptions.ErrorRecipient, mailModel);
                }
                catch (Exception e)
                {
                    _logger.LogError(0, e, "Unhandled exception in error-handling api");
                }
            }

            return View();
        }

        /// <summary>   Redirect to default language. </summary>
        /// <returns>   A response stream to send to the RedirectToDefaultLanguage View. </returns>
        public ActionResult RedirectToDefaultLanguage()
        {
            var lang = CurrentLanguage;
            return RedirectToAction("Index", new { language = lang });
        }

        #endregion

        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                {
                    return _currentLanguage;
                }
                if (RouteData.Values.ContainsKey("language"))
                {
                    _currentLanguage = RouteData.Values["language"].ToString().ToLower();
                }
                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }
                return _currentLanguage;
            }
        }
    }
}