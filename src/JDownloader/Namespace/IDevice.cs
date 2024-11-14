using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IDevice
    {
        /// <summary>
        /// Retrieves the direct connection information.
        /// </summary>
        /// <returns>The direct connection information.</returns>
        Task<DirectConnectionInfos> GetDirectConnectionInfos();

        /// <summary>
        /// Retrieves the session public key.
        /// </summary>
        /// <returns>The session public key.</returns>
        Task<string> GetSessionPublicKey();

        /// <summary>
        /// Pings the device.
        /// </summary>
        /// <returns>True if the device is reachable, otherwise, false.</returns>
        Task<bool> Ping();
    }
}
