using System;

namespace JDownloader.Model
{
    public class MyJDownloaderException : Exception
    {
        public MyJDownloaderException() { }

        public MyJDownloaderException(string message) : base(message) { }

        public MyJDownloaderException(string message, Exception innerException) : base(message, innerException) { }
    }
}