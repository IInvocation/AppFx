using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   A JSON api. </summary>
    public abstract class JsonApi<TModel> where TModel : class
    {
        #region Fields

        /// <summary>   Full pathname of the sub file. </summary>
        protected readonly string SubPath;

        /// <summary>   The service. </summary>
        protected readonly IWebService Service;

        #endregion

        #region Constructors

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="service">  The service. </param>
        /// <param name="subPath">  Full pathname of the sub file. </param>
        protected JsonApi(IWebService service, string subPath)
        {
            Service = service;
            SubPath = subPath;
        }

        #endregion

        #region Methods

        /// <summary>   Builds the client. </summary>
        /// <returns>   An asynchronous result that yields a HttpClient. </returns>
        protected virtual Task<HttpClient> BuildClient()
        {
            return Service.BuildClient(SubPath);
        }

        /// <summary>   Gets all items in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        protected virtual async Task<IEnumerable<TModel>> GetAll()
        {
            var client = await BuildClient();
            var response = await client.GetAsync(string.Empty);

            if (!response.IsSuccessStatusCode)
                throw new ResponseException(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TModel>>(json);
        }

        /// <summary>   Gets a task&lt; t model&gt; using the given identifier. </summary>
        /// <exception cref="ResponseException">    Thrown when a Response error condition occurs. </exception>
        /// <param name="id">   The Identifier to get. </param>
        /// <returns>   An asynchronous result that yields a TModel. </returns>
        protected virtual async Task<TModel> Get(int id)
        {
            var client = await BuildClient();
            var response = await client.GetAsync($"{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;
            if (!response.IsSuccessStatusCode)
                throw new ResponseException(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(json);
        }

        /// <summary>   Adds the model. </summary>
        /// <exception cref="ResponseException">    Thrown when a Response error condition occurs. </exception>
        /// <param name="model">    The model to add. </param>
        /// <returns>   An asynchronous result that yields a TModel. </returns>
        protected virtual async Task<TModel> Add(TModel model)
        {
            var client = await BuildClient();
            var postContent = new StringContent(JsonConvert.SerializeObject(model));
            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(string.Empty, postContent);

            if (!response.IsSuccessStatusCode)
                throw new ResponseException(response);

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TModel>(json);
        }

        /// <summary>   Updates the given model. </summary>
        /// <exception cref="ResponseException">    Thrown when a Response error condition occurs. </exception>
        /// <param name="model">    The model to add. </param>
        /// <returns>   An asynchronous result. </returns>
        protected virtual async Task Update(TModel model)
        {
            var client = await BuildClient();
            var putContent = new StringContent(JsonConvert.SerializeObject(model));
            putContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync(string.Empty, putContent);

            if (!response.IsSuccessStatusCode)
                throw new ResponseException(response);
        }

        /// <summary>   Deletes the given ID. </summary>
        /// <param name="id">   The Identifier to get. </param>
        /// <returns>   An asynchronous result. </returns>
        protected virtual async Task Delete(int id)
        {
            var client = await BuildClient();
            var response = await client.DeleteAsync($"{id}");

            if (!response.IsSuccessStatusCode)
                throw new ResponseException(response);
        }

        #endregion
    }
}