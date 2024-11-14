using System;

namespace JDownloader.Model
{
    public class DirectConnectionException : Exception
    {
        public DirectConnectionException() { }

        public DirectConnectionException(string message) : base(message) { }

        public DirectConnectionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
