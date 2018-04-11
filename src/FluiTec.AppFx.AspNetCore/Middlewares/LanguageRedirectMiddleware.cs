using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;

namespace FluiTec.AppFx.AspNetCore.Middlewares
{
    /// <summary>   A language middleware. </summary>
    public class LanguageRedirectMiddleware
    {
        /// <summary>   The next. </summary>
        private readonly RequestDelegate _next;

        /// <summary>   Constructor. </summary>
        /// <param name="next"> The next. </param>
        public LanguageRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///     Executes the given operation on a different thread, and waits for the result.
        /// </summary>
        /// <param name="httpContext">  Context for the HTTP. </param>
        /// <returns>   An asynchronous result. </returns>
        public Task Invoke(HttpContext httpContext)
        {
            // if an empty path was given - redirect to determined/default language
            if (!httpContext.Request.Path.HasValue || string.IsNullOrWhiteSpace(httpContext.Request.Path.Value) || httpContext.Request.Path.Value == "/") 
                return RedirectToLanguage(httpContext);
            // otherwise - let other handlers do their work
            return _next(httpContext); 
        }

        /// <summary>   Redirect to language. </summary>
        /// <param name="httpContext">  Context for the HTTP. </param>
        /// <returns>   An asynchronous result. </returns>
        private Task RedirectToLanguage(HttpContext httpContext)
        {
            var language = string.Empty;
            var routeData = httpContext.GetRouteData();
            if (routeData != null && routeData.Values.ContainsKey("language")) // return url-specified language
            {
                language = routeData.Values["language"].ToString().ToLower();
            }
            if (string.IsNullOrEmpty(language))
            {
                var feature = httpContext.Features.Get<IRequestCultureFeature>();
                language = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
            }

            httpContext.Response.Redirect($"/{language}");
            return Task.CompletedTask;
        }
    }
}