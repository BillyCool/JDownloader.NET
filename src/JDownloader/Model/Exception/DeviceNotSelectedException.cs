using System;

namespace JDownloader.Model
{
    public class DeviceNotSelectedException : Exception
    {
        public DeviceNotSelectedException() { }

        public DeviceNotSelectedException(string message) : base(message) { }

        public DeviceNotSelectedException(string message, Exception innerException) : base(message, innerException) { }
    }
}