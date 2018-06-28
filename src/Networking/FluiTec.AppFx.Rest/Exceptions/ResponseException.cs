using System;
using System.Net.Http;

namespace FluiTec.AppFx.Rest
{
    /// <summary>   Exception for signalling response errors. </summary>
    public class ResponseException : Exception
    {
        /// <summary>   Constructor. </summary>
        /// <param name="response"> The response. </param>
        public ResponseException(HttpResponseMessage response)
        {
            Response = response;
        }

        /// <summary>   Gets the response. </summary>
        /// <value> The response. </value>
        public HttpResponseMessage Response { get; }
    }
}