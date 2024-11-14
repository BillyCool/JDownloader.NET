using JDownloader.Model;
using System.Threading.Tasks;

namespace JDownloader.Namespace
{
    public interface IDownloadController
    {
        /// <summary>
        /// Forces the download of the specified link IDs and package IDs.
        /// </summary>
        /// <param name="linkIds">The IDs of the links to be downloaded.</param>
        /// <param name="packageIds">The IDs of the packages to be downloaded.</param>
        Task ForceDownload(long[] linkIds, long[] packageIds);

        /// <summary>
        /// Gets the current state of the downloader.
        /// </summary>
        /// <returns>The current state of the downloader.</returns>
        Task<DownloaderState> GetCurrentState();

        /// <summary>
        /// Gets the download speed in bytes per second.
        /// </summary>
        /// <returns>The download speed in bytes per second.</returns>
        Task<long> GetSpeedInBps();

        /// <summary>
        /// Starts the downloader.
        /// </summary>
        /// <returns>True if the downloader was successfully started, otherwise, false.</returns>
        Task<bool> Start();

        /// <summary>
        /// Stops the downloader.
        /// </summary>
        /// <returns>True if the downloader was successfully stopped, otherwise, false.</returns>
        Task<bool> Stop();

        /// <summary>
        /// Pauses or resumes the downloader.
        /// </summary>
        /// <param name="pause">True to pause the downloader, false to resume it.</param>
        /// <returns>True if the downloader was successfully paused or resumed, otherwise, false.</returns>
        Task<bool> Pause(bool pause);
    }
}
