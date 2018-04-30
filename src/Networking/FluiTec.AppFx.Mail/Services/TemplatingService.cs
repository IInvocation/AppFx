namespace FluiTec.AppFx.Mail
{
    /// <summary>A templating service.</summary>
    public abstract class TemplatingService : ITemplatingService
    {
        /// <summary>Parses the given model.</summary>
        /// <typeparam name="TModel">   Type of the model. </typeparam>
        /// <param name="model">    The model. </param>
        /// <returns>A string.</returns>
        public virtual string Parse<TModel>(TModel model)
        {
            return Parse(GetViewName<TModel>(), model);
        }

        /// <summary>Parses.</summary>
        /// <typeparam name="TModel">   Type of the model. </typeparam>
        /// <param name="viewName"> Name of the view. </param>
        /// <param name="model">    The model. </param>
        /// <returns>A string.</returns>
        public abstract string Parse<TModel>(string viewName, TModel model);

        /// <summary>	Gets view name. </summary>
        /// <typeparam name="TModel">	Type of the model. </typeparam>
        /// <returns>	The view name. </returns>
        protected virtual string GetViewName<TModel>()
        {
            var modelType = typeof(TModel);
            return $"{modelType.Name}.cshtml";
        }
    }
}