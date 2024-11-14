using JDownloader.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface ISystem
    {
        /// <summary>
        /// Exits the JDownloader application.
        /// </summary>
        /// <returns>True if the application was successfully exited, otherwise false.</returns>
        Task<bool> ExitJD();

        /// <summary>
        /// Retrieves the storage information for the specified path.
        /// </summary>
        /// <param name="path">The path for which to retrieve the storage information.</param>
        /// <returns>A list of StorageInformation objects representing the storage information for the specified path.</returns>
        Task<List<StorageInformation>> GetStorageInfos(string path);

        /// <summary>
        /// Retrieves the system information.
        /// </summary>
        /// <returns>A SystemInformation object representing the system information.</returns>
        Task<SystemInformation> GetSystemInfos();

        /// <summary>
        /// Hibernates the operating system.
        /// </summary>
        /// <returns>True if the operating system was successfully hibernated, otherwise false.</returns>
        Task<bool> HibernateOS();

        /// <summary>
        /// Restarts the JDownloader application.
        /// </summary>
        /// <returns>True if the application was successfully restarted, otherwise false.</returns>
        Task<bool> RestartJD();

        /// <summary>
        /// Shuts down the operating system.
        /// </summary>
        /// <param name="forceShutdown">Specifies whether to force a shutdown or not.</param>
        /// <returns>True if the operating system was successfully shut down, otherwise false.</returns>
        Task<bool> ShutdownOS(bool forceShutdown);

        /// <summary>
        /// Puts the operating system in standby mode.
        /// </summary>
        /// <returns>True if the operating system was successfully put in standby mode, otherwise false.</returns>
        Task<bool> StandbyOS();
    }
}