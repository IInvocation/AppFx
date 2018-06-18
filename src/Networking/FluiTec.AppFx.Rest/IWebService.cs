using System.Net.Http;
using System.Threading.Tasks;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   Interface for web service. </summary>
    public interface IWebService
    {
        /// <summary>   Builds a client. </summary>
        /// <param name="subPath">  Full pathname of the sub file. </param>
        /// <returns>   An asynchronous result that yields a HttpClient. </returns>
        Task<HttpClient> BuildClient(string subPath);
    }
}