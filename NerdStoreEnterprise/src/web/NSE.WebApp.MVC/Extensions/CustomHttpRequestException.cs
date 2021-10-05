using System;
using System.Net;
using System.Runtime.Serialization;

namespace NSE.WebApp.MVC.Services
{
    [Serializable]
    internal class CustomHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode;

        public CustomHttpRequestException() { }

        public CustomHttpRequestException(string message, Exception innerException)
            : base(message, innerException) { }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}