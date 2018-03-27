using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.Mail
{
    /// <summary>   A razor templating mail service. </summary>
    public abstract class RazorTemplatingMailService : ITemplatingMailService
    {
        /// <summary>   The razor view engine. </summary>
        private readonly IViewEngine _razorViewEngine;

        /// <summary>   The temporary data provider. </summary>
        private readonly ITempDataProvider _tempDataProvider;

        /// <summary>   The service provider. </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="razorViewEngine">  The razor view engine. </param>
        /// <param name="tempDataProvider"> The temporary data provider. </param>
        /// <param name="serviceProvider">  The service provider. </param>
        protected RazorTemplatingMailService(IViewEngine razorViewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _razorViewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        /// <summary>	Sends an email asynchronous. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <param name="email">	The email. </param>
        /// <param name="model">	The model. </param>
        /// <returns>	A Task. </returns>
        public abstract Task SendEmailAsync<TModel>(string email, TModel model) where TModel : IMailModel;

        /// <summary>	Sends an email asynchronous. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <param name="email">	   	The email. </param>
        /// <param name="templateName">	Name of the template. </param>
        /// <param name="model">	   	The model. </param>
        /// <returns>	A Task. </returns>
        public abstract Task SendEmailAsync<TModel>(string email, string templateName, TModel model)
            where TModel : IMailModel;

        /// <summary>	Gets view name. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <returns>	The view name. </returns>
        protected virtual string GetViewName<TModel>()
        {
            var modelType = typeof(TModel);
            return $"{modelType.Name}.cshtml";
        }

        /// <summary>	Parses the given model. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <param name="model">	The model. </param>
        /// <returns>	A string. </returns>
        public string Parse<TModel>(TModel model)
        {
            return Parse(GetViewName<TModel>(), model);
        }

        /// <summary>	Parses. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <param name="viewName">	Name of the view. </param>
        /// <param name="model">   	The model. </param>
        /// <returns>	A string. </returns>
        public string Parse<TModel>(string viewName, TModel model)
        {
            var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
            var routeData = new RouteData();
            var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

            using (var sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.FindView(actionContext, viewName, false);

                if (viewResult.View == null)
                {
                    throw new ArgumentException($"{viewName} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                viewResult.View.RenderAsync(viewContext).Wait();
                return sw.ToString();
            }
        }
    }
}