using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   A bearer secured JSON service. </summary>
    /// <typeparam name="TOptions"> Type of the options. </typeparam>
    public abstract class BearerSecuredJsonService<TOptions> : BearerSecuredService<TOptions>, IWebService
        where TOptions : BearerSecuredServiceOptions
    {
        #region Constructors

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        protected BearerSecuredJsonService(TOptions options) : base(options) { }

        #endregion

        #region Client

        /// <summary>   Builds a client. </summary>
        /// <param name="subPath">  Full pathname of the sub file. </param>
        /// <returns>   A HttpClient. </returns>
        public async Task<HttpClient> BuildClient(string subPath)
        {
            var baseUrl = string.Concat(Options.ServiceUrl, subPath);

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.SetBearerToken(await GetAccessToken());

            return client;
        }

        #endregion
    }
}
