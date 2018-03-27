using System;
using RazorLight;

namespace FluiTec.AppFx.Mail
{
	/// <summary>	A razor templating mail service. </summary>
	public class RazorLightTemplatingService : TemplatingService
    {
        /// <summary>   The engine. </summary>
		protected readonly IRazorLightEngine Engine;

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <param name="engine">	The engine. </param>
        public RazorLightTemplatingService(IRazorLightEngine engine)
		{
			Engine = engine ?? throw new ArgumentNullException(nameof(engine));
		}

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        /// <param name="viewPath">	Full pathname of the view file. </param>
        public RazorLightTemplatingService(string viewPath)
		{
			if (string.IsNullOrWhiteSpace(viewPath))
				throw new ArgumentNullException(nameof(viewPath));
			Engine = new EngineFactory().ForFileSystem(viewPath);
		}

		/// <summary>	Parses. </summary>
		/// <typeparam name="TModel">	Type of the model. </typeparam>
		/// <param name="viewName">	Name of the view. </param>
		/// <param name="model">   	The model. </param>
		/// <returns>	A string. </returns>
		public override string Parse<TModel>(string viewName, TModel model)
		{
			return Engine.CompileRenderAsync(viewName, model).Result;
		}
	}
}