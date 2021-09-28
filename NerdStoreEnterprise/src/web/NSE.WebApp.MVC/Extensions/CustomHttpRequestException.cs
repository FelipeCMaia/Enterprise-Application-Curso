using System;
using System.Net;
using System.Runtime.Serialization;

namespace NSE.WebApp.MVC.Services
{
    [Serializable]
    internal class CustomHttpRequestException : Exception
    {
        private HttpStatusCode statusCode;

        public CustomHttpRequestException()
        {
        }

        public CustomHttpRequestException(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public CustomHttpRequestException(string message) : base(message)
        {
        }

        public CustomHttpRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }        
    }
}