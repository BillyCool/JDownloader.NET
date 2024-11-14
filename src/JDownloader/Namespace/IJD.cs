using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IJD
    {
        /// <summary>
        /// Gets the core revision of JDownloader.
        /// </summary>
        /// <returns>The core revision as an integer.</returns>
        Task<int> GetCoreRevision();

        /// <summary>
        /// Refreshes the plugins in JDownloader.
        /// </summary>
        /// <returns>True if the plugins were successfully refreshed, otherwise false.</returns>
        Task<bool> RefreshPlugins();

        /// <summary>
        /// Gets the uptime of JDownloader.
        /// </summary>
        /// <returns>The uptime in milliseconds.</returns>
        Task<long> Uptime();

        /// <summary>
        /// Gets the version of JDownloader.
        /// </summary>
        /// <returns>The version as a long.</returns>
        Task<long> Version();
    }
}
