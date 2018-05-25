using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   A default bearer secured JSON service. </summary>
    /// <typeparam name="TOptions"> Type of the options. </typeparam>
    /// <typeparam name="TModel">   Type of the model. </typeparam>
    public abstract class DefaultBearerSecuredJsonService<TOptions, TModel> : BearerSecuredJsonService<TOptions, TModel> where TModel : class where TOptions : BearerSecuredServiceOptions
    {
        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        protected DefaultBearerSecuredJsonService(TOptions options) : base(options)
        {
        }

        /// <summary>   Gets all actions associated with the current client. </summary>
        /// <exception cref="ResponseException">    Thrown when a Response error condition occurs. </exception>
        /// <returns>
        ///     An asynchronous result that yields an enumerator that allows foreach to be used to
        ///     process the matched items.
        /// </returns>
        public new async Task<IEnumerable<TModel>> GetAll()
        {
            return await base.GetAll();
        }

        /// <summary>   Gets the action by using it's id. </summary>
        /// <exception cref="ResponseException">    Thrown when a Response error condition occurs. </exception>
        /// <param name="id">   The Identifier to get. </param>
        /// <returns>
        ///     An asynchronous result that yields an enumerator that allows foreach to be used to
        ///     process the matched items.
        /// </returns>
        public new async Task<TModel> Get(int id)
        {
            return await base.Get(id);
        }

        /// <summary>   Adds model. </summary>
        /// <param name="model">    The model to add. </param>
        /// <returns>   An asynchronous result that yields an ActionModel. </returns>
        public new async Task<TModel> Add(TModel model)
        {
            return await base.Add(model);
        }

        /// <summary>   Updates the given model. </summary>
        /// <param name="model">    The model to add. </param>
        /// <returns>   An asynchronous result. </returns>
        public new async Task Update(TModel model)
        {
            await base.Update(model);
        }

        /// <summary>   Deletes the given ID. </summary>
        /// <param name="id">   The Identifier to get. </param>
        /// <returns>   An asynchronous result. </returns>
        public new async Task Delete(int id)
        {
            await base.Delete(id);
        }

        /// <summary>   Deletes the given ID. </summary>
        /// <param name="model">    The model to add. </param>
        /// <returns>   An asynchronous result. </returns>
        public abstract Task Delete(TModel model);
    }
}