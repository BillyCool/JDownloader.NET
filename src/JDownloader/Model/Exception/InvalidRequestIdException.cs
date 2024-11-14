using System;

namespace JDownloader.Model
{
    public class InvalidRequestIdException : Exception
    {
        private const string errorMessage = "The RequestId of the request differs from the RequestId of the server response.";

        public InvalidRequestIdException() : base(errorMessage) { }

        public InvalidRequestIdException(string message) : base(message) { }

        public InvalidRequestIdException(string message, Exception innerException) : base(message, innerException) { }
    }
}