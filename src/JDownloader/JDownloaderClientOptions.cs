using System;

namespace JDownloader
{
    public class JDownloaderClientOptions
    {
        /// <summary>
        /// Unique key for this application
        /// </summary>
        public string AppKey { get; set; }

        /// <summary>
        /// Salt used to compute login secret
        /// </summary>
        public string LoginSecretSalt { get; set; } = "server";

        /// <summary>
        /// Salt used to compute device secret
        /// </summary>
        public string DeviceSecretSalt { get; set; } = "device";

        public void Validate()
        {
            // App key
            if (string.IsNullOrWhiteSpace(AppKey))
            {
                throw new ArgumentNullException(nameof(AppKey));
            }
        }

        public byte[] GetLoginSecret(string email, string password) => JDownloaderCrypto.GetSecret(email, password, LoginSecretSalt);

        public byte[] GetDeviceSecret(string email, string password) => JDownloaderCrypto.GetSecret(email, password, DeviceSecretSalt);
    }
}
