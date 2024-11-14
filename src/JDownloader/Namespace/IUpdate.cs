using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IUpdate
    {
        /// <summary>
        /// Checks if an update is available.
        /// </summary>
        /// <returns>True if an update is available, otherwise false.</returns>
        Task<bool> IsUpdateAvailable();

        /// <summary>
        /// Restarts the application and performs the update.
        /// </summary>
        Task RestartAndUpdate();

        /// <summary>
        /// Runs the update check.
        /// </summary>
        Task RunUpdateCheck();
    }
}